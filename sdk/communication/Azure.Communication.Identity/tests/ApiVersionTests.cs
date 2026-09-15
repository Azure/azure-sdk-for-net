// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Identity.Tests
{
    // Asserts the api-version actually sent on the wire. Body-level comparisons cannot catch a
    // version regression, since api-version is a query parameter and the bodies are unaffected.
    // Uses a mock transport, so it is unaffected by recorded-session sanitizers.
    public class ApiVersionTests
    {
        private static (CommunicationIdentityClient Client, List<string> Uris) Probe(
            CommunicationIdentityClientOptions options)
        {
            var uris = new List<string>();
            var transport = new MockTransport(request =>
            {
                uris.Add(request.Uri.ToString());
                var r = new MockResponse(201);
                r.SetContent("{\"identity\":{\"id\":\"8:acs:probe\"}}");
                return r;
            });

            options.Transport = transport;
            var client = new CommunicationIdentityClient(
                new Uri("https://contoso.communication.azure.com"),
                new AzureKeyCredential(Convert.ToBase64String(Encoding.UTF8.GetBytes("probe-key"))),
                options);

            return (client, uris);
        }

        [Test]
        public async Task DefaultClientSendsCurrentApiVersion()
        {
            var p = Probe(new CommunicationIdentityClientOptions());
            try { await p.Client.CreateUserAsync(); } catch { }

            Assert.That(p.Uris, Is.Not.Empty, "no request was sent");
            Assert.That(p.Uris[0], Does.Contain("api-version=2026-09-23"),
                "A default-constructed client must send the current api-version. A body-level " +
                "comparison cannot catch a regression here, because api-version is a query parameter.");
        }

        [Test]
        public async Task DefaultApiVersionIsSentOnEveryOperation()
        {
            var user = new CommunicationUserIdentifier("8:acs:probe");
            var scopes = new[] { CommunicationTokenScope.Chat };

            foreach (var op in new (string Name, Func<CommunicationIdentityClient, Task> Act)[]
            {
                ("CreateUser", c => c.CreateUserAsync()),
                ("CreateUserAndToken", c => c.CreateUserAndTokenAsync(scopes)),
                ("GetToken", c => c.GetTokenAsync(user, scopes)),
                ("RevokeTokens", c => c.RevokeTokensAsync(user)),
                ("DeleteUser", c => c.DeleteUserAsync(user)),
                ("GetTokenForTeamsUser", c => c.GetTokenForTeamsUserAsync(new GetTokenForTeamsUserOptions("a", "b", "c"))),
            })
            {
                var p = Probe(new CommunicationIdentityClientOptions());
                try { await op.Act(p.Client); } catch { }
                Assert.That(p.Uris, Is.Not.Empty, $"{op.Name}: no request sent");
                Assert.That(p.Uris[0], Does.Contain("api-version=2026-09-23"), $"{op.Name} sent the wrong api-version");
            }
        }

        [Test]
        public async Task ExplicitServiceVersionIsHonoured()
        {
            foreach (var pair in new (CommunicationIdentityClientOptions.ServiceVersion V, string Wire)[]
            {
                (CommunicationIdentityClientOptions.ServiceVersion.V2021_03_07, "2021-03-07"),
                (CommunicationIdentityClientOptions.ServiceVersion.V2022_06_01, "2022-06-01"),
                (CommunicationIdentityClientOptions.ServiceVersion.V2022_10_01, "2022-10-01"),
                (CommunicationIdentityClientOptions.ServiceVersion.V2023_10_01, "2023-10-01"),
                (CommunicationIdentityClientOptions.ServiceVersion.V2026_09_23, "2026-09-23"),
            })
            {
                var p = Probe(new CommunicationIdentityClientOptions(pair.V));
                try { await p.Client.CreateUserAsync(); } catch { }
                Assert.That(p.Uris, Is.Not.Empty, $"{pair.V}: no request sent");
                Assert.That(p.Uris[0], Does.Contain($"api-version={pair.Wire}"),
                    $"{pair.V} must map to api-version={pair.Wire}");
            }
        }
    }
}