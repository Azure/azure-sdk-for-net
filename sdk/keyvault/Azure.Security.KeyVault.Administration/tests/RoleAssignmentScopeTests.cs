// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Threading;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class RoleAssignmentScopeTests
    {
        [Test]
        [TestCase(default(string))]
        [TestCase(default(Uri))]
        public void CtorValidatesArgs(object arg)
        {
            Assert.That(() => new RoleAssignmentScope(default(string)), Throws.ArgumentNullException);
            Assert.That(() => new RoleAssignmentScope(default(Uri)), Throws.ArgumentNullException);

            Assert.That(() => new RoleAssignmentScope("someScope"), Throws.Nothing);
            Assert.That(() => new RoleAssignmentScope(new Uri("https://myvault.vault.azure.net/keys/keyName")), Throws.Nothing);
        }

        [Test]
        [TestCase("https://myvault.vault.azure.net/keys/keyName", "/keys/keyName")]
        [TestCase("https://myvault.vault.azure.net/keys/keyName/78deebed173b48e48f55abf87ed4cf71", "/keys/keyName")]
        [TestCase("https://myvault.vault.azure.net/foo/fooName", "/foo/fooName")]
        public void CtorValidatesArgs(string id, string expectedValue)
        {
            var ras = new RoleAssignmentScope(new Uri(id));
            Assert.That(ras.ToString(), Is.EqualTo(expectedValue));
        }
    }
}
