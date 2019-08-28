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

namespace Microsoft.Azure.Management.StorageSync.Tests
{
    public class SyncGroupTests
    {
        [Fact]
        public void SyncGroupCreateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                IResourceManagementClient resourcesClient = StorageSyncManagementTestUtilities.GetResourceManagementClient(context, handler);
                IStorageSyncManagementClient storageSyncManagementClient = StorageSyncManagementTestUtilities.GetStorageSyncManagementClient(context, handler);

                // Create ResourceGroup
                string resourceGroupName = StorageSyncManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create SyncGroup Name
                string storageSyncServiceName = TestUtilities.GenerateName("ssscreate-sgcreate");
                string syncGroupName = TestUtilities.GenerateName("sgcreate");

                var storageSyncServiceParameters = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceParameters();
                var syncGroupParameters = StorageSyncManagementTestUtilities.GetDefaultSyncGroupParameters();

                StorageSyncService storageSyncServiceResource = storageSyncManagementClient.StorageSyncServices.Create(resourceGroupName, storageSyncServiceName, storageSyncServiceParameters);
                Assert.NotNull(storageSyncServiceResource);
                StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(storageSyncServiceResource, true);

                SyncGroup syncGroupResource = storageSyncManagementClient.SyncGroups.Create(resourceGroupName, storageSyncServiceResource.Name, syncGroupName, syncGroupParameters);

                StorageSyncManagementTestUtilities.VerifySyncGroupProperties(syncGroupResource, true);

                storageSyncManagementClient.SyncGroups.Delete(resourceGroupName, storageSyncServiceResource.Name, syncGroupName);
                storageSyncManagementClient.StorageSyncServices.Delete(resourceGroupName, storageSyncServiceResource.Name);
                StorageSyncManagementTestUtilities.RemoveResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact]
        public void SyncGroupGetTest()
        {

            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                IResourceManagementClient resourcesClient = StorageSyncManagementTestUtilities.GetResourceManagementClient(context, handler);
                IStorageSyncManagementClient storageSyncManagementClient = StorageSyncManagementTestUtilities.GetStorageSyncManagementClient(context, handler);

                // Create ResourceGroup
                string resourceGroupName = StorageSyncManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create SyncGroup Name
                string storageSyncServiceName = TestUtilities.GenerateName("ssscreate-sgget");
                string syncGroupName = TestUtilities.GenerateName("sgget");

                var storageSyncServiceParameters = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceParameters();
                var syncGroupParameters = StorageSyncManagementTestUtilities.GetDefaultSyncGroupParameters();

                StorageSyncService storageSyncServiceResource = storageSyncManagementClient.StorageSyncServices.Create(resourceGroupName, storageSyncServiceName, storageSyncServiceParameters);
                Assert.NotNull(storageSyncServiceResource);
                StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(storageSyncServiceResource, true);

                SyncGroup syncGroupResource = storageSyncManagementClient.SyncGroups.Create(resourceGroupName, storageSyncServiceResource.Name, syncGroupName, syncGroupParameters);
                syncGroupResource = storageSyncManagementClient.SyncGroups.Get(resourceGroupName, storageSyncServiceResource.Name, syncGroupName);
                StorageSyncManagementTestUtilities.VerifySyncGroupProperties(syncGroupResource, false);

                storageSyncManagementClient.SyncGroups.Delete(resourceGroupName, storageSyncServiceResource.Name, syncGroupName);
                storageSyncManagementClient.StorageSyncServices.Delete(resourceGroupName, storageSyncServiceResource.Name);
                StorageSyncManagementTestUtilities.RemoveResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact]
        public void SyncGroupListTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                IResourceManagementClient resourcesClient = StorageSyncManagementTestUtilities.GetResourceManagementClient(context, handler);
                IStorageSyncManagementClient storageSyncManagementClient = StorageSyncManagementTestUtilities.GetStorageSyncManagementClient(context, handler);

                // Create ResourceGroup
                string resourceGroupName = StorageSyncManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create SyncGroup Name
                string storageSyncServiceName = TestUtilities.GenerateName("ssscreate-sglist");
                string syncGroupName = TestUtilities.GenerateName("sglist");

                var storageSyncServiceParameters = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceParameters();
                var syncGroupParameters = StorageSyncManagementTestUtilities.GetDefaultSyncGroupParameters();

                StorageSyncService storageSyncServiceResource = storageSyncManagementClient.StorageSyncServices.Create(resourceGroupName, storageSyncServiceName, storageSyncServiceParameters);
                Assert.NotNull(storageSyncServiceResource);
                StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(storageSyncServiceResource, true);

                SyncGroup syncGroupResource = storageSyncManagementClient.SyncGroups.Create(resourceGroupName, storageSyncServiceResource.Name, syncGroupName, syncGroupParameters);

                IEnumerable<SyncGroup> syncGroupResources = storageSyncManagementClient.SyncGroups.ListByStorageSyncService(resourceGroupName, storageSyncServiceResource.Name);

                Assert.NotNull(syncGroupResources);
                Assert.Single(syncGroupResources);

                StorageSyncManagementTestUtilities.VerifySyncGroupProperties(syncGroupResources.First(), false);

                storageSyncManagementClient.SyncGroups.Delete(resourceGroupName, storageSyncServiceResource.Name, syncGroupName);
                storageSyncManagementClient.StorageSyncServices.Delete(resourceGroupName, storageSyncServiceResource.Name);
                StorageSyncManagementTestUtilities.RemoveResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact]
        public void SyncGroupDeleteTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                IResourceManagementClient resourcesClient = StorageSyncManagementTestUtilities.GetResourceManagementClient(context, handler);
                IStorageSyncManagementClient storageSyncManagementClient = StorageSyncManagementTestUtilities.GetStorageSyncManagementClient(context, handler);

                // Create ResourceGroup
                string resourceGroupName = StorageSyncManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create SyncGroup Name
                string storageSyncServiceName = TestUtilities.GenerateName("sss-sgdelete");
                string syncGroupName = TestUtilities.GenerateName("sgdelete");

                var storageSyncServiceParameters = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceParameters();
                var syncGroupParameters = StorageSyncManagementTestUtilities.GetDefaultSyncGroupParameters();

                StorageSyncService storageSyncServiceResource = storageSyncManagementClient.StorageSyncServices.Create(resourceGroupName, storageSyncServiceName, storageSyncServiceParameters);
                Assert.NotNull(storageSyncServiceResource);
                StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(storageSyncServiceResource, true);

                // Delete SyncGroup which does not exists
                storageSyncManagementClient.SyncGroups.Delete(resourceGroupName, storageSyncServiceResource.Name, syncGroupName);

                SyncGroup syncGroupResource = storageSyncManagementClient.SyncGroups.Create(resourceGroupName, storageSyncServiceResource.Name, syncGroupName, syncGroupParameters);

                // Delete SyncGroup
                storageSyncManagementClient.SyncGroups.Delete(resourceGroupName, storageSyncServiceResource.Name, syncGroupName);

                // Delete SyncGroup which was just deleted
                storageSyncManagementClient.SyncGroups.Delete(resourceGroupName, storageSyncServiceResource.Name, syncGroupName);

                storageSyncManagementClient.SyncGroups.Delete(resourceGroupName, storageSyncServiceResource.Name, syncGroupName);
                storageSyncManagementClient.StorageSyncServices.Delete(resourceGroupName, storageSyncServiceResource.Name);
                StorageSyncManagementTestUtilities.RemoveResourceGroup(resourcesClient, resourceGroupName);
            }
        }

    }
}

