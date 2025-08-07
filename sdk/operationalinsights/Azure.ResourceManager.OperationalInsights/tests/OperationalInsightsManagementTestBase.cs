// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.OperationalInsights.Tests
{
    public class OperationalInsightsManagementTestBase : ManagementRecordedTestBase<OperationalInsightsManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; set; }
        protected AzureLocation DefaultLocation => AzureLocation.EastUS;

        private const string _rgNamePrefix = "OperationalInsightsRG";

        protected OperationalInsightsManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected OperationalInsightsManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync();
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup()
        {
            string rgName = Recording.GenerateAssetName(_rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(DefaultLocation);
            var lro = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<OperationalInsightsWorkspaceResource> CreateAOIWorkspace(ResourceGroupResource resourceGroup, string workspaceName)
        {
            OperationalInsightsWorkspaceData data = new OperationalInsightsWorkspaceData(resourceGroup.Data.Location)
            {
            };
            var workspaceLro = await resourceGroup.GetOperationalInsightsWorkspaces().CreateOrUpdateAsync(WaitUntil.Completed, workspaceName, data);
            return workspaceLro.Value;
        }
    }
}
