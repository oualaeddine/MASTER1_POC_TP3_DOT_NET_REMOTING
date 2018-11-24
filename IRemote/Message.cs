using System;
using System.Runtime.Serialization;

namespace IRemote
{
    [Serializable]
    public class Message 
    {
        public string content { get; set; }
        public string from { get; set; }
    }
}