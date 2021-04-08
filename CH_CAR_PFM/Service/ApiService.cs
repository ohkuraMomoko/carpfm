using CH_CAR_PFM.Models;
using CH_CAR_PFM.Models.AppFormPay;
using System.Threading.Tasks;

namespace CH_CAR_PFM.Service
{
    public class ApiService : BaseService
    {
        private ApiService()
        {
        }

        private static ApiService instance;

        public static ApiService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApiService();
                }
                return instance;
            }
        }

        /// <summary>
        /// 取得標的物資料(繳款紀錄)
        /// </summary>
        /// <param name="model">param</param>
        /// <param name="apiUrl">Api 路徑</param>
        /// <returns>result</returns>
        public async Task<BaseListResult<GetArRecLvOutput>> ApiGetArRecLv1(GetArRecLvInput model, string apiUrl)
        {
            BaseListResult<GetArRecLvOutput> result = await this.GetApiResultAsync<BaseListResult<GetArRecLvOutput>>(apiUrl, model);

            return result;
        }

        /// <summary>
        /// 取得往來明細清單(未繳/逾期)
        /// </summary>
        /// <param name="model">param</param>
        /// <param name="apiUrl">Api 路徑</param>
        /// <returns>result</returns>
        public async Task<BaseListResult<GetArRecLvNewOutput>> ApiGetArLv1New(object model, string apiUrl)
        {
            BaseListResult<GetArRecLvNewOutput> result = await this.GetApiResultAsync<BaseListResult<GetArRecLvNewOutput>>(apiUrl, model);

            return result;
        }

        /// <summary>
        /// 取得往來明細清單(未繳/逾期)
        /// </summary>
        /// <param name="model">param</param>
        /// <param name="apiUrl">Api 路徑</param>
        /// <returns>result</returns>
        public async Task<BaseResult<ValidArPayOutput>> ApiValidateArPay(object model, string apiUrl)
        {
            BaseResult<ValidArPayOutput> result = await this.GetApiResultAsync<BaseResult<ValidArPayOutput>>(apiUrl, model);

            return result;
        }

        /// <summary>
        /// 取得標的物資料(繳款紀錄)
        /// </summary>
        /// <param name="model">param</param>
        /// <param name="apiUrl">Api 路徑</param>
        /// <returns>result</returns>
        public async Task<BaseListResult<GetArRecOutput>> ApiGetArRec(GetArRecInput model, string apiUrl)
        {
            BaseListResult<GetArRecOutput> result = await this.GetApiResultAsync<BaseListResult<GetArRecOutput>>(apiUrl, model);

            return result;
        }

        /// <summary>
        /// 取得會員資訊
        /// </summary>
        /// <param name="model">param</param>
        /// <param name="apiUrl">Api 路徑</param>
        /// <returns>result</returns>
        public async Task<BaseResult<GetCustInfoOutput>> ApiGetCustInfo(GetCustInfoInput model, string apiUrl)
        {
            BaseResult<GetCustInfoOutput> result = await this.GetApiResultAsync<BaseResult<GetCustInfoOutput>>(apiUrl, model);

            return result;
        }

        /// <summary>
        /// 取得客戶綁定代繳契約狀態
        /// </summary>
        /// <param name="model">param</param>
        /// <param name="apiUrl">Api 路徑</param>
        /// <returns>result</returns>
        public async Task<BaseResult<CustProxyPayStatus>> ApiGetCustProxyPayStatus(GetCustInfoInput model, string apiUrl)
        {
            BaseResult<CustProxyPayStatus> result = await this.GetApiResultAsync<BaseResult<CustProxyPayStatus>>(apiUrl, model);

            return result;
        }

        /// <summary>
        /// 取得全資料(已繳/未繳/逾期)
        /// </summary>
        /// <param name="model">param</param>
        /// <param name="apiUrl">Api 路徑</param>
        /// <returns>result</returns>
        public async Task<BaseListResult<InitOutput>> ApiINIT(object model, string apiUrl)
        {
            BaseListResult<InitOutput> result = await this.GetApiResultAsync<BaseListResult<InitOutput>>(apiUrl, model);

            return result;
        }

        /// <summary>
        /// 取得 7-11 超商繳費 BarCode
        /// </summary>
        /// <param name="model">param</param>
        /// <param name="apiUrl">Api 路徑</param>
        /// <returns>result</returns>
        public async Task<BaseResult<Barcode711Output>> ApiGet711BarCodeImg(Barcode711Input model, string apiUrl)
        {
            BaseResult<Barcode711Output> result = await this.GetApiResultAsync<BaseResult<Barcode711Output>>(apiUrl, model);

            return result;
        }

        /// <summary>
        /// 取得超商繳費 BarCode
        /// </summary>
        /// <param name="model">param</param>
        /// <param name="apiUrl">Api 路徑</param>
        /// <returns>result</returns>
        public async Task<BaseResult<MergeBarcodeOutput>> ApiGetMergeBarCode(MergeBarcodeInput model, string apiUrl)
        {
            BaseResult<MergeBarcodeOutput> result = await this.GetApiResultAsync<BaseResult<MergeBarcodeOutput>>(apiUrl, model);

            return result;
        }

        /// <summary>
        /// 取得銀行列表
        /// </summary>
        /// <param name="model">param</param>
        /// <param name="apiUrl">Api 路徑</param>
        /// <returns>result</returns>
        public async Task<BaseListResult<GetBankOutput>> ApiGetBank(object model, string apiUrl)
        {
            BaseListResult<GetBankOutput> result = await this.GetApiResultAsync<BaseListResult<GetBankOutput>>(apiUrl, model, true);

            return result;
        }

        /// <summary>
        /// 取得保險列表
        /// </summary>
        /// <param name="model">param</param>
        /// <param name="apiUrl">Api 路徑</param>
        /// <returns>result</returns>
        public async Task<BaseListResult<GetInsuranceOutput>> ApiGetInsurance(object model, string apiUrl)
        {
            BaseListResult<GetInsuranceOutput> result = await this.GetApiResultAsync<BaseListResult<GetInsuranceOutput>>(apiUrl, model, true);

            return result;
        }
    }
}