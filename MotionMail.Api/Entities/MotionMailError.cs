namespace MotionMail.Api.Entities {
    using System;

    public class MotionMailError {
        #region Public Properties

        public DateTime DateTimeCreated { get; set; }

        public string Error { get; set; }

        public string ErrorType { get; set; }

        public string Message { get; set; }

        #endregion
    }
}