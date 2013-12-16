namespace MotionMail.Api.Infrastructure {
    using System;

    public class Urls {
        #region Constants and Fields

        public static string DateTime = String.Format("{0}tokens/datetime", BaseUrl);

        private const string BaseUrl = "http://motionmail.apphb.com/";

        #endregion
    }
}