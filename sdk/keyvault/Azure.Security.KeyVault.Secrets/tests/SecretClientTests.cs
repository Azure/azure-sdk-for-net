// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Secrets.Tests
{
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
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.PurgeDeletedSecretAsync(null, default(CancellationToken)));
            Assert.ThrowsAsync<ArgumentException>(() => Client.PurgeDeletedSecretAsync("", default(CancellationToken)));
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
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.GetDeletedSecretAsync(null, default(CancellationToken)));
            Assert.ThrowsAsync<ArgumentException>(() => Client.GetDeletedSecretAsync("", default(CancellationToken)));
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

            var secrets = await client.GetDeletedSecretsAsync(default(CancellationToken)).ToEnumerableAsync();
            Assert.AreEqual(3, secrets.Count);
        }
    }
}
