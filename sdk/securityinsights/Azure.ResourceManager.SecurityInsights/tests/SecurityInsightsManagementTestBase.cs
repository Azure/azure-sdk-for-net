// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.ResourceManager.OperationalInsights;
using Azure.ResourceManager.OperationalInsights.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityInsights.Tests
{
    public class SecurityInsightsManagementTestBase : ManagementRecordedTestBase<SecurityInsightsManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected AzureLocation DefaultLocation => AzureLocation.EastUS;
        protected string groupName;
        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected SecurityInsightsManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
            IgnoreOperationalInsightsDependencyVersion();
        }

        public ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}";
            return new ResourceIdentifier(resourceId);
        }

        protected SecurityInsightsManagementTestBase(bool isAsync)
            : base(isAsync)
        {
            IgnoreOperationalInsightsDependencyVersion();
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        private void IgnoreOperationalInsightsDependencyVersion()
        {
            UriRegexSanitizers.Add(new UriRegexSanitizer(@"/providers\/Microsoft.OperationalInsights\/(.*?)\?api-version=(?<group>[a-z0-9-]+)")
            {
                GroupForReplace = "group",
                Value = "**"
            });
            UriRegexSanitizers.Add(new UriRegexSanitizer(@"/resourceGroups/")
            {
                Value = "/resourcegroups/"
            });
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            var resourceGroupName = Recording.GenerateAssetName("testRG-");
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
            if (Mode == RecordedTestMode.Playback)
            {
                groupName = resourceGroupName;
            }
            else
            {
                using (Recording.DisableRecording())
                {
                    groupName = rgOp.Value.Data.Name;
                }
            }

            if (Mode == RecordedTestMode.Playback)
            {
                // Existing recordings were captured with an older OperationalInsights client that issued one additional setup request.
                // Keep the deterministic asset-name sequence aligned while matching those recordings against the regenerated client.
                Recording.Random.NewGuid();
            }
            return rgOp.Value;
        }
        #region workspace
        public static OperationalInsightsWorkspaceData GetWorkspaceData()
        {
            var data = new OperationalInsightsWorkspaceData(AzureLocation.WestUS)
            {
                RetentionInDays = 30,
                Sku = new OperationalInsightsWorkspaceSku(OperationalInsightsWorkspaceSkuName.PerNode),
                PublicNetworkAccessForIngestion = OperationalInsightsPublicNetworkAccessType.Enabled,
                PublicNetworkAccessForQuery = OperationalInsightsPublicNetworkAccessType.Enabled,
            };
            return data;
        }

        #endregion
    }
}
