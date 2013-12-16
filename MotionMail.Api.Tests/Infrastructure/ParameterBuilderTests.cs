namespace MotionMail.Api.Tests.Infrastructure {
    using System;
    using System.Globalization;
    using System.Web;

    using MotionMail.Api.Infrastructure;
    using MotionMail.Api.Tests.Helpers;

    using Xunit;

    public class ParameterBuilderTests {
        #region Constants and Fields

        private const string BaseUrl = "http://baseurl.com:8081/";

        #endregion

        #region Public Methods and Operators

        [Fact]
        public void ApplyAllParamatersShouldReturnNewUrlWithWithProperyNamesAsKeysAndAssoiatedSetValues() {
            var model = new MockModel { MockDateTime = DateTime.Now, MockLong = 25, MockString = "Mock String" };
            string expected = string.Format(
                "{0}?MockDateTime={1}&MockString={2}&MockLong={3}",
                BaseUrl,
                HttpUtility.UrlEncode(model.MockDateTime.ToString()),
                HttpUtility.UrlEncode(model.MockString),
                HttpUtility.UrlEncode(model.MockLong.ToString(CultureInfo.InvariantCulture)));
            Assert.Equal(expected, ParameterBuilder.ApplyAllParameters(model, BaseUrl));
        }

        [Fact]
        public void ApplyAllParametersShouldReturnBaseUrlWhenProvidedNullObject() {
            Assert.Equal(BaseUrl, ParameterBuilder.ApplyAllParameters(null, BaseUrl));
        }

        [Fact]
        public void ApplyParamaterToUrlShouldUseAmpersandAsTokenWhenThereIsAQuestionMarkInProvidedUrl() {
            string expected = string.Format(
                "{0}?foo={1}&bar={2}",
                BaseUrl,
                HttpUtility.UrlEncode("bar"),
                HttpUtility.UrlEncode("foo"));
            string newUrl = ParameterBuilder.ApplyParameterToUrl(BaseUrl, "foo", "bar");
            Assert.Equal(expected, ParameterBuilder.ApplyParameterToUrl(newUrl, "bar", "foo"));
        }

        [Fact]
        public void ApplyParamaterToUrlShouldUseEmptyStringForEmptyOrNullValues() {
            string expected = string.Format("{0}?foo=", BaseUrl);
            Assert.Equal(expected, ParameterBuilder.ApplyParameterToUrl(BaseUrl, "foo", null));
        }

        [Fact]
        public void ApplyParamaterToUrlShouldUseQuestionMarkAsTokenWhenThereIsNoQuestionMarkInProvidedUrl() {
            string expected = string.Format("{0}?foo={1}", BaseUrl, HttpUtility.UrlEncode("bar"));
            Assert.Equal(expected, ParameterBuilder.ApplyParameterToUrl(BaseUrl, "foo", "bar"));
        }

        #endregion
    }
}