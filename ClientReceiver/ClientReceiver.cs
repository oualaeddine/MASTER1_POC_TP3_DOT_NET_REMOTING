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
        static void Main(string[] args)
        {
            try
            {
                TcpChannel chl = new TcpChannel();
                ChannelServices.RegisterChannel(chl, false);
                Console.WriteLine("Client: Canal enregistré");

                 IFabrique obj = (IFabrique)Activator.GetObject(typeof(IFabrique),"tcp://localhost:1234/ObjMailBox");
                  IMailBox obj1 = obj.createMailBox();

               // IMailBox obj1 = (IMailBox)Activator.GetObject(typeof(IMailBox), "tcp://localhost:1234/ObjMailBox");



                if (obj1 == null)
                    Console.WriteLine("Problème de SERVEUR... ");
                else
                {
                    Console.WriteLine("Reference acquise de l'objet");
                    // Utilisation de l’objet : receptions des messages
                    Message[] msgs = obj1.receiveMsg();
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
