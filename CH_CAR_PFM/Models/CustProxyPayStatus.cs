using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CH_CAR_PFM.Models
{
    public class CustProxyPayStatus
    {
        /// <summary>
        /// 已綁定代繳他人的契約數量
        /// </summary>
        public int REG_COUNT { get; set; }

        public List<CustProxyPayInfo> REG_LIST { get; set; }
    }

    /// <summary>
    /// 客戶綁定代繳他人契約 MODEL
    /// </summary>
    public class CustProxyPayInfo
    {
        /// <summary>
        /// 會員編號
        /// </summary>
        public string MBR_ID { get; set; }

        /// <summary>
        /// 契約編號
        /// </summary>
        public string CNTRT_NO { get; set; }

        /// <summary>
        /// 車號
        /// </summary>
        public string LIC_NO { get; set; }

        /// <summary>
        /// 客戶統編
        /// </summary>
        public string CUST_ID { get; set; }
    }
}