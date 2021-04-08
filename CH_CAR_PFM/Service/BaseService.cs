using CH_CAR_PFM.Helps;
using System;
using System.Threading.Tasks;

namespace CH_CAR_PFM.Service
{
    public class BaseService
    {
        private WebApiAdapter _webapi = null;

        public BaseService()
            : this(new WebApiAdapter())
        {
        }

        public BaseService(WebApiAdapter adapter)
        {
            this.WebApi = adapter;
        }

        public WebApiAdapter WebApi
        {
            get
            {
                if (null == this._webapi)
                {
                    this._webapi = new WebApiAdapter();
                }
                return this._webapi;
            }
            set
            {
                this._webapi = value;
            }
        }

        protected async Task<T> GetApiResultAsync<T>(string requestMethod, object jsonData, bool isBack = false)
        {
            T rtnModel = await this.WebApi.QueryAsync<T>(requestMethod, jsonData, isBack);
            return rtnModel;
        }
    }
}