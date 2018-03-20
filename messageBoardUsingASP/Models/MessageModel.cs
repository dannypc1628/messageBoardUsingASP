using System;

namespace messageBoardUsingASP.Models
{
    public class MessageModel
    {
        public int Id { get; set; } // 留言ID編號

        public string Name { get; set; } // 名字

        public string Message { get; set; } // 留言內容

        public DateTime Time { get; set; } // 留言時間
    }
}
