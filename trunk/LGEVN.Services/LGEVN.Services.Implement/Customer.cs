using LGEVN.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace LGEVN.Services.Implement
{
    public sealed class Customer : ICustomer
    {
        public string CustKey { get; set; }

        public string Cid { get; set; }

        public string ResultCode { get; set; }

        public string RespMsg { get; set; }

        public string RespTime { get; set; }
    }
}
