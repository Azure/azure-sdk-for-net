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
        public void TableSasPermission_Does_Not_Throw()
        {
            AccountSasServices services = SasExtensions.ParseAccountServices("bfqt");
            Assert.IsTrue(services.HasFlag(AccountSasServices.Blobs));
            Assert.IsTrue(services.HasFlag(AccountSasServices.Files));
            Assert.IsTrue(services.HasFlag(AccountSasServices.Queues));
            Assert.AreEqual(services.ToPermissionsString(), "bfq"); // tables is not a supported permission, but we shouldn't throw
        }
    }
}
