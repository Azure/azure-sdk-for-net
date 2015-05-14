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
using Microsoft.WindowsAzure.Management.SiteRecovery;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;
using Microsoft.WindowsAzure;
using Microsoft.Azure.Test;
using System.Net;
using Xunit;
using System;


namespace SiteRecovery.Tests
{
    public class StorageOperationTests : SiteRecoveryTestsBase
    {
        [Fact]
        public void EnumerateStoragesTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                // Get Servers
                var servers = client.Servers.List(RequestHeaders);

                var response = client.Storages.List(servers.Servers[0].ID, RequestHeaders);

                Assert.True(response.Storages.Count > 0, "Storages count can't be less than 1");
                Assert.True(response.Storages.All(storage => !string.IsNullOrEmpty(storage.Name)), "Storage name can't be null or empty");
                Assert.True(response.Storages.All(storage => !string.IsNullOrEmpty(storage.ID)), "Storage Id can't be null or empty");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void EnumerateStorageMappingsTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                // Get Servers
                var servers = client.Servers.List(RequestHeaders);

                var response = client.StorageMappings.List(servers.Servers[0].ID, servers.Servers[1].ID, RequestHeaders);

                Assert.True(response.StorageMappings.Count > 0, "Storage mappings count can't be less than 1");
                Assert.True(response.StorageMappings.All(storageMapping => !string.IsNullOrEmpty(storageMapping.PrimaryServerId)), "Storage mapping primary server ID can't be null or empty");
                Assert.True(response.StorageMappings.All(storageMapping => !string.IsNullOrEmpty(storageMapping.PrimaryStorageId)), "Storage mapping primary storage ID can't be null or empty");
                Assert.True(response.StorageMappings.All(storageMapping => !string.IsNullOrEmpty(storageMapping.RecoveryServerId)), "Storage mapping recovery server ID can't be null or empty");
                Assert.True(response.StorageMappings.All(storageMapping => !string.IsNullOrEmpty(storageMapping.RecoveryStorageId)), "Storage mapping recovery storage ID can't be null or empty");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void CreateStorageMappingTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                // Get Servers
                var servers = client.Servers.List(RequestHeaders);

                var storagesOnPrimary = client.Storages.List(servers.Servers[0].ID, RequestHeaders);
                var storagesOnRecovery = client.Storages.List(servers.Servers[1].ID, RequestHeaders);

                StorageMappingInput mappingInput = new StorageMappingInput();
                mappingInput.PrimaryServerId = servers.Servers[0].ID;
                mappingInput.PrimaryStorageId = storagesOnPrimary.Storages[0].ID;
                mappingInput.RecoveryServerId = servers.Servers[1].ID;
                mappingInput.RecoveryStorageId = storagesOnRecovery.Storages[0].ID;

                var response = client.StorageMappings.Create(mappingInput, RequestHeaders);

                Assert.NotNull(response.Job);
                Assert.NotNull(response.Job.ID);
                Assert.True(response.Job.Errors.Count < 1, "Errors found while creating storage mapping");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void DeleteStorageMappingTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                // Get Servers
                var servers = client.Servers.List(RequestHeaders);

                var storagesOnPrimary = client.Storages.List(servers.Servers[0].ID, RequestHeaders);
                var storagesOnRecovery = client.Storages.List(servers.Servers[1].ID, RequestHeaders);

                StorageMappingInput mappingInput = new StorageMappingInput();
                mappingInput.PrimaryServerId = servers.Servers[0].ID;
                mappingInput.PrimaryStorageId = storagesOnPrimary.Storages[0].ID;
                mappingInput.RecoveryServerId = servers.Servers[1].ID;
                mappingInput.RecoveryStorageId = storagesOnRecovery.Storages[0].ID;

                var response = client.StorageMappings.Delete(mappingInput, RequestHeaders);

                Assert.NotNull(response.Job);
                Assert.NotNull(response.Job.ID);
                Assert.True(response.Job.Errors.Count < 1, "Errors found while deleting storage mapping");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
