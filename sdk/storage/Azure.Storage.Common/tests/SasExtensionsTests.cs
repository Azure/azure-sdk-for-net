// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Sas;
using NUnit.Framework;

namespace Azure.Storage.Tests
{
    [TestFixture]
    public class SasExtensionsTests
    {
        [Test]
        public void AccountSasPermission_Round_Trip()
        {
            AccountSasServices services = SasExtensions.ParseAccountServices("bfqt");
            Assert.That(services.HasFlag(AccountSasServices.Blobs), Is.True);
            Assert.That(services.HasFlag(AccountSasServices.Files), Is.True);
            Assert.That(services.HasFlag(AccountSasServices.Queues), Is.True);
            Assert.That(services.HasFlag(AccountSasServices.Tables), Is.True);
            Assert.That(services.ToPermissionsString(), Is.EqualTo("bfqt"));
        }
    }
}
