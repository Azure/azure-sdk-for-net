// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class RoleAssignmentScopeTests
    {
        [Test]
        [TestCase(default(string))]
        [TestCase(default(Uri))]
        public void CtorValidatesArgs(object arg)
        {
            Assert.That<KeyVaultRoleScope>(() => new KeyVaultRoleScope(default(string)), Throws.ArgumentNullException);
            Assert.That<KeyVaultRoleScope>(() => new KeyVaultRoleScope(default(Uri)), Throws.ArgumentNullException);

            Assert.That<KeyVaultRoleScope>(() => new KeyVaultRoleScope("someScope"), Throws.Nothing);
            Assert.That<KeyVaultRoleScope>(() => new KeyVaultRoleScope(new Uri("https://myvault.vault.azure.net/keys/keyName")), Throws.Nothing);
        }

        [Test]
        [TestCase("https://myvault.vault.azure.net/keys/keyName", "/keys/keyName")]
        [TestCase("https://myvault.vault.azure.net/keys/keyName/78deebed173b48e48f55abf87ed4cf71", "/keys/keyName")]
        [TestCase("https://myvault.vault.azure.net/foo/fooName", "/foo/fooName")]
        public void CtorValidatesArgs(string id, string expectedValue)
        {
            var ras = new KeyVaultRoleScope(new Uri(id));
            Assert.That(ras.ToString(), Is.EqualTo(expectedValue));
        }
    }
}
