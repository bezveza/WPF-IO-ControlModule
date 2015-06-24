using SensorPipeServerWpfOct14.Model;
using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;

namespace SensorPipeServerWpfOct14
{
    //client class for debugging/manual trigger  
    public class SensorPipeClient
    {
        static bool NoConnectERROR { get; set; }
        static NamedPipeClientStream p;
        
        public static async Task PipeClientAsync(string m)
        {
                try
                {
                    using (p = new NamedPipeClientStream("sensorPipe"))
                    {
                        Data.Source.Msg("\nClient connected ...");
                        await Task.Run(() =>
                        {
                            ClientPipeProcess(m, p);
                        });

                        Data.Source.Msg("\nClient Rx data: " + m);
                        Data.Source.Msg("\n***** Debug End Ouput ******");
                    }
                    Data.Source.Msg("\nClient disconnected ...");
                }
                catch (Exception e)
                {
                    NoConnectERROR = true;

                    Data.Source.Msg("\nError from client: " + e.Message);
                    Data.Source.Msg("\nCheck server status.");
                }
        }

        private static void ClientPipeProcess(string m, NamedPipeClientStream p)
        {
            p.Connect(300);
            p.ReadMode = PipeTransmissionMode.Message;
            m = Encoding.UTF8.GetString(ReadMessage(p));  //reading data
        }
        //helper method for client pipe process
        static byte[] ReadMessage(PipeStream s)
        {
            MemoryStream ms = new MemoryStream();
            byte[] buffer = new byte[0x1000]; // Read in 4 KB blocks
            do { ms.Write(buffer, 0, s.Read(buffer, 0, buffer.Length)); }
            while (!s.IsMessageComplete);
            return ms.ToArray();
        }

    }
}
