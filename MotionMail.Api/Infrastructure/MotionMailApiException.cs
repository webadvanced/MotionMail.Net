namespace MotionMail.Api.Infrastructure {
    using System;
    using System.Net;

    using MotionMail.Api.Entities;

    [Serializable]
    public class MotionMailApiException : ApplicationException {
        #region Constructors and Destructors

        public MotionMailApiException() {
        }

        public MotionMailApiException(HttpStatusCode httpStatusCode, MotionMailError motionMailError, string message)
            : base(message) {
            HttpStatusCode = httpStatusCode;
            MotionMailError = motionMailError;
        }

        #endregion

        #region Public Properties

        public HttpStatusCode HttpStatusCode { get; set; }

        public MotionMailError MotionMailError { get; set; }

        #endregion
    }
}