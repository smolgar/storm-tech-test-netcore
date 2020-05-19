using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Todo.Models;
using Todo.Models.TodoItems;

namespace Todo.Services
{
    public  class GravatarAPI
    {
        static HttpClient client = new HttpClient();

        public  GravatarUserModel GetJsonvatar(string userid) {
            HttpWebResponse responseStream = null;
            string receiveContent;
            GravatarUserModel objGravatar = new GravatarUserModel();

            string gravatorUrl = "http://www.gravatar.com/" + userid + ".json";

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(gravatorUrl);
                request.Method = "GET";
                request.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36";
                using (responseStream = (HttpWebResponse)request.GetResponse())
                {
                    if (responseStream.StatusCode == HttpStatusCode.OK)
                    {
                        StreamReader sr = new StreamReader(responseStream.GetResponseStream());
                        if (responseStream != null)
                        {
                            receiveContent = sr.ReadToEnd();
                            sr.Close();
                            objGravatar = JsonConvert.DeserializeObject<GravatarUserModel>(receiveContent);
                            string displayName = objGravatar.Entry[0].DisplayName;
                            return objGravatar;
                        }
                    }
                }
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    responseStream = (HttpWebResponse)e.Response;
                    Console.Write("Errorcode: {0}", (int)responseStream.StatusCode);
                }
                else
                {
                    Console.Write("Error: {0}", e.Status);
                }
            }
            finally
            {
                if (responseStream != null)
                {
                    responseStream.Close();
                }
            }
            return objGravatar;

        }
    }
}