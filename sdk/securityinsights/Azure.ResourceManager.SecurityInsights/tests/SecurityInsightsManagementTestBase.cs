// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using Azure.ResourceManager.OperationalInsights;
using NUnit.Framework;
using System.Threading.Tasks;
using Azure.ResourceManager.OperationalInsights.Models;

namespace Azure.ResourceManager.SecurityInsights.Tests
{
    public class SecurityInsightsManagementTestBase : ManagementRecordedTestBase<SecurityInsightsManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected AzureLocation DefaultLocation => AzureLocation.EastUS;
        protected string groupName;
        protected string workspaceName = "wait to change";
        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected SecurityInsightsManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected SecurityInsightsManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            var resourceGroupName = Recording.GenerateAssetName("testRG-");
            groupName = resourceGroupName;
            var rgOp = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceGroupName,
                new ResourceGroupData(DefaultLocation)
                {
                    Tags =
                    {
                        { "test", "env" }
                    }
                });
            return rgOp.Value;
        }
        #region workspace
        public static WorkspaceData GetWorkspaceData()
        {
            var data = new WorkspaceData(AzureLocation.EastUS)
            {
                RetentionInDays = 30,
                Sku = new OperationalInsights.Models.WorkspaceSku(WorkspaceSkuNameEnum.PerNode),
                PublicNetworkAccessForIngestion = PublicNetworkAccessType.Enabled,
                PublicNetworkAccessForQuery = PublicNetworkAccessType.Enabled,
            };
            return data;
        }
        #endregion
    }
}
