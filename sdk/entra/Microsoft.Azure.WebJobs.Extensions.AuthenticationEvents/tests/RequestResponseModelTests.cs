
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart;
using NUnit.Framework;
using static Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests.TestHelper;
using Payload = Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests.Payloads.TokenIssuanceStart;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests
{

    /// <summary>Tests the OnTokenIssuanceStart request and response for the csharp object model for version preview_10_01_2021</summary>
    [TestFixture]
    public class RequestResponseModelTests
    {
        /// <summary>Runs 10000 calls to the library concurrently with success payload and response</summary>
        [Test]
        public void ConcurrencyTest()
        {
            for (int i = 0; i < 10000; i++)
                ThreadPool.QueueUserWorkItem(async w =>
                {
                    HttpResponseMessage httpResponseMessage = await EventResponseBaseTest(async eventsResponseHandler =>
                    {
                        await eventsResponseHandler.SetValueAsync(Payload.TokenIssuanceStart.ActionResponse, CancellationToken.None);
                    });

                    Assert.AreEqual(HttpStatusCode.OK, httpResponseMessage.StatusCode);
                    Assert.True(DoesPayloadMatch(Payload.TokenIssuanceStart.ExpectedPayload, await httpResponseMessage.Content.ReadAsStringAsync()));
                });
        }

        /// <summary>Tests query string parameter conversions.</summary>
        [Test]
        public void QueryParameterTest()
        {
            WebJobsTokenIssuanceStartRequest tokenIssuanceStartRequest = new WebJobsTokenIssuanceStartRequest(new HttpRequestMessage(HttpMethod.Get, "http://test?param1=test1&param2=test2"));
            Assert.True(DoesPayloadMatch(Payload.TokenIssuanceStart.TokenIssuanceStartQueryParameter, tokenIssuanceStartRequest.ToString()));
        }

        /// <summary>Tests the OnTokenIssuanceStart request and response object model for CSharp for version: 10_01_2021</summary>
        [Test]
        public async Task TokenIssuanceStartObjectModelTest()
        {
            HttpResponseMessage httpResponseMessage = await EventResponseBaseTest(async eventsResponseHandler =>
            {
                if (eventsResponseHandler.Request is WebJobsTokenIssuanceStartRequest request)
                {
                    request.Response.Actions.Add(
                        new WebJobsProvideClaimsForToken(
                            new WebJobsAuthenticationEventsTokenClaim("DateOfBirth", "01/01/2000"),
                            new WebJobsAuthenticationEventsTokenClaim("CustomRoles", "Writer", "Editor")
                            ));

                    await eventsResponseHandler.SetValueAsync(request.Completed(), CancellationToken.None);
                }
            });

            Assert.AreEqual(HttpStatusCode.OK, httpResponseMessage.StatusCode);
            Assert.True(DoesPayloadMatch(Payload.TokenIssuanceStart.ExpectedPayload, await httpResponseMessage.Content.ReadAsStringAsync()));
        }

        /// <summary>Test the request object to verify the correct HttpStatusCode is respond</summary>
        [Test]
        [TestCase(WebJobsAuthenticationEventsRequestStatusType.Successful, HttpStatusCode.OK, "OK")]
        [TestCase(WebJobsAuthenticationEventsRequestStatusType.Failed, HttpStatusCode.BadRequest, "Bad Request")]
        [TestCase(WebJobsAuthenticationEventsRequestStatusType.ValidationError, HttpStatusCode.BadRequest, "Bad Request")]
        [TestCase(WebJobsAuthenticationEventsRequestStatusType.TokenInvalid, HttpStatusCode.Unauthorized, "Unauthorized")]
        public async Task TokenIssuanceStartRequestValidationTest(WebJobsAuthenticationEventsRequestStatusType requestStatusType, HttpStatusCode httpStatusCode, string reasonPhrase)
        {
            HttpResponseMessage httpResponseMessage = await EventResponseBaseTest(async eventsResponseHandler =>
            {
                if (eventsResponseHandler.Request is WebJobsTokenIssuanceStartRequest request)
                {
                    request.Response.Actions.Add(
                        new WebJobsProvideClaimsForToken(
                            new WebJobsAuthenticationEventsTokenClaim("DateOfBirth", "01/01/2000"),
                            new WebJobsAuthenticationEventsTokenClaim("CustomRoles", "Writer", "Editor")
                            ));

                    // set the request status type
                    request.RequestStatus = requestStatusType;
                    await eventsResponseHandler.SetValueAsync(request.Completed(), CancellationToken.None);
                }
            });

            Assert.AreEqual(httpStatusCode, httpResponseMessage.StatusCode);
            Assert.AreEqual(reasonPhrase, httpResponseMessage.ReasonPhrase);
        }

        /// <summary>Tests the OnTokenIssuanceStart request and response object model when the response is set to null</summary>
        [Test]
        [Description("Tests the OnTokenIssuanceStart request and response object model when the response is set to null")]
        public async Task TokenIssuanceStartObjectModelNullResponseTest()
        {
            HttpResponseMessage httpResponseMessage = await EventResponseBaseTest(async eventsResponseHandler =>
            {
                if (eventsResponseHandler.Request is WebJobsTokenIssuanceStartRequest request)
                {
                    request.Response = null;

                    await eventsResponseHandler.SetValueAsync(request.Completed(), CancellationToken.None);
                }
            });

            Assert.AreEqual(HttpStatusCode.InternalServerError, httpResponseMessage.StatusCode);
            Assert.True(DoesPayloadMatch(Payload.TokenIssuanceStart.NullResponsePayload, await httpResponseMessage.Content.ReadAsStringAsync()));
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
            (WebJobsTokenIssuanceAction action, HttpStatusCode expectReturnCode, string expectedResponse) = GetActionTestExepected(actionTestTypes);

            HttpResponseMessage httpResponseMessage = await EventResponseBaseTest(async eventsResponseHandler =>
            {
                if (eventsResponseHandler.Request is WebJobsTokenIssuanceStartRequest request)
                {
                    request.Response.Actions.Add(action);

                    await eventsResponseHandler.SetValueAsync(request.Completed(), CancellationToken.None);
                }
            });

            Assert.AreEqual(httpResponseMessage.StatusCode, expectReturnCode);
            Assert.True(DoesPayloadMatch(expectedResponse, await httpResponseMessage.Content.ReadAsStringAsync()));
        }
    }
}
