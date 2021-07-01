// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    [Parallelizable]
    public class ResourceManagerTestBase : ManagementRecordedTestBase<ResourceManagerTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected ResourceManagerTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected ResourceManagerTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected static GenericResourceData ConstructGenericAvailabilitySet()
        {
            var data = new GenericResourceData();
            data.Location = LocationData.WestUS2;
            data.Sku = new Sku();
            data.Sku.Name = "Aligned";
            var propertyBag = new Dictionary<string, object>();
            propertyBag.Add("platformUpdateDomainCount", 5);
            propertyBag.Add("platformFaultDomainCount", 2);
            data.Properties = propertyBag;
            return data;
        }

        protected async Task<GenericResource> CreateGenericAvailabilitySetAsync(ResourceGroupResourceIdentifier rgId)
        {
            var genericResources = Client.DefaultSubscription.GetGenericResources();
            GenericResourceData data = ConstructGenericAvailabilitySet();
            var asetId = rgId.AppendProviderResource("Microsoft.Compute", "availabilitySets", Recording.GenerateAssetName("test-aset"));
            return await genericResources.CreateOrUpdateAsync(asetId, data);
        }

        protected async Task<ResourcesCreateOrUpdateByIdOperation> StartCreateGenericAvailabilitySetAsync(ResourceGroupResourceIdentifier rgId)
        {
            var genericResources = Client.DefaultSubscription.GetGenericResources();
            GenericResourceData data = ConstructGenericAvailabilitySet();
            var asetId = rgId.AppendProviderResource("Microsoft.Compute", "availabilitySets", Recording.GenerateAssetName("test-aset"));
            return await genericResources.StartCreateOrUpdateAsync(asetId, data);
        }

        protected static void AssertAreEqual(GenericResource aset, GenericResource aset2)
        {
            Assert.AreEqual(aset.Data.Id, aset2.Data.Id);
            Assert.AreEqual(aset.Data.Identity, aset2.Data.Identity);
            Assert.AreEqual(aset.Data.Kind, aset2.Data.Kind);
            Assert.AreEqual(aset.Data.Location, aset2.Data.Location);
            Assert.AreEqual(aset.Data.ManagedBy, aset2.Data.ManagedBy);
            Assert.AreEqual(aset.Data.Name, aset2.Data.Name);
            Assert.AreEqual(aset.Data.Plan, aset2.Data.Plan);
            Assert.AreEqual(aset.Data.Sku, aset2.Data.Sku);
            //TODO: Add equal for Properties and Tags
        }

        protected static async Task<int> GetResourceCountAsync(GenericResourceContainer genericResources, ResourceGroup rg = default)
        {
            int result = 0;
            var pageable = rg == null ? genericResources.ListAsync() : genericResources.ListByResourceGroupAsync(rg.Id.Name);
            await foreach (var resource in pageable)
                result++;
            return result;
        }
    }
}
