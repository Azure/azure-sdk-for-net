
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Actions;
using NUnit.Framework;
using static Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests.TestHelper;
using Payload = Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests.Payloads.TokenIssuanceStart;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests
{

    /// <summary>Tests the OnTokenIssuanceStart request and response for the csharp object model for version preview_10_01_2021</summary>
    [TestFixture]
    public class MiscTests
    {
        /// <summary>Runs 10000 calls to the library concurrently with success payload and response</summary>
        [Test]
        public void ConcurrencyTest()
        {
            for (int i = 0; i < 10000; i++)
                ThreadPool.QueueUserWorkItem(async w =>
                {
                    HttpResponseMessage httpResponseMessage = await TestHelper.EventResponseBaseTest(eventsResponseHandler =>
                    {
                        eventsResponseHandler.SetValueAsync(Payload.TokenIssuanceStart.ActionResponse, CancellationToken.None);
                    });

                    Assert.AreEqual(System.Net.HttpStatusCode.OK, httpResponseMessage.StatusCode);
                    Assert.True(TestHelper.DoesPayloadMatch(Payload.TokenIssuanceStart.ExpectedPayload, httpResponseMessage.Content.ReadAsStringAsync().Result));
                });
        }

        /// <summary>Tests query string parameter conversions.</summary>
        [Test]
        public void QueryParameterTest()
        {
            TokenIssuanceStartRequest tokenIssuanceStartRequest = new TokenIssuanceStartRequest(new HttpRequestMessage(HttpMethod.Get, "http://test?param1=test1&param2=test2"));
            Assert.True(TestHelper.DoesPayloadMatch(Payload.TokenIssuanceStart.TokenIssuanceStartQueryParameter, tokenIssuanceStartRequest.ToString()));
        }

        /// <summary>Tests the OnTokenIssuanceStart request and response object model for CSharp for version: 10_01_2021</summary>
        [Test]
        public async Task TokenIssuanceStartObjectModelTest()
        {
            HttpResponseMessage httpResponseMessage = await TestHelper.EventResponseBaseTest(eventsResponseHandler =>
            {
                if (eventsResponseHandler.Request is TokenIssuanceStartRequest request)
                {
                    request.Response.Actions.Add(
                        new ProvideClaimsForToken(
                            new TokenClaim("DateOfBirth", "01/01/2000"),
                            new TokenClaim("CustomRoles", "Writer", "Editor")
                            ));

                    eventsResponseHandler.SetValueAsync(request.Completed().Result, CancellationToken.None);
                }
            });

            Assert.AreEqual(System.Net.HttpStatusCode.OK, httpResponseMessage.StatusCode);
            Assert.True(TestHelper.DoesPayloadMatch(Payload.TokenIssuanceStart.ExpectedPayload, httpResponseMessage.Content.ReadAsStringAsync().Result));
        }

        /// <summary>Test the request object to verify the correct HttpStatusCode is respond</summary>
        [Test]
        [TestCase(RequestStatusType.Successful, HttpStatusCode.OK)]
        [TestCase(RequestStatusType.Failed, HttpStatusCode.BadRequest)]
        [TestCase(RequestStatusType.ValidationError, HttpStatusCode.BadRequest)]
        [TestCase(RequestStatusType.TokenInvalid, HttpStatusCode.Unauthorized)]
        public async Task TokenIssuanceStartRequestValidationTest(RequestStatusType requestStatusType, HttpStatusCode httpStatusCode)
        {
            HttpResponseMessage httpResponseMessage = await TestHelper.EventResponseBaseTest(eventsResponseHandler =>
            {
                if (eventsResponseHandler.Request is TokenIssuanceStartRequest request)
                {
                    request.Response.Actions.Add(
                        new ProvideClaimsForToken(
                            new TokenClaim("DateOfBirth", "01/01/2000"),
                            new TokenClaim("CustomRoles", "Writer", "Editor")
                            ));

                    // set the request status type
                    request.RequestStatus = requestStatusType;
                    eventsResponseHandler.SetValueAsync(request.Completed().Result, CancellationToken.None);
                }
            });

            Assert.AreEqual(httpStatusCode, httpResponseMessage.StatusCode);
        }

        /// <summary>Tests the OnTokenIssuanceStart request and response object model when the response is set to null</summary>
        [Test]
        [Description("Tests the OnTokenIssuanceStart request and response object model when the response is set to null")]
        public async Task TokenIssuanceStartObjectModelNullResponseTest()
        {
            HttpResponseMessage httpResponseMessage = await TestHelper.EventResponseBaseTest(eventsResponseHandler =>
            {
                if (eventsResponseHandler.Request is TokenIssuanceStartRequest request)
                {
                    request.Response = null;

                    eventsResponseHandler.SetValueAsync(request.Completed().Result, CancellationToken.None);
                }
            });

            Assert.AreEqual(HttpStatusCode.InternalServerError, httpResponseMessage.StatusCode);
            Assert.True(DoesPayloadMatch(Payload.TokenIssuanceStart.NullResponsePayload, httpResponseMessage.Content.ReadAsStringAsync().Result));
        }

        [Test]
        [TestCase(ActionTestTypes.NullClaims)]
        [TestCase(ActionTestTypes.EmptyClaims)]
        [TestCase(ActionTestTypes.NullClaimId)]
        [TestCase(ActionTestTypes.EmptyClaimsId)]
        [TestCase(ActionTestTypes.EmptyValueString)]
        [TestCase(ActionTestTypes.NullValue)]
        [TestCase(ActionTestTypes.EmptyValueArray)]
        [TestCase(ActionTestTypes.EmptyValueStringArray)]
        [TestCase(ActionTestTypes.EmptyMixedArray)]
        [TestCase(ActionTestTypes.NullActionItems)]
        public async Task TokenIssuanceStartActionTest(ActionTestTypes actionTestTypes)
        {
            (TokenIssuanceAction action, HttpStatusCode expectReturnCode, string expectedResponse) = GetActionTestExepected(actionTestTypes);

            HttpResponseMessage httpResponseMessage = await TestHelper.EventResponseBaseTest(eventsResponseHandler =>
            {
                if (eventsResponseHandler.Request is TokenIssuanceStartRequest request)
                {
                    request.Response.Actions.Add(action);

                    eventsResponseHandler.SetValueAsync(request.Completed().Result, CancellationToken.None);
                }
            });

            Assert.AreEqual(httpResponseMessage.StatusCode, expectReturnCode);
            Assert.True(TestHelper.DoesPayloadMatch(expectedResponse, httpResponseMessage.Content.ReadAsStringAsync().Result));
        }
    }
}
