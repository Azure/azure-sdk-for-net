// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Test
{
    public class SecretClientTests
    {
        public SecretClientTests()
        {
            Client = new SecretClient(new Uri("http://localhost"), AzureCredential.Default);
        }

        public SecretClient Client { get; set; }

        [Test]
        public void SetArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.SetAsync(null, "value"));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.SetAsync("name", null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.SetAsync(null));
        }

        [Test]
        public void UpdateArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.UpdateAsync(null));
        }

        [Test]
        public void PurgeDeletedArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.PurgeDeletedAsync(null));
        }

        [Test]
        public void GetArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.GetAsync(null));
        }

        [Test]
        public void DeleteArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.DeleteAsync(null));
        }

        [Test]
        public void GetDeletedArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.GetDeletedAsync(null));
        }

        [Test]
        public void RecoverDeletedArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecoverDeletedAsync(null));
        }

        [Test]
        public void GetAllVersionsArgumentValidation()
        {
            Assert.Throws<ArgumentNullException>(() => Client.GetAllVersionsAsync(null));
        }
    }
}