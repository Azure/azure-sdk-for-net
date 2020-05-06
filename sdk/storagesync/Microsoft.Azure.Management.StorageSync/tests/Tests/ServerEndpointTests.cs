using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Management.StorageSync.Models;
using Microsoft.Azure.Management.Tests.Common;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Net;
using Xunit;
using System.Linq;
using System;

namespace Microsoft.Azure.Management.StorageSync.Tests
{
    public class ServerEndpointTests
    {
        [Fact]
        public void ServerEndpointAllOperationsTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                IResourceManagementClient resourcesClient = StorageSyncManagementTestUtilities.GetResourceManagementClient(context, handler);
                IStorageSyncManagementClient storageSyncManagementClient = StorageSyncManagementTestUtilities.GetStorageSyncManagementClient(context, handler);

                // Create ResourceGroup
                string resourceGroupName = StorageSyncManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create ServerEndpoint
                string storageSyncServiceName = TestUtilities.GenerateName("sss-sepall");
                string syncGroupName = TestUtilities.GenerateName("sg-sepall");
                string resourceName = TestUtilities.GenerateName("sepall");

                var storageSyncServiceParameters = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceParameters();
                var syncGroupParameters = StorageSyncManagementTestUtilities.GetDefaultSyncGroupParameters();
                var cloudEndpointParameters = StorageSyncManagementTestUtilities.GetDefaultCloudEndpointParameters();

                StorageSyncService storageSyncServiceResource = storageSyncManagementClient.StorageSyncServices.Create(resourceGroupName, storageSyncServiceName, storageSyncServiceParameters);
                Assert.NotNull(storageSyncServiceResource);
                StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(storageSyncServiceResource, true);

                SyncGroup syncGroupResource = storageSyncManagementClient.SyncGroups.Create(resourceGroupName, storageSyncServiceResource.Name, syncGroupName, syncGroupParameters);
                Assert.NotNull(syncGroupResource);
                StorageSyncManagementTestUtilities.VerifySyncGroupProperties(syncGroupResource, true);

                CloudEndpoint cloudEndpointResource = storageSyncManagementClient.CloudEndpoints.Create(resourceGroupName, storageSyncServiceResource.Name, syncGroupResource.Name, resourceName, cloudEndpointParameters);
                Assert.NotNull(cloudEndpointResource);
                StorageSyncManagementTestUtilities.VerifyCloudEndpointProperties(cloudEndpointResource, true);

                RegisteredServer registeredServerResource = EnsureRegisteredServerResource(storageSyncManagementClient, resourceGroupName, storageSyncServiceName, syncGroupName, storageSyncServiceResource);
                Assert.NotNull(registeredServerResource);

                StorageSyncManagementTestUtilities.VerifyRegisteredServerProperties(registeredServerResource, true);

                var serverEndpointParameters = StorageSyncManagementTestUtilities.GetDefaultServerEndpointParameters(registeredServerResource.Id);
                var serverEndpointUpdateParameters = StorageSyncManagementTestUtilities.GetDefaultServerEndpointUpdateParameters();

                // Delete Test before it exists.
                storageSyncManagementClient.ServerEndpoints.Delete(resourceGroupName, storageSyncServiceResource.Name, syncGroupResource.Name, resourceName);

                ServerEndpoint serverEndpointResource = storageSyncManagementClient.ServerEndpoints.Create(resourceGroupName, storageSyncServiceResource.Name, syncGroupResource.Name, resourceName, serverEndpointParameters);
                Assert.NotNull(serverEndpointResource);
                StorageSyncManagementTestUtilities.VerifyServerEndpointProperties(serverEndpointResource, true);

                // GET Test
                serverEndpointResource = storageSyncManagementClient.ServerEndpoints.Get(resourceGroupName, storageSyncServiceResource.Name, syncGroupResource.Name, resourceName);
                Assert.NotNull(serverEndpointResource);
                StorageSyncManagementTestUtilities.VerifyServerEndpointProperties(serverEndpointResource, true);

                // List Test
                IEnumerable<ServerEndpoint> serverEndpoints = storageSyncManagementClient.ServerEndpoints.ListBySyncGroup(resourceGroupName, storageSyncServiceResource.Name, syncGroupResource.Name);
                Assert.Single(serverEndpoints);
                Assert.NotNull(serverEndpoints.Single());
                StorageSyncManagementTestUtilities.VerifyServerEndpointProperties(serverEndpoints.Single(), true);

                // Recall Test
                RecallActionParameters recallActionParameters = StorageSyncManagementTestUtilities.GetDefaultRecallActionParameters();
                ServerEndpointsRecallActionHeaders serverEndpointsRecallActionHeaders = storageSyncManagementClient.ServerEndpoints.RecallAction(resourceGroupName, storageSyncServiceResource.Name, syncGroupResource.Name, resourceName, recallActionParameters);
                Assert.NotNull(serverEndpointsRecallActionHeaders);
                Assert.NotEmpty(serverEndpointsRecallActionHeaders.XMsCorrelationRequestId);
                Assert.NotEmpty(serverEndpointsRecallActionHeaders.XMsRequestId);

                // Update Test
                serverEndpointResource = storageSyncManagementClient.ServerEndpoints.Update(resourceGroupName, storageSyncServiceResource.Name, syncGroupResource.Name, resourceName, serverEndpointUpdateParameters);
                Assert.NotNull(serverEndpointResource);
                StorageSyncManagementTestUtilities.VerifyServerEndpointUpdateProperties(serverEndpointResource, true);

                // Delete Test
                 storageSyncManagementClient.ServerEndpoints.Delete(resourceGroupName, storageSyncServiceResource.Name, syncGroupResource.Name, resourceName);

                storageSyncManagementClient.CloudEndpoints.Delete(resourceGroupName, storageSyncServiceResource.Name, syncGroupName, resourceName);
                storageSyncManagementClient.SyncGroups.Delete(resourceGroupName, storageSyncServiceResource.Name, syncGroupName);
                storageSyncManagementClient.RegisteredServers.Delete(resourceGroupName, storageSyncServiceResource.Name, registeredServerResource.ServerId.Trim('"'));
                storageSyncManagementClient.StorageSyncServices.Delete(resourceGroupName, storageSyncServiceResource.Name);
                StorageSyncManagementTestUtilities.RemoveResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        private RegisteredServer EnsureRegisteredServerResource(IStorageSyncManagementClient storageSyncManagementClient, string resourceGroupName, string storageSyncServiceName, string syncGroupName, StorageSyncService storageSyncServiceResource)
        {
            //Guid serverGuid = Guid.NewGuid();
            //var registeredServerParameters = StorageSyncManagementTestUtilities.GetDefaultRegisteredServerParameters(serverGuid);
            //RegisteredServer registeredServerResource = storageSyncManagementClient.RegisteredServers.Create(resourceGroupName, storageSyncServiceResource.Name, serverGuid.ToString(), registeredServerParameters);
            //Assert.NotNull(registeredServerResource);
            //StorageSyncManagementTestUtilities.VerifyRegisteredServerProperties(registeredServerResource, true);

            string message = $"$ResourceGroupName = \"{resourceGroupName}\";" + Environment.NewLine +
                             $"$StorageSyncServiceName = \"{storageSyncServiceName}\";" + Environment.NewLine +
                             $"$SyncGroupName = \"{syncGroupName}\";";

            // For Record :  PLACE A BREAKPOINT HERE , REGISTER SERVER AND CONITNUE.
            IEnumerable<RegisteredServer> registeredServers = storageSyncManagementClient.RegisteredServers.ListByStorageSyncService(resourceGroupName, storageSyncServiceResource.Name);
            Assert.Single(registeredServers);

            return registeredServers.Single();
        }
    }
}

