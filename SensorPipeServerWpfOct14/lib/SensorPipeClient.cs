using DataSourceEventLib;
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
        static NamedPipeClientStream s;
        
        public static async Task PipeClientAsync(string n)
        {
                try
                {
                    using (s = new NamedPipeClientStream("sensorPipe"))
                    {
                        //Data.Source.Msg("\nClient connected ...");
                        await Task.Run(() =>
                        {
                            ClientPipeProcess(n, s);
                        });
                        //Data.Source.Msg("\nClient disconnected ...");
                    }
                }
                catch (Exception e)
                {
                    Data.Source.Msg("\nError from client: " + e.Message);
                    Data.Source.Msg("\nCheck server status.");
                }
        }

        private static void ClientPipeProcess(string n, NamedPipeClientStream s)
        {
            s.Connect(300);
            s.ReadMode = PipeTransmissionMode.Message;
            n = Encoding.UTF8.GetString(ReadMessage(s));  //reading data
        }

        //memory stream buffer helper method
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
