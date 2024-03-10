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
    internal class GetAzureExtendedZoneTests : EdgeZonesManagementTestBase
    {
        public GetAzureExtendedZoneTests() : base(true)
        {
        }

        [TestCase, Order(1)]
        [RecordedTest]
        public async Task TestGetAzureExtendedZone()
        {
            var edgezone = await EdgeZonesExtensions.GetAzureExtendedZoneAsync(DefaultSubscription, "losangeles");

            Assert.NotNull(edgezone);
        }
    }
}
