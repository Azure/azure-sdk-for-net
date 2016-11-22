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

using System.Collections.Generic;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Management.ContainerRegistry;
using Microsoft.Azure.Management.ContainerRegistry.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ContainerRegistry.Tests
{
    public class ContainerRegistryTestUtilities
    {
        public static string DefaultLocation = "southcentralus";

        public static SkuName DefaultStorageAccountSku = SkuName.StandardGRS;
        public static Kind DefaultStorageAccountKind = Kind.Storage;

        public static Dictionary<string, string> DefaultTags = new Dictionary<string, string>
        {
            { "key1","value1"},
            { "key2","value2"}
        };

        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            ResourceManagementClient client = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
            return client;
        }

        public static StorageManagementClient GetStorageManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            StorageManagementClient client = context.GetServiceClient<StorageManagementClient>(handlers: handler);
            return client;
        }

        public static ContainerRegistryManagementClient GetContainerRegistryManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            ContainerRegistryManagementClient client = context.GetServiceClient<ContainerRegistryManagementClient>(handlers: handler);
            return client;
        }

        public static string CreateResourceGroup(ResourceManagementClient client)
        {
            var rgName = TestUtilities.GenerateName("acr_rg");

            var createRequest = client.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup
            {
                Location = DefaultLocation
            });

            return rgName;
        }

        public static string CreateStorageAccount(StorageManagementClient client, string rgName)
        {
            string storageName = TestUtilities.GenerateName("acrstorage");

            var createRequest = client.StorageAccounts.Create(rgName, storageName, new StorageAccountCreateParameters
            {
                Location = DefaultLocation,
                Sku = new Sku { Name = DefaultStorageAccountSku },
                Kind = DefaultStorageAccountKind
            });

            return storageName;
        }

        public static string CreateContainerRegistry(ContainerRegistryManagementClient client, string rgName, string storageName, string storageKey)
        {
            string registryName = TestUtilities.GenerateName("acrregistry");
            Registry registry = GetDefaultRegistryProperties(storageName, storageKey);

            var createRequest = client.Registries.CreateOrUpdate(rgName, registryName, registry);

            return registryName;
        }

        public static Registry GetDefaultRegistryProperties(string storageName, string storageKey)
        {
            Registry registry = new Registry
            {
                Location = DefaultLocation,
                StorageAccount = new StorageAccountProperties
                {
                    Name = storageName,
                    AccessKey = storageKey
                },
                Tags = DefaultTags
            };

            return registry;
        }

        public static string GetStorageAccessKey(StorageManagementClient client, string rgName, string storageName)
        {
            return client.StorageAccounts.ListKeys(rgName, storageName).Keys[0].Value;
        }

        public static void VerifyRegistryProperties(Registry registry, string storageName, bool useDefaults)
        {
            Assert.NotNull(registry);
            Assert.NotNull(registry.Id);
            Assert.NotNull(registry.Name);
            Assert.NotNull(registry.Location);
            Assert.NotNull(registry.AdminUserEnabled);
            Assert.NotNull(registry.LoginServer);
            Assert.NotNull(registry.CreationDate);
            Assert.NotNull(registry.StorageAccount);
            Assert.NotNull(registry.StorageAccount.Name);
            Assert.Null(registry.StorageAccount.AccessKey);

            Assert.Equal(registry.StorageAccount.Name, storageName);

            if (useDefaults)
            {
                Assert.Equal(registry.Location, DefaultLocation);
                Assert.Equal(registry.AdminUserEnabled, false);
                Assert.NotNull(registry.Tags);
                Assert.Equal(2, registry.Tags.Count);
                Assert.Equal(registry.Tags["key1"], "value1");
                Assert.Equal(registry.Tags["key2"], "value2");
            }
        }
    }
}
