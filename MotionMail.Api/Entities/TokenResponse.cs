namespace MotionMail.Api.Entities {
    using System;

    public class TokenResponse {
        #region Public Properties

        public DateTimeOffset DateCreated { get; set; }

        public bool Success { get; set; }

        public string Value { get; set; }

        #endregion
    }
}