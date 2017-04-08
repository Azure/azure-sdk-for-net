using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;

namespace Network.Tests.Tests
{
    using Microsoft.Azure.Management.Storage.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public class FlowLogTests
    {
        [Fact(Skip = "Test can be run after fixes for this API will be deployed in every region")]
        public void FlowLogApiTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler3 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler4 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);
                var computeManagementClient = NetworkManagementTestUtilities.GetComputeManagementClientWithHandler(context, handler3);
                var storageManagementClient = NetworkManagementTestUtilities.GetStorageManagementClientWithHandler(context, handler4);

                string location = "westcentralus";

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

                FlowLogInformation configParameters = new FlowLogInformation()
                {
                    TargetResourceId = getNsgResponse.Id,
                    Enabled = true,
                    StorageId = storageAccount.Id
                };


                var configureFlowLog1 = networkManagementClient.NetworkWatchers.SetFlowLogConfiguration(resourceGroupName, networkWatcherName, configParameters);

                FlowLogStatusParameters flowLogParameters = new FlowLogStatusParameters()
                {
                    TargetResourceId = getNsgResponse.Id
                };

                var queryFlowLogStatus1 = networkManagementClient.NetworkWatchers.GetFlowLogStatus(resourceGroupName, networkWatcherName, flowLogParameters);

                configParameters.Enabled = false;
                var configureFlowLog2 = networkManagementClient.NetworkWatchers.SetFlowLogConfiguration(resourceGroupName, networkWatcherName, configParameters);
                var queryFlowLogStatus2 = networkManagementClient.NetworkWatchers.GetFlowLogStatus(resourceGroupName, networkWatcherName, flowLogParameters);

                //TO DO: make verification once API is working
            }
        }
    }
}
