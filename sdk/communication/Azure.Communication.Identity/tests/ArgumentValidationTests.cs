// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Identity.Tests
{
    /// <summary>
    /// Asserts that a null argument fails client-side with ArgumentNullException rather than
    /// travelling to the service and returning a 400.
    ///
    /// AutoRest emitted these guards into the generated rest client; the DPG emitter does not,
    /// so they now live in the convenience layer. Nothing else in CI sees this: the signatures
    /// are unchanged, so ApiCompat and the API listing both stay green, and a header or body
    /// comparison cannot observe a request that should never have been sent at all. Only the
    /// live suite caught the regression, and it caught it after the fact.
    /// </summary>
    public class ArgumentValidationTests
    {
        private const string CreatePayload = "{\"identity\":{\"id\":\"8:acs:probe\"},\"accessToken\":{\"token\":\"T\",\"expiresOn\":\"2030-01-01T00:00:00.0000000+00:00\"}}";

        private static readonly CommunicationUserIdentifier User = new CommunicationUserIdentifier("8:acs:probe");

        private static (CommunicationIdentityClient Client, List<string> Sent) Probe(int status, string payload)
        {
            var sent = new List<string>();
            var transport = new MockTransport(request =>
            {
                sent.Add(request.Uri.ToString());
                var r = new MockResponse(status);
                r.SetContent(payload);
                return r;
            });

            var options = new CommunicationIdentityClientOptions { Transport = transport };
            var client = new CommunicationIdentityClient(
                new Uri("https://contoso.communication.azure.com"),
                new AzureKeyCredential(Convert.ToBase64String(Encoding.UTF8.GetBytes("probe-key"))),
                options);
            return (client, sent);
        }

        [Test]
        public void GetTokenWithNullScopesThrowsBeforeSending()
        {
            var p = Probe(200, CreatePayload);

            ArgumentNullException? ex = Assert.Throws<ArgumentNullException>(
                () => p.Client.GetToken(User, scopes: null!));

            Assert.That(ex!.ParamName, Is.EqualTo("scopes"));
            Assert.That(p.Sent, Is.Empty, "a request must not reach the service when scopes is null");
        }

        [Test]
        public void GetTokenAsyncWithNullScopesThrowsBeforeSending()
        {
            var p = Probe(200, CreatePayload);

            ArgumentNullException? ex = Assert.ThrowsAsync<ArgumentNullException>(
                async () => await p.Client.GetTokenAsync(User, scopes: null!));

            Assert.That(ex!.ParamName, Is.EqualTo("scopes"));
            Assert.That(p.Sent, Is.Empty);
        }

        // The parameter names are the ones the AutoRest client reported, so callers that catch
        // ArgumentNullException and inspect ParamName see no change across the migration.
        [TestCase(null, "b", "c", "token")]
        [TestCase("a", null, "c", "appId")]
        [TestCase("a", "b", null, "userId")]
        [TestCase(null, null, null, "token")]
        public void GetTokenForTeamsUserWithNullOptionThrowsBeforeSending(string? token, string? appId, string? userId, string expected)
        {
            var p = Probe(200, CreatePayload);

            ArgumentNullException? ex = Assert.Throws<ArgumentNullException>(
                () => p.Client.GetTokenForTeamsUser(new GetTokenForTeamsUserOptions(token!, appId!, userId!)));

            Assert.That(ex!.ParamName, Is.EqualTo(expected));
            Assert.That(p.Sent, Is.Empty);
        }

        [TestCase(null, "b", "c", "token")]
        [TestCase("a", null, "c", "appId")]
        [TestCase("a", "b", null, "userId")]
        [TestCase(null, null, null, "token")]
        public void GetTokenForTeamsUserAsyncWithNullOptionThrowsBeforeSending(string? token, string? appId, string? userId, string expected)
        {
            var p = Probe(200, CreatePayload);

            ArgumentNullException? ex = Assert.ThrowsAsync<ArgumentNullException>(
                async () => await p.Client.GetTokenForTeamsUserAsync(new GetTokenForTeamsUserOptions(token!, appId!, userId!)));

            Assert.That(ex!.ParamName, Is.EqualTo(expected));
            Assert.That(p.Sent, Is.Empty);
        }

        /// <summary>
        /// Control, and a deliberate asymmetry. The AutoRest client emitted no guard on the create
        /// operation, so CreateUserAndToken(null) sent a request with an empty scope list rather
        /// than throwing. Adding a guard here would be a new break, not a fix, so this test exists
        /// to stop one being added.
        /// </summary>
        [Test]
        public void CreateUserAndTokenWithNullScopesStillSendsARequest()
        {
            var p = Probe(201, CreatePayload);

            Assert.DoesNotThrow(() => p.Client.CreateUserAndToken(scopes: null!));
            Assert.That(p.Sent, Has.Count.EqualTo(1), "create must keep its AutoRest behaviour of sending empty scopes");
        }
    }
}
