namespace LGEVN.Services.Implement
{
    using System;
    using System.Collections.Generic;

    public sealed class TB_CM_SHOP_CELL
    {
        public string SHOP_ID { get; set; }
        public string SHOP_CELL { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public DateTime? MODIFY_DATE { get; set; }
        public string CREATE_USER { get; set; }
        public string USE_FLAG { get; set; }
        public string MODIFY_USER { get; set; }
        public string SO_TRANSFER_FLAG { get; set; }
        public DateTime? SO_TRANSFER_DATE { get; set; }
    }
}
