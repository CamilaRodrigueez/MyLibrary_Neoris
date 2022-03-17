using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils.Exceptions
{
    public class HttpResponseException
    {
        public int Status { get; set; }

        public object Value { get; set; }
    }
}
