using System;
using System.Net;
using System.Net.Http;
using Xunit;
using static Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests.TestHelper;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests
{
    /// <summary>
    /// this class will test EventsTriggerConfigProvider
    /// </summary>
    public class ConfigProviderTests
    {
        /// <summary>
        /// This functions runs the test case defined by params and in-line data
        /// </summary>
        /// <param name="url"></param>
        /// <param name="httpStatusCode"></param>
        /// <param name="method"></param>
        /// <param name="expectedMessage"></param>
        ///
        [Obsolete]
        [Theory]
        [InlineData("http://test/mock?function=onTokenissuancestart", HttpStatusCode.Unauthorized, HttpMethods.Post, null)]
        [InlineData("http://test/mock?function=onTokenissuancestart", HttpStatusCode.BadRequest, HttpMethods.Post, null)]
        [InlineData("http://test/mock?function=onTokenissuancestart", HttpStatusCode.OK, HttpMethods.Post, "{'hi':'bye'}")]
        [InlineData("http://test/mock?", HttpStatusCode.BadRequest, HttpMethods.Post, "{\"errors\":[\"Please supply the function name via the query parameter: functionName, available functions: onTokenIssuanceStart\"]}")]
        [InlineData("http://test/mock?function=onTokenissuancestart", HttpStatusCode.BadRequest, HttpMethods.Get, "{\"errors\":[\"Method can only be post.\"]}")]
        public async void PostConfigProviderTests(string url, HttpStatusCode httpStatusCode, HttpMethods method, string expectedMessage)
        {
            HttpResponseMessage httpResponse = await BaseTest(method, url, t =>
            {
                if (t.FunctionData.TriggerValue is HttpRequestMessage mockedRequest)
                {

                    AuthenticationEventResponseHandler eventsResponseHandler = (AuthenticationEventResponseHandler)mockedRequest.Properties[AuthenticationEventResponseHandler.EventResponseProperty];
                    eventsResponseHandler.Response = GetContentForHttpStatus(httpStatusCode);
                }
            });

            Assert.Equal(httpStatusCode, httpResponse.StatusCode);
            if (expectedMessage != null)
            {
                Assert.Equal(expectedMessage, await httpResponse.Content.ReadAsStringAsync());
            }
        }
    }
}
