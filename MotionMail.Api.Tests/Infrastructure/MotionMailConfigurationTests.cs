namespace MotionMail.Api.Tests.Infrastructure {
    using MotionMail.Api.Infrastructure;

    using Xunit;

    public class MotionMailConfigurationTests {
        #region Public Methods and Operators

        [Fact]
        public void GetApiKeyShouldReturnStaticValueWhenStaticValueIsNotNull() {
            const string ExpectedApiKey = "api_from_code";
            MotionMailConfiguration.SetApiKey(ExpectedApiKey);
            Assert.Equal(ExpectedApiKey, MotionMailConfiguration.GetApiKey());
        }

        [Fact]
        public void GetApiKeyShouldReturnValueFromConfigWhenStaticValueIsNull() {
            const string ExpectedApiKey = "api_from_config";
            MotionMailConfiguration.SetApiKey(string.Empty);
            Assert.Equal(ExpectedApiKey, MotionMailConfiguration.GetApiKey());
        }

        [Fact]
        public void GetSecretKeyShouldReturnStaticValueWhenStaticValueIsNotNull() {
            const string ExpectedSecretKey = "secret_from_code";
            MotionMailConfiguration.SetSecretKey(ExpectedSecretKey);
            Assert.Equal(ExpectedSecretKey, MotionMailConfiguration.GetSecretKey());
        }

        [Fact]
        public void GetSecretKeyShouldReturnValueFromConfigWhenStaticValueIsNull() {
            const string ExpectedSecretKey = "secret_from_config";
            MotionMailConfiguration.SetSecretKey(string.Empty);
            Assert.Equal(ExpectedSecretKey, MotionMailConfiguration.GetSecretKey());
        }

        [Fact]
        public void SetApiKeyShouldSetApiKeyTo123() {
            const string ExpectedApiKey = "api_from_code";
            MotionMailConfiguration.SetApiKey(ExpectedApiKey);
            Assert.Equal(ExpectedApiKey, MotionMailConfiguration.ApiKey);
        }

        [Fact]
        public void SetSecretKeyShouldSetApiKeyTo456() {
            const string ExpectedSecretKey = "secret_from_code";
            MotionMailConfiguration.SetSecretKey(ExpectedSecretKey);
            Assert.Equal(ExpectedSecretKey, MotionMailConfiguration.SecretKey);
        }

        #endregion
    }
}