using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRemote
{
    public interface IMailBox
    {
         void sendMsg(Message msg);
         Message[] receiveMsg();
    }
}
