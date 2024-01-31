// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.NetworkAnalytics.Tests.Utilities;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;
using Azure.ResourceManager.NetworkAnalytics.Models;

namespace Azure.ResourceManager.NetworkAnalytics.Tests
{
    public class NetworkAnalyticsManagementTestBase : ManagementRecordedTestBase<NetworkAnalyticsManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected NetworkAnalyticsManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected NetworkAnalyticsManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<DataProductResource> CreateDataProductResource(ResourceGroupResource resourceGroup, string dataProductName)
        {
            var dataProductData = new DataProductData(NetworkAnalyticsManagementUtilities.DefaultResourceLocation)
            {
                Publisher = "Microsoft",
                Product = "MCC",
                MajorVersion = "2.0.0"
            };
            var lro = await resourceGroup.GetDataProducts().CreateOrUpdateAsync(WaitUntil.Completed, dataProductName, dataProductData);
            return lro.Value;
        }
    }
}
