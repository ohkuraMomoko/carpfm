using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CH_CAR_PFM.Models
{
    /// <summary>
    /// API 基底 MODEL
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseListResult<T>
    {
        /// <summary>
        ///  API 查詢資料
        /// </summary>
        public List<T> Data { get; set; }

        /// <summary>
        /// 基底 API 執行狀態及訊息
        /// </summary>
        public ResultModel Result { get; set; }
    }
}