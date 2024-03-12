using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MDA_Web.Models
{
    public class ReCaptcha
    {
        public static string MessageError { get; set; }
        public static string Validate(string EncodedResponse, string PrivateKey)
        {
            try
            {
                var client = new System.Net.WebClient();

                //string PrivateKey = "6LcH-v8SerfgAPlLLffghrITSL9xM7XLrz8aeory";

                var GoogleReply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", PrivateKey, EncodedResponse));

                var captchaResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ReCaptcha>(GoogleReply);

                return captchaResponse.Success.ToLower();

            }catch(Exception ex)
            {
                MessageError = ex.Message;
                return "fail";
            }
        }

        [JsonProperty("success")]
        public string Success
        {
            get { return m_Success; }
            set { m_Success = value; }
        }

        private string m_Success;
        [JsonProperty("error-codes")]
        public List<string> ErrorCodes
        {
            get { return m_ErrorCodes; }
            set { m_ErrorCodes = value; }
        }


        private List<string> m_ErrorCodes;
    }
}