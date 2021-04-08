using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CH_CAR_PFM.Helps
{
    public class WebApiAdapter : Controller
    {
        private static Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly string API_ID = ConfigurationManager.AppSettings["API_ID"];

        public async Task<T> QueryAsync<T>(String requestMethod, object jsonData, bool isBack)
        {
            HttpResponseMessage response = null;
            string responseBody = null;
            WebApiResult<T> jsonResult = new WebApiResult<T>();
            try
            {
                string url = ConfigurationManager.AppSettings["API_URL"] + requestMethod;

                if (isBack)
                {
                    url = ConfigurationManager.AppSettings["APIBACK_URL"] + requestMethod;
                }

                string stringData = JsonConvert.SerializeObject(jsonData);
                Logger.Log(LogLevel.Info, String.Format("requestMethod={0},Post Json={1}", requestMethod, stringData));
                HttpContent content = new StringContent(stringData, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                System.Web.HttpContext context = System.Web.HttpContext.Current;

                if (context.Session["LOGIN_TOKEN"] != null)
                {
                    string LOGIN_TOKEN = context.Session["LOGIN_TOKEN"].ToString();
                    string API_ID = ConfigurationManager.AppSettings["API_ID"];

                    HttpClientHandler handler = new HttpClientHandler()
                    {
                        UseDefaultCredentials = false,
                        Credentials = new System.Net.NetworkCredential(API_ID, LOGIN_TOKEN)
                    };
                    client = new HttpClient(handler);
                }

                client.DefaultRequestHeaders.Add("authorization", "token {api token}");

                //WebApi連線
                response = await client.PostAsync(url, content);

                //取得WebApi回傳ContentText
                if (response.IsSuccessStatusCode)
                {
                    responseBody = await response.Content.ReadAsStringAsync();
                    //解析JSon
                    if (responseBody != null)
                    {
                        jsonResult.Data = JsonConvert.DeserializeObject<T>(responseBody);
                    }
                }
                else
                {
                    Logger.Log(LogLevel.Info, String.Format("requestMethod={0},StatusCode={1},responseBody={2}", requestMethod, response.StatusCode, "authorize_failed"));
                    throw new Exception("authorize_failed");
                }
            }
            catch (Exception ex)
            {
                if (response == null)
                {
                    Logger.Log(LogLevel.Info, "API連線異常，response 無任何回傳值");
                    this.HandleWebApiException(jsonResult, "解析JSon為WebApiResult Object失敗", responseBody, ex);
                    return default(T);
                }

                Logger.Log(LogLevel.Info, String.Format("requestMethod={0},StatusCode={1},responseBody={2}", requestMethod, response.StatusCode, responseBody));
                this.HandleWebApiException(jsonResult, "解析JSon為WebApiResult Object失敗", responseBody, ex);
            }

            return jsonResult.Data;
        }

        private void HandleWebApiException<T>(WebApiResult<T> jsonResult, String message, string responseBody, Exception ex = null)
        {
            if (null != ex)
            {
                message += (":" + ex.Message + " DATA=[" + responseBody + "]");
            }
            if (null == ex)
            {
                throw new WebApiHandleException<T>(message, jsonResult);
            }
            else
            {
                throw new WebApiHandleException<T>(message, jsonResult, ex);
            }
        }

        public class WebApiHandleException<resT> : Exception
        {
            private WebApiResult<resT> JsonResult;

            public WebApiHandleException(String message, WebApiResult<resT> result)
                : base(message)
            {
                this.JsonResult = result;
            }

            public WebApiHandleException(String message, WebApiResult<resT> result, Exception ex)
                : base(message, ex)
            {
                this.JsonResult = result;
            }

            public WebApiResult<resT> WebApiResult
            {
                get { return this.JsonResult; }
            }
        }

        public class WebApiResult<T>
        {
            public string STATUS { get; set; }

            public string ERROR_MSG { get; set; }

            public WebApiResult()
            {
            }

            private T _resultData;

            public T Data
            {
                get { return this._resultData; }
                set { this._resultData = value; }
            }
        }

        private string GetQuery<T>(T model)
        {
            string query = "?";
            IList<PropertyInfo> props = new List<PropertyInfo>(model.GetType().GetProperties());
            for (int i = 0; i < props.Count; i++)
            {
                object queVal = props[i].GetValue(model, null);
                string queNme = props[i].GetMethod.Name.Substring(4);
                if (queVal != null)
                {
                    query += $"{(i > 0 ? "&" : "")}{queNme}={queVal}";
                }
            }
            return query;
        }
    }
}