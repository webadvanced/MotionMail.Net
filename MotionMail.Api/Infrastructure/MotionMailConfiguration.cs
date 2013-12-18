namespace MotionMail.Api.Infrastructure {
    using System;
    using System.Configuration;

    public static class MotionMailConfiguration {
        #region Public Properties

        public static string ApiKey { get; private set; }

        public static string SecretKey { get; private set; }

        #endregion

        #region Public Methods and Operators

        public static void SetApiKey(string key) {
            ApiKey = key;
        }

        public static void SetSecretKey(string key) {
            SecretKey = key;
        }

        #endregion

        #region Methods

        public static string GetApiKey() {
            if (String.IsNullOrEmpty(ApiKey)) {
                ApiKey = ConfigurationManager.AppSettings["MotionMailApiKey"];
            }

            return ApiKey;
        }

        public static string GetSecretKey() {
            if (String.IsNullOrEmpty(SecretKey)) {
                SecretKey = ConfigurationManager.AppSettings["MotionMailSecretKey"];
            }

            return SecretKey;
        }

        #endregion
    }
}