using messageBoardUsingASP.Mondels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace messageBoardUsingASP.Controllers
{
    public class MessageController:Controller
    {
        public IActionResult Board()
        {
            MessageOperate operate = new MessageOperate();
            ViewBag.dataList =  operate.getMessages();
            var response = View();
            return response;
        }
        public IActionResult addMessage(MessageModel data)
        {
            data.Time = DateTime.Now;

            MessageOperate operate = new MessageOperate();
            operate.addMessage(data);

            return RedirectToAction("Board");
        }
    }
}
