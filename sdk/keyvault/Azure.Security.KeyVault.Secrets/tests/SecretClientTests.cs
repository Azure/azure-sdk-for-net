// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Identity;
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

        public SecretClient Client { get; set; }

        [Test]
        public void SetArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.SetSecretAsync(null, "value"));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.SetSecretAsync("name", null));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.SetSecretAsync(null));

            Assert.ThrowsAsync<ArgumentException>(async () => await Client.SetSecretAsync("", "value"));
        }

        [Test]
        public void UpdatePropertiesArgumentValidation()
        {
            SecretProperties secret = new SecretProperties("secret-name");
            Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.UpdateSecretPropertiesAsync(null));
            Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.UpdateSecretPropertiesAsync(secret));
        }

        [Test]
        public void RestoreArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.RestoreSecretBackupAsync(null));
        }

        [Test]
        public void PurgeDeletedArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.PurgeDeletedSecretAsync(null));
            Assert.ThrowsAsync<ArgumentException>(async () => await Client.PurgeDeletedSecretAsync(""));
        }

        [Test]
        public void GetArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.GetSecretAsync(null));
            Assert.ThrowsAsync<ArgumentException>(async () => await Client.GetSecretAsync(""));
        }

        [Test]
        public void DeleteArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.StartDeleteSecretAsync(null));
            Assert.ThrowsAsync<ArgumentException>(async () => await Client.StartDeleteSecretAsync(""));
        }

        [Test]
        public void GetDeletedArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.GetDeletedSecretAsync(null));
            Assert.ThrowsAsync<ArgumentException>(async () => await Client.GetDeletedSecretAsync(""));
        }

        [Test]
        public void RecoverDeletedArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await Client.StartRecoverDeletedSecretAsync(null));
            Assert.ThrowsAsync<ArgumentException>(async () => await Client.StartRecoverDeletedSecretAsync(""));
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
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Client.GetSecretAsync("test"));
        }
    }
}
