using IRemote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;

namespace ClientSender
{
    class ClientSender
    {
        private static int SENDER = 1;

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
                    // Utilisation de l’objet : dépôt d’un message
                   Message msg = new Message();
                    msg.content = "message 1";
                    msg.from = "sender" + SENDER;
                    obj.sendMsg(msg);
                    Console.WriteLine("Client: message envoyé");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERREUR :" + ex.Message); Console.ReadLine();

            }
            Console.ReadLine();

        }
    }
}
