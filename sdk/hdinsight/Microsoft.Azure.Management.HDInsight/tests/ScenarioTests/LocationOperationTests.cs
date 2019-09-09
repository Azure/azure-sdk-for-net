// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.HDInsight;
using Xunit;

namespace Management.HDInsight.Tests
{
    public class LocationOperationTests : HDInsightManagementTestBase
    {
        protected override void CreateResources()
        {
        }

        [Fact]
        public void TestGetUsages()
        {
            TestInitialize();

            var usages = HDInsightClient.Locations.ListUsages(CommonData.Location);
            Assert.NotNull(usages);
            Assert.NotNull(usages.Value);
            foreach (var usage in usages.Value)
            {
                Assert.NotNull(usage);
                Assert.NotNull(usage.CurrentValue);
                Assert.NotNull(usage.Limit);
                Assert.NotNull(usage.Name);
                Assert.NotNull(usage.Unit);
            }
        }

        [Fact]
        public void TestGetCapabilities()
        {
            TestInitialize();

            var capabilitiesResult = HDInsightClient.Locations.GetCapabilities(CommonData.Location);
            Assert.NotNull(capabilitiesResult);
            Assert.NotNull(capabilitiesResult.Features);
            Assert.NotNull(capabilitiesResult.Quota);
            Assert.NotNull(capabilitiesResult.Regions);
            Assert.NotNull(capabilitiesResult.Versions);
            Assert.NotNull(capabilitiesResult.VmSizeFilters);
            Assert.NotNull(capabilitiesResult.VmSizes);

            foreach (var feature in capabilitiesResult.Features)
            {
                Assert.NotNull(feature);
            }

            foreach (var regionQuota in capabilitiesResult.Quota.RegionalQuotas)
            {
                Assert.NotNull(regionQuota);
            }

            foreach (var region in capabilitiesResult.Regions.Keys)
            {
                Assert.NotNull(capabilitiesResult.Regions[region]);
            }

            foreach (var platform in capabilitiesResult.Versions.Keys)
            {
                Assert.NotNull(capabilitiesResult.Versions[platform]);
            }

            foreach (var filter in capabilitiesResult.VmSizeFilters)
            {
                Assert.NotNull(filter);
            }

            foreach (var platform in capabilitiesResult.VmSizes.Keys)
            {
                Assert.NotNull(capabilitiesResult.VmSizes[platform]);
            }
        }
    }
}
