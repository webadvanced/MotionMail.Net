namespace MotionMail.Api.Infrastructure {
    using System;

    public class Urls {
        #region Constants and Fields

        public static string DateTime = String.Format("{0}tokens/datetime", BaseUrl);
#if DEBUG
        private const string BaseUrl = "http://localhost:59975/";
#else
        private const string BaseUrl = "https://api.motionmailapp.com/";
#endif

        #endregion
    }
}