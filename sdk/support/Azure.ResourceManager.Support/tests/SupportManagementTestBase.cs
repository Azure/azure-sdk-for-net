// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Support.Tests
{
    public class SupportManagementTestBase : ManagementRecordedTestBase<SupportManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected TenantResource DefaultTenant { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected SupportManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected SupportManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            var tenants = await Client.GetTenants().GetAllAsync().ToEnumerableAsync();
            DefaultTenant = tenants.FirstOrDefault();
            try
            {
                DefaultSubscription = await Client.GetDefaultSubscriptionAsync();
            }catch (Exception){ } //  bypassing failures for tenant level scenarios
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }
    }
}
