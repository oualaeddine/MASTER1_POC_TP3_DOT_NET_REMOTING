using IRemote;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Serveur
{
    class MailBox : MarshalByRefObject, IRemote.IMailBox
    {
        private ArrayList msgList;

        public MailBox() {
            msgList = new ArrayList();
        }

        public Message[] receiveMsg()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*************************");
            Console.WriteLine("recuperation des messages");
            Console.WriteLine("*************************");
            Console.ForegroundColor = ConsoleColor.White;

            return msgList.ToArray(typeof(Message))as Message[];
        }

        public void sendMsg(Message msg)
        {
            msgList.Add(msg);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("*************************");
            Console.WriteLine("envoie d'un message");
            Console.WriteLine("from : " + msg.from);
            Console.WriteLine("msg : " + msg.content);
            Console.WriteLine("*************************");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
