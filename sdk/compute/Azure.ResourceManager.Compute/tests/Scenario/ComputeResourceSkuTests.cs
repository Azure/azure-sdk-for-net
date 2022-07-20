// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class ComputeResourceSkuTests : ComputeTestBase
    {
        public ComputeResourceSkuTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task GetResourceSkus()
        {
            var subscription = await Client.GetDefaultSubscriptionAsync();
            int count = 0;
            await foreach (var resourceSku in subscription.GetComputeResourceSkusAsync(filter: "location eq 'westus'", includeExtendedLocations: "true"))
            {
                count++;
            }

            Assert.Greater(count, 0);
        }
    }
}
