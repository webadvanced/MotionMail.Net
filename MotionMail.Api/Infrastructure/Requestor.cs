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
            return ExecuteWebRequest(url, "DELETE", apiKey, secretKey);
        }

        public static async Task<string> DeleteAsync(string url, string apiKey = null, string secretKey = null) {
            return await ExecuteWebRequestAsync(url, "DELETE", apiKey, secretKey);
        }

        public static string GetString(string url, string apiKey = null, string secretKey = null) {
            return ExecuteWebRequest(url, "GET", apiKey, secretKey);
        }

        public static async Task<string> GetStringAsync(string url, string apiKey = null, string secretKey = null) {
            return await ExecuteWebRequestAsync(url, "GET", apiKey, secretKey);
        }

        public static string PostString(string url, string apiKey = null, string secretKey = null) {
            return ExecuteWebRequest(url, "POST", apiKey, secretKey);
        }

        public static async Task<string> PostStringAsync(string url, string apiKey = null, string secretKey = null) {
            return await ExecuteWebRequestAsync(url, "POST", apiKey, secretKey);
        }

        #endregion

        #region Methods

        private static string ExecuteWebRequest(
            string url,
            string method,
            string apiKey = null,
            string secretKey = null) {
            apiKey = apiKey ?? MotionMailConfiguration.GetApiKey();
            secretKey = secretKey ?? MotionMailConfiguration.GetSecretKey();

            try {
                using (var client = new WebClient()) {
                    client.Headers.Add("Authorization", GetAuthorizationHeaderValue(apiKey, secretKey));
                    return client.UploadString(url, method, url.Split('?')[1]);
                }
            }
            catch (WebException webException) {
                if (webException.Response == null) {
                    throw;
                }
                HttpStatusCode statusCode = ((HttpWebResponse)webException.Response).StatusCode;
                string rawError = ReadStream(webException.Response.GetResponseStream());

                var error = JsonConvert.DeserializeObject<MotionMailError>(rawError);

                throw new MotionMailApiException(statusCode, error, error.Message);
            }
        }

        private static async Task<string> ExecuteWebRequestAsync(
            string url,
            string method,
            string apiKey = null,
            string secretKey = null) {
            apiKey = apiKey ?? MotionMailConfiguration.GetApiKey();
            secretKey = secretKey ?? MotionMailConfiguration.GetSecretKey();
            try {
                using (var client = new WebClient()) {
                    client.Headers.Add("Authorization", GetAuthorizationHeaderValue(apiKey, secretKey));
                    return await client.UploadStringTaskAsync(url, method, url.Split('?')[1]);
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

                throw new MotionMailApiException(statusCode, error, error.Message);
            }
        }

        private static string GetAuthorizationHeaderValue(string apiKey, string secretKey) {
            string token = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", apiKey, secretKey)));
            return string.Format("Basic {0}", token);
        }

        private static string ReadStream(Stream stream) {
            using (var reader = new StreamReader(stream, Encoding.UTF8)) {
                return reader.ReadToEnd();
            }
        }

        #endregion
    }
}