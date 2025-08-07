// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Fabric;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using Azure.ResourceManager.Fabric.Models;
using NUnit.Framework;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Azure.ResourceManager.Fabric.Tests.Scenario
{
    public class FabricCapacityTests : FabricManagementTestBase
    {
        private FabricCapacityCollection _fabricCapacityCollection { get => ResourceGroup.GetFabricCapacities(); }

        public FabricCapacityTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<FabricCapacityResource> CreateFabricCapacityAsync(string capacityName)
        {
            var capacityData = new FabricCapacityData(
                DefaultLocation,
                new FabricCapacityProperties(new FabricCapacityAdministration(new[] { "VsavTest@pbiotest.onmicrosoft.com" })),
                new FabricSku() { Name = "F2", Tier = "Fabric" });
            var capacity = await _fabricCapacityCollection.CreateOrUpdateAsync(WaitUntil.Completed, capacityName, capacityData);
            return capacity.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCreateOrUpdate()
        {
            // Act
            var capacityName = "azsdktestcapacity";
            var capacity = await CreateFabricCapacityAsync(capacityName);

            // Assert
            var result = await _fabricCapacityCollection.GetAsync(capacityName);
            Assert.IsNotNull(result?.Value?.Data);
            AssertTrackedResource(capacity.Data, result.Value.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetAsync()
        {
            // Act
            var result = await _fabricCapacityCollection.GetAsync(TestEnvironment.CapacityName);

            // Assert
            Assert.IsNotNull(result?.Value?.Data);
            AssertFabricCapacity(result.Value.Data);
        }

        [TestCase]
        [RecordedTest]
        public void TestGetAsync_NotFound()
        {
            // Act & Assert
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await _fabricCapacityCollection.GetAsync(TestEnvironment.CapacityName + "1"));
            Assert.AreEqual(ex.Status, StatusCodes.Status404NotFound);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCheckNameAvailability_NotAvailable()
        {
            // Act
            var content = new FabricNameAvailabilityContent()
            {
                Name = TestEnvironment.CapacityName,
                ResourceType = ResourceType
            };
            var result = await Subscription.CheckFabricCapacityNameAvailabilityAsync(DefaultLocation, content);

            // Assert
            Assert.IsNotNull(result?.Value);
            Assert.IsFalse(result.Value.IsNameAvailable);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCheckNameAvailability_Available()
        {
            // Act
            var content = new FabricNameAvailabilityContent()
            {
                Name = TestEnvironment.CapacityName + "1",
                ResourceType = ResourceType
            };
            var result = await Subscription.CheckFabricCapacityNameAvailabilityAsync(DefaultLocation, content);

            // Assert
            Assert.IsNotNull(result?.Value);
            Assert.IsTrue(result.Value.IsNameAvailable);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestDelete()
        {
            // Setup
            var capacityName = "azsdktestcapacity";
            var capacity = await CreateFabricCapacityAsync(capacityName);
            Assert.IsTrue(await _fabricCapacityCollection.ExistsAsync(capacityName));

            // Act
            await capacity.DeleteAsync(WaitUntil.Completed);

            // Assert
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await _fabricCapacityCollection.GetAsync(capacityName));
            Assert.AreEqual(ex.Status, StatusCodes.Status404NotFound);
        }

        [TestCase]
        [RecordedTest]
        public void TestListByResourceGroup()
        {
            // Act
            var fabricCapacitiesCollection = ResourceGroup.GetFabricCapacities();
            var fabricCapacities = fabricCapacitiesCollection.GetAllAsync();
            var result = fabricCapacities.ToEnumerableAsync().Result;

            // Assert
            Assert.IsTrue(result.Any(capacity => capacity.Data.Name.Equals(TestEnvironment.CapacityName)));
        }

        [TestCase]
        [RecordedTest]
        public async Task TestListBySubscription()
        {
            // Act
            var fabricCapacities = Subscription.GetFabricCapacitiesAsync();
            var result = await fabricCapacities.ToEnumerableAsync();

            // Assert
            Assert.IsTrue(result.Any(capacity => capacity.Data.Name.Equals(TestEnvironment.CapacityName)));
        }

        [TestCase]
        [RecordedTest]
        public async Task TestListSkus()
        {
            // Act
            var skus = Subscription.GetSkusFabricCapacitiesAsync();
            var result = await skus.ToEnumerableAsync();

            // Assert
            Assert.IsTrue(result.Any(sku => sku.Name.Equals("F2")));
            Assert.IsTrue(result.Any(sku => sku.Name.Equals("F8")));
            Assert.IsTrue(result.Any(sku => sku.Name.Equals("F64")));
            Assert.IsTrue(result.Any(sku => sku.Name.Equals("F128")));
            Assert.IsTrue(result.Any(sku => sku.Name.Equals("F512")));
            Assert.IsTrue(result.All(sku => sku.ResourceType == "Capacities"));
        }

        [TestCase]
        [RecordedTest]
        public async Task TestListSkusForCapacity()
        {
            //Setup
            var fabricCapacities = ResourceGroup.GetFabricCapacities();
            var fabricCapacity = (await fabricCapacities.GetAsync(TestEnvironment.CapacityName)).Value;

            // Act
            var skus = fabricCapacity.GetSkusForCapacityAsync();
            var result = await skus.ToEnumerableAsync();

            // Assert
            Assert.IsTrue(result.Any(sku => sku.Sku.Name.Equals("F2")));
            Assert.IsTrue(result.Any(sku => sku.Sku.Name.Equals("F8")));
            Assert.IsTrue(result.Any(sku => sku.Sku.Name.Equals("F64")));
            Assert.IsTrue(result.Any(sku => sku.Sku.Name.Equals("F128")));
            Assert.IsTrue(result.Any(sku => sku.Sku.Name.Equals("F512")));
            Assert.IsTrue(result.All(sku => sku.ResourceType == ResourceType));
            Assert.IsTrue(result.All(sku => sku.Sku.Tier == FabricSkuTier.Fabric));
        }

        [TestCase]
        [RecordedTest]
        public async Task TestUpdate()
        {
            //Setup
            var fabricCapacities = ResourceGroup.GetFabricCapacities();
            var fabricCapacity = Client.GetFabricCapacityResource(new ResourceIdentifier(TestEnvironment.CapacityId));
            var fabricCapacityPatch = new FabricCapacityPatch()
            {
                Sku = new FabricSku()
                {
                    Name = "F8",
                    Tier = FabricSkuTier.Fabric,
                }
            };

            // Act
            var result = await fabricCapacity.UpdateAsync(WaitUntil.Completed, fabricCapacityPatch);

            // Assert
            Assert.AreEqual(result.Value.Data.Sku.Name, "F8");

            // Revert
            await fabricCapacity.UpdateAsync(WaitUntil.Completed, new FabricCapacityPatch()
            {
                Sku = new FabricSku()
                {
                    Name = "F2",
                    Tier = FabricSkuTier.Fabric,
                }
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestResumeAndSuspend()
        {
            //Setup
            var fabricCapacities = ResourceGroup.GetFabricCapacities();
            var fabricCapacity = (await fabricCapacities.GetAsync(TestEnvironment.CapacityName)).Value;

            // Act
            var suspendResult = await fabricCapacity.SuspendAsync(WaitUntil.Completed);
            fabricCapacity = (await fabricCapacities.GetAsync(TestEnvironment.CapacityName)).Value;
            Assert.AreEqual(fabricCapacity.Data.Properties.State, FabricResourceState.Paused);

            var resumeResult = await fabricCapacity.ResumeAsync(WaitUntil.Completed);
            fabricCapacity = (await fabricCapacities.GetAsync(TestEnvironment.CapacityName)).Value;
            Assert.AreEqual(fabricCapacity.Data.Properties.State, FabricResourceState.Active);
        }

        private void AssertTrackedResource(TrackedResourceData r1, TrackedResourceData r2)
        {
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.ResourceType, r2.ResourceType);
            Assert.AreEqual(r1.Location, r2.Location);
            Assert.AreEqual(r1.Tags, r2.Tags);
        }

        private void AssertFabricCapacity(FabricCapacityData data)
        {
            Assert.AreEqual(data.Name, TestEnvironment.CapacityName);
            Assert.AreEqual(data.Id, TestEnvironment.CapacityId);
            Assert.AreEqual(data.Location.Name, TestEnvironment.CapacityLocation);
            Assert.AreEqual(data.ResourceType, ResourceType);
        }
    }
}
