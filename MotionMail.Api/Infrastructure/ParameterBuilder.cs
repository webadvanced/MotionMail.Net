﻿namespace MotionMail.Api.Infrastructure {
    using System.Reflection;
    using System.Web;

    public static class ParameterBuilder {
        #region Public Methods and Operators

        public static string ApplyAllParameters(object obj, string url) {
            if (obj == null) {
                return url;
            }

            string newUrl = url;

            foreach (PropertyInfo property in
                obj.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)) {
                object value = property.GetValue(obj, null);

                if (value != null) {
                    newUrl = ApplyParameterToUrl(newUrl, property.Name, value.ToString());
                }
            }

            return newUrl;
        }

        public static string ApplyParameterToUrl(string url, string argument, string value) {
            string token = "&";

            if (!url.Contains("?")) {
                token = "?";
            }

            return string.Format("{0}{1}{2}={3}", url, token, argument, HttpUtility.UrlEncode(value));
        }

        #endregion
    }
}