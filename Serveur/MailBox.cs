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
            throw new NotImplementedException();
        }

        public void sendMsg(Message msg)
        {
            throw new NotImplementedException();
        }
    }
}
