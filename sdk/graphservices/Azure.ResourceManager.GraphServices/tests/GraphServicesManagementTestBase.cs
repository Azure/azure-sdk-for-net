// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.GraphServices.Tests
{
    public class GraphServicesManagementTestBase : ManagementRecordedTestBase<GraphServicesManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected GraphServicesManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected GraphServicesManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        public void CreateCommonClient()
        {
            ArmClientOptions options = new ArmClientOptions();
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
