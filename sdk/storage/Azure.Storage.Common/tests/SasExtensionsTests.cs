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
            Assert.IsTrue(services.HasFlag(AccountSasServices.Blobs));
            Assert.IsTrue(services.HasFlag(AccountSasServices.Files));
            Assert.IsTrue(services.HasFlag(AccountSasServices.Queues));
            Assert.IsTrue(services.HasFlag(AccountSasServices.Tables));
            Assert.AreEqual(services.ToPermissionsString(), "bfqt");
        }
    }
}
