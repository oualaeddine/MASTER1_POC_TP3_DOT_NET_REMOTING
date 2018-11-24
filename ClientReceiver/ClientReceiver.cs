using IRemote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;

namespace ClientReceiver
{
    class ClientReceiver
    {
        private static int RECEIVER = 1;
        static void Main(string[] args)
        {
            try
            {
                TcpChannel chl = new TcpChannel();
                ChannelServices.RegisterChannel(chl, false);
                Console.WriteLine("Client: Canal enregistré");
                IMailBox obj = (IMailBox)Activator.GetObject(typeof(IMailBox),
                "tcp://localhost:1234/ObjMailBox");
                if (obj == null)
                    Console.WriteLine("Problème de SERVEUR... ");
                else
                {
                    Console.WriteLine("Reference acquise de l'objet Singleton");
                    // Utilisation de l’objet : receptions des messages
                    Message[] msgs = obj.receiveMsg();
                    for (int i = 0; i < msgs.Length; i++)
                    {
                        Console.WriteLine("*************************");
                        Console.WriteLine("from : " + msgs[i].from);
                        Console.WriteLine("msg : " + msgs[i].content);
                        Console.WriteLine("*************************");
                    }
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERREUR :" + ex.Message);
            }
        }
    }
}
