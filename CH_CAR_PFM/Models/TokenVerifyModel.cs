using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CH_CAR_PFM.Models
{
    public class TokenVerifyModel
    {
        /// <summary>
        /// 身分證字號(統編)
        /// </summary>
        public string Id { get; set; }

        /// 登入帳號
        /// </summary>
        public string MbrId { get; set; }

        /// <summary>
        /// 裝置編號
        /// </summary>
        public string DevId { get; set; }


        /// <summary>
        /// 持久登入用TOKEN
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 同INPUT 客戶ID
        /// </summary>
        public string CustId { get; set; }

        /// <summary>
        /// 契約編號
        /// </summary>
        public string CntrtNo { get; set; }
    }
}