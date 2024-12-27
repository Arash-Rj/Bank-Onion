using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Bnak.ResultModel
{
    public class Result
    {
        public bool IsDone { get; set; }
        public string Message { get; set; }
        public Result(bool isdone, string message = null)
        {
            IsDone = isdone;
            Message = message;
        }
    }
}
