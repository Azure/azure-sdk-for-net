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
    public class CloudEndpointTests
    {
        [Fact]
        public void CloudEndpointCreateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                IResourceManagementClient resourcesClient = StorageSyncManagementTestUtilities.GetResourceManagementClient(context, handler);
                IStorageSyncManagementClient storageSyncManagementClient = StorageSyncManagementTestUtilities.GetStorageSyncManagementClient(context, handler);

                // Create ResourceGroup
                string resourceGroupName = StorageSyncManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create CloudEndpoint Name
                string storageSyncServiceName = TestUtilities.GenerateName("sss-cepcreate");
                string syncGroupName = TestUtilities.GenerateName("sg-cepcreate");
                string cloudEndpointName = TestUtilities.GenerateName("cepcreate");

                var storageSyncServiceParameters = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceParameters();
                var syncGroupParameters = StorageSyncManagementTestUtilities.GetDefaultSyncGroupParameters();
                var cloudEndpointParameters = StorageSyncManagementTestUtilities.GetDefaultCloudEndpointParameters();

                StorageSyncService parentResource = storageSyncManagementClient.StorageSyncServices.Create(resourceGroupName, storageSyncServiceName, storageSyncServiceParameters);
                Assert.NotNull(parentResource);
                StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(parentResource, true);

                SyncGroup parentResource2 = storageSyncManagementClient.SyncGroups.Create(resourceGroupName, parentResource.Name, syncGroupName, syncGroupParameters);
                Assert.NotNull(parentResource2);
                StorageSyncManagementTestUtilities.VerifySyncGroupProperties(parentResource2, true);

                CloudEndpoint resource = storageSyncManagementClient.CloudEndpoints.Create(resourceGroupName, parentResource.Name, parentResource2.Name,cloudEndpointName, cloudEndpointParameters);
                Assert.NotNull(resource);
                StorageSyncManagementTestUtilities.VerifyCloudEndpointProperties(resource, true);

                storageSyncManagementClient.CloudEndpoints.Delete(resourceGroupName, parentResource.Name, syncGroupName, cloudEndpointName);
                storageSyncManagementClient.SyncGroups.Delete(resourceGroupName, parentResource.Name, syncGroupName);
                storageSyncManagementClient.StorageSyncServices.Delete(resourceGroupName, parentResource.Name);
                StorageSyncManagementTestUtilities.RemoveResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact]
        public void CloudEndpointGetTest()
        {

            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                IResourceManagementClient resourcesClient = StorageSyncManagementTestUtilities.GetResourceManagementClient(context, handler);
                IStorageSyncManagementClient storageSyncManagementClient = StorageSyncManagementTestUtilities.GetStorageSyncManagementClient(context, handler);

                // Create ResourceGroup
                string resourceGroupName = StorageSyncManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create CloudEndpoint Name
                string storageSyncServiceName = TestUtilities.GenerateName("sss-cepget");
                string syncGroupName = TestUtilities.GenerateName("sg-cepget");
                string cloudEndpointName = TestUtilities.GenerateName("cepget");

                var storageSyncServiceParameters = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceParameters();
                var syncGroupParameters = StorageSyncManagementTestUtilities.GetDefaultSyncGroupParameters();
                var cloudEndpointParameters = StorageSyncManagementTestUtilities.GetDefaultCloudEndpointParameters();

                StorageSyncService storageSyncServiceResource = storageSyncManagementClient.StorageSyncServices.Create(resourceGroupName, storageSyncServiceName, storageSyncServiceParameters);
                Assert.NotNull(storageSyncServiceResource);
                StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(storageSyncServiceResource, true);

                SyncGroup syncGroupResource = storageSyncManagementClient.SyncGroups.Create(resourceGroupName, storageSyncServiceResource.Name, syncGroupName, syncGroupParameters);
                Assert.NotNull(syncGroupResource);
                StorageSyncManagementTestUtilities.VerifySyncGroupProperties(syncGroupResource, true);

                CloudEndpoint cloudEndpointResource = storageSyncManagementClient.CloudEndpoints.Create(resourceGroupName, storageSyncServiceResource.Name, syncGroupResource.Name, cloudEndpointName, cloudEndpointParameters);
                Assert.NotNull(cloudEndpointResource);
                StorageSyncManagementTestUtilities.VerifyCloudEndpointProperties(cloudEndpointResource, true);

                cloudEndpointResource = storageSyncManagementClient.CloudEndpoints.Get(resourceGroupName, storageSyncServiceResource.Name, syncGroupResource.Name, cloudEndpointName);
                StorageSyncManagementTestUtilities.VerifyCloudEndpointProperties(cloudEndpointResource, false);

                storageSyncManagementClient.CloudEndpoints.Delete(resourceGroupName, storageSyncServiceResource.Name, syncGroupName, cloudEndpointName);
                storageSyncManagementClient.SyncGroups.Delete(resourceGroupName, storageSyncServiceResource.Name, syncGroupName);
                storageSyncManagementClient.StorageSyncServices.Delete(resourceGroupName, storageSyncServiceResource.Name);
                StorageSyncManagementTestUtilities.RemoveResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact]
        public void CloudEndpointListTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                IResourceManagementClient resourcesClient = StorageSyncManagementTestUtilities.GetResourceManagementClient(context, handler);
                IStorageSyncManagementClient storageSyncManagementClient = StorageSyncManagementTestUtilities.GetStorageSyncManagementClient(context, handler);

                // Create ResourceGroup
                string resourceGroupName = StorageSyncManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create CloudEndpoint Name
                string storageSyncServiceName = TestUtilities.GenerateName("sss-ceplist");
                string syncGroupName = TestUtilities.GenerateName("sg-ceplist");
                string cloudEndpointName = TestUtilities.GenerateName("ceplist");

                var storageSyncServiceParameters = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceParameters();
                var syncGroupParameters = StorageSyncManagementTestUtilities.GetDefaultSyncGroupParameters();
                var cloudEndpointParameters = StorageSyncManagementTestUtilities.GetDefaultCloudEndpointParameters();

                StorageSyncService storageSyncServiceResource = storageSyncManagementClient.StorageSyncServices.Create(resourceGroupName, storageSyncServiceName, storageSyncServiceParameters);
                Assert.NotNull(storageSyncServiceResource);
                StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(storageSyncServiceResource, true);

                SyncGroup syncGroupResource = storageSyncManagementClient.SyncGroups.Create(resourceGroupName, storageSyncServiceResource.Name, syncGroupName, syncGroupParameters);
                Assert.NotNull(syncGroupResource);
                StorageSyncManagementTestUtilities.VerifySyncGroupProperties(syncGroupResource, true);

                CloudEndpoint cloudEndpointResource = storageSyncManagementClient.CloudEndpoints.Create(resourceGroupName, storageSyncServiceResource.Name, syncGroupResource.Name, cloudEndpointName, cloudEndpointParameters);
                Assert.NotNull(cloudEndpointResource);
                StorageSyncManagementTestUtilities.VerifyCloudEndpointProperties(cloudEndpointResource, true);

                IEnumerable<CloudEndpoint> cloudEndpointResources = storageSyncManagementClient.CloudEndpoints.ListBySyncGroup(resourceGroupName, storageSyncServiceResource.Name, syncGroupResource.Name);

                Assert.NotNull(cloudEndpointResources);
                Assert.Single(cloudEndpointResources);

                StorageSyncManagementTestUtilities.VerifyCloudEndpointProperties(cloudEndpointResources.First(), false);

                storageSyncManagementClient.CloudEndpoints.Delete(resourceGroupName, storageSyncServiceResource.Name, syncGroupName, cloudEndpointName);
                storageSyncManagementClient.SyncGroups.Delete(resourceGroupName, storageSyncServiceResource.Name, syncGroupName);
                storageSyncManagementClient.StorageSyncServices.Delete(resourceGroupName, storageSyncServiceResource.Name);
                StorageSyncManagementTestUtilities.RemoveResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact]
        public void CloudEndpointDeleteTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                IResourceManagementClient resourcesClient = StorageSyncManagementTestUtilities.GetResourceManagementClient(context, handler);
                IStorageSyncManagementClient storageSyncManagementClient = StorageSyncManagementTestUtilities.GetStorageSyncManagementClient(context, handler);

                // Create ResourceGroup
                string resourceGroupName = StorageSyncManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create CloudEndpoint Name
                string storageSyncServiceName = TestUtilities.GenerateName("sss-cepdelete");
                string syncGroupName = TestUtilities.GenerateName("sg-cepdelete");
                string cloudEndpointName = TestUtilities.GenerateName("cepdelete");

                var storageSyncServiceParameters = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceParameters();
                var syncGroupParameters = StorageSyncManagementTestUtilities.GetDefaultSyncGroupParameters();
                var cloudEndpointParameters = StorageSyncManagementTestUtilities.GetDefaultCloudEndpointParameters();

                StorageSyncService storageSyncServiceResource = storageSyncManagementClient.StorageSyncServices.Create(resourceGroupName, storageSyncServiceName, storageSyncServiceParameters);
                Assert.NotNull(storageSyncServiceResource);
                StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(storageSyncServiceResource, true);

                SyncGroup syncGroupResource = storageSyncManagementClient.SyncGroups.Create(resourceGroupName, storageSyncServiceResource.Name, syncGroupName, syncGroupParameters);
                Assert.NotNull(syncGroupResource);
                StorageSyncManagementTestUtilities.VerifySyncGroupProperties(syncGroupResource, true);

                // Delete CloudEndpoint before its created.
                storageSyncManagementClient.CloudEndpoints.Delete(resourceGroupName, storageSyncServiceResource.Name, syncGroupResource.Name, cloudEndpointName);

                CloudEndpoint cloudEndpointResource = storageSyncManagementClient.CloudEndpoints.Create(resourceGroupName, storageSyncServiceResource.Name, syncGroupResource.Name, cloudEndpointName, cloudEndpointParameters);
                Assert.NotNull(cloudEndpointResource);
                StorageSyncManagementTestUtilities.VerifyCloudEndpointProperties(cloudEndpointResource, true);

                // Delete CloudEndpoint
                storageSyncManagementClient.CloudEndpoints.Delete(resourceGroupName, storageSyncServiceResource.Name, syncGroupResource.Name, cloudEndpointName);

                // Delete CloudEndpoint which was just deleted
                storageSyncManagementClient.CloudEndpoints.Delete(resourceGroupName, storageSyncServiceResource.Name, syncGroupResource.Name, cloudEndpointName);

                storageSyncManagementClient.SyncGroups.Delete(resourceGroupName, storageSyncServiceResource.Name, syncGroupName);
                storageSyncManagementClient.StorageSyncServices.Delete(resourceGroupName, storageSyncServiceResource.Name);
                StorageSyncManagementTestUtilities.RemoveResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact]
        public void CloudEndpointInvokeChangeDetectionTest()
        {

            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                IResourceManagementClient resourcesClient = StorageSyncManagementTestUtilities.GetResourceManagementClient(context, handler);
                IStorageSyncManagementClient storageSyncManagementClient = StorageSyncManagementTestUtilities.GetStorageSyncManagementClient(context, handler);

                // Create ResourceGroup
                string resourceGroupName = StorageSyncManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create CloudEndpoint Name
                string storageSyncServiceName = TestUtilities.GenerateName("sss-cepchangedetection");
                string syncGroupName = TestUtilities.GenerateName("sg-cepchangedetection");
                string cloudEndpointName = TestUtilities.GenerateName("cepchangedetection");

                var storageSyncServiceParameters = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceParameters();
                var syncGroupParameters = StorageSyncManagementTestUtilities.GetDefaultSyncGroupParameters();
                var cloudEndpointParameters = StorageSyncManagementTestUtilities.GetDefaultCloudEndpointParameters();

                StorageSyncService storageSyncServiceResource = storageSyncManagementClient.StorageSyncServices.Create(resourceGroupName, storageSyncServiceName, storageSyncServiceParameters);
                Assert.NotNull(storageSyncServiceResource);
                StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(storageSyncServiceResource, true);

                SyncGroup syncGroupResource = storageSyncManagementClient.SyncGroups.Create(resourceGroupName, storageSyncServiceResource.Name, syncGroupName, syncGroupParameters);
                Assert.NotNull(syncGroupResource);
                StorageSyncManagementTestUtilities.VerifySyncGroupProperties(syncGroupResource, true);

                CloudEndpoint cloudEndpointResource = storageSyncManagementClient.CloudEndpoints.Create(resourceGroupName, storageSyncServiceResource.Name, syncGroupResource.Name, cloudEndpointName, cloudEndpointParameters);
                Assert.NotNull(cloudEndpointResource);
                StorageSyncManagementTestUtilities.VerifyCloudEndpointProperties(cloudEndpointResource, true);

                // invoke with directory path
                storageSyncManagementClient.CloudEndpoints.TriggerChangeDetection(
                    resourceGroupName: resourceGroupName,
                    storageSyncServiceName: storageSyncServiceName,
                    syncGroupName: syncGroupName,
                    cloudEndpointName: cloudEndpointName,
                    parameters: new TriggerChangeDetectionParameters(
                        directoryPath: "",
                        changeDetectionMode: ChangeDetectionMode.Recursive));

                // invoke with individual paths
                storageSyncManagementClient.CloudEndpoints.TriggerChangeDetection(
                    resourceGroupName: resourceGroupName,
                    storageSyncServiceName: storageSyncServiceName,
                    syncGroupName: syncGroupName,
                    cloudEndpointName: cloudEndpointName,
                    parameters: new TriggerChangeDetectionParameters(
                        paths: new string[] { "dir1/subdir1", "file.txt" } ));

                storageSyncManagementClient.CloudEndpoints.Delete(resourceGroupName, storageSyncServiceResource.Name, syncGroupName, cloudEndpointName);
                storageSyncManagementClient.SyncGroups.Delete(resourceGroupName, storageSyncServiceResource.Name, syncGroupName);
                storageSyncManagementClient.StorageSyncServices.Delete(resourceGroupName, storageSyncServiceResource.Name);
                StorageSyncManagementTestUtilities.RemoveResourceGroup(resourcesClient, resourceGroupName);
            }
        }
    }
}

