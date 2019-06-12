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
    }
}
