using SensorPipeServerWpfOct14.Model;
using System;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SensorPipeServerWpfOct14
{
    //server class accesible by an independent control module application 
    public class SensorPipeServer
    {
        string m { get; set; }
        static bool done { get; set; }
        static string sN, input;
        static int N;

        static Color ColorON = Color.FromArgb(255, 255, 255, 0); //Yellow
        static Color ColorOFF = Color.FromArgb(100, 171, 153, 153); //Gray

        public static async Task PipeServerAsync(Ellipse[] led, Led[] LedArray)
        {
            SolidColorBrush ledON  = new SolidColorBrush(ColorON);
            SolidColorBrush ledOFF = new SolidColorBrush(ColorOFF);
            
            await led[7].Dispatcher.InvokeAsync(new Action(() =>  led[7].Fill = ledON ));  //led[7] = ledServer
            Data.Source.Msg("\nSensorServer started ...");
            
            while (!done)
            {
                //random no. generator, int and string output for debug, window display 
                N = new System.Random().Next(13);
                sN = N.ToString();
                input = sN;

                string error = null;

                await Task.Run(() =>
                {
                    try
                    {
                        PipeProcess(N, sN, input); //also need to consider pipeName
                    }
                    catch (Exception e)
                    {
                        done = true;
                        error = "\nError from server:" + e.Message + "\nServer is stopped!";
                    }
                });

                if (error != null) { Data.Source.Msg(error); }
                input = LedModule.ledControl(N, LedArray).ToString();
                debugInfo(N, sN, input);
            }

            done = false;
            await led[7].Dispatcher.InvokeAsync(new Action(() => led[7].Fill = ledOFF)); //ledServer.Fill = ledOFF;
            Data.Source.Msg("\nServer is stopped!");
        }

        private static void PipeProcess(int N, string sN, string input)
        {
            using (var s = new NamedPipeServerStream("sensorPipe", PipeDirection.InOut, 1, PipeTransmissionMode.Message))
            {
                //output section
                s.WaitForConnection();
                byte[] msg = Encoding.UTF8.GetBytes(input); //input will generate random message
                s.Write(msg, 0, msg.Length);  //send data
            }
        }

        private static void debugInfo(int N, string sN, string input/*, TextBox[] inTxt*/)
        {
            Data.Source.Msg("\n***** Debug Start Ouput ******");
            Data.Source.Msg("\nRandomNo = " + sN);
            Data.Source.Msg("\nServer Tx data (string) = " + input);
        }

    }
}
