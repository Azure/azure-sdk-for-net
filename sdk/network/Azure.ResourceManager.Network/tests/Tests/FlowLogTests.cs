// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if false
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
//using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Network.Tests.Helpers;
using NUnit.Framework;
//using Sku = Azure.ResourceManager.Storage.Models.Sku;

namespace Azure.ResourceManager.Network.Tests
{
    public class FlowLogTests : NetworkServiceClientTestBase
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

        [Test]
        [Ignore("Track2: Need OperationalInsightsManagementClient")]
        public async Task FlowLogApiTest()
        {
            string resourceGroupName = Recording.GenerateAssetName("azsmnet");

            string location = "eastus2euap";
            //string workspaceLocation = "East US";
            var resourceGroup = await CreateResourceGroup(resourceGroupName,location);

            //Create network security group
            string networkSecurityGroupName = Recording.GenerateAssetName("azsmnet");
            var networkSecurityGroup = new NetworkSecurityGroupData() { Location = location, };

            // Put Nsg
            var securityGroupCollection = resourceGroup.GetNetworkSecurityGroups();
            var putNsgResponseOperation = await securityGroupCollection.CreateOrUpdateAsync(true, networkSecurityGroupName, networkSecurityGroup);
            await putNsgResponseOperation.WaitForCompletionAsync();;
            // Get NSG
            Response<NetworkSecurityGroupResource> getNsgResponse = await securityGroupCollection.GetAsync(networkSecurityGroupName);

            string networkWatcherName = Recording.GenerateAssetName("azsmnet");
            var properties = new NetworkWatcherData { Location = location };

            //Create network Watcher
            var networkWatcherCollection = resourceGroup.GetNetworkWatchers();
            await networkWatcherCollection.CreateOrUpdateAsync(true, networkWatcherName, properties);

            //Create storage
            string storageName = Recording.GenerateAssetName("azsmnet");

            //var storageParameters = new StorageAccountCreateParameters(new Sku(SkuName.StandardLRS), Kind.Storage, location);

            //Operation<StorageAccountResource> storageAccountOperation = await StorageManagementClient.StorageAccounts.CreateAsync(resourceGroupName, storageName, storageParameters);
            //Response<StorageAccountResource> storageAccount = await storageAccountOperation.WaitForCompletionAsync();;

            //create workspace
            string workspaceName = Recording.GenerateAssetName("azsmnet");

            //TODO:Need OperationalInsightsManagementClient SDK
            //var workSpaceParameters = new Workspace()
            //{
            //    Location = workspaceLocation
            //};
            //var workspace = operationalInsightsManagementClient.Workspaces.CreateOrUpdate(resourceGroupName, workspaceName, workSpaceParameters);

            //FlowLogInformation configParameters = new FlowLogInformation(getNsgResponse.Value.Id, storageAccount.Value.Id, true)
            //{
            //    RetentionPolicy = new RetentionPolicyParameters
            //    {
            //        Days = 5,
            //        Enabled = true
            //    },
            //    FlowAnalyticsConfiguration = new TrafficAnalyticsProperties()
            //    {
            //        NetworkWatcherFlowAnalyticsConfiguration = new TrafficAnalyticsConfigurationProperties()
            //        {
            //            Enabled = true,
            //            //WorkspaceId = workspace.CustomerId,
            //            //WorkspaceRegion = workspace.Location,
            //            //WorkspaceResourceId = workspace.Id
            //        }
            //    }
            //};

            //configure flowlog and TA
            //var configureFlowLog1Operation = await networkWatcherCollection.Get(networkWatcherName).Value.SetFlowLogConfigurationAsync(configParameters);
            //await configureFlowLog1Operation.WaitForCompletionAsync();;

            //var queryFlowLogStatus1Operation = await networkWatcherCollection.Get(networkWatcherName).Value.GetFlowLogStatusAsync(new FlowLogStatusParameters(getNsgResponse.Value.Id));
            //Response<FlowLogInformation> queryFlowLogStatus1 = await queryFlowLogStatus1Operation.WaitForCompletionAsync();;
            ////check both flowlog and TA config and enabled status
            //Assert.AreEqual(queryFlowLogStatus1.Value.TargetResourceId, configParameters.TargetResourceId);
            //Assert.True(queryFlowLogStatus1.Value.Enabled);
            //Assert.AreEqual(queryFlowLogStatus1.Value.StorageId, configParameters.StorageId);
            //Assert.AreEqual(queryFlowLogStatus1.Value.RetentionPolicy.Days, configParameters.RetentionPolicy.Days);
            //Assert.AreEqual(queryFlowLogStatus1.Value.RetentionPolicy.Enabled, configParameters.RetentionPolicy.Enabled);
            //Assert.True(queryFlowLogStatus1.Value.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.Enabled);
            //Assert.AreEqual(queryFlowLogStatus1.Value.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceId,
            //    configParameters.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceId);
            //Assert.AreEqual(queryFlowLogStatus1.Value.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceRegion,
            //    configParameters.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceRegion);
            //Assert.AreEqual(queryFlowLogStatus1.Value.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceResourceId,
            //    configParameters.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceResourceId);

            ////disable TA
            //configParameters.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.Enabled = false;
            //var configureFlowLog2Operation = await networkWatcherCollection.Get(networkWatcherName).Value.SetFlowLogConfigurationAsync(configParameters);
            //await configureFlowLog2Operation.WaitForCompletionAsync();;

            //var queryFlowLogStatus2Operation = await networkWatcherCollection.Get(networkWatcherName).Value.GetFlowLogStatusAsync(new FlowLogStatusParameters(getNsgResponse.Value.Id));
            //Response<FlowLogInformation> queryFlowLogStatus2 = await queryFlowLogStatus2Operation.WaitForCompletionAsync();;

            ////check TA disabled and ensure flowlog config is unchanged
            //Assert.AreEqual(queryFlowLogStatus2.Value.StorageId, configParameters.StorageId);
            //Assert.AreEqual(queryFlowLogStatus2.Value.RetentionPolicy.Days, configParameters.RetentionPolicy.Days);
            //Assert.AreEqual(queryFlowLogStatus2.Value.RetentionPolicy.Enabled, configParameters.RetentionPolicy.Enabled);
            //Assert.False(queryFlowLogStatus2.Value.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.Enabled);

            ////disable flowlog (and TA)
            //configParameters.Enabled = false;
            //var configureFlowLog3Operation = await networkWatcherCollection.Get(networkWatcherName).Value.SetFlowLogConfigurationAsync(configParameters);
            //await configureFlowLog3Operation.WaitForCompletionAsync();;

            //var queryFlowLogStatus3Operation = await networkWatcherCollection.Get(networkWatcherName).Value.GetFlowLogStatusAsync(new FlowLogStatusParameters(getNsgResponse.Value.Id));
            //Response<FlowLogInformation> queryFlowLogStatus3 = await queryFlowLogStatus3Operation.WaitForCompletionAsync();;

            ////check both flowlog and TA disabled
            //Assert.False(queryFlowLogStatus3.Value.Enabled);
            //Assert.False(queryFlowLogStatus3.Value.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.Enabled);
        }
    }
}
#endif
