// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.MobileNetwork.Models;
using Azure.ResourceManager.MobileNetwork.Tests.Utilities;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Azure.ResourceManager.MobileNetwork.Tests
{
    public class MobileNetworkManagementTestBase : ManagementRecordedTestBase<MobileNetworkManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource Subscription { get; private set; }

        protected MobileNetworkManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected MobileNetworkManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            Subscription = await Client.GetDefaultSubscriptionAsync();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<MobileNetworkResource> CreateMobileNetworkResource(ResourceGroupResource resourceGroup, string mobileNetworkName)
        {
            var mobileNetworkData = new MobileNetworkData(MobileNetworkManagementUtilities.DefaultResourceLocation, new MobileNetworkPlmnId("001", "01"));
            var lro = await resourceGroup.GetMobileNetworks().CreateOrUpdateAsync(WaitUntil.Completed, mobileNetworkName, mobileNetworkData);
            return lro.Value;
        }
    }
}
