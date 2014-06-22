namespace LGEVN.Services.Implement
{
    using System;
    using System.Collections.Generic;

    public sealed class TB_CM_MRP
    {
        public string MODEL { get; set; }
        public string MRP { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string SO_TRANSFER_FLAG { get; set; }
        public DateTime? SO_TRANSFER_DATE { get; set; }
    }
}
