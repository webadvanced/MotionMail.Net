namespace MotionMail.Api.Commands {
    using System;

    public class DateTimeCreateCommand {
        #region Constructors and Destructors

        public DateTimeCreateCommand(DateTime dateTime) {
            DateTime = dateTime.ToString("s");
        }

        #endregion

        #region Public Properties

        public string DateTime { get; private set; }

        #endregion

        #region Public Methods and Operators

        public static DateTimeCreateCommand FromDateTime(DateTime dateTime) {
            return new DateTimeCreateCommand(dateTime);
        }

        #endregion
    }
}