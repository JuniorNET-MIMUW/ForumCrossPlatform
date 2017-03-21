using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Server.Models
{
    public class ErrorMessage
    {
        public bool IsOk { get; set; } = true;
        
        public string Message { get; set; }
    }
}