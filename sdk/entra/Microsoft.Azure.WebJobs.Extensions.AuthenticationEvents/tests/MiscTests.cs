
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Actions;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using Xunit;
using payloads = Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests.Payloads.TokenIssuanceStart;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests
{

    /// <summary>Tests the OnTokenIssuanceStart request and response for the csharp object model for version preview_10_01_2021</summary>
    [Obsolete]
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
                        eventsResponseHandler.SetValueAsync(payloads.TokenIssuanceStart.ActionResponse, CancellationToken.None);
                    });

                    Assert.Equal(System.Net.HttpStatusCode.OK, httpResponseMessage.StatusCode);
                    Assert.True(TestHelper.DoesPayloadMatch(payloads.TokenIssuanceStart.ExpectedPayload, httpResponseMessage.Content.ReadAsStringAsync().Result));
                });
        }

        /// <summary>Tests query string parameter conversions.</summary>
        [Fact]
        public void QueryParameterTest()
        {
            TokenIssuanceStartRequest tokenIssuanceStartRequest = new TokenIssuanceStartRequest(new HttpRequestMessage(HttpMethod.Get, "http://test?param1=test1&param2=test2"));
            Assert.True(TestHelper.DoesPayloadMatch(payloads.TokenIssuanceStart.TokenIssuanceStartQueryParameter, tokenIssuanceStartRequest.ToString()));
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
            Assert.True(TestHelper.DoesPayloadMatch(payloads.TokenIssuanceStart.ExpectedPayload, httpResponseMessage.Content.ReadAsStringAsync().Result));
        }


        public enum ActionTestTypes { NullClaims, EmptyClaims, NullClaimId, EmptyClaimsId, EmptyValueString, NullValue, EmptyValueArray, EmptyValueStringArray, EmptyMixedArray }

        [Theory]
        [InlineData(ActionTestTypes.NullClaims)]
        [InlineData(ActionTestTypes.EmptyClaims)]
        [InlineData(ActionTestTypes.NullClaimId)]
        [InlineData(ActionTestTypes.EmptyClaimsId)]
        [InlineData(ActionTestTypes.EmptyValueString)]
        [InlineData(ActionTestTypes.NullValue)]
        [InlineData(ActionTestTypes.EmptyValueArray)]
        [InlineData(ActionTestTypes.EmptyValueStringArray)]
        [InlineData(ActionTestTypes.EmptyMixedArray)]
        public async void TokenIssuanceStartActionTest(ActionTestTypes actionTestTypes)
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

            Assert.Equal(httpResponseMessage.StatusCode, expectReturnCode);
            Assert.True(TestHelper.DoesPayloadMatch(expectedResponse, httpResponseMessage.Content.ReadAsStringAsync().Result));
        }

        public (TokenIssuanceAction action, HttpStatusCode expectReturnCode, string expectedResponse) GetActionTestExepected(ActionTestTypes actionTestTypes)
        {
            switch (actionTestTypes)
            {
                case ActionTestTypes.NullClaims: return (new ProvideClaimsForToken(null), HttpStatusCode.InternalServerError, "{\"errors\":[\"TokenIssuanceStartResponse: ProvideClaimsForToken: The Claims field is required.\"]}");
                case ActionTestTypes.EmptyClaims: return (new ProvideClaimsForToken(), HttpStatusCode.OK, "{\"data\":{\"@odata.type\":\"microsoft.graph.onTokenIssuanceStartResponseData\",\"actions\":[{\"@odata.type\":\"microsoft.graph.provideClaimsForToken\",\"claims\":{}}]}}");
                case ActionTestTypes.NullClaimId: return (new ProvideClaimsForToken(new TokenClaim[] { new TokenClaim(null, string.Empty) }), HttpStatusCode.InternalServerError, "{\"errors\":[\"TokenIssuanceStartResponse: ProvideClaimsForToken: TokenClaim: The Id field is required.\"]}");
                case ActionTestTypes.EmptyClaimsId: return (new ProvideClaimsForToken(new TokenClaim[] { new TokenClaim(String.Empty, string.Empty) }), HttpStatusCode.InternalServerError, "{\"errors\":[\"TokenIssuanceStartResponse: ProvideClaimsForToken: TokenClaim: The Id field is required.\"]}");
                case ActionTestTypes.EmptyValueString: return (new ProvideClaimsForToken(new TokenClaim[] { new TokenClaim("key", string.Empty) }), HttpStatusCode.OK, "{\"data\":{\"@odata.type\":\"microsoft.graph.onTokenIssuanceStartResponseData\",\"actions\":[{\"@odata.type\":\"microsoft.graph.provideClaimsForToken\",\"claims\":{\"key\":\"\"}}]}}");
                case ActionTestTypes.NullValue: return (new ProvideClaimsForToken(new TokenClaim[] { new TokenClaim("key", null) }), HttpStatusCode.OK, "{\"data\":{\"@odata.type\":\"microsoft.graph.onTokenIssuanceStartResponseData\",\"actions\":[{\"@odata.type\":\"microsoft.graph.provideClaimsForToken\",\"claims\":{\"key\":null}}]}}");
                case ActionTestTypes.EmptyValueArray: return (new ProvideClaimsForToken(new TokenClaim[] { new TokenClaim("key", new string[] { }) }), HttpStatusCode.OK, "{\"data\":{\"@odata.type\":\"microsoft.graph.onTokenIssuanceStartResponseData\",\"actions\":[{\"@odata.type\":\"microsoft.graph.provideClaimsForToken\",\"claims\":{\"key\":[]}}]}}");
                case ActionTestTypes.EmptyValueStringArray: return (new ProvideClaimsForToken(new TokenClaim[] { new TokenClaim("key", new string[] { String.Empty, String.Empty }) }), HttpStatusCode.OK, "{\"data\":{\"@odata.type\":\"microsoft.graph.onTokenIssuanceStartResponseData\",\"actions\":[{\"@odata.type\":\"microsoft.graph.provideClaimsForToken\",\"claims\":{\"key\":[\"\",\"\"]}}]}}");
                case ActionTestTypes.EmptyMixedArray: return (new ProvideClaimsForToken(new TokenClaim[] { new TokenClaim("key", new string[] { String.Empty, null, " " }) }), HttpStatusCode.OK, "{\"data\":{\"@odata.type\":\"microsoft.graph.onTokenIssuanceStartResponseData\",\"actions\":[{\"@odata.type\":\"microsoft.graph.provideClaimsForToken\",\"claims\":{\"key\":[\"\",null,\" \"]}}]}}");
                default: return (null, HttpStatusCode.InternalServerError, null);
            }
        }
    }
}
