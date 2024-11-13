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

        protected QuotaManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected QuotaManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
          string ppeEndpointBaseUri = "https://centraluseuap.management.azure.com";

          string defaultSubscriptionId = "65a85478-2333-4bbd-981b-1a818c944faf";

        var options = new ArmClientOptions();
            options.Environment = new ArmEnvironment(new Uri(ppeEndpointBaseUri), "https://management.azure.com/");
            //var rType = Resources.ResourceProviderResource.Get("Microsoft.Quota");
            options.SetApiVersion(new ResourceType("Microsoft.Quota/groupQuotas"), "2024-10-15-preview");
            //Client = GetArmClient();
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client

            Client = new ArmClient(cred, defaultSubscriptionId, options);
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
