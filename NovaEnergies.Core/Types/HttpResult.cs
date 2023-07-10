using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NovaEnergies.Core.Types
{
    public class HttpResult<TResult>
    {
        public HttpResult(TResult result, HttpStatusCode httpStatusCode)
        {
            Result = result;
            HttpStatusCode = httpStatusCode;
        }

        public TResult Result { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}
