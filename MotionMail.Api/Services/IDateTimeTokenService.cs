namespace MotionMail.Api.Services {
    using System.Threading.Tasks;

    using MotionMail.Api.Commands;
    using MotionMail.Api.Entities;

    public interface IDateTimeTokenService {
        #region Public Methods and Operators

        TokenResponse Crate(DateTimeCreateCommand command);

        Task<TokenResponse> CrateAsync(DateTimeCreateCommand command);

        #endregion
    }
}