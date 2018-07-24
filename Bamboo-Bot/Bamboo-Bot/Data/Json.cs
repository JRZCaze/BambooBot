using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Bamboo_Bot.Modules;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bamboo_Bot.Data
{
    public class Json
    {
        private static Socket sck;
        private string ipAdress;
        int adressPort;

        /*public static void StartDataLink()
        {
            string ipAdress = "127.00.00.1";
            int adressPort = 8080;
            Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ipAdress), adressPort);
            sck.Connect(endPoint);
        }
        public static void Send(string data)
        {
            string msg = Newtonsoft.Json.JsonConvert.SerializeObject(data) + "\n";
            byte[] msgBuffer = Encoding.Default.GetBytes(msg);
            sck.Send(msgBuffer, 0, msgBuffer.Length, 0);
        }*/

        public static string DataToJson(string data)
        {
           return Newtonsoft.Json.JsonConvert.SerializeObject(data) + "\n";
        }

        /*public static string DataToJson(data)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(data) + "\n";
        }*/

        /*public static void Recieve()
        {
            byte[] buffer = new byte[1023];
            if (buffer.Length > 0)
            {
                int rec = sck.Receive(buffer, 0, buffer.Length, 0);

                Array.Resize(ref buffer, rec);
                RecievedDataConverter(Encoding.Default.GetString(buffer));
            }
        }*/

        public static void RecievedDataConverter(string Data)
        {
            try
            {
                string[] DataRecived = JsonConvert.DeserializeObject<string[]>(Data);
                if (DataRecived != null)
                {
                    LeagueOfLegendsTeamBuilder.champions = DataRecived;
                }
            }
            catch
            { }   
        }
    }
}

