using messageBoardUsingASP.Models;
using Microsoft.AspNetCore.Mvc;
using System;


namespace messageBoardUsingASP.Controllers
{
    public class MessageController:Controller
    {
            // 首頁為Message/Board
        public IActionResult Board()
        {
                // 新建立一個定義於Models資料夾中的MessageOperate物件
            MessageOperate operate = new MessageOperate();

                // 查詢所有留言，將結果傳入ViewBag.dataList
            ViewBag.dataList =  operate.SelectAllMessages();

                // 執行View，產生之網頁命名為response
            var response = View();

            return response; //將網頁結果回傳給使用者
        }

            // 網址Message/Board網址以定義於Models資料夾中的MessageModel物件來接收留言
        public IActionResult NewMessage(MessageModel data)
        {
                // 填入接受到留言的現在時間
            data.Time = DateTime.Now;

                // 新建立一個定義於Models資料夾中的MessageOperate物件
            MessageOperate operate = new MessageOperate();
            operate.InsertMessage(data); //執行新增留言

            return RedirectToAction("Board"); //將使用者導向到首頁
        }
    }
}
