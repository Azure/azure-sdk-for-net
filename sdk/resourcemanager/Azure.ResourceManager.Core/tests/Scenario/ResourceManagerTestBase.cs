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
            data.Sku = new Sku("Aligned");
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
    }
}
