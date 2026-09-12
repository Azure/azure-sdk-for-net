// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Identity.Tests
{
    /// <summary>
    /// Asserts the request headers actually put on the wire.
    ///
    /// Body-level comparison cannot catch a header regression, and the two operations that return
    /// 204 No Content have no recorded session covering them, so a header change on those is
    /// invisible to the recorded suite as well. This is the only check that sees them.
    /// </summary>
    public class RequestHeaderTests
    {
        // Vary per request or per build; excluded from comparison.
        private static readonly HashSet<string> Volatile_ = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "x-ms-client-request-id", "User-Agent", "Date", "Authorization", "traceparent", "x-ms-date",
        };

        private static (CommunicationIdentityClient Client, List<HttpHeader[]> Sent) Probe(int status, string? payload)
        {
            var sent = new List<HttpHeader[]>();
            var transport = new MockTransport(request =>
            {
                sent.Add(request.Headers.Where(h => !Volatile_.Contains(h.Name)).ToArray());
                var r = new MockResponse(status);
                if (payload != null) { r.SetContent(payload); }
                return r;
            });

            var options = new CommunicationIdentityClientOptions { Transport = transport };
            var client = new CommunicationIdentityClient(
                new Uri("https://contoso.communication.azure.com"),
                new AzureKeyCredential(Convert.ToBase64String(Encoding.UTF8.GetBytes("probe-key"))),
                options);
            return (client, sent);
        }

        private const string CreatePayload = "{\"identity\":{\"id\":\"8:acs:probe\"},\"accessToken\":{\"token\":\"T\",\"expiresOn\":\"2030-01-01T00:00:00.0000000+00:00\"}}";
        private const string TokenPayload = "{\"token\":\"T\",\"expiresOn\":\"2030-01-01T00:00:00.0000000+00:00\"}";

        private static async Task<HttpHeader[]> Send(Func<CommunicationIdentityClient, Task> act, int status, string? payload)
        {
            var p = Probe(status, payload);
            try { await act(p.Client).ConfigureAwait(false); } catch { }
            Assert.That(p.Sent, Is.Not.Empty, "no request reached the transport");
            return p.Sent[0];
        }

        private static string? Value(HttpHeader[] headers, string name)
            => headers.Where(h => string.Equals(h.Name, name, StringComparison.OrdinalIgnoreCase))
                      .Select(h => h.Value)
                      .FirstOrDefault();

        private static CommunicationUserIdentifier User => new CommunicationUserIdentifier("8:acs:probe");
        private static CommunicationTokenScope[] Scopes => new[] { CommunicationTokenScope.Chat };

        private static IEnumerable<TestCaseData> BodyOperations()
        {
            yield return new TestCaseData((Func<CommunicationIdentityClient, Task>)(c => c.CreateUserAsync()), 201, CreatePayload).SetName("CreateUser");
            yield return new TestCaseData((Func<CommunicationIdentityClient, Task>)(c => c.CreateUserAndTokenAsync(Scopes)), 201, CreatePayload).SetName("CreateUserAndToken");
            yield return new TestCaseData((Func<CommunicationIdentityClient, Task>)(c => c.CreateUserAndTokenAsync(Scopes, TimeSpan.FromHours(2))), 201, CreatePayload).SetName("CreateUserAndToken_Expiry");
            yield return new TestCaseData((Func<CommunicationIdentityClient, Task>)(c => c.GetTokenAsync(User, Scopes)), 200, TokenPayload).SetName("GetToken");
            yield return new TestCaseData((Func<CommunicationIdentityClient, Task>)(c => c.GetTokenAsync(User, Scopes, TimeSpan.FromHours(3))), 200, TokenPayload).SetName("GetToken_Expiry");
            yield return new TestCaseData((Func<CommunicationIdentityClient, Task>)(c => c.GetTokenForTeamsUserAsync(new GetTokenForTeamsUserOptions("a", "b", "c"))), 200, TokenPayload).SetName("GetTokenForTeamsUser");
        }

        private static IEnumerable<TestCaseData> NoContentOperations()
        {
            yield return new TestCaseData((Func<CommunicationIdentityClient, Task>)(c => c.DeleteUserAsync(User)), 204, (string?)null).SetName("DeleteUser");
            yield return new TestCaseData((Func<CommunicationIdentityClient, Task>)(c => c.RevokeTokensAsync(User)), 204, (string?)null).SetName("RevokeTokens");
        }

        /// <summary>Headers every request carries, whatever the operation returns.</summary>
        [TestCaseSource(nameof(BodyOperations))]
        [TestCaseSource(nameof(NoContentOperations))]
        public async Task EveryRequestCarriesTheCommunicationHeaders(Func<CommunicationIdentityClient, Task> act, int status, string? payload)
        {
            HttpHeader[] headers = await Send(act, status, payload);

            Assert.That(Value(headers, "x-ms-content-sha256"), Is.Not.Null.And.Not.Empty,
                "HMAC authentication requires a content digest on every request.");
            Assert.That(Value(headers, "x-ms-return-client-request-id"), Is.EqualTo("true"));
        }

        /// <summary>Every operation negotiates JSON, including the two that return 204.</summary>
        [TestCaseSource(nameof(BodyOperations))]
        [TestCaseSource(nameof(NoContentOperations))]
        public async Task EveryOperationSendsAccept(Func<CommunicationIdentityClient, Task> act, int status, string? payload)
        {
            HttpHeader[] headers = await Send(act, status, payload);

            Assert.That(Value(headers, "Accept"), Is.EqualTo("application/json"),
                "AutoRest sent Accept on every operation. The DPG emitter omits it for no-content " +
                "responses, so DeleteUser and RevokeTokens restore it explicitly.");
        }

        /// <summary>Operations that send a body declare its type.</summary>
        [TestCaseSource(nameof(BodyOperations))]
        public async Task OperationsSendingContentSendContentType(Func<CommunicationIdentityClient, Task> act, int status, string? payload)
        {
            HttpHeader[] headers = await Send(act, status, payload);

            Assert.That(Value(headers, "Content-Type"), Is.EqualTo("application/json"));
        }

        /// <summary>
        /// Restoring a default must not remove the ability to override it. A caller-registered
        /// policy that sets Accept has to reach the wire unchanged, which is what the pre-migration
        /// client did. A fix that writes the header unconditionally passes the tests above and
        /// fails this one.
        /// </summary>
        [TestCaseSource(nameof(NoContentOperations))]
        public async Task CallerSuppliedAcceptIsNotOverwritten(Func<CommunicationIdentityClient, Task> act, int status, string? payload)
        {
            var sent = new List<HttpHeader[]>();
            var transport = new MockTransport(request =>
            {
                sent.Add(request.Headers.ToArray());
                return new MockResponse(status);
            });

            var options = new CommunicationIdentityClientOptions { Transport = transport };
            options.AddPolicy(new SetAcceptPolicy("application/custom"), HttpPipelinePosition.PerCall);

            var client = new CommunicationIdentityClient(
                new Uri("https://contoso.communication.azure.com"),
                new AzureKeyCredential(Convert.ToBase64String(Encoding.UTF8.GetBytes("probe-key"))),
                options);

            try { await act(client).ConfigureAwait(false); } catch { }

            Assert.That(sent, Is.Not.Empty, "no request reached the transport");
            Assert.That(Value(sent[0], "Accept"), Is.EqualTo("application/custom"),
                "a caller-supplied Accept must survive; the restoration only fills in a missing value");
        }

        private sealed class SetAcceptPolicy : HttpPipelineSynchronousPolicy
        {
            private readonly string _value;
            public SetAcceptPolicy(string value) => _value = value;
            public override void OnSendingRequest(HttpMessage message)
                => message.Request.Headers.SetValue("Accept", _value);
        }
    }
}