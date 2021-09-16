// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Cdn.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Cdn.Tests
{
    public class CdnManagementTestBase : ManagementRecordedTestBase<CdnManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected CdnManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected CdnManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected async Task<ResourceGroup> CreateResourceGroup(string rgNamePrefix)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData rgData = new ResourceGroupData(Location.WestUS);
            var lro = await Client.DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(rgName, rgData);
            return lro.Value;
        }
        protected static ProfileData CreateProfileData(SkuName skuName) => new ProfileData(Location.WestUS, new Sku { Name = skuName });
    }
}
