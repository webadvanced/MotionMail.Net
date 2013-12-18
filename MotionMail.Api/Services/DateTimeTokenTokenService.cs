namespace MotionMail.Api.Services {
    using System.Threading.Tasks;

    using MotionMail.Api.Commands;
    using MotionMail.Api.Entities;
    using MotionMail.Api.Infrastructure;

    using Newtonsoft.Json;

    public class DateTimeTokenService : IDateTimeTokenService {
        #region Constructors and Destructors

        public DateTimeTokenService(string apiKey = null, string privateKey = null) {
            ApiKey = apiKey;
            PrivateKey = privateKey;
        }

        #endregion

        #region Properties

        private string ApiKey { get; set; }
        private string PrivateKey { get; set; }

        #endregion

        #region Public Methods and Operators

        public TokenResponse Create(DateTimeTokenCreateCommand command) {
            string url = ParameterBuilder.ApplyAllParameters(command, Urls.DateTime);
            string response = Requestor.PostString(url, ApiKey, PrivateKey);
            return JsonConvert.DeserializeObject<TokenResponse>(response);
        }

        public async Task<TokenResponse> CreateAsync(DateTimeTokenCreateCommand command) {
            string url = ParameterBuilder.ApplyAllParameters(command, Urls.DateTime);
            string response = await Requestor.PostStringAsync(url, ApiKey, PrivateKey);
            return await JsonConvert.DeserializeObjectAsync<TokenResponse>(response);
        }

        #endregion
    }
}