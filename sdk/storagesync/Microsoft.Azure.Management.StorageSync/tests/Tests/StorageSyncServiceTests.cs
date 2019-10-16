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
    public class StorageSyncServiceTests
    {
        [Fact]
        public void StorageSyncServiceCreateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                IResourceManagementClient resourcesClient = StorageSyncManagementTestUtilities.GetResourceManagementClient(context, handler);
                IStorageSyncManagementClient storageSyncManagementClient = StorageSyncManagementTestUtilities.GetStorageSyncManagementClient(context, handler);

                // Create ResourceGroup
                string resourceGroupName = StorageSyncManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create StorageSyncService Name
                string resourceName = TestUtilities.GenerateName("ssscreate");

                var parameters = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceParameters();

                StorageSyncService resource = storageSyncManagementClient.StorageSyncServices.Create(resourceGroupName, resourceName, parameters);

                StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(resource, true);

                storageSyncManagementClient.StorageSyncServices.Delete(resourceGroupName, resourceName);

                StorageSyncManagementTestUtilities.RemoveResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact]
        public void StorageSyncServiceUpdateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                IResourceManagementClient resourcesClient = StorageSyncManagementTestUtilities.GetResourceManagementClient(context, handler);
                IStorageSyncManagementClient storageSyncManagementClient = StorageSyncManagementTestUtilities.GetStorageSyncManagementClient(context, handler);

                // Create ResourceGroup
                string resourceGroupName = StorageSyncManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create StorageSyncService Name
                string resourceName = TestUtilities.GenerateName("ssscreate");

                var parameters = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceParameters();
                var updateParameters = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceUpdateParameters();

                StorageSyncService resource = storageSyncManagementClient.StorageSyncServices.Create(resourceGroupName, resourceName, parameters);

                StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(resource, true);

                resource = storageSyncManagementClient.StorageSyncServices.Update(resourceGroupName, resourceName, updateParameters);

                StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(resource, true);

                storageSyncManagementClient.StorageSyncServices.Delete(resourceGroupName, resourceName);
                StorageSyncManagementTestUtilities.RemoveResourceGroup(resourcesClient, resourceGroupName);
            }
        }
        [Fact]
        public void StorageSyncServiceGetTest()
        {

            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                IResourceManagementClient resourcesClient = StorageSyncManagementTestUtilities.GetResourceManagementClient(context, handler);
                IStorageSyncManagementClient storageSyncManagementClient = StorageSyncManagementTestUtilities.GetStorageSyncManagementClient(context, handler);

                // Create ResourceGroup
                string resourceGroupName = StorageSyncManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create StorageSyncService Name
                string resourceName = TestUtilities.GenerateName("sssget");

                var parameters = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceParameters();

                StorageSyncService resource = storageSyncManagementClient.StorageSyncServices.Create(resourceGroupName, resourceName, parameters);
                resource = storageSyncManagementClient.StorageSyncServices.Get(resourceGroupName, resourceName);
                StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(resource, false);

                storageSyncManagementClient.StorageSyncServices.Delete(resourceGroupName, resourceName);
                StorageSyncManagementTestUtilities.RemoveResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact]
        public void StorageSyncServiceListTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                IResourceManagementClient resourcesClient = StorageSyncManagementTestUtilities.GetResourceManagementClient(context, handler);
                IStorageSyncManagementClient storageSyncManagementClient = StorageSyncManagementTestUtilities.GetStorageSyncManagementClient(context, handler);

                // Create ResourceGroup
                string resourceGroupName = StorageSyncManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create StorageSyncService Name
                string resourceName = TestUtilities.GenerateName("ssslist");

                var parameters = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceParameters();

                StorageSyncService resource = storageSyncManagementClient.StorageSyncServices.Create(resourceGroupName, resourceName, parameters);

                IEnumerable<StorageSyncService> resources = storageSyncManagementClient.StorageSyncServices.ListByResourceGroup(resourceGroupName);

                Assert.NotNull(resources);
                Assert.Single(resources);

                StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(resources.First(), false);

                resources = storageSyncManagementClient.StorageSyncServices.ListBySubscription();

                Assert.NotNull(resources);

                // Change the number if json has more results under this subscription.
                Assert.True(1 <= resources.Count());

                StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(resources.Single(r => r.Name == resourceName), false);

                storageSyncManagementClient.StorageSyncServices.Delete(resourceGroupName, resourceName);

                StorageSyncManagementTestUtilities.RemoveResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact]
        public void StorageSyncServiceDeleteTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                IResourceManagementClient resourcesClient = StorageSyncManagementTestUtilities.GetResourceManagementClient(context, handler);
                IStorageSyncManagementClient storageSyncManagementClient = StorageSyncManagementTestUtilities.GetStorageSyncManagementClient(context, handler);

                // Create ResourceGroup
                string resourceGroupName = StorageSyncManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create StorageSyncService Name
                string resourceName = TestUtilities.GenerateName("sssdelete");

                // Delete an account which does not exist
                storageSyncManagementClient.StorageSyncServices.Delete(resourceGroupName, resourceName);

                var parameters = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceParameters();

                // Create StorageSyncService
                StorageSyncService resource = storageSyncManagementClient.StorageSyncServices.Create(resourceGroupName, resourceName, parameters);

                // Delete StorageSyncService
                storageSyncManagementClient.StorageSyncServices.Delete(resourceGroupName, resourceName);

                // Delete StorageSyncService which was just deleted
                storageSyncManagementClient.StorageSyncServices.Delete(resourceGroupName, resourceName);

                StorageSyncManagementTestUtilities.RemoveResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact]
        public void StorageSyncServiceCheckNameAvailabilityTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                IResourceManagementClient resourcesClient = StorageSyncManagementTestUtilities.GetResourceManagementClient(context, handler);
                IStorageSyncManagementClient storageSyncManagementClient = StorageSyncManagementTestUtilities.GetStorageSyncManagementClient(context, handler);

                // Create ResourceGroup
                string resourceGroupName = StorageSyncManagementTestUtilities.CreateResourceGroup(resourcesClient);
                string locationName = StorageSyncManagementTestUtilities.DefaultLocation;

                // Create StorageSyncService Name
                string resourceName = TestUtilities.GenerateName("ssscheckName");

                // Check Name Availability which does not exists
                Models.CheckNameAvailabilityResult checkNameAvailabilityResult = storageSyncManagementClient.StorageSyncServices.CheckNameAvailability(locationName, resourceName);

                Assert.True(checkNameAvailabilityResult.NameAvailable.HasValue);
                Assert.True(checkNameAvailabilityResult.NameAvailable.Value);

                var parameters = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceParameters();

                // Create StorageSyncService
                StorageSyncService resource = storageSyncManagementClient.StorageSyncServices.Create(resourceGroupName, resourceName, parameters);

                // Check Name Availability which does exists
                checkNameAvailabilityResult = storageSyncManagementClient.StorageSyncServices.CheckNameAvailability(locationName, resourceName);

                Assert.True(checkNameAvailabilityResult.NameAvailable.HasValue);
                Assert.False(checkNameAvailabilityResult.NameAvailable.Value);

                storageSyncManagementClient.StorageSyncServices.Delete(resourceGroupName, resourceName);
                StorageSyncManagementTestUtilities.RemoveResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact]
        public void StorageSyncServiceBadRequestTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                IResourceManagementClient resourcesClient = StorageSyncManagementTestUtilities.GetResourceManagementClient(context, handler);
                IStorageSyncManagementClient storageSyncManagementClient = StorageSyncManagementTestUtilities.GetStorageSyncManagementClient(context, handler);

                // Create ResourceGroup
                string resourceGroupName = StorageSyncManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create StorageSyncService Name
                string resourceName = TestUtilities.GenerateName("#$%badsss");

                var parameters = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceParameters();

                // Try Create StorageSyncService
                Assert.Throws<StorageSyncErrorException>(() => storageSyncManagementClient.StorageSyncServices.Create(resourceGroupName, resourceName, parameters));

                StorageSyncManagementTestUtilities.RemoveResourceGroup(resourcesClient, resourceGroupName);
            }
        }
    }
}

