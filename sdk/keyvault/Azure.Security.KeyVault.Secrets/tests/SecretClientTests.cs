// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Testing;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Test
{
    public class SecretClientTests: ClientTestBase
    {
        public SecretClientTests(bool isAsync) : base(isAsync)
        {
            Client = InstrumentClient(new SecretClient(new Uri("http://localhost"), new DefaultAzureCredential()));
        }

        public SecretClient Client { get; set; }

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
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RestoreSecretAsync(null));
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
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.DeleteSecretAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.DeleteSecretAsync(""));
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
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecoverDeletedSecretAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.RecoverDeletedSecretAsync(""));
        }

        [Test]
        public void GetSecretVersionsArgumentValidation()
        {
            Assert.Throws<ArgumentNullException>(() => Client.GetSecretVersionsAsync(null));
            Assert.Throws<ArgumentException>(() => Client.GetSecretVersionsAsync(""));
        }
    }
}
