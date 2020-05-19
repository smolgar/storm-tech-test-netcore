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
    public static class Gravatar
    {
        static HttpClient client = new HttpClient();
        public static string GetHash(string emailAddress)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.Default.GetBytes(emailAddress.Trim().ToLowerInvariant());
                var hashBytes = md5.ComputeHash(inputBytes);

                var builder = new StringBuilder();
                foreach (var b in hashBytes)
                {
                    builder.Append(b.ToString("X2"));
                }
                return builder.ToString().ToLowerInvariant();
            }
        }

        public static string GetGravatarDisplayName(string userid)
        {
            GravatarAPI ob = new GravatarAPI();
               //GravatarUserModel objUserGravatar1 = GetJsonvatar(userid);
            GravatarUserModel objUserGravatar = ob.GetJsonvatar(userid);
            string displayName = objUserGravatar.Entry[0].DisplayName;
            return displayName;
        }
    
        //public static GravatarUserModel GetJsonvatar(string userid) {
        //    HttpWebResponse responseStream = null;
        //    string receiveContent;
        //    GravatarUserModel objGravatar = new GravatarUserModel();

        //    string gravatorUrl = "http://www.gravatar.com/" + userid + ".json";
            
        //    try
        //    {
        //        var request = (HttpWebRequest)WebRequest.Create(gravatorUrl);
        //        request.Method = "GET";
        //        request.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36";
        //        using (responseStream = (HttpWebResponse)request.GetResponse())
        //        {
        //            if (responseStream.StatusCode == HttpStatusCode.OK)
        //            {
        //                StreamReader sr = new StreamReader(responseStream.GetResponseStream());
        //                if (responseStream != null)
        //                {
        //                    receiveContent = sr.ReadToEnd();
        //                    sr.Close();
        //                    objGravatar = JsonConvert.DeserializeObject<GravatarUserModel>(receiveContent);
        //                    string displayName = objGravatar.Entry[0].DisplayName;
        //                    return objGravatar;
        //                }
        //            }
        //        }
        //    }
        //    catch (WebException e)
        //    {
        //        if (e.Status == WebExceptionStatus.ProtocolError)
        //        {
        //            responseStream = (HttpWebResponse)e.Response;
        //            Console.Write("Errorcode: {0}", (int)responseStream.StatusCode);
        //        }
        //        else
        //        {
        //            Console.Write("Error: {0}", e.Status);
        //        }
        //    }
        //    finally
        //    {
        //        if (responseStream != null)
        //        {
        //            responseStream.Close();
        //        }
        //    }
        //    return objGravatar;

        //}
    }
}