namespace MotionMail.Api.Entities {
    using System;

    public class MotionMailError {
        #region Public Properties

        public DateTime DateTimeCreated { get; private set; }

        public string Message { get; set; }

        public string Param { get; set; }

        public long? StatusCode { get; set; }

        public string Type { get; set; }

        #endregion
    }
}