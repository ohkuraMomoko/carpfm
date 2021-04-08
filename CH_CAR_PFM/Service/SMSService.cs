using CH_CAR_PFM.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace CH_CAR_PFM.Service
{
    public class SMSService
    {
        public static SMS_MESSAGE_MODEL SendSmeAsk(string phone, string body)
        {
            dynamic response = null;
            string test_mode = ConfigurationManager.AppSettings["TestMode"].ToString();

            if (test_mode == "Y")
                phone = "0930101124";

            string apiUrl = ConfigurationManager.AppSettings["MSG_URL"].ToString();
            string msg_id = ConfigurationManager.AppSettings["MSG_ID"].ToString();
            string msg_pwd = ConfigurationManager.AppSettings["MSG_PWD"].ToString();
            string postData = "username=" + msg_id + "&password=" + msg_pwd + "&encoding=UTF8&dstaddr=" + phone + "&DestName=會員申請貼現成功&smbody=" + body;
            string fullUrl = apiUrl + "?" + postData;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fullUrl);
            response = (HttpWebResponse)request.GetResponse();
            string json = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return new SMS_MESSAGE_MODEL() { Result = true, Message = string.Empty };

        }
    }
}