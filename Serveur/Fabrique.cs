using IRemote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Serveur
{
    class Fabrique : IFabrique
    {
        public IMailBox createMailBox()
        {
            return new MailBox();
        }
    }
}
