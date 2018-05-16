using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.Azure.Management.OperationalInsights.Models;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;
using System;

namespace Network.Tests.Tests
{
    using Microsoft.Azure.Management.Storage.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public class FlowLogTests
    {
        [Fact(Skip = "Test can be run after latest SDK for all dependent modules is available")]
        public void FlowLogApiTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler3 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler4 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler5 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);
                var computeManagementClient = NetworkManagementTestUtilities.GetComputeManagementClientWithHandler(context, handler3);
                var storageManagementClient = NetworkManagementTestUtilities.GetStorageManagementClientWithHandler(context, handler4);
                var operationalInsightsManagementClient = NetworkManagementTestUtilities.GetOperationalInsightsManagementClientWithHandler(context, handler5);

                string location = "eastus2euap";
                string workspaceLocation = "East US";

                string resourceGroupName = TestUtilities.GenerateName();
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                //Create network security group
                string networkSecurityGroupName = TestUtilities.GenerateName();

                var networkSecurityGroup = new NetworkSecurityGroup()
                {
                    Location = location,
                };

                // Put Nsg
                var putNsgResponse = networkManagementClient.NetworkSecurityGroups.CreateOrUpdate(resourceGroupName, networkSecurityGroupName, networkSecurityGroup);

                // Get NSG
                var getNsgResponse = networkManagementClient.NetworkSecurityGroups.Get(resourceGroupName, networkSecurityGroupName);

                string networkWatcherName = TestUtilities.GenerateName();
                NetworkWatcher properties = new NetworkWatcher();
                properties.Location = location;

                //Create network Watcher
                var createNetworkWatcher = networkManagementClient.NetworkWatchers.CreateOrUpdate(resourceGroupName, networkWatcherName, properties);

                //Create storage
                string storageName = TestUtilities.GenerateName();

                var storageParameters = new StorageAccountCreateParameters()
                {
                    Location = location,
                    Kind = Kind.Storage,
                    Sku = new Sku
                    {
                        Name = SkuName.StandardLRS
                    }
                };

                var storageAccount = storageManagementClient.StorageAccounts.Create(resourceGroupName, storageName, storageParameters);

                //create workspace
                string workspaceName = TestUtilities.GenerateName();

                var workSpaceParameters = new Workspace()
                {
                    Location = workspaceLocation
                };

                var workspace = operationalInsightsManagementClient.Workspaces.CreateOrUpdate(resourceGroupName, workspaceName, workSpaceParameters);

                FlowLogInformation configParameters = new FlowLogInformation()
                {
                    TargetResourceId = getNsgResponse.Id,
                    Enabled = true,
                    StorageId = storageAccount.Id,
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
                            WorkspaceId = workspace.CustomerId,
                            WorkspaceRegion = workspace.Location,
                            WorkspaceResourceId = workspace.Id
                        }
                    }
                };


                //configure flowlog and TA 
                var configureFlowLog1 = networkManagementClient.NetworkWatchers.SetFlowLogConfiguration(resourceGroupName, networkWatcherName, configParameters);

                FlowLogStatusParameters flowLogParameters = new FlowLogStatusParameters()
                {
                    TargetResourceId = getNsgResponse.Id
                };

                var queryFlowLogStatus1 = networkManagementClient.NetworkWatchers.GetFlowLogStatus(resourceGroupName, networkWatcherName, flowLogParameters);

                //check both flowlog and TA config and enabled status
                Assert.Equal(queryFlowLogStatus1.TargetResourceId, configParameters.TargetResourceId);
                Assert.True(queryFlowLogStatus1.Enabled);
                Assert.Equal(queryFlowLogStatus1.StorageId, configParameters.StorageId);
                Assert.Equal(queryFlowLogStatus1.RetentionPolicy.Days, configParameters.RetentionPolicy.Days);
                Assert.Equal(queryFlowLogStatus1.RetentionPolicy.Enabled, configParameters.RetentionPolicy.Enabled);
                Assert.True(queryFlowLogStatus1.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.Enabled);
                Assert.Equal(queryFlowLogStatus1.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceId,
                    configParameters.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceId);
                Assert.Equal(queryFlowLogStatus1.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceRegion,
                    configParameters.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceRegion);
                Assert.Equal(queryFlowLogStatus1.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceResourceId,
                    configParameters.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.WorkspaceResourceId);

                //disable TA 
                configParameters.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.Enabled = false;
                var configureFlowLog2 = networkManagementClient.NetworkWatchers.SetFlowLogConfiguration(resourceGroupName, networkWatcherName, configParameters);
                var queryFlowLogStatus2 = networkManagementClient.NetworkWatchers.GetFlowLogStatus(resourceGroupName, networkWatcherName, flowLogParameters);

                //check TA disabled and ensure flowlog config is unchanged
                Assert.Equal(queryFlowLogStatus2.TargetResourceId, configParameters.TargetResourceId);
                Assert.True(queryFlowLogStatus2.Enabled);
                Assert.Equal(queryFlowLogStatus2.StorageId, configParameters.StorageId);
                Assert.Equal(queryFlowLogStatus2.RetentionPolicy.Days, configParameters.RetentionPolicy.Days);
                Assert.Equal(queryFlowLogStatus2.RetentionPolicy.Enabled, configParameters.RetentionPolicy.Enabled);
                Assert.False(queryFlowLogStatus2.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.Enabled);

                //disable flowlog (and TA)
                configParameters.Enabled = false;
                var configureFlowLog3 = networkManagementClient.NetworkWatchers.SetFlowLogConfiguration(resourceGroupName, networkWatcherName, configParameters);
                var queryFlowLogStatus3 = networkManagementClient.NetworkWatchers.GetFlowLogStatus(resourceGroupName, networkWatcherName, flowLogParameters);

                //check both flowlog and TA disabled
                Assert.False(queryFlowLogStatus3.Enabled);
                Assert.False(queryFlowLogStatus3.FlowAnalyticsConfiguration.NetworkWatcherFlowAnalyticsConfiguration.Enabled);
            }
        }
    }
}
