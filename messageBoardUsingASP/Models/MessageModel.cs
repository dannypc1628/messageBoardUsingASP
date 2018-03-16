using System;

namespace messageBoardUsingASP.Models
{
    public class MessageModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Message { get; set; }

        public DateTime Time { get; set; }
    }
}
