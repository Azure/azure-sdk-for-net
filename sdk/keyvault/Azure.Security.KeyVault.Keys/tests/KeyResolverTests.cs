// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Identity;
using Azure.Security.KeyVault.Keys.Cryptography;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class KeyResolverTests
    {
        [Test]
        public void ConstructorArgumentValidation()
        {
            Assert.Throws<ArgumentNullException>(() => new KeyResolver(null));
        }

        [Test]
        public void ResolveArgumentValidation()
        {
            Assert.Throws<ArgumentNullException>(() => new KeyResolver(new DefaultAzureCredential()).Resolve(null));
        }

        [Test]
        public void ResolveAsyncArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => new KeyResolver(new DefaultAzureCredential()).ResolveAsync(null));
        }
    }
}
