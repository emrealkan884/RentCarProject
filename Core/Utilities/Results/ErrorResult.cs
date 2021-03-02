using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult:Result
    {
        public ErrorResult(string message) : base(false, message)//Base e true ve message gönder
        {

        }
        public ErrorResult() : base(false)
        {

        }
    }
}
