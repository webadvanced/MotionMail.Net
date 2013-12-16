namespace MotionMail.Api.Infrastructure {
    using System;
    using System.Net;

    using MotionMail.Api.Entities;

    [Serializable]
    public class MotionMailException : ApplicationException {
        #region Constructors and Destructors

        public MotionMailException() {
        }

        public MotionMailException(HttpStatusCode httpStatusCode, MotionMailError motionMailError, string message)
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