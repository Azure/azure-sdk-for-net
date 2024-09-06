// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.ComputeFleet.Tests
{
    internal class ComputeFleetCRUDTests : ComputeFleetTestBase
    {
        public ComputeFleetCRUDTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        public async Task TestCreateComputeFleet()
        {
            var computeFleetCollection = await GetComputeFleetCollectionAsync();
            var vnet = await CreateVirtualNetwork();
            var computeFleetName = Recording.GenerateAssetName("testFleetViaSDK-");
            var computeFleetData = GetBasicComputeFleetData(DefaultLocation, computeFleetName, GetSubnetId(vnet));

            // Create the compute fleet
            var createFleetResult = await computeFleetCollection.CreateOrUpdateAsync(WaitUntil.Completed, computeFleetName, computeFleetData);
            Assert.AreEqual(computeFleetName, createFleetResult.Value.Data.Name);
            Assert.AreEqual(DefaultLocation, createFleetResult.Value.Data.Location);

            // Get the compute fleet
            var getComputeFleet = await computeFleetCollection.GetAsync(computeFleetName);
            Assert.AreEqual(computeFleetName, getComputeFleet.Value.Data.Name);

            // Delete the compute fleet
            await createFleetResult.Value.DeleteAsync(WaitUntil.Completed);
        }
    }
}
