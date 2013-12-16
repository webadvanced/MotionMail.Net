namespace MotionMail.Api.Entities {
    using System;

    public class TokenResponse {
        #region Public Properties

        public DateTimeOffset DateTimeCreated { get; set; }

        public bool Success { get; set; }

        public string Value { get; set; }

        #endregion
    }
}