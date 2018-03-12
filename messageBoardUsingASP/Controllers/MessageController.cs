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
            var response = View();
            return response;
        }
    }
}
