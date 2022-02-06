using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolMS_API.Models
{
    public class Cls_APIResponse
    {
        public int StatusCode { get; set; }
        public dynamic Data { get; set; }
        public string Message { get; set; }
    }
}