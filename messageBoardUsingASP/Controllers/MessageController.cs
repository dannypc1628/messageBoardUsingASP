using messageBoardUsingASP.Models;
using Microsoft.AspNetCore.Mvc;
using System;


namespace messageBoardUsingASP.Controllers
{
    public class MessageController:Controller
    {
        public IActionResult Board()
        {
            MessageOperate operate = new MessageOperate();
            ViewBag.dataList =  operate.SelectAllMessages();
            var response = View();
            return response;
        }
        public IActionResult NewMessage(MessageModel data)
        {
            data.Time = DateTime.Now;

            MessageOperate operate = new MessageOperate();
            operate.InsertMessage(data);

            return RedirectToAction("Board");
        }
    }
}
