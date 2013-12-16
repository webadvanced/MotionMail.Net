namespace MotionMail.Api.Commands {
    using System;

    public class DateTimeTokenCreateCommand {
        #region Constructors and Destructors

        public DateTimeTokenCreateCommand(DateTime dateTime) {
            DateTime = dateTime.ToString("s");
        }

        #endregion

        #region Public Properties

        public string DateTime { get; private set; }

        #endregion

        #region Public Methods and Operators

        public static DateTimeTokenCreateCommand FromDateTime(DateTime dateTime) {
            return new DateTimeTokenCreateCommand(dateTime);
        }

        #endregion
    }
}