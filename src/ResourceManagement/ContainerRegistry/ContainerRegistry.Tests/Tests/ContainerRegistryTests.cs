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

using System;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.ContainerRegistry;
using Microsoft.Azure.Management.ContainerRegistry.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ContainerRegistry.Tests
{
    public class ContainerRegistryTests
    {
        [Fact]
        public void ContainerRegistryCheckNameTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourceClient = ContainerRegistryTestUtilities.GetResourceManagementClient(context, handler);
                var storageClient = ContainerRegistryTestUtilities.GetStorageManagementClient(context, handler);
                var registryClient = ContainerRegistryTestUtilities.GetContainerRegistryManagementClient(context, handler);

                // Create resource group and storage account
                ResourceGroup resourceGroup = ContainerRegistryTestUtilities.CreateResourceGroup(resourceClient);
                string storageName = ContainerRegistryTestUtilities.CreateStorageAccount(storageClient, resourceGroup);
                string storageKey = ContainerRegistryTestUtilities.GetStorageAccessKey(storageClient, resourceGroup, storageName);

                // Check valid name
                string registryName = TestUtilities.GenerateName("acrregistry");
                var checkNameRequest = registryClient.Registries.CheckNameAvailability(registryName);
                Assert.True(checkNameRequest.NameAvailable);
                Assert.Null(checkNameRequest.Reason);
                Assert.Null(checkNameRequest.Message);

                // Check invalid name
                registryName = "CAPS";
                checkNameRequest = registryClient.Registries.CheckNameAvailability(registryName);
                Assert.False(checkNameRequest.NameAvailable);
                Assert.Equal("Invalid", checkNameRequest.Reason);
                Assert.Equal("Registry names may contain alpha numeric characters only and must be between 5 and 50 characters",
                    checkNameRequest.Message);

                // Check name of container registry that already exists
                registryName = ContainerRegistryTestUtilities.CreateContainerRegistry(registryClient, resourceGroup, storageName, storageKey);
                checkNameRequest = registryClient.Registries.CheckNameAvailability(registryName);
                Assert.False(checkNameRequest.NameAvailable);
                Assert.Equal("AlreadyExists", checkNameRequest.Reason);
                Assert.Equal("The registry " + registryName + " is already in use.", checkNameRequest.Message);
            }
        }

        [Fact]
        public void ContainerRegistryCreateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourceClient = ContainerRegistryTestUtilities.GetResourceManagementClient(context, handler);
                var storageClient = ContainerRegistryTestUtilities.GetStorageManagementClient(context, handler);
                var registryClient = ContainerRegistryTestUtilities.GetContainerRegistryManagementClient(context, handler);

                // Create resource group and storage account
                ResourceGroup resourceGroup = ContainerRegistryTestUtilities.CreateResourceGroup(resourceClient);
                string storageName = ContainerRegistryTestUtilities.CreateStorageAccount(storageClient, resourceGroup);
                string storageKey = ContainerRegistryTestUtilities.GetStorageAccessKey(storageClient, resourceGroup, storageName);

                // Create container registry
                string registryName = TestUtilities.GenerateName("acrregistry");
                Registry registryProperties = ContainerRegistryTestUtilities.GetDefaultRegistryProperties(resourceGroup, storageName, storageKey);
                Registry registry = registryClient.Registries.CreateOrUpdate(resourceGroup.Name, registryName, registryProperties);
                ContainerRegistryTestUtilities.VerifyRegistryProperties(registry, storageName, true);

                // Create container registry with optional parameters
                registryName = TestUtilities.GenerateName("acrregistry");
                registryProperties = new Registry
                {
                    Location = resourceGroup.Location,
                    StorageAccount = new StorageAccountProperties
                    {
                        Name = storageName,
                        AccessKey = storageKey
                    },
                    Tags = ContainerRegistryTestUtilities.DefaultTags,
                    AdminUserEnabled = true
                };
                registry = registryClient.Registries.CreateOrUpdate(resourceGroup.Name, registryName, registryProperties);
                ContainerRegistryTestUtilities.VerifyRegistryProperties(registry, storageName, false);
                Assert.True(registry.AdminUserEnabled);
            }
        }

        [Fact]
        public void ContainerRegistryListBySubscriptionTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourceClient = ContainerRegistryTestUtilities.GetResourceManagementClient(context, handler);
                var storageClient = ContainerRegistryTestUtilities.GetStorageManagementClient(context, handler);
                var registryClient = ContainerRegistryTestUtilities.GetContainerRegistryManagementClient(context, handler);

                // Create resource group, storage account, and container registry
                ResourceGroup resourceGroup1 = ContainerRegistryTestUtilities.CreateResourceGroup(resourceClient);
                string storageName1 = ContainerRegistryTestUtilities.CreateStorageAccount(storageClient, resourceGroup1);
                string storageKey1 = ContainerRegistryTestUtilities.GetStorageAccessKey(storageClient, resourceGroup1, storageName1);
                string registryName1 = ContainerRegistryTestUtilities.CreateContainerRegistry(registryClient, resourceGroup1, storageName1, storageKey1);

                // Create different resource group, storage account, and container registry
                ResourceGroup resourceGroup2 = ContainerRegistryTestUtilities.CreateResourceGroup(resourceClient);
                string storageName2 = ContainerRegistryTestUtilities.CreateStorageAccount(storageClient, resourceGroup2);
                string storageKey2 = ContainerRegistryTestUtilities.GetStorageAccessKey(storageClient, resourceGroup2, storageName2);
                string registryName2 = ContainerRegistryTestUtilities.CreateContainerRegistry(registryClient, resourceGroup2, storageName2, storageKey2);

                var registries = registryClient.Registries.List();

                Registry registry1 = registries.First(
                    r => StringComparer.OrdinalIgnoreCase.Equals(r.Name, registryName1));
                ContainerRegistryTestUtilities.VerifyRegistryProperties(registry1, storageName1, true);

                Registry registry2 = registries.First(
                    r => StringComparer.OrdinalIgnoreCase.Equals(r.Name, registryName2));
                ContainerRegistryTestUtilities.VerifyRegistryProperties(registry2, storageName2, true);
            }
        }

        [Fact]
        public void ContainerRegistryListByResourceGroupTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourceClient = ContainerRegistryTestUtilities.GetResourceManagementClient(context, handler);
                var storageClient = ContainerRegistryTestUtilities.GetStorageManagementClient(context, handler);
                var registryClient = ContainerRegistryTestUtilities.GetContainerRegistryManagementClient(context, handler);

                // Create resource group and storage account
                ResourceGroup resourceGroup = ContainerRegistryTestUtilities.CreateResourceGroup(resourceClient);
                string storageName = ContainerRegistryTestUtilities.CreateStorageAccount(storageClient, resourceGroup);
                string storageKey = ContainerRegistryTestUtilities.GetStorageAccessKey(storageClient, resourceGroup, storageName);

                // Create container registries
                string registryName1 = ContainerRegistryTestUtilities.CreateContainerRegistry(registryClient, resourceGroup, storageName, storageKey);
                string registryName2 = ContainerRegistryTestUtilities.CreateContainerRegistry(registryClient, resourceGroup, storageName, storageKey);

                var registries = registryClient.Registries.ListByResourceGroup(resourceGroup.Name);
                Assert.Equal(2, registries.Count());

                ContainerRegistryTestUtilities.VerifyRegistryProperties(registries.First(), storageName, true);
                ContainerRegistryTestUtilities.VerifyRegistryProperties(registries.ToArray()[1], storageName, true);
            }
        }

        [Fact]
        public void ContainerRegistryGetTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourceClient = ContainerRegistryTestUtilities.GetResourceManagementClient(context, handler);
                var storageClient = ContainerRegistryTestUtilities.GetStorageManagementClient(context, handler);
                var registryClient = ContainerRegistryTestUtilities.GetContainerRegistryManagementClient(context, handler);

                // Create resource group and storage account
                ResourceGroup resourceGroup = ContainerRegistryTestUtilities.CreateResourceGroup(resourceClient);
                string storageName = ContainerRegistryTestUtilities.CreateStorageAccount(storageClient, resourceGroup);
                string storageKey = ContainerRegistryTestUtilities.GetStorageAccessKey(storageClient, resourceGroup, storageName);

                // Get default registry properties
                Registry registryProperties = ContainerRegistryTestUtilities.GetDefaultRegistryProperties(resourceGroup, storageName, storageKey);

                // Create container registry with admin enabled
                string registryName = TestUtilities.GenerateName("acrregistry");
                registryProperties.AdminUserEnabled = true;
                registryClient.Registries.CreateOrUpdate(resourceGroup.Name, registryName, registryProperties);
                Registry registry = registryClient.Registries.GetProperties(resourceGroup.Name, registryName);
                ContainerRegistryTestUtilities.VerifyRegistryProperties(registry, storageName, false);
                Assert.True(registry.AdminUserEnabled);

                // Create container registry with admin disabled
                registryName = TestUtilities.GenerateName("acrregistry");
                registryProperties.AdminUserEnabled = false;
                registryClient.Registries.CreateOrUpdate(resourceGroup.Name, registryName, registryProperties);
                registry = registryClient.Registries.GetProperties(resourceGroup.Name, registryName);
                ContainerRegistryTestUtilities.VerifyRegistryProperties(registry, storageName, true);
            }
        }

        [Fact]
        public void ContainerRegistryUpdateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourceClient = ContainerRegistryTestUtilities.GetResourceManagementClient(context, handler);
                var storageClient = ContainerRegistryTestUtilities.GetStorageManagementClient(context, handler);
                var registryClient = ContainerRegistryTestUtilities.GetContainerRegistryManagementClient(context, handler);

                // Create resource group and storage account
                ResourceGroup resourceGroup = ContainerRegistryTestUtilities.CreateResourceGroup(resourceClient);
                string storageName1 = ContainerRegistryTestUtilities.CreateStorageAccount(storageClient, resourceGroup);
                string storageKey1 = ContainerRegistryTestUtilities.GetStorageAccessKey(storageClient, resourceGroup, storageName1);

                // Create a different storage account
                string storageName2 = ContainerRegistryTestUtilities.CreateStorageAccount(storageClient, resourceGroup);
                string storageKey2 = ContainerRegistryTestUtilities.GetStorageAccessKey(storageClient, resourceGroup, storageName2);

                // Create container registry
                string registryName = ContainerRegistryTestUtilities.CreateContainerRegistry(registryClient, resourceGroup, storageName1, storageKey1);

                // Enable admin
                RegistryUpdateParameters registryUpdateParameters = new RegistryUpdateParameters
                {
                    AdminUserEnabled = true
                };
                registryClient.Registries.Update(resourceGroup.Name, registryName, registryUpdateParameters);

                // Validate
                Registry registry = registryClient.Registries.GetProperties(resourceGroup.Name, registryName);
                Assert.True(registry.AdminUserEnabled);

                // Update tags
                registryUpdateParameters = new RegistryUpdateParameters
                {
                    Tags = new Dictionary<string, string>
                    {
                        {"key2","value2"},
                        {"key3","value3"},
                        {"key4","value4"}
                    }
                };
                registryClient.Registries.Update(resourceGroup.Name, registryName, registryUpdateParameters);

                // Validate
                registry = registryClient.Registries.GetProperties(resourceGroup.Name, registryName);
                Assert.Equal(registry.Tags.Count, registryUpdateParameters.Tags.Count);
                Assert.Equal(registry.Tags["key2"], "value2");
                Assert.Equal(registry.Tags["key3"], "value3");
                Assert.Equal(registry.Tags["key4"], "value4");

                // Update storage account
                registryUpdateParameters = new RegistryUpdateParameters
                {
                    StorageAccount = new StorageAccountProperties
                    {
                        Name = storageName2,
                        AccessKey = storageKey2
                    }
                };
                registryClient.Registries.Update(resourceGroup.Name, registryName, registryUpdateParameters);

                // Validate
                registry = registryClient.Registries.GetProperties(resourceGroup.Name, registryName);
                Assert.Equal(registry.StorageAccount.Name, storageName2);
            }
        }

        [Fact]
        public void ContainerRegistryUpdateWithCreateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourceClient = ContainerRegistryTestUtilities.GetResourceManagementClient(context, handler);
                var storageClient = ContainerRegistryTestUtilities.GetStorageManagementClient(context, handler);
                var registryClient = ContainerRegistryTestUtilities.GetContainerRegistryManagementClient(context, handler);

                // Create resource group and storage account
                ResourceGroup resourceGroup = ContainerRegistryTestUtilities.CreateResourceGroup(resourceClient);
                string storageName1 = ContainerRegistryTestUtilities.CreateStorageAccount(storageClient, resourceGroup);
                string storageKey1 = ContainerRegistryTestUtilities.GetStorageAccessKey(storageClient, resourceGroup, storageName1);

                // Create a different storage account
                string storageName2 = ContainerRegistryTestUtilities.CreateStorageAccount(storageClient, resourceGroup);
                string storageKey2 = ContainerRegistryTestUtilities.GetStorageAccessKey(storageClient, resourceGroup, storageName2);

                // Create container registry
                string registryName = ContainerRegistryTestUtilities.CreateContainerRegistry(registryClient, resourceGroup, storageName1, storageKey1);
                Registry registryProperties = registryClient.Registries.GetProperties(resourceGroup.Name, registryName);

                // Enable admin
                registryProperties.AdminUserEnabled = true;
                registryProperties.StorageAccount.AccessKey = storageKey1;
                registryClient.Registries.CreateOrUpdate(resourceGroup.Name, registryName, registryProperties);

                // Validate
                Registry registry = registryClient.Registries.GetProperties(resourceGroup.Name, registryName);
                Assert.True(registry.AdminUserEnabled);

                // Update tags
                registryProperties.Tags = new Dictionary<string, string>
                {
                    { "key2","value2" },
                    { "key3","value3" },
                    { "key4","value4" }
                };
                registryProperties.StorageAccount.AccessKey = storageKey1;
                registryClient.Registries.CreateOrUpdate(resourceGroup.Name, registryName, registryProperties);

                // Validate
                registry = registryClient.Registries.GetProperties(resourceGroup.Name, registryName);
                Assert.Equal(registry.Tags.Count, registryProperties.Tags.Count);
                Assert.Equal(registry.Tags["key2"], "value2");
                Assert.Equal(registry.Tags["key3"], "value3");
                Assert.Equal(registry.Tags["key4"], "value4");

                // Update storage account
                registryProperties.StorageAccount = new StorageAccountProperties
                {
                    Name = storageName2,
                    AccessKey = storageKey2
                };
                registryClient.Registries.CreateOrUpdate(resourceGroup.Name, registryName, registryProperties);

                // Validate
                registry = registryClient.Registries.GetProperties(resourceGroup.Name, registryName);
                Assert.Equal(registry.StorageAccount.Name, storageName2);

                // Update location should fail
                registryProperties.Location = ContainerRegistryTestUtilities.GetNonDefaultRegistryLocation(resourceClient);
                try
                {
                    registryClient.Registries.CreateOrUpdate(resourceGroup.Name, registryName, registryProperties);
                    Assert.True(false);
                }
                catch (CloudException ex)
                {
                    Assert.NotNull(ex);
                    Assert.Equal(HttpStatusCode.Conflict, ex.Response.StatusCode);
                }
            }
        }

        [Fact]
        public void ContainerRegistryGetCredentialsTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourceClient = ContainerRegistryTestUtilities.GetResourceManagementClient(context, handler);
                var storageClient = ContainerRegistryTestUtilities.GetStorageManagementClient(context, handler);
                var registryClient = ContainerRegistryTestUtilities.GetContainerRegistryManagementClient(context, handler);

                // Create resource group and storage account
                ResourceGroup resourceGroup = ContainerRegistryTestUtilities.CreateResourceGroup(resourceClient);
                string storageName = ContainerRegistryTestUtilities.CreateStorageAccount(storageClient, resourceGroup);
                string storageKey = ContainerRegistryTestUtilities.GetStorageAccessKey(storageClient, resourceGroup, storageName);

                // Create container registry with admin disabled
                string registryName = ContainerRegistryTestUtilities.CreateContainerRegistry(registryClient, resourceGroup, storageName, storageKey);

                // Get credentials should fail when admin is disabled
                try
                {
                    registryClient.Registries.GetCredentials(resourceGroup.Name, registryName);
                    Assert.True(false);
                }
                catch (CloudException ex)
                {
                    Assert.NotNull(ex);
                    Assert.Equal(HttpStatusCode.BadRequest, ex.Response.StatusCode);
                }

                // Enable admin
                RegistryUpdateParameters registryUpdateParameters = new RegistryUpdateParameters
                {
                    AdminUserEnabled = true
                };
                registryClient.Registries.Update(resourceGroup.Name, registryName, registryUpdateParameters);

                RegistryCredentials credentials = registryClient.Registries.GetCredentials(resourceGroup.Name, registryName);
                Assert.NotNull(credentials);

                // Validate username and password
                string username = credentials.Username;
                string password = credentials.Password;
                Assert.NotNull(username);
                Assert.NotNull(password);
            }
        }

        [Fact]
        public void ContainerRegistryRegenerateCredentialsTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourceClient = ContainerRegistryTestUtilities.GetResourceManagementClient(context, handler);
                var storageClient = ContainerRegistryTestUtilities.GetStorageManagementClient(context, handler);
                var registryClient = ContainerRegistryTestUtilities.GetContainerRegistryManagementClient(context, handler);

                // Create resource group and storage account
                ResourceGroup resourceGroup = ContainerRegistryTestUtilities.CreateResourceGroup(resourceClient);
                string storageName = ContainerRegistryTestUtilities.CreateStorageAccount(storageClient, resourceGroup);
                string storageKey = ContainerRegistryTestUtilities.GetStorageAccessKey(storageClient, resourceGroup, storageName);

                string registryName = TestUtilities.GenerateName("acrregistry");
                Registry registryProperties = ContainerRegistryTestUtilities.GetDefaultRegistryProperties(resourceGroup, storageName, storageKey);
                registryProperties.AdminUserEnabled = true;
                Registry registry = registryClient.Registries.CreateOrUpdate(resourceGroup.Name, registryName, registryProperties);

                RegistryCredentials credentials = registryClient.Registries.GetCredentials(resourceGroup.Name, registryName);
                Assert.NotNull(credentials);

                // Validate username and password
                string username1 = credentials.Username;
                string password1 = credentials.Password;
                Assert.NotNull(username1);
                Assert.NotNull(password1);

                credentials = registryClient.Registries.RegenerateCredentials(resourceGroup.Name, registryName);
                Assert.NotNull(credentials);

                // Validate regenerated username and password
                string username2 = credentials.Username;
                string password2 = credentials.Password;
                Assert.NotNull(username2);
                Assert.NotNull(password2);

                // Validate if generated password is different
                Assert.Equal(username1, username2);
                Assert.NotEqual(password1, password2);
            }
        }

        [Fact]
        public void ContainerRegistryDeleteTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourceClient = ContainerRegistryTestUtilities.GetResourceManagementClient(context, handler);
                var storageClient = ContainerRegistryTestUtilities.GetStorageManagementClient(context, handler);
                var registryClient = ContainerRegistryTestUtilities.GetContainerRegistryManagementClient(context, handler);

                // Create resource group and storage account
                ResourceGroup resourceGroup = ContainerRegistryTestUtilities.CreateResourceGroup(resourceClient);
                string storageName = ContainerRegistryTestUtilities.CreateStorageAccount(storageClient, resourceGroup);
                string storageKey = ContainerRegistryTestUtilities.GetStorageAccessKey(storageClient, resourceGroup, storageName);

                // Delete a container registry which does not exist
                registryClient.Registries.Delete(resourceGroup.Name, "doesnotexist");

                // Create a container registry
                string registryName = ContainerRegistryTestUtilities.CreateContainerRegistry(registryClient, resourceGroup, storageName, storageKey);

                // Delete the container registry
                registryClient.Registries.Delete(resourceGroup.Name, registryName);

                // Delete the container registry again
                registryClient.Registries.Delete(resourceGroup.Name, registryName);
            }
        }
    }
}
