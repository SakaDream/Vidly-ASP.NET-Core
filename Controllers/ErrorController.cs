﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Vidly.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index(int errorStatusCode)
        {

            return View();
        }
    }
}