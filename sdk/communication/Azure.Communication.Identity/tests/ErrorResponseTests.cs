// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Identity.Tests
{
    /// <summary>
    /// Asserts that an error response surfaces the HTTP status even when the body is not a
    /// CommunicationError envelope.
    ///
    /// The risk is real in other languages: a generated client that eagerly deserializes the error
    /// body into a typed field throws while constructing the error, discarding the status. Gateway
    /// 502s, WAF blocks and throttling pages all return non-envelope bodies, so a caller branching
    /// on ex.Status stops working against infrastructure faults rather than programmer error.
    ///
    /// C# is structurally immune because the generated code never deserializes the error body: it
    /// throws RequestFailedException(response) and lets Azure.Core parse defensively. These tests
    /// exist so that an emitter change to eager deserialization is caught here rather than in
    /// production.
    /// </summary>
    public class ErrorResponseTests
    {
        private static CommunicationIdentityClient Client(int status, string payload, string contentType)
        {
            var transport = new MockTransport(_ =>
            {
                var r = new MockResponse(status);
                if (payload != null) { r.SetContent(payload); }
                if (contentType != null) { r.AddHeader(new Core.HttpHeader("Content-Type", contentType)); }
                return r;
            });

            return new CommunicationIdentityClient(
                new Uri("https://contoso.communication.azure.com"),
                new AzureKeyCredential(Convert.ToBase64String(Encoding.UTF8.GetBytes("k"))),
                new CommunicationIdentityClientOptions { Transport = transport });
        }

        // Bodies that are NOT a CommunicationError envelope. Each must still carry the status.
        [TestCase(502, "<html>Bad Gateway</html>", "text/html", TestName = "Html_gateway_page")]
        [TestCase(429, "<html>Too Many Requests</html>", "text/html", TestName = "Html_throttle_page")]
        [TestCase(500, "{\"message\":\"oops\"}", "application/json", TestName = "Json_but_not_envelope")]
        [TestCase(500, "{\"error\":\"notanobject\"}", "application/json", TestName = "Error_is_a_string")]
        [TestCase(500, "{\"error\":{\"code\":123,\"message\":null}}", "application/json", TestName = "Envelope_wrong_types")]
        [TestCase(500, "{{{not json at all", "application/json", TestName = "Malformed_json")]
        [TestCase(500, "null", "application/json", TestName = "Json_null")]
        [TestCase(500, "[1,2,3]", "application/json", TestName = "Json_array")]
        [TestCase(503, "", null, TestName = "Empty_body")]
        public void NonEnvelopeErrorBodyStillCarriesStatus(int status, string payload, string contentType)
        {
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await Client(status, payload, contentType)
                    .CreateUserAndTokenAsync(new[] { CommunicationTokenScope.Chat }));

            Assert.That(ex!.Status, Is.EqualTo(status));
        }

        [TestCase(502, "<html>Bad Gateway</html>", TestName = "Delete_html_gateway_page")]
        [TestCase(500, "{\"message\":\"oops\"}", TestName = "Delete_json_but_not_envelope")]
        public void NonEnvelopeErrorBodyStillCarriesStatusOnNoContentOperation(int status, string payload)
        {
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await Client(status, payload, "application/json")
                    .DeleteUserAsync(new CommunicationUserIdentifier("8:acs:abc")));

            Assert.That(ex!.Status, Is.EqualTo(status));
        }

        /// <summary>A well-formed envelope must still populate ErrorCode, or the above proves only that nothing parses.</summary>
        [Test]
        public void ProperEnvelopePopulatesErrorCode()
        {
            RequestFailedException? ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await Client(401, "{\"error\":{\"code\":\"Unauthorized\",\"message\":\"no\"}}", "application/json")
                    .CreateUserAndTokenAsync(new[] { CommunicationTokenScope.Chat }));

            Assert.That(ex!.Status, Is.EqualTo(401));
            Assert.That(ex.ErrorCode, Is.EqualTo("Unauthorized"));
        }

        /// <summary>
        /// Control. A success body that cannot be deserialized must throw, proving these tests can
        /// see deserialization faults at all. Without it, the clean results above could equally
        /// mean the body is never read.
        /// </summary>
        [TestCase("{{{not json", TestName = "Control_malformed_success_body")]
        [TestCase("{\"identity\":\"notanobject\"}", TestName = "Control_success_body_wrong_shape")]
        public void MalformedSuccessBodyThrows(string payload)
        {
            Assert.That(
                async () => await Client(201, payload, "application/json")
                    .CreateUserAndTokenAsync(new[] { CommunicationTokenScope.Chat }),
                Throws.Exception,
                "if this does not throw, the success body is not being deserialized and the error-path results above are vacuous");
        }
    }
}
