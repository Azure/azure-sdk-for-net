﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.HybridContainerService.Tests
{
    public class HybridContainerServiceManagementTestBase : ManagementRecordedTestBase<HybridContainerServiceManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource Subscription { get; private set; }
        protected ResourceGroupResource ResourceGroup { get; private set; }
        protected AzureLocation DefaultLocation => AzureLocation.WestEurope;

        protected HybridContainerServiceManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected HybridContainerServiceManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        protected async Task InitializeClient()
        {
            Client = GetArmClient();
            Subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            ResourceGroup = await CreateResourceGroup(Subscription, "hybridaksresgrp-netsdk", DefaultLocation);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgName, AzureLocation location)
        {
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }
    }
}
