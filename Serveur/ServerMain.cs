using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;

namespace Serveur
{
    class ServerMain
    {
        static void Main(string[] args)
        {
            try
            {
                TcpChannel chnl = new TcpChannel(1234);
                ChannelServices.RegisterChannel(chnl, false);

                //pour lancer le serveur en mode Singleton,
                //  RemotingConfiguration.RegisterWellKnownServiceType(typeof(MailBox), "ObjMailBox", WellKnownObjectMode.Singleton);
                // Console.WriteLine("Serveur démarré...");

                //pour lancer le serveur en mode SingleCall,
            //    RemotingConfiguration.RegisterWellKnownServiceType(typeof(MailBox), "ObjMailBox", WellKnownObjectMode.SingleCall);
              //  Console.WriteLine("Serveur démarré...");


                //  pour lancer le serveur en mode avec fabrique,
                 RemotingConfiguration.RegisterWellKnownServiceType(typeof(Fabrique), "ObjMailBox", WellKnownObjectMode.Singleton);
                 Console.WriteLine("Serveur démarré...");


            }
            catch (Exception ex)
            {
                Console.WriteLine("Serveur:Erreur d'initialisation !" + ex.Message);
            }
            Console.ReadLine();
        }
    }
}
