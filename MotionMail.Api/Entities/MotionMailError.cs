namespace MotionMail.Api.Entities {
    using System;
    using System.Net;

    public class MotionMailError {
        #region Public Properties

        public DateTime DateTimeCreated { get; private set; }

        public string Message { get; set; }

        public string Param { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string Type { get; set; }

        #endregion
    }
}