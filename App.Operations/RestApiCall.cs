using App.Service;
using App.Service.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace App.Service
{
    public static class RestApiCall
    {
        const string RestWsUserName = "";
        const string RestWsPassword = "";
        public static OperationResult ExecuteApiMethod(string Url, Object requestData, string requestMethodType = "POST")
        {
            var request = (HttpWebRequest)(WebRequest.Create(Url));
            request.Method = requestMethodType;
            request.ContentType = "application/json";
            //request.Headers.Add("username", RestWsUserName);
            //request.Headers.Add("password", RestWsPassword);

            //we can log request to rest service here  
            string data = JsonConvert.SerializeObject(requestData);

            Stream webStream = request.GetRequestStream();
            StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.UTF8);
            requestWriter.Write(data);
            var result = new OperationResult();
            WebResponse response = request.GetResponse();
            try
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                
                result.ReturnedObject = reader.ReadToEnd();
                result.severity = severity_num.success;
                reader.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                result.severity = severity_num.error;
                result.Text = ex.Message;
            }
            return result;
        }

    }
}
