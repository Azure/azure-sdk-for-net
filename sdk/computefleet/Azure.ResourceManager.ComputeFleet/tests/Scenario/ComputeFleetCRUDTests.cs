// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
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

        // To enable record - set AZURE_TEST_MODE=Record to record the test.
        [TestCase]
        [RecordedTest]
        public async Task TestCreateComputeFleet()
        {
            var computeFleetCollection = await GetComputeFleetCollectionAsync();
            var vnet = await CreateVirtualNetwork();
            var computeFleetName = Recording.GenerateAssetName("testFleetViaSDK-");
            var computeFleetData = GetBasicComputeFleetData(DefaultLocation, computeFleetName, GetSubnetId(vnet));

            // Create the compute fleet
            var createFleetResult = await computeFleetCollection.CreateOrUpdateAsync(WaitUntil.Completed, computeFleetName, computeFleetData);
            Assert.That(createFleetResult.Value.Data.Name, Is.EqualTo(computeFleetName));
            Assert.That(createFleetResult.Value.Data.Location, Is.EqualTo(DefaultLocation));

            // Get the compute fleet
            var getComputeFleet = await computeFleetCollection.GetAsync(computeFleetName);
            Assert.That(getComputeFleet.Value.Data.Name, Is.EqualTo(computeFleetName));

            // Check if Fleet exists.
            var isExists = await computeFleetCollection.ExistsAsync(computeFleetName);
            Assert.That((bool)isExists, Is.True);

            // Delete the compute fleet
            await createFleetResult.Value.DeleteAsync(WaitUntil.Completed);

            // Check if Fleet does not exists.
            isExists = await computeFleetCollection.ExistsAsync(computeFleetName);
            Assert.That((bool)isExists, Is.False);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCreateMultipleComputeFleetsAndCheck()
        {
            Console.WriteLine("Stating Test TestCreateMultipleComputeFleetsAndCheck");
            var computeFleetCollection = await GetComputeFleetCollectionAsync();
            var vnet = await CreateVirtualNetwork();
            var computeFleetName = Recording.GenerateAssetName("testFleetViaSDK-");
            var computeFleetData = GetBasicComputeFleetData(DefaultLocation, computeFleetName, GetSubnetId(vnet));

            // Create the compute fleet
            var createFleetResult = await computeFleetCollection.CreateOrUpdateAsync(WaitUntil.Completed, computeFleetName, computeFleetData);
            Assert.That(createFleetResult.Value.Data.Name, Is.EqualTo(computeFleetName));
            Assert.That(createFleetResult.Value.Data.Location, Is.EqualTo(DefaultLocation));

            // Get the compute fleet
            var getComputeFleet = await computeFleetCollection.GetAsync(computeFleetName);
            Assert.That(getComputeFleet.Value.Data.Name, Is.EqualTo(computeFleetName));

            // Check if Fleet exists.
            var isExists = await computeFleetCollection.ExistsAsync(computeFleetName);
            Assert.That((bool)isExists, Is.True);

            // Create 2nd Fleet
            var computeFleetName2nd = Recording.GenerateAssetName("testFleetViaSDK-", "multi");
            var computeFleetData2nd = GetBasicComputeFleetData(DefaultLocation, computeFleetName2nd, GetSubnetId(vnet));
            var createFleetResult2nd = await computeFleetCollection.CreateOrUpdateAsync(WaitUntil.Completed, computeFleetName2nd, computeFleetData2nd);
            Assert.That(createFleetResult2nd.Value.Data.Name, Is.EqualTo(computeFleetName2nd));
            Assert.That(createFleetResult2nd.Value.Data.Location, Is.EqualTo(DefaultLocation));

            // Check if 2nd Fleet exists.
            isExists = await computeFleetCollection.ExistsAsync(computeFleetName2nd);
            Assert.That((bool)isExists, Is.True);

            var fleet2nd = await computeFleetCollection.GetIfExistsAsync(computeFleetName2nd);
            Assert.NotNull(fleet2nd);

            // Delete the 1st compute fleet
            await createFleetResult.Value.DeleteAsync(WaitUntil.Completed);

            // Check if 1st Fleet does not exists.
            isExists = await computeFleetCollection.ExistsAsync(computeFleetName);
            Assert.That((bool)isExists, Is.False);

            // Delete the 2nd compute fleet
            await createFleetResult2nd.Value.DeleteAsync(WaitUntil.Completed);

            // Check if 2nd Fleet does not exists.
            isExists = await computeFleetCollection.ExistsAsync(computeFleetName2nd);
            Assert.That((bool)isExists, Is.False);
        }
    }
}
