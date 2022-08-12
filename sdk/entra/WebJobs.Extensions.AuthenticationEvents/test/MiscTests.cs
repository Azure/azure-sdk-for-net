
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Actions;
using System.Net.Http;
using System.Threading;
using WebJobs.Extensions.AuthenticationEvents.Tests.Payloads.TokenIssuanceStart;
using WebJobs.Extensions.AuthenticationEvents.Tests.Payloads.TokenIssuanceStart.Legacy;
using Xunit;

namespace WebJobs.Extensions.AuthenticationEvents.Tests
{

    /// <summary>Tests the OnTokenIssuanceStart request and response for the csharp object model for version preview_10_01_2021</summary>
    public class MiscTests
    {
        /// <summary>Runs 10000 calls to the library concurrently with success payload and response</summary>
        [Fact]
        public void ConcurrencyTest()
        {
            for (int i = 0; i < 10000; i++)
                ThreadPool.QueueUserWorkItem(async w =>
                {
                    HttpResponseMessage httpResponseMessage = await TestHelper.EventResponseBaseTest(eventsResponseHandler =>
                    {
                        eventsResponseHandler.SetValueAsync(TokenIssuanceStart.ActionResponse, CancellationToken.None);
                    });

                    Assert.Equal(System.Net.HttpStatusCode.OK, httpResponseMessage.StatusCode);
                    Assert.True(TestHelper.DoesPayloadMatch(TokenIssuanceStartLegacy.ExpectedPayload, httpResponseMessage.Content.ReadAsStringAsync().Result));
                });
        }

        /// <summary>Tests query string parameter conversions.</summary>
        [Fact]
        public void QueryParameterTest()
        {
            TokenIssuanceStartRequest tokenIssuanceStartRequest = new TokenIssuanceStartRequest(new HttpRequestMessage(HttpMethod.Get, "http://test?param1=test1&param2=test2"));
            Assert.True(TestHelper.DoesPayloadMatch(TokenIssuanceStart.TokenInssuanceStartQueryParameter, tokenIssuanceStartRequest.ToString()));
        }

        /// <summary>Tests the OnTokenIssuanceStart request and response object model for CSharp for version: 10_01_2021</summary>
        [Fact]
        public async void TokenIssuanceStartObjectModelTest()
        {
            HttpResponseMessage httpResponseMessage = await TestHelper.EventResponseBaseTest(eventsResponseHandler =>
            {
                if (eventsResponseHandler.Request is TokenIssuanceStartRequest request)
                {
                    request.Response.Actions.Add(new ProvideClaimsForToken(
                                                  new TokenClaim("DateOfBirth", "01/01/2000"),
                                                  new TokenClaim("CustomRoles", "Writer", "Editor")
                                              ));

                    eventsResponseHandler.SetValueAsync(request.Completed().Result, CancellationToken.None);
                }
            });

            Assert.Equal(System.Net.HttpStatusCode.OK, httpResponseMessage.StatusCode);
            Assert.True(TestHelper.DoesPayloadMatch(TokenIssuanceStartLegacy.ExpectedPayload, httpResponseMessage.Content.ReadAsStringAsync().Result));
        }
    }
}
