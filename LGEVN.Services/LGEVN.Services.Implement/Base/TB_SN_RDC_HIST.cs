//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LGEVN.Services.Implement
{
    using System;
    using System.Collections.Generic;

    public sealed class TB_SN_RDC_HIST
    {
        public string INV_ORG { get; set; }
        public string EDI_NO { get; set; }
        public string SERIAL_NO { get; set; }
        public string BOX_NO { get; set; }
        public string MODEL_SUFFIX { get; set; }
        public string MODEL { get; set; }
        public string SUFFIX { get; set; }
        public string SHIP_NO { get; set; }
        public string LINE_NO { get; set; }
        public System.DateTime OUT_DATE { get; set; }
        public System.DateTime CREATE_DATE { get; set; }
        public DateTime? SELLOUT_DATE { get; set; }
        public DateTime? INCENTIVE_DATE { get; set; }
        public DateTime? WT_IF_DATE { get; set; }
        public string WT_IF_FLAG { get; set; }
        public string SELLOUT_STATUS { get; set; }
        public string INCENTIVE_FLAG { get; set; }
        public string SMS_YN { get; set; }
        public string SO_TRANSFER_FLAG { get; set; }
        public DateTime? SO_TRANSFER_DATE { get; set; }
    }
}
