//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.Linq;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Management.SiteRecovery;
using Microsoft.WindowsAzure.Management.RecoveryServices;
using System.Net;
using Xunit;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;


namespace SiteRecovery.Tests
{
    public class EnumerationTests : SiteRecoveryTestsBase
    {
        private const string RecoveryservicePrefix = "RecoveryServices";

        [Fact]
        public void EnumerateCloudServicesTests()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetRecoveryServicesClient(CustomHttpHandler);

                var response = client.CloudServices.List();

                Assert.True(response.CloudServices.Count > 0, "Cloud Services count can't be less than 1");
                Assert.True(response.CloudServices.Any(c => c.Name.StartsWith(RecoveryservicePrefix)), "Recovery Service not found in cloud services list");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void EnumerateServersTests()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var response = client.Servers.List(RequestHeaders);

                Assert.True(response.Servers.Count > 0, "Servers count can't be less than 1");
                Assert.True(response.Servers.All(server => !string.IsNullOrEmpty(server.Name)), "Server name can't be null or empty");
                Assert.True(response.Servers.All(server => !string.IsNullOrEmpty(server.ID)), "Server Id can't be null or empty");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void EnumerateSitesTests()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var response = client.Sites.List(RequestHeaders);

                Assert.True(response.Sites.Count > 0, "Sites count can't be less than 1");
                Assert.True(response.Sites.All(server => !string.IsNullOrEmpty(server.Name)), "Site name can't be null or empty");
                Assert.True(response.Sites.All(server => !string.IsNullOrEmpty(server.ID)), "Site Id can't be null or empty");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void EnumerateProtectedContainerTests()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var response = client.ProtectionContainer.List(RequestHeaders);

                Assert.True(response.ProtectionContainers.Count > 0, "Protection containers count can't be less than 1");
                Assert.True(response.ProtectionContainers.All(protectedContainer => !string.IsNullOrEmpty(protectedContainer.Name)), "Protection Container name can't be null or empty");
                Assert.True(response.ProtectionContainers.All(protectedContainer => !string.IsNullOrEmpty(protectedContainer.ID)), "Protection Container Id can't be null or empty");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void EnumerateProtectedProfileTests()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var response = client.ProtectionProfile.List(RequestHeaders);

                Assert.True(response.ProtectionProfiles.Count > 0, "Protection Profiles count can't be less than 1");
                Assert.True(response.ProtectionProfiles.All(protectedContainer => !string.IsNullOrEmpty(protectedContainer.Name)), "Protection Profile name can't be null or empty");
                Assert.True(response.ProtectionProfiles.All(protectedContainer => !string.IsNullOrEmpty(protectedContainer.ID)), "Protection Profile Id can't be null or empty");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void EnumerateVirtualMachinesTests()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var protectionContainerList = client.ProtectionContainer.List(RequestHeaders);
                VirtualMachineListResponse response = null;
                foreach (var pc in protectionContainerList.ProtectionContainers)
                {
                    if (pc.Role == "Primary")
                    {
                        response = client.Vm.List(pc.ID, RequestHeaders);
                    }
                }

                Assert.True(response.Vms.Count > 0, "Virtual machines count can't be less than 1");
                Assert.True(response.Vms.All(vm => !string.IsNullOrEmpty(vm.Name)), "Vm name can't be null or empty");
                Assert.True(response.Vms.All(vm => !string.IsNullOrEmpty(vm.ID)), "Vm Id can't be null or empty");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public void EnumerateVirtualMachineGroupsTests()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var protectionContainerList = client.ProtectionContainer.List(RequestHeaders);

                var response = client.VmGroup.List(protectionContainerList.ProtectionContainers[0].ID, RequestHeaders);

                //Assert.True(response.VmGroups.Count > 0, "Virtual machine groups count can't be less than 1");
                //Assert.True(response.VmGroups.All(vmg => !string.IsNullOrEmpty(vmg.Name)), "Vmg name can't be null or empty");
                //Assert.True(response.VmGroups.All(vmg => !string.IsNullOrEmpty(vmg.ID)), "Vmg Id can't be null or empty");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void EnumerateAzureStorageTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                StorageAccountListResponse azureStorageListResponse = client.Storages.ListAzureStorages(client.Credentials.SubscriptionId);

                Assert.True(azureStorageListResponse.StorageAccounts.Count > 0, "Storage accounts count can't be less than 1");
                Assert.True(!string.IsNullOrEmpty(azureStorageListResponse.StorageAccounts.First().Properties.Location), "Storage account location shouldn't be null/empty unless it is in some affinity group");
                Assert.Equal(HttpStatusCode.OK, azureStorageListResponse.StatusCode);
            }
        }
    }
}
