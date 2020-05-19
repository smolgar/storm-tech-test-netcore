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
            GravatarUserModel objUserGravatar = ob.GetJsonvatar(userid);
            string displayName = objUserGravatar.Entry[0].DisplayName;
            return displayName;
        }
    
    }
}