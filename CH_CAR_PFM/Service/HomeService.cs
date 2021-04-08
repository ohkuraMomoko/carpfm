using CH_CAR_PFM.Models;
using CH_CAR_PFM.Models.AppFormPay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CH_CAR_PFM.Service
{
    public class HomeService
    {
        /// <summary>
        /// 取得會員資訊
        /// </summary>
        /// <param name="model">取得會員資訊 Input</param>
        /// <returns>取得會員資訊 Output</returns>
        public async Task<GetCustInfoOutput> GetCustInfo(GetCustInfoInput model)
        {
            // 透過 Api 把資料送出去
            string apiUrl = "APP_ACCT_BIND/GET_CUST_INFO";

            BaseResult<GetCustInfoOutput> baseListResult = await ApiService.Instance.ApiGetCustInfo(model, apiUrl);

            GetCustInfoOutput result = new GetCustInfoOutput();

            if (baseListResult.Result.ReturnCode == 0 && baseListResult.Data != null)
            {
                result = baseListResult.Data;
            }

            return result;
        }

        /// <summary>
        /// 取得客戶綁定代繳契約狀態
        /// </summary>
        /// <param name="model">取得客戶綁定代繳契約狀態 Input</param>
        /// <returns>取得客戶綁定代繳契約狀態 Output</returns>
        public async Task<CustProxyPayStatus> GetCustProxyPayStatus(GetCustInfoInput model)
        {
            // 透過 Api 把資料送出去
            string apiUrl = "APP_ACCT_BIND/CUST_PROXY_PAY_STATUS";          

            BaseResult<CustProxyPayStatus> baseListResult = await ApiService.Instance.ApiGetCustProxyPayStatus(model, apiUrl);

            CustProxyPayStatus result = new CustProxyPayStatus();

            if (baseListResult.Result.ReturnCode == 0 && baseListResult.Data != null)
            {
                result = baseListResult.Data;
            }

            return result;
        }

        /// <summary>
        /// 取得全資料(已繳/未繳/逾期)
        /// </summary>
        /// <param name="model">取得會員資訊 Input</param>
        /// <returns>取得會員資訊 Output</returns>
        public async Task<InitOutput> INIT(string id)
        {
            // 透過 Api 把資料送出去
            string apiUrl = "APP_FORM_PAY/INIT";

            InitInput model = new InitInput
            {
                ID = id
            };

            BaseListResult<InitOutput> baseListResult = await ApiService.Instance.ApiINIT(model, apiUrl);

            InitOutput result = new InitOutput();

            if (baseListResult.Result.ReturnCode == 0 && baseListResult.Data != null)
            {
                result = baseListResult.Data.FirstOrDefault();
            }

            return result;
        }
    }
}