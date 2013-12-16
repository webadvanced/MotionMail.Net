namespace MotionMail.Api.Infrastructure {
    using System;
    using System.Configuration;

    public static class MotionMailConfiguration {
        #region Constants and Fields

        private static string apiKey;

        private static string secretKey;

        #endregion

        #region Public Methods and Operators

        public static void SetApiKey(string key) {
            apiKey = key;
        }

        public static void SetSecretKey(string key) {
            secretKey = key;
        }

        #endregion

        #region Methods

        internal static string GetApiKey() {
            if (String.IsNullOrEmpty(apiKey)) {
                apiKey = ConfigurationManager.AppSettings["MotionMailApiKey"];
            }

            return apiKey;
        }

        internal static string GetSecretKey() {
            if (String.IsNullOrEmpty(secretKey)) {
                apiKey = ConfigurationManager.AppSettings["MotionMailSecretKey"];
            }

            return apiKey;
        }

        #endregion
    }
}