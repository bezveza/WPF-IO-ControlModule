using DataSourceEventLib;
using LedSystemLib;
using SensorPipeServerWpfOct14.Model;
using System;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;

namespace SensorPipeServerWpfOct14
{
    /******************************************************************
    * The pipe server here is performing two services.
    *
    * The first service is generating a random number during client connection.
    * The second service is controlling the internal LED visual display
    * according to the random number generated. 
    *******************************************************************/

    public class SensorPipeServer
    {
        static bool done { get; set; }

        public static async Task PipeServerAsync(Led[] LedArray)
        {
            Data.Source.Msg("\nSensorServer started ...");
            LedArray[7].switchLED(1); //direct way to turn on using input 1 
            //LedModule.ledControl(13, LedArray); //using pattern to turn on. Either way works fine.

           //a quick startup test to check the condition of the Led's
           await StartUpPattern.startupCheckAsync4(LedArray);
           await StartUpPattern.startupCheckAsync3(LedArray);

            while (!done)
            {
                //internal random number generator
                int n = new System.Random().Next(13);
                string error = null;
                
                await Task.Run(() =>
                {
                    try
                    {
                        //calling 1st service method for pipe connection 
                        PipeProcessAsync(n); 
                    }
                    catch (Exception e)
                    {
                        done = true;
                        error = "\nError from server:" + e.Message + "\nServer is stopped!";
                    }
                });
              
                //calling 2nd service method for internal visual control
                visualLedModuleControlAsync(n, LedArray);

                if (error != null) { Data.Source.Msg(error); }
                debugInfo(n);
            }
            done = false;
            LedArray[7].switchLED(1);
            Data.Source.Msg("\nServer is stopped!");
        }

        //1st service
        //method to send the random numbers into the pipe stream for client consumption
        private static void PipeProcessAsync(int n)
        {
            using (var s = new NamedPipeServerStream("sensorPipe", PipeDirection.InOut, 1, PipeTransmissionMode.Message))
            {
                string sN = n.ToString();
                //output section
                s.WaitForConnection();
                byte[] msg = Encoding.UTF8.GetBytes(sN); 
                s.Write(msg, 0, msg.Length);  //send data
            }
        }

        //2nd service
        //method for internal visual display control
        private static void visualLedModuleControlAsync(int n, Led[] LedArray)
        {
            LedModule.ledControl(n, LedArray);
        }
        
        //method for debug display 
        private static void debugInfo(int n)
        {
            //Data.Source.Msg("\n***** Debug Start Ouput ******");
            Data.Source.Msg("\nrandom n = " + n);
        }
    }
}
