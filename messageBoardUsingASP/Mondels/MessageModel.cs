using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace messageBoardUsingASP.Mondels
{
    public class MessageModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Message { get; set; }

        public DateTime Time { get; set; }
    }
}
