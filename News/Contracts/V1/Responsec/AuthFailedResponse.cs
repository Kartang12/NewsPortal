using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Contracts.V1.Responsec
{
    public class AuthFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
