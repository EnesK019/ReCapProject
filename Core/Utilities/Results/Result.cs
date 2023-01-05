using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{ 
    public class Result : IResult
    {
        public Result(bool success, string messages):this(success)
        {
            this.success = success;
            this.message = messages;
        }

        public Result(bool success) 
        { 
            this.success = success; 
        }

        public bool success { get; }
        public string message { get; }
    }
}
