// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Secrets.Tests
{
    [NonParallelizable]
    public class SecretClientTests: ClientTestBase
    {
        public SecretClientTests(bool isAsync) : base(isAsync)
        {
            SecretClientOptions options = new SecretClientOptions
            {
                Transport = new MockTransport(),
            };

            Client = InstrumentClient(new SecretClient(new Uri("http://localhost"), new DefaultAzureCredential(), options));
        }

        public SecretClient Client { get; }

        [SetUp]
        public void Setup()
        {
            ChallengeBasedAuthenticationPolicy.ClearCache();
        }

        [TearDown]
        public void TearDown()
        {
            ChallengeBasedAuthenticationPolicy.ClearCache();
        }

        [Test]
        public void ChallengeResourceWithUserInfoIsRejected([Values("resource", "scope")] string parameter)
        {
            string value = "https://resource.example@contoso.test";
            if (parameter == "scope")
            {
                value += "/.default";
            }

            var transport = new MockTransport(new MockResponse(401).WithHeader(
                "WWW-Authenticate",
                $"Bearer authorization=\"https://login.microsoftonline.com/11111111-1111-1111-1111-111111111111\", {parameter}=\"{value}\""));
            int credentialCalls = 0;
            var credential = new MockCredential
            {
                GetTokenCallback = (_, _) => credentialCalls++
            };
            SecretClient client = InstrumentClient(new SecretClient(
                new Uri("https://test.contoso.test"), credential, new SecretClientOptions { Transport = transport }));

            Assert.ThrowsAsync<InvalidOperationException>(async () => await client.GetSecretAsync("test"));
            Assert.That(credentialCalls, Is.Zero);
            Assert.That(transport.Requests.Count, Is.EqualTo(1));
            Assert.That(transport.SingleRequest.Headers.Contains("Authorization"), Is.False);
        }

        [Test]
        public void RedirectDoesNotDiscloseToken(
            [Values(301, 302, 307, 308)] int status,
            [Values(false, true)] bool allowRedirect)
        {
            int credentialCalls = 0;
            var credential = new MockCredential
            {
                GetTokenCallback = (_, _) => credentialCalls++
            };
            int sends = 0;
            var transport = new MockTransport(request =>
            {
                switch (++sends)
                {
                    case 1:
                        Assert.That(request.Uri.Host, Is.EqualTo("redirect.vault.azure.net"));
                        Assert.That(request.Headers.Contains("Authorization"), Is.False);
                        return new MockResponse(401).WithHeader(
                            "WWW-Authenticate",
                            "Bearer authorization=\"https://login.microsoftonline.com/11111111-1111-1111-1111-111111111111\", resource=\"https://vault.azure.net\"");
                    case 2:
                        Assert.That(request.Uri.Host, Is.EqualTo("redirect.vault.azure.net"));
                        Assert.That(request.Headers.Contains("Authorization"), Is.True);
                        return new MockResponse(status).WithHeader("Location", "https://test.contoso.test/secrets/test");
                    case 3:
                        Assert.That(allowRedirect, Is.True);
                        Assert.That(request.Uri.Host, Is.EqualTo("test.contoso.test"));
                        Assert.That(request.Headers.Contains("Authorization"), Is.False);
                        return new MockResponse(401).WithHeader(
                            "WWW-Authenticate",
                            "Bearer authorization=\"https://login.microsoftonline.com/11111111-1111-1111-1111-111111111111\", resource=\"https://resource.example@contoso.test\"");
                    default:
                        throw new AssertionException("A redirected challenge must not result in an authenticated resend.");
                }
            });
            var options = new SecretClientOptions { Transport = transport };
            if (allowRedirect)
            {
                options.AddPolicy(new HttpPipelineSynchronousPolicyForTest(
                    message => RedirectPolicy.SetAllowAutoRedirect(message, true)), HttpPipelinePosition.PerCall);
            }
            SecretClient client = InstrumentClient(new SecretClient(
                new Uri("https://redirect.vault.azure.net"), credential, options));

            if (allowRedirect)
            {
                Assert.ThrowsAsync<InvalidOperationException>(async () => await client.GetSecretAsync("test"));
            }
            else
            {
                RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(
                    async () => await client.GetSecretAsync("test"));
                Assert.That(exception.Status, Is.EqualTo(status));
            }

            Assert.That(sends, Is.EqualTo(allowRedirect ? 3 : 2));
            Assert.That(credentialCalls, Is.EqualTo(1));
        }

        [Test]
        public async Task DisableChallengeResourceVerification_True_AllowsMismatchedChallengeResource()
        {
            Uri vaultUri = new($"https://verification-disabled-{IsAsync}.vault.azure.net");
            var challenge = new MockResponse(401);
            challenge.AddHeader("WWW-Authenticate",
                "Bearer authorization=\"https://login.microsoftonline.com/common\", resource=\"https://attacker.example\"");
            var success = new MockResponse(200).WithJson(
                $@"{{""value"":""v"",""id"":""{vaultUri}secrets/x/1""}}");

            var transport = new MockTransport(challenge, success);
            var options = new SecretClientOptions
            {
                Transport = transport,
                DisableChallengeResourceVerification = true,
            };
            SecretClient client = InstrumentClient(new SecretClient(vaultUri, new MockCredential(), options));

            await client.GetSecretAsync("x");

            Assert.AreEqual(2, transport.Requests.Count);
            Assert.IsTrue(transport.Requests[1].Headers.TryGetValue("Authorization", out string authorization));
            StringAssert.StartsWith("Bearer", authorization);
        }

        private sealed class HttpPipelineSynchronousPolicyForTest : HttpPipelineSynchronousPolicy
        {
            private readonly Action<HttpMessage> _onSend;

            public HttpPipelineSynchronousPolicyForTest(Action<HttpMessage> onSend)
            {
                _onSend = onSend;
            }

            public override void OnSendingRequest(HttpMessage message)
            {
                _onSend(message);
                base.OnSendingRequest(message);
            }
        }

        [Test]
        public void SetArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.SetSecretAsync(null, "value"));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.SetSecretAsync("name", null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.SetSecretAsync(null));

            Assert.ThrowsAsync<ArgumentException>(() => Client.SetSecretAsync("", "value"));
        }

        [Test]
        public void UpdatePropertiesArgumentValidation()
        {
            SecretProperties secret = new SecretProperties("secret-name");
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.UpdateSecretPropertiesAsync(null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.UpdateSecretPropertiesAsync(secret));
        }

        [Test]
        public void RestoreArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RestoreSecretBackupAsync(null));
        }

        [Test]
        public void PurgeDeletedArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.PurgeDeletedSecretAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.PurgeDeletedSecretAsync(""));
        }

        [Test]
        public void GetArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.GetSecretAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.GetSecretAsync(""));
        }

        [Test]
        public void DeleteArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.StartDeleteSecretAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.StartDeleteSecretAsync(""));
        }

        [Test]
        public void GetDeletedArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.GetDeletedSecretAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.GetDeletedSecretAsync(""));
        }

        [Test]
        public void RecoverDeletedArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.StartRecoverDeletedSecretAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.StartRecoverDeletedSecretAsync(""));
        }

        [Test]
        public void GetSecretVersionsArgumentValidation()
        {
            Assert.Throws<ArgumentNullException>(() => Client.GetPropertiesOfSecretVersionsAsync(null));
            Assert.Throws<ArgumentException>(() => Client.GetPropertiesOfSecretVersionsAsync(""));
        }

        [Test]
        public void ChallengeBasedAuthenticationRequiresHttps()
        {
            // After passing parameter validation, ChallengeBasedAuthenticationPolicy should throw for "http" requests.
            Assert.ThrowsAsync<InvalidOperationException>(() => Client.GetSecretAsync("test"));
        }

        [Test]
        public async Task PagesResults()
        {
            MockTransport transport = new(
                new MockResponse(200).WithJson(@"
                {
                    ""value"": [
                        {""id"": ""https://test/secrets/1""},
                        {""id"": ""https://test/secrets/2""}
                    ],
                    ""nextLink"": ""https://test/secrets?$skiptoken=1""
                }"),
                new MockResponse(200).WithJson(@"
                {
                    ""value"": [],
                    ""nextLink"": ""https://test/secrets?$skiptoken=2""
                }"),
                new MockResponse(200).WithJson(@"
                {
                    ""value"": [
                        {""id"": ""https://test/secrets/3""}
                    ]
                }"));

            SecretClient client = InstrumentClient(new SecretClient(new Uri("https://test"), new MockCredential(), new() { Transport = transport }));

            var secrets = await client.GetPropertiesOfSecretsAsync().ToEnumerableAsync();
            Assert.AreEqual(3, secrets.Count);
        }

        [Test]
        public async Task PagesVersionsResults()
        {
            MockTransport transport = new(
                new MockResponse(200).WithJson(@"
                {
                    ""value"": [
                        {""id"": ""https://test/secrets/1/1""},
                        {""id"": ""https://test/secrets/1/2""}
                    ],
                    ""nextLink"": ""https://test/secrets/1/versions?$skiptoken=1""
                }"),
                new MockResponse(200).WithJson(@"
                {
                    ""value"": [],
                    ""nextLink"": ""https://test/secrets/1/versions?$skiptoken=2""
                }"),
                new MockResponse(200).WithJson(@"
                {
                    ""value"": [
                        {""id"": ""https://test/secrets/1/3""}
                    ]
                }"));

            SecretClient client = InstrumentClient(new SecretClient(new Uri("https://test"), new MockCredential(), new() { Transport = transport }));

            var versions = await client.GetPropertiesOfSecretVersionsAsync("1").ToEnumerableAsync();
            Assert.AreEqual(3, versions.Count);
        }

        [Test]
        public async Task PagesDeletedResults()
        {
            MockTransport transport = new(
                new MockResponse(200).WithJson(@"
                {
                    ""value"": [
                        {""id"": ""https://test/secrets/1""},
                        {""id"": ""https://test/secrets/2""}
                    ],
                    ""nextLink"": ""https://test/deletedsecrets?$skiptoken=1""
                }"),
                new MockResponse(200).WithJson(@"
                {
                    ""value"": [],
                    ""nextLink"": ""https://test/deletedsecrets?$skiptoken=2""
                }"),
                new MockResponse(200).WithJson(@"
                {
                    ""value"": [
                        {""id"": ""https://test/secrets/3""}
                    ]
                }"));

            SecretClient client = InstrumentClient(new SecretClient(new Uri("https://test"), new MockCredential(), new() { Transport = transport }));

            var secrets = await client.GetDeletedSecretsAsync().ToEnumerableAsync();
            Assert.AreEqual(3, secrets.Count);
        }
    }
}
