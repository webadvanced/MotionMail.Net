namespace MotionMail.Api.Infrastructure {
    using System;
    using System.Net;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    using MotionMail.Api.Entities;

    [Serializable]
    public class MotionMailApiException : Exception {
        #region Constructors and Destructors

        public MotionMailApiException() {
        }

        public MotionMailApiException(HttpStatusCode httpStatusCode, MotionMailError motionMailError, string message)
            : base(message) {
            HttpStatusCode = httpStatusCode;
            MotionMailError = motionMailError;
        }

        public MotionMailApiException(
            HttpStatusCode httpStatusCode,
            MotionMailError motionMailError,
            string message,
            Exception innerException)
            : base(message, innerException) {
            HttpStatusCode = httpStatusCode;
            MotionMailError = motionMailError;
        }

        protected MotionMailApiException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
            HttpStatusCode = (HttpStatusCode)info.GetValue("HttpStatusCode", typeof(HttpStatusCode));
            MotionMailError = (MotionMailError)info.GetValue("MotionMailError", typeof(MotionMailError));
        }

        #endregion

        #region Public Properties

        public HttpStatusCode HttpStatusCode { get; set; }

        public MotionMailError MotionMailError { get; set; }

        #endregion

        #region Public Methods and Operators

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context) {
            if (info == null) {
                throw new ArgumentNullException("info");
            }
            info.AddValue("HttpStatusCode", HttpStatusCode);
            info.AddValue("MotionMailError", MotionMailError);
            base.GetObjectData(info, context);
        }

        #endregion
    }
}