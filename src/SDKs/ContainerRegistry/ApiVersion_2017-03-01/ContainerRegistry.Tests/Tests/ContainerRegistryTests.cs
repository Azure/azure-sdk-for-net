// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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

                // Check disallowed name
                registryName = "Microsoft";
                checkNameRequest = registryClient.Registries.CheckNameAvailability(registryName);
                Assert.False(checkNameRequest.NameAvailable);
                Assert.Equal("Invalid", checkNameRequest.Reason);
                Assert.Equal("The specified registry name is disallowed", checkNameRequest.Message);

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
                RegistryCreateParameters parameters = ContainerRegistryTestUtilities.GetDefaultRegistryCreateParameters(resourceGroup, storageName, storageKey);
                Registry registry = registryClient.Registries.Create(resourceGroup.Name, registryName, parameters);
                ContainerRegistryTestUtilities.VerifyRegistryProperties(registry, storageName, true);

                // Create container registry with optional parameters
                registryName = TestUtilities.GenerateName("acrregistry");
                parameters = new RegistryCreateParameters
                {
                    Location = resourceGroup.Location,
                    Sku = new Microsoft.Azure.Management.ContainerRegistry.Models.Sku
                    {
                        Name = "Basic"
                    },
                    StorageAccount = new StorageAccountParameters
                    {
                        Name = storageName,
                        AccessKey = storageKey
                    },
                    Tags = ContainerRegistryTestUtilities.DefaultTags,
                    AdminUserEnabled = true
                };
                registry = registryClient.Registries.Create(resourceGroup.Name, registryName, parameters);
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
                RegistryCreateParameters parameters = ContainerRegistryTestUtilities.GetDefaultRegistryCreateParameters(resourceGroup, storageName, storageKey);

                // Create container registry with admin enabled
                string registryName = TestUtilities.GenerateName("acrregistry");
                parameters.AdminUserEnabled = true;
                registryClient.Registries.Create(resourceGroup.Name, registryName, parameters);
                Registry registry = registryClient.Registries.Get(resourceGroup.Name, registryName);
                ContainerRegistryTestUtilities.VerifyRegistryProperties(registry, storageName, false);
                Assert.True(registry.AdminUserEnabled);

                // Create container registry with admin disabled
                registryName = TestUtilities.GenerateName("acrregistry");
                parameters.AdminUserEnabled = false;
                registryClient.Registries.Create(resourceGroup.Name, registryName, parameters);
                registry = registryClient.Registries.Get(resourceGroup.Name, registryName);
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
                Registry registry = registryClient.Registries.Get(resourceGroup.Name, registryName);
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
                registry = registryClient.Registries.Get(resourceGroup.Name, registryName);
                Assert.Equal(registry.Tags.Count, registryUpdateParameters.Tags.Count);
                Assert.Equal(registry.Tags["key2"], "value2");
                Assert.Equal(registry.Tags["key3"], "value3");
                Assert.Equal(registry.Tags["key4"], "value4");

                // Update storage account
                registryUpdateParameters = new RegistryUpdateParameters
                {
                    StorageAccount = new StorageAccountParameters
                    {
                        Name = storageName2,
                        AccessKey = storageKey2
                    }
                };
                registryClient.Registries.Update(resourceGroup.Name, registryName, registryUpdateParameters);

                // Validate
                registry = registryClient.Registries.Get(resourceGroup.Name, registryName);
                Assert.Equal(registry.StorageAccount.Name, storageName2);
            }
        }

        [Fact]
        public void ContainerRegistryListCredentialsTest()
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
                    registryClient.Registries.ListCredentials(resourceGroup.Name, registryName);
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

                RegistryListCredentialsResult credentials = registryClient.Registries.ListCredentials(resourceGroup.Name, registryName);
                Assert.NotNull(credentials);

                // Validate username and password
                string username = credentials.Username;
                Assert.True(credentials.Passwords.Count > 1);
                string password1 = credentials.Passwords[0].Value;
                string password2 = credentials.Passwords[1].Value;
                Assert.NotNull(username);
                Assert.NotNull(password1);
                Assert.NotNull(password2);
            }
        }

        [Fact]
        public void ContainerRegistryRegenerateCredentialTest()
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
                RegistryCreateParameters parameters = ContainerRegistryTestUtilities.GetDefaultRegistryCreateParameters(resourceGroup, storageName, storageKey);
                parameters.AdminUserEnabled = true;
                Registry registry = registryClient.Registries.Create(resourceGroup.Name, registryName, parameters);

                RegistryListCredentialsResult credentials = registryClient.Registries.ListCredentials(resourceGroup.Name, registryName);
                Assert.NotNull(credentials);

                // Validate username and password
                string username_1 = credentials.Username;
                Assert.True(credentials.Passwords.Count > 1);
                string password1_1 = credentials.Passwords[0].Value;
                string password2_1 = credentials.Passwords[1].Value;
                Assert.NotNull(username_1);
                Assert.NotNull(password1_1);
                Assert.NotNull(password2_1);

                credentials = registryClient.Registries.RegenerateCredential(resourceGroup.Name, registryName, PasswordName.Password);
                Assert.NotNull(credentials);

                // Validate username and password
                string username_2 = credentials.Username;
                Assert.True(credentials.Passwords.Count > 1);
                string password1_2 = credentials.Passwords[0].Value;
                string password2_2 = credentials.Passwords[1].Value;
                Assert.NotNull(username_2);
                Assert.NotNull(password1_2);
                Assert.NotNull(password2_2);

                // Validate if generated password is different
                Assert.Equal(username_1, username_2);
                Assert.NotEqual(password1_1, password1_2);
                Assert.Equal(password2_1, password2_2);

                credentials = registryClient.Registries.RegenerateCredential(resourceGroup.Name, registryName, PasswordName.Password2);
                Assert.NotNull(credentials);

                // Validate username and password
                string username_3 = credentials.Username;
                Assert.True(credentials.Passwords.Count > 1);
                string password1_3 = credentials.Passwords[0].Value;
                string password2_3 = credentials.Passwords[1].Value;
                Assert.NotNull(username_2);
                Assert.NotNull(password1_2);
                Assert.NotNull(password2_2);

                // Validate if generated password is different
                Assert.Equal(username_2, username_3);
                Assert.Equal(password1_2, password1_3);
                Assert.NotEqual(password2_2, password2_3);
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
