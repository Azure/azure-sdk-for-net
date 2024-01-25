using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using static Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests.TestHelper;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests
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
        /// <summary>A valid payload for supported cloud event envelope</summary>
        ValidCloudEvent
    }

    /// <summary>Class to house all payload tests</summary>
    [TestFixture]
    public class PayloadTests
    {
        /// <summary>Tests the specified payload based on TestType</summary>
        /// <param name="testType">Type of the test.</param>
        [Test]
        [TestCase(TestTypes.Valid)]
        [TestCase(TestTypes.InvalidAction)]
        [TestCase(TestTypes.NoAction)]
        [TestCase(TestTypes.Empty)]
        [TestCase(TestTypes.Conversion)]
        [TestCase(TestTypes.ValidCloudEvent)]
        public async Task Tests(TestTypes testType)
        {
            var (payload, expected, expectedStatus) = GetTestData(testType);

            HttpResponseMessage httpResponseMessage = await EventResponseBaseTest(eventsResponseHandler =>
            {
                eventsResponseHandler.SetValueAsync(payload, CancellationToken.None);
            });

            Assert.AreEqual(expectedStatus, httpResponseMessage.StatusCode);
            Assert.True(DoesPayloadMatch(expected, httpResponseMessage.Content.ReadAsStringAsync().Result));
        }


        private (string payload, string expected, HttpStatusCode expectedStatus) GetTestData(TestTypes testTypes)
        {
            switch (testTypes)
            {
                case TestTypes.Valid:
                    return (Payloads.TokenIssuanceStart.TokenIssuanceStart.ActionResponse, Payloads.TokenIssuanceStart.TokenIssuanceStart.ExpectedPayload, HttpStatusCode.OK);
                case TestTypes.Conversion:
                    return (Payloads.TokenIssuanceStart.TokenIssuanceStart.ConversionPayload, Payloads.TokenIssuanceStart.TokenIssuanceStart.ExpectedPayload, HttpStatusCode.OK);
                case TestTypes.InvalidAction:
                    return (Payloads.TokenIssuanceStart.TokenIssuanceStart.InvalidActionResponse, @"{'errors':['The action \'ProvideClaims\' is invalid, please use one of the following actions: \'microsoft.graph.tokenissuancestart.provideclaimsfortoken\'']}", HttpStatusCode.InternalServerError);
                case TestTypes.NoAction:
                    return (Payloads.TokenIssuanceStart.TokenIssuanceStart.NoActionResponse, @"{'errors':['No Actions Found. Please supply atleast one action.']}", HttpStatusCode.InternalServerError);
                case TestTypes.Empty:
                    return (string.Empty, @"{'errors':['Return type is invalid, please return either an AuthEventResponse, HttpResponse, HttpResponseMessage or string in your function return: JSON is null or empty.']}", HttpStatusCode.InternalServerError);
                case TestTypes.ValidCloudEvent:
                    return (Payloads.TokenIssuanceStart.TokenIssuanceStart.ActionResponse, Payloads.TokenIssuanceStart.TokenIssuanceStart.ExpectedPayload, HttpStatusCode.OK);
                default:
                    return (string.Empty, string.Empty, HttpStatusCode.NotFound);
            }
        }
    }
}
