// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Quota.Tests
{
    public class QuotaManagementTestBase : ManagementRecordedTestBase<QuotaManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected QuotaManagementTestBase(bool isAsync, ResourceType resourceType, string apiVersion, RecordedTestMode mode)
        : base(isAsync, resourceType, apiVersion, mode)
        {
        }

        protected QuotaManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            var options = new ArmClientOptions();
            Client = GetArmClient(options);
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
