// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppPlatform.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.ResourceManager.AppPlatform.Tests
{
    public class AppPlatformManagementTestBase : ManagementRecordedTestBase<AppPlatformManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected TenantResource DefaultTenant { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        protected AzureLocation DefaultLocation = AzureLocation.EastUS;
        protected const string DefaultRGNamePrefix = "AppPlatfromRG";

        protected AppPlatformManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected AppPlatformManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            var tenants = await Client.GetTenants().GetAllAsync().ToEnumerableAsync();
            DefaultTenant = tenants.FirstOrDefault();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup()
        {
            string rgName = Recording.GenerateAssetName(DefaultRGNamePrefix);
            ResourceGroupData input = new ResourceGroupData(DefaultLocation);
            var lro = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<AppPlatformServiceResource> CreateAppPlatformService(ResourceGroupResource rg, string serviceName)
        {
            AppPlatformServiceData data = new AppPlatformServiceData(rg.Data.Location)
            {
                Properties = new AppPlatformServiceProperties(),
                Sku = new AppPlatformSku()
                {
                    Name = "S0",
                    Tier = "Standard",
                },
                Tags =
                {
                    ["key1"] = "value1",
                },
            };
            var lro = await rg.GetAppPlatformServices().CreateOrUpdateAsync(WaitUntil.Completed, serviceName, data);
            return lro.Value;
        }
    }
}
