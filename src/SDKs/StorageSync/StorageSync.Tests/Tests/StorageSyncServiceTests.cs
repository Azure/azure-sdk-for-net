using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Management.StorageSync.Models;
using Microsoft.Azure.Management.Tests.Common;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Net;
using Xunit;

namespace Microsoft.Azure.Management.StorageSync.Tests
{
    public class StorageSyncServiceTests
    {
        [Fact]
        public void StorageSyncServiceCreateTest()
        {
            
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                IResourceManagementClient resourcesClient = StorageSyncManagementTestUtilities.GetResourceManagementClient(context, handler);
                IStorageSyncManagementClient storageSyncManagementClient = StorageSyncManagementTestUtilities.GetStorageSyncManagementClient(context, handler);

                // Create ResourceGroup
                string resourceGroupName = StorageSyncManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create StorageSyncService Name
                string resourceName = TestUtilities.GenerateName("sto");

                var parameters = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceParameters();

                StorageSyncService resource = storageSyncManagementClient.StorageSyncServices.Create(resourceGroupName, resourceName, parameters);

                StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(resource, true);
            }
        }
    }
}
