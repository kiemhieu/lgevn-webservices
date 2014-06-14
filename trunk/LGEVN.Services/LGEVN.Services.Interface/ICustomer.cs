using System;
using System.Collections.Generic;
using System.Text;

namespace LGEVN.Services.Interface
{
    public interface ICustomer 
    {
        string CustKey { get; set; }
        string Cid { get; set; }
        string ResultCode { get; set; }
        string RespMsg { get; set; }
        string RespTime { get; set; }
    }
}
