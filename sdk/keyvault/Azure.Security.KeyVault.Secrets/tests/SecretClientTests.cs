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
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.SetAsync(null, "value"));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.SetAsync("name", null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.SetAsync(null));

            Assert.ThrowsAsync<ArgumentException>(() => Client.SetAsync("", "value"));
        }

        [Test]
        public void UpdatePropertiesArgumentValidation()
        {
            SecretProperties secret = new SecretProperties("secret-name");
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.UpdatePropertiesAsync(null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.UpdatePropertiesAsync(secret));
        }

        [Test]
        public void RestoreArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RestoreAsync(null));
        }

        [Test]
        public void PurgeDeletedArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.PurgeDeletedAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.PurgeDeletedAsync(""));
        }

        [Test]
        public void GetArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.GetAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.GetAsync(""));
        }

        [Test]
        public void DeleteArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.DeleteAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.DeleteAsync(""));
        }

        [Test]
        public void GetDeletedArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.GetDeletedAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.GetDeletedAsync(""));
        }

        [Test]
        public void RecoverDeletedArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecoverDeletedAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.RecoverDeletedAsync(""));
        }

        [Test]
        public void GetSecretVersionsArgumentValidation()
        {
            Assert.Throws<ArgumentNullException>(() => Client.GetSecretVersionsAsync(null));
            Assert.Throws<ArgumentException>(() => Client.GetSecretVersionsAsync(""));
        }
    }
}
