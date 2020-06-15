// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Management.Resources;
using Azure.Management.Resources.Models;
using Azure.Management.Storage.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;
using Sku = Azure.Management.Storage.Models.Sku;

namespace Azure.ResourceManager.Network.Tests.Tests
{
    public class FlowLogTests : NetworkTestsManagementClientBase
    {
        public FlowLogTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        [Ignore("Track2: Need OperationalInsightsManagementClient")]
        public async Task FlowLogApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");

            string location = "eastus2euap";
            //string workspaceLocation = "East US";
            await ResourceGroupsOperations.CreateOrUpdateAsync(resourceGroupName, new ResourceGroup(location));

            //Create network security group
            string networkSecurityGroupName = Recording.GenerateAssetName("azsmnet");
            var networkSecurityGroup = new NetworkSecurityGroup() { Location = location, };

            // Put Nsg
            NetworkSecurityGroupsCreateOrUpdateOperation putNsgResponseOperation = await NetworkManagementClient.NetworkSecurityGroups.StartCreateOrUpdateAsync(resourceGroupName, networkSecurityGroupName, networkSecurityGroup);
            await WaitForCompletionAsync(putNsgResponseOperation);
            // Get NSG
            Response<NetworkSecurityGroup> getNsgResponse = await NetworkManagementClient.NetworkSecurityGroups.GetAsync(resourceGroupName, networkSecurityGroupName);

            string networkWatcherName = Recording.GenerateAssetName("azsmnet");
            NetworkWatcher properties = new NetworkWatcher { Location = location };

            //Create network Watcher
            await NetworkManagementClient.NetworkWatchers.CreateOrUpdateAsync(resourceGroupName, networkWatcherName, properties);

            //Create storage
            string storageName = Recording.GenerateAssetName("azsmnet");

            var storageParameters = new StorageAccountCreateParameters(new Sku(SkuName.StandardLRS), Kind.Storage, location);

            Operation<StorageAccount> storageAccountOperation = await StorageManagementClient.StorageAccounts.StartCreateAsync(resourceGroupName, storageName, storageParameters);
            Response<StorageAccount> storageAccount = await WaitForCompletionAsync(storageAccountOperation);

            //create workspace
            string workspaceName = Recording.GenerateAssetName("azsmnet");

            //TODO:Need OperationalInsightsManagementClient SDK
            //var workSpaceParameters = new Workspace()
            //{
            //    Location = workspaceLocation
            //};
            //var workspace = operationalInsightsManagementClient.Workspaces.CreateOrUpdate(resourceGroupName, workspaceName, workSpaceParameters);

            FlowLogInformation configParameters = new FlowLogInformation(getNsgResponse.Value.Id, storageAccount.Value.Id, true)
            {
                RetentionPolicy = new RetentionPolicyParameters
                {
                    Days = 5,
                    Enabled = true
                },
                FlowAnalyticsConfiguration = new TrafficAnalyticsProperties()
                {
                    NetworkWatcherFlowAnalyticsConfiguration = new TrafficAnalyticsConfigurationProperties()
                    {
                        Enabled = true,
                        //WorkspaceId = workspace.CustomerId,
                        //WorkspaceRegion = workspace.Location,
                        //WorkspaceResourceId = workspace.Id
                    }
                }
            };

            //configure flowlog and TA
            NetworkWatchersSetFlowLogConfigurationOperation configureFlowLog1Operation = await NetworkManagementClient.NetworkWatchers.StartSetFlowLogConfigurationAsync(resourceGroupName, networkWatcherName, configParameters);
            await WaitForCompletionAsync(configureFlowLog1Operation);
            FlowLogStatusParameters flowLogParameters = new FlowLogStatusParameters(getNsgResponse.Value.Id);

            NetworkWatchersGetFlowLogStatusOperation queryFlowLogStatus1Operation = await NetworkManagementClient.NetworkWatchers.StartGetFlowLogStatusAsync(resourceGroupName, networkWatcherName, flowLogParameters);
            Response<FlowLogInformation> queryFlowLogStatus1 = await WaitForCompletionAsync(queryFlowLogStatus1Operation);
            //check both flowlog and TA config and enabled status
            Assert.AreEqual(queryFlowLogStatus1.Value.TargetResourceId, configParameters.TargetResourceId);
            Assert.True(queryFlowLogStatus1.Value.Enabled);
            Assert.AreEqual(queryFlowLogStatus1.Value.StorageId, configParameters.StorageId);
            Assert.AreEqual(queryFlowLogStatus1.Value.RetentionPolicy.Days, configParameters.RetentionPolicy.Days);
            Assert.AreEqual(queryFlowLogStatus1.Value.RetentionPolicy.Enabled, configParameters.RetentionPolicy.Enabled);
            Assert.True(queryFlowLogStatus1.Value.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.Enabled);
            Assert.AreEqual(queryFlowLogStatus1.Value.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceId,
                configParameters.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceId);
            Assert.AreEqual(queryFlowLogStatus1.Value.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceRegion,
                configParameters.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceRegion);
            Assert.AreEqual(queryFlowLogStatus1.Value.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceResourceId,
                configParameters.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceResourceId);

            //disable TA
            configParameters.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.Enabled = false;
            NetworkWatchersSetFlowLogConfigurationOperation configureFlowLog2Operation = await NetworkManagementClient.NetworkWatchers.StartSetFlowLogConfigurationAsync(resourceGroupName, networkWatcherName, configParameters);
            await WaitForCompletionAsync(configureFlowLog2Operation);

            NetworkWatchersGetFlowLogStatusOperation queryFlowLogStatus2Operation = await NetworkManagementClient.NetworkWatchers.StartGetFlowLogStatusAsync(resourceGroupName, networkWatcherName, flowLogParameters);
            Response<FlowLogInformation> queryFlowLogStatus2 = await WaitForCompletionAsync(queryFlowLogStatus2Operation);

            //check TA disabled and ensure flowlog config is unchanged
            Assert.AreEqual(queryFlowLogStatus2.Value.TargetResourceId, configParameters.TargetResourceId);
            Assert.True(queryFlowLogStatus2.Value.Enabled);
            Assert.AreEqual(queryFlowLogStatus2.Value.StorageId, configParameters.StorageId);
            Assert.AreEqual(queryFlowLogStatus2.Value.RetentionPolicy.Days, configParameters.RetentionPolicy.Days);
            Assert.AreEqual(queryFlowLogStatus2.Value.RetentionPolicy.Enabled, configParameters.RetentionPolicy.Enabled);
            Assert.False(queryFlowLogStatus2.Value.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.Enabled);

            //disable flowlog (and TA)
            configParameters.Enabled = false;
            NetworkWatchersSetFlowLogConfigurationOperation configureFlowLog3Operation = await NetworkManagementClient.NetworkWatchers.StartSetFlowLogConfigurationAsync(resourceGroupName, networkWatcherName, configParameters);
            await WaitForCompletionAsync(configureFlowLog3Operation);

            NetworkWatchersGetFlowLogStatusOperation queryFlowLogStatus3Operation = await NetworkManagementClient.NetworkWatchers.StartGetFlowLogStatusAsync(resourceGroupName, networkWatcherName, flowLogParameters);
            Response<FlowLogInformation> queryFlowLogStatus3 = await WaitForCompletionAsync(queryFlowLogStatus3Operation);

            //check both flowlog and TA disabled
            Assert.False(queryFlowLogStatus3.Value.Enabled);
            Assert.False(queryFlowLogStatus3.Value.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.Enabled);
        }
    }
}
