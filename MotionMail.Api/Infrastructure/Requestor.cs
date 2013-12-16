namespace MotionMail.Api.Infrastructure {
    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;

    using MotionMail.Api.Entities;

    using Newtonsoft.Json;

    internal static class Requestor {
        #region Public Methods and Operators

        public static string Delete(string url, string apiKey = null, string secretKey = null) {
            WebRequest wr = GetWebRequest(url, "DELETE", apiKey, secretKey);

            return ExecuteWebRequest(wr);
        }

        public static async Task<string> DeleteAsync(string url, string apiKey = null, string secretKey = null) {
            WebRequest wr = GetWebRequest(url, "DELETE", apiKey, secretKey);

            return await ExecuteWebRequestAsync(wr);
        }

        public static string GetString(string url, string apiKey = null, string secretKey = null) {
            WebRequest wr = GetWebRequest(url, "GET", apiKey, secretKey);

            return ExecuteWebRequest(wr);
        }

        public static async Task<string> GetStringAsync(string url, string apiKey = null, string secretKey = null) {
            WebRequest wr = GetWebRequest(url, "GET", apiKey, secretKey);

            return await ExecuteWebRequestAsync(wr);
        }

        public static string PostString(string url, string apiKey = null, string secretKey = null) {
            WebRequest wr = GetWebRequest(url, "POST", apiKey, secretKey);

            return ExecuteWebRequest(wr);
        }

        public static async Task<string> PostStringAsync(string url, string apiKey = null, string secretKey = null) {
            WebRequest wr = GetWebRequest(url, "POST", apiKey, secretKey);

            return await ExecuteWebRequestAsync(wr);
        }

        public static string PostStringBearer(string url, string apiKey = null, string secretKey = null) {
            WebRequest wr = GetWebRequest(url, "POST", apiKey, secretKey, true);

            return ExecuteWebRequest(wr);
        }

        public static async Task<string> PostStringBearerAsync(
            string url,
            string apiKey = null,
            string secretKey = null) {
            WebRequest wr = GetWebRequest(url, "POST", apiKey, secretKey, true);

            return await ExecuteWebRequestAsync(wr);
        }

        #endregion

        #region Methods

        private static string ExecuteWebRequest(WebRequest webRequest) {
            try {
                using (WebResponse response = webRequest.GetResponse()) {
                    return ReadStream(response.GetResponseStream());
                }
            }
            catch (WebException webException) {
                if (webException.Response == null) {
                    throw;
                }
                HttpStatusCode statusCode = ((HttpWebResponse)webException.Response).StatusCode;

                var error =
                    JsonConvert.DeserializeObject<MotionMailError>(
                        ReadStream(webException.Response.GetResponseStream()));

                throw new MotionMailException(statusCode, error, error.Message);
            }
        }

        private static async Task<string> ExecuteWebRequestAsync(WebRequest webRequest) {
            try {
                using (WebResponse response = webRequest.GetResponse()) {
                    return await ReadStreamAsync(response.GetResponseStream());
                }
            }
            catch (WebException webException) {
                if (webException.Response == null) {
                    throw;
                }
                HttpStatusCode statusCode = ((HttpWebResponse)webException.Response).StatusCode;

                var error =
                    JsonConvert.DeserializeObject<MotionMailError>(
                        ReadStream(webException.Response.GetResponseStream()));

                throw new MotionMailException(statusCode, error, error.Message);
            }
        }

        private static string GetAuthorizationHeaderValue(string apiKey, string secretKey) {
            string token = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", apiKey, secretKey)));
            return string.Format("Basic {0}", token);
        }

        private static string GetAuthorizationHeaderValueBearer(string apiKey) {
            return string.Format("Bearer {0}", apiKey);
        }

        private static WebRequest GetWebRequest(
            string url,
            string method,
            string apiKey = null,
            string secretKey = null,
            bool useBearer = false) {
            apiKey = apiKey ?? MotionMailConfiguration.GetApiKey();
            secretKey = secretKey ?? MotionMailConfiguration.GetSecretKey();

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;

            request.Headers.Add(
                "Authorization",
                !useBearer ? GetAuthorizationHeaderValue(apiKey, secretKey) : GetAuthorizationHeaderValueBearer(apiKey));

            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "MotionMail.net (https://github.com/webadvanced/MotionMail.Net)";

            return request;
        }

        private static string ReadStream(Stream stream) {
            using (var reader = new StreamReader(stream, Encoding.UTF8)) {
                return reader.ReadToEnd();
            }
        }

        private static async Task<string> ReadStreamAsync(Stream stream) {
            using (var reader = new StreamReader(stream, Encoding.UTF8)) {
                return await reader.ReadToEndAsync();
            }
        }

        #endregion
    }
}