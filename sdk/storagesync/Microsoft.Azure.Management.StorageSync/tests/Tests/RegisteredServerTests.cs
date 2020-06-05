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
using Microsoft.Rest.Azure;
using System.Diagnostics;

namespace Microsoft.Azure.Management.StorageSync.Tests
{
    public class RegisteredServerTests
    {
        [Fact(Skip = "Pending bug fix in the service")]
        public void RegisteredServerCreateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                IResourceManagementClient resourcesClient = StorageSyncManagementTestUtilities.GetResourceManagementClient(context, handler);
                IStorageSyncManagementClient storageSyncManagementClient = StorageSyncManagementTestUtilities.GetStorageSyncManagementClient(context, handler);

                // Create ResourceGroup
                string resourceGroupName = StorageSyncManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create RegisteredServer Name
                string storageSyncServiceName = TestUtilities.GenerateName("sss-rscreate");
                Guid serverGuid = TestUtilities.GenerateGuid();

                var storageSyncServiceParameters = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceParameters();
                var registeredServerParameters = StorageSyncManagementTestUtilities.GetDefaultRegisteredServerParameters(serverGuid);

                StorageSyncService storageSyncServiceResource = storageSyncManagementClient.StorageSyncServices.Create(resourceGroupName, storageSyncServiceName, storageSyncServiceParameters);
                Assert.NotNull(storageSyncServiceResource);
                StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(storageSyncServiceResource, true);

                RegisteredServer resource = storageSyncManagementClient.RegisteredServers.Create(resourceGroupName, storageSyncServiceResource.Name, serverGuid.ToString(), registeredServerParameters);
                Assert.NotNull(resource);
                StorageSyncManagementTestUtilities.VerifyRegisteredServerProperties(resource, true);

                storageSyncManagementClient.RegisteredServers.Delete(resourceGroupName, storageSyncServiceResource.Name, serverGuid.ToString());
                storageSyncManagementClient.StorageSyncServices.Delete(resourceGroupName, storageSyncServiceResource.Name);
                StorageSyncManagementTestUtilities.RemoveResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact(Skip = "Pending bug fix in the service")]
        public void RegisteredServerGetTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                IResourceManagementClient resourcesClient = StorageSyncManagementTestUtilities.GetResourceManagementClient(context, handler);
                IStorageSyncManagementClient storageSyncManagementClient = StorageSyncManagementTestUtilities.GetStorageSyncManagementClient(context, handler);

                // Create ResourceGroup
                string resourceGroupName = StorageSyncManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create RegisteredServer Name
                string storageSyncServiceName = TestUtilities.GenerateName("sss-rsget");
                 Guid serverGuid = TestUtilities.GenerateGuid();

                var storageSyncServiceParameters = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceParameters();
                var registeredServerParameters = StorageSyncManagementTestUtilities.GetDefaultRegisteredServerParameters(serverGuid);

                StorageSyncService storageSyncServiceResource = storageSyncManagementClient.StorageSyncServices.Create(resourceGroupName, storageSyncServiceName, storageSyncServiceParameters);
                Assert.NotNull(storageSyncServiceResource);
                StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(storageSyncServiceResource, true);

                RegisteredServer registeredServerResource = storageSyncManagementClient.RegisteredServers.Create(resourceGroupName, storageSyncServiceResource.Name, serverGuid.ToString(), registeredServerParameters);
                Assert.NotNull(registeredServerResource);
                StorageSyncManagementTestUtilities.VerifyRegisteredServerProperties(registeredServerResource, true);

                registeredServerResource = storageSyncManagementClient.RegisteredServers.Get(resourceGroupName, storageSyncServiceResource.Name, serverGuid.ToString());
                StorageSyncManagementTestUtilities.VerifyRegisteredServerProperties(registeredServerResource, true);

                storageSyncManagementClient.RegisteredServers.Delete(resourceGroupName, storageSyncServiceResource.Name, serverGuid.ToString());
                storageSyncManagementClient.StorageSyncServices.Delete(resourceGroupName, storageSyncServiceResource.Name);
                StorageSyncManagementTestUtilities.RemoveResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact(Skip = "Pending bug fix in the service")]
        public void RegisteredServerTriggerRolloverTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                IResourceManagementClient resourcesClient = StorageSyncManagementTestUtilities.GetResourceManagementClient(context, handler);
                IStorageSyncManagementClient storageSyncManagementClient = StorageSyncManagementTestUtilities.GetStorageSyncManagementClient(context, handler);

                // Create ResourceGroup
                string resourceGroupName = StorageSyncManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create RegisteredServer Name
                string storageSyncServiceName = TestUtilities.GenerateName("sss-rscert");
                Guid serverGuid = TestUtilities.GenerateGuid();

                var storageSyncServiceParameters = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceParameters();
                var registeredServerParameters = StorageSyncManagementTestUtilities.GetDefaultRegisteredServerParameters(serverGuid);

                StorageSyncService storageSyncServiceResource = storageSyncManagementClient.StorageSyncServices.Create(resourceGroupName, storageSyncServiceName, storageSyncServiceParameters);
                Assert.NotNull(storageSyncServiceResource);
                StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(storageSyncServiceResource, true);

                RegisteredServer registeredServerResource = storageSyncManagementClient.RegisteredServers.Create(resourceGroupName, storageSyncServiceResource.Name, serverGuid.ToString(), registeredServerParameters);
                Assert.NotNull(registeredServerResource);
                StorageSyncManagementTestUtilities.VerifyRegisteredServerProperties(registeredServerResource, true);

                registeredServerResource = storageSyncManagementClient.RegisteredServers.Get(resourceGroupName, storageSyncServiceResource.Name, serverGuid.ToString());
                StorageSyncManagementTestUtilities.VerifyRegisteredServerProperties(registeredServerResource, true);

                string serverCertificate = StorageSyncManagementTestUtilities.GetSecondaryCertificate();
                storageSyncManagementClient.RegisteredServers.TriggerRollover(resourceGroupName, storageSyncServiceResource.Name, serverGuid.ToString(), serverCertificate);

                storageSyncManagementClient.RegisteredServers.Delete(resourceGroupName, storageSyncServiceResource.Name, serverGuid.ToString());
                storageSyncManagementClient.StorageSyncServices.Delete(resourceGroupName, storageSyncServiceResource.Name);
                StorageSyncManagementTestUtilities.RemoveResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact(Skip = "Pending bug fix in the service")]
        public void RegisteredServerListTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                IResourceManagementClient resourcesClient = StorageSyncManagementTestUtilities.GetResourceManagementClient(context, handler);
                IStorageSyncManagementClient storageSyncManagementClient = StorageSyncManagementTestUtilities.GetStorageSyncManagementClient(context, handler);

                // Create ResourceGroup
                string resourceGroupName = StorageSyncManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create RegisteredServer Name
                string storageSyncServiceName = TestUtilities.GenerateName("sss-rslist");
                 Guid serverGuid = TestUtilities.GenerateGuid();

                var storageSyncServiceParameters = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceParameters();
                var registeredServerParameters = StorageSyncManagementTestUtilities.GetDefaultRegisteredServerParameters(serverGuid);

                StorageSyncService storageSyncServiceResource = storageSyncManagementClient.StorageSyncServices.Create(resourceGroupName, storageSyncServiceName, storageSyncServiceParameters);
                Assert.NotNull(storageSyncServiceResource);
                StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(storageSyncServiceResource, true);

                RegisteredServer registeredServerResource = storageSyncManagementClient.RegisteredServers.Create(resourceGroupName, storageSyncServiceResource.Name, serverGuid.ToString(), registeredServerParameters);
                Assert.NotNull(registeredServerResource);
                StorageSyncManagementTestUtilities.VerifyRegisteredServerProperties(registeredServerResource, true);

                IEnumerable<RegisteredServer> registeredServerResources = storageSyncManagementClient.RegisteredServers.ListByStorageSyncService(resourceGroupName, storageSyncServiceResource.Name);
                Assert.True(1 <= registeredServerResources.Count());
                StorageSyncManagementTestUtilities.VerifyRegisteredServerProperties(registeredServerResources.Single(r => r.ServerId.Contains(serverGuid.ToString())), true);

                storageSyncManagementClient.RegisteredServers.Delete(resourceGroupName, storageSyncServiceResource.Name, serverGuid.ToString());
                storageSyncManagementClient.StorageSyncServices.Delete(resourceGroupName, storageSyncServiceResource.Name);
                StorageSyncManagementTestUtilities.RemoveResourceGroup(resourcesClient, resourceGroupName);
            }
        }

        [Fact(Skip = "Pending bug fix in the service")]
        public void RegisteredServerDeleteTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                IResourceManagementClient resourcesClient = StorageSyncManagementTestUtilities.GetResourceManagementClient(context, handler);
                IStorageSyncManagementClient storageSyncManagementClient = StorageSyncManagementTestUtilities.GetStorageSyncManagementClient(context, handler);

                // Create ResourceGroup
                string resourceGroupName = StorageSyncManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create RegisteredServer Name
                string storageSyncServiceName = TestUtilities.GenerateName("sss-rscreate");
                Guid serverGuid = TestUtilities.GenerateGuid();

                var storageSyncServiceParameters = StorageSyncManagementTestUtilities.GetDefaultStorageSyncServiceParameters();
                var registeredServerParameters = StorageSyncManagementTestUtilities.GetDefaultRegisteredServerParameters(serverGuid);

                // Delete RegisteredServer when it does not exists
                //  storageSyncManagementClient.RegisteredServers.Delete(resourceGroupName, storageSyncServiceName, serverGuid.ToString());

                StorageSyncService storageSyncServiceResource = storageSyncManagementClient.StorageSyncServices.Create(resourceGroupName, storageSyncServiceName, storageSyncServiceParameters);
                Assert.NotNull(storageSyncServiceResource);
                StorageSyncManagementTestUtilities.VerifyStorageSyncServiceProperties(storageSyncServiceResource, true);

                // Delete RegisteredServer when it does not exists
                storageSyncManagementClient.RegisteredServers.Delete(resourceGroupName, storageSyncServiceResource.Name, serverGuid.ToString());

                RegisteredServer registeredServerResource = storageSyncManagementClient.RegisteredServers.Create(resourceGroupName, storageSyncServiceResource.Name, serverGuid.ToString(), registeredServerParameters);
                Assert.NotNull(registeredServerResource);
                StorageSyncManagementTestUtilities.VerifyRegisteredServerProperties(registeredServerResource, true);

                storageSyncManagementClient.RegisteredServers.Delete(resourceGroupName, storageSyncServiceResource.Name, serverGuid.ToString());

                // Delete RegisteredServer when it's been already deleted.
                storageSyncManagementClient.RegisteredServers.Delete(resourceGroupName, storageSyncServiceResource.Name, serverGuid.ToString());
                storageSyncManagementClient.StorageSyncServices.Delete(resourceGroupName, storageSyncServiceResource.Name);
                StorageSyncManagementTestUtilities.RemoveResourceGroup(resourcesClient, resourceGroupName);
            }
        }
    }
}

