using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CO_CARO_2
{
    public class SocketManager
    {
        #region Client
        Socket client;
        public bool ConnectServer()
        {
            IPEndPoint iep = null;
            if (client == null || iep == null)
            {
                iep = new IPEndPoint(IPAddress.Parse(IP), PORT);
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
            try
            {
                client.Connect(iep);
                this.isConnected = true;
                return true;
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Server connect Error : {0}", e.Message);
                return false;
            }
        }
        #endregion

        #region server

        /*Socket server;
        public void CreateServer()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP), PORT);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            server.Bind(iep);
            server.Listen(10);

            Thread acceptClient = new Thread(() =>
            {
                client = server.Accept();
            });
            acceptClient.IsBackground = true;
            acceptClient.Start();
        }*/
        #endregion

        #region Both
        public string IP = "127.0.0.1";
        public int PORT = 5501;
        public const int BUFFER = 512;
        public bool isConnected = false;

        public bool Send(object data)
        {
            byte[] sendData = SerializeData(data);

            return SendData(client, sendData);
        }

        public object Receive()
        {
            byte[] receiveData = new byte[BUFFER];
            int bytesRec = ReceiveData(client, receiveData);
            Console.WriteLine("Nhan duoc data : {0}", Encoding.ASCII.GetString(receiveData, 0, bytesRec));
            return DeserializeData(receiveData);
        }

        private bool SendData(Socket target, byte[] data)
        {
            return target.Send(data) == 1 ? true : false;
        }


        private int ReceiveData(Socket target, byte[] data)
        {
            return target.Receive(data);
        }
        /// <summary>
        /// Nén đối tượng thành mảng byte[]
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public byte[] SerializeData(Object o)
        {
            try
            {
                string json = JsonConvert.SerializeObject(o, Formatting.None);
                return Encoding.ASCII.GetBytes(json);
            } catch (Exception e)
            {
                Console.WriteLine("Serialize Error : {0}", e.Message);
                return null;
            }
        }

        /// <summary>
        /// Giải nén mảng byte[] thành đối tượng object
        /// </summary>
        /// <param name="theByteArray"></param>
        /// <returns></returns>
        public object DeserializeData(byte[] theByteArray)
        {
            try
            {
                String msg = Encoding.ASCII.GetString(theByteArray, 0, theByteArray.Length);
                SocketData data = JsonConvert.DeserializeObject<SocketData>(msg);
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine("Deserialize Error : {0}", e.Message);
                return null;
            }
        }

        /// <summary>
        /// Lấy ra IP V4 của card mạng đang dùng
        /// </summary>
        /// <param name="_type"></param>
        /// <returns></returns>
        public string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }

        #endregion
    }
}
