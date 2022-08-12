using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework;
using System.Net;
using System.Net.Http;
using System.Threading;
using WebJobs.Extensions.AuthenticationEvents.Tests.Payloads.TokenIssuanceStart;
using WebJobs.Extensions.AuthenticationEvents.Tests.Payloads.TokenIssuanceStart.Legacy;
using Xunit;
using static WebJobs.Extensions.AuthenticationEvents.Tests.TestHelper;

namespace WebJobs.Extensions.AuthenticationEvents.Tests
{
    /// <summary>Payload test types</summary>
    public enum TestTypes
    {
        /// <summary>A valid payload</summary>
        Valid,
        /// <summary>A payload with an invalid action</summary>
        InvalidAction,
        /// <summary>No actions supplied payload</summary>
        NoAction,
        /// <summary>An empty return payload</summary>
        Empty,
        /// <summary> A string response that wll be converted to an IActionResult </summary>
        Conversion,
        /// <summary>A valid payload for supported cloud event envolope</summary>
        ValidCloudEvent
    }


    /// <summary>Class to house all payload tests</summary>
    public class PayloadTests
    {
        /// <summary>Tests the specified payload based on TestType</summary>
        /// <param name="testType">Type of the test.</param>
        [Theory]
        [InlineData(TestTypes.Valid)]
        [InlineData(TestTypes.InvalidAction)]
        [InlineData(TestTypes.NoAction)]
        [InlineData(TestTypes.Empty)]
        [InlineData(TestTypes.Conversion)]
        [InlineData(TestTypes.ValidCloudEvent)]
        public async void Tests(TestTypes testType)
        {
            var (payload, expected, expectedStatus) = GetTestData(testType);

            HttpResponseMessage httpResponseMessage = await EventResponseBaseTest(eventsResponseHandler =>
            {
                eventsResponseHandler.SetValueAsync(payload, CancellationToken.None);
            }, testType);

            Assert.Equal(expectedStatus, httpResponseMessage.StatusCode);
            Assert.True(DoesPayloadMatch(expected, httpResponseMessage.Content.ReadAsStringAsync().Result));
        }


        private (string payload, string expected, HttpStatusCode expectedStatus) GetTestData(TestTypes testTypes)
        {
            switch (testTypes)
            {
                case TestTypes.Valid: return (TokenIssuanceStartLegacy.ActionResponse, TokenIssuanceStartLegacy.ExpectedPayload, HttpStatusCode.OK);
                case TestTypes.Conversion: return (TokenIssuanceStart.ConversionPayload, TokenIssuanceStartLegacy.ExpectedPayload, HttpStatusCode.OK);
                case TestTypes.InvalidAction: return (TokenIssuanceStart.InvalidActionResponse, @"{'errors':['The action \'ProvideClaims\' is invalid, please use one of the following actions: \'ProvideClaimsForToken\'']}", HttpStatusCode.BadRequest);
                case TestTypes.NoAction: return (TokenIssuanceStart.NoActionResponse, @"{'errors':['No Actions Found. Please supply atleast one action.']}", HttpStatusCode.BadRequest);
                case TestTypes.Empty: return (string.Empty, @"{'errors':['Return type is invalid, please return either an AuthEventResponse, HttpResponse, HttpResponseMessage or string in your function return.']}", HttpStatusCode.BadRequest);
                case TestTypes.ValidCloudEvent: return (TokenIssuanceStart.ActionResponse, TokenIssuanceStart.ExpectedPayload, HttpStatusCode.OK);
                default: return (string.Empty, string.Empty, HttpStatusCode.NotFound);
            }
        }
    }

    internal class TestAuthResponse : AuthEventResponse
    {
        internal TestAuthResponse(HttpStatusCode code, string content)
            : this(code)
        {
            Content = new StringContent(content);
        }

        internal TestAuthResponse(HttpStatusCode code)
        {
            StatusCode = code;
        }
        internal override void Invalidate()
        { }
    }
}
