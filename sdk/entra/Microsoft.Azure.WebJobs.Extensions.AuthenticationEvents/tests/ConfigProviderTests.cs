using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using static Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests.TestHelper;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests
{
    [TestFixture]
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
        [Test]
        [TestCase("http://test/mock?function=onTokenissuancestart", HttpStatusCode.Unauthorized, HttpMethods.Post, null)]
        [TestCase("http://test/mock?function=onTokenissuancestart", HttpStatusCode.BadRequest, HttpMethods.Post, null)]
        [TestCase("http://test/mock?function=onTokenissuancestart", HttpStatusCode.OK, HttpMethods.Post, "{'hi':'bye'}")]
        [TestCase("http://test/mock?", HttpStatusCode.BadRequest, HttpMethods.Post, "{\"errors\":[\"Please supply the function name via the query parameter: functionName, available functions: onTokenIssuanceStart\"]}")]
        [TestCase("http://test/mock?function=onTokenissuancestart", HttpStatusCode.BadRequest, HttpMethods.Get, "{\"errors\":[\"Method can only be post.\"]}")]
        public async Task PostConfigProviderTests(string url, HttpStatusCode httpStatusCode, HttpMethods method, string expectedMessage)
        {
            HttpResponseMessage httpResponse = await BaseTest(method, url, async t =>
            {
                if (t.FunctionData.TriggerValue is HttpRequestMessage mockedRequest)
                {
                    WebJobsAuthenticationEventResponseHandler eventsResponseHandler = GetAuthenticationEventResponseHandler(mockedRequest);

                    await eventsResponseHandler.SetValueAsync(GetContentForHttpStatus(httpStatusCode), CancellationToken.None);
                }
            });

            Assert.AreEqual(httpStatusCode, httpResponse.StatusCode);
            if (expectedMessage != null)
            {
                Assert.AreEqual(expectedMessage, await httpResponse.Content.ReadAsStringAsync());
            }
        }
    }
}
