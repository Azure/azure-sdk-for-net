// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.EdgeZones.Tests.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using Azure.Core.TestFramework;
    using Azure.ResourceManager.EdgeZones.Models;
    using Microsoft.Identity.Client;
    using NUnit.Framework;

    [TestFixture]
    internal class ListAzureExtendedZoneTests : EdgeZonesManagementTestBase
    {
        public ListAzureExtendedZoneTests() : base(true)
        {
        }

        [TestCase, Order(1)]
        [RecordedTest]
        public void TestListAzureExtendedZones()
        {
            var azureExtendedZones = EdgeZonesExtensions.GetAzureExtendedZones(DefaultSubscription);
            Assert.NotNull(azureExtendedZones);
            Assert.IsTrue(azureExtendedZones.Count() >= 1);
        }
    }
}
