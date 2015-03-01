using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Model
{
    public abstract class MessageBase
    {
        public Guid MessageId { get; set; }

        public  MessageTypeEnum MessageTypeEnum { get; set; }

        public string Name { get; set; }

        public string StandardMessageText { get; set; }

        abstract public void Flush();

    }
}
