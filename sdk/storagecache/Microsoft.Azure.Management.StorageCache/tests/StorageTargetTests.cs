// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.Management.StorageCache.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Reflection.Metadata;
    using Microsoft.Azure.Management.Storage;
    using Microsoft.Azure.Management.StorageCache.Models;
    using Microsoft.Azure.Management.StorageCache.Tests.Fixtures;
    using Microsoft.Azure.Management.StorageCache.Tests.Helpers;
    using Microsoft.Azure.Management.StorageCache.Tests.Utilities;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// Defines the <see cref="StorageCacheTest" />.
    /// </summary>
    [Collection("StorageCacheCollection")]
    public class StorageTargetTests
    {
        /// <summary>
        /// Defines the testOutputHelper.
        /// </summary>
        private readonly ITestOutputHelper testOutputHelper;

        /// <summary>
        /// Defines the Fixture.
        /// </summary>
        private readonly StorageCacheTestFixture fixture;

        // private StorageTarget storageTarget;

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageCacheTest"/> class.
        /// </summary>
        /// <param name="testOutputHelper">The testOutputHelper<see cref="ITestOutputHelper"/>.</param>
        /// <param name="fixture">The Fixture<see cref="StorageCacheTestFixture"/>.</param>
        public StorageTargetTests(ITestOutputHelper testOutputHelper, StorageCacheTestFixture fixture)
        {
            this.fixture = fixture;
            this.testOutputHelper = testOutputHelper;
        }

        /// <summary>
        /// The TestCreateClfsStorageTarget.
        /// </summary>
        [Fact]
        public void TestCreateClfsStorageTarget()
        {
            this.testOutputHelper.WriteLine($"Running in {HttpMockServer.GetCurrentMode()} mode.");
            using (StorageCacheTestContext context = new StorageCacheTestContext(this))
            {
                var client = context.GetClient<StorageCacheManagementClient>();
                client.ApiVersion = Constants.DefaultAPIVersion;
                this.fixture.CacheHelper.StoragecacheManagementClient = client;
                var storageTarget = this.AddClfsStorageAccount(context);
                string id =
                    $"/subscriptions/{this.fixture.SubscriptionID}" +
                    $"/resourceGroups/{this.fixture.ResourceGroup.Name}" +
                    $"/providers/Microsoft.StorageCache/caches/{this.fixture.Cache.Name}" +
                    $"/storageTargets/{"st-" + this.fixture.ResourceGroup.Name}";

                string clfsTarget =
                    $"/subscriptions/{this.fixture.SubscriptionID}" +
                    $"/resourceGroups/{this.fixture.ResourceGroup.Name}" +
                    $"/providers/Microsoft.Storage/storageAccounts/{this.fixture.ResourceGroup.Name}" +
                    $"/blobServices/default/containers/{"bc-" + this.fixture.ResourceGroup.Name}";
                Assert.Equal("st-" + this.fixture.ResourceGroup.Name, storageTarget.Name);
                Assert.Equal(id, storageTarget.Id, ignoreCase: true);
                Assert.Equal("clfs", storageTarget.TargetType);
                Assert.Equal(clfsTarget, storageTarget.Clfs.Target);
                Assert.Equal("/" + this.fixture.ResourceGroup.Name, storageTarget.Junctions[0].NamespacePath);
                Assert.Equal("/", storageTarget.Junctions[0].TargetPath);
            }
        }

        /// <summary>
        /// The list storage target by cache.
        /// </summary>
        [Fact]
        public void TestListStorageTargetByCache()
        {
            this.testOutputHelper.WriteLine($"Running in {HttpMockServer.GetCurrentMode()} mode.");
            using (StorageCacheTestContext context = new StorageCacheTestContext(this))
            {
                var client = context.GetClient<StorageCacheManagementClient>();
                client.ApiVersion = Constants.DefaultAPIVersion;
                this.fixture.CacheHelper.StoragecacheManagementClient = client;
                var storageTarget = this.AddClfsStorageAccount(context, "2");
                IList<StorageTarget> storageTargetListResponse = this.fixture.CacheHelper.StoragecacheManagementClient.StorageTargets.ListByCache(this.fixture.ResourceGroup.Name, this.fixture.Cache.Name).Value;
                Assert.True(storageTargetListResponse.Count >= 1);
                bool found = false;
                foreach (StorageTarget response in storageTargetListResponse)
                {
                    if (string.Equals(response.Name, storageTarget.Name))
                    {
                        found = true;
                        Assert.Equal(storageTarget.Id, response.Id, ignoreCase: true);
                        Assert.Equal(storageTarget.Clfs.Target, response.Clfs.Target);
                        Assert.Equal(storageTarget.Type, response.Type);
                        Assert.Equal(storageTarget.Junctions[0].NamespacePath, response.Junctions[0].NamespacePath);
                        Assert.Equal(storageTarget.Junctions[0].TargetPath, response.Junctions[0].TargetPath);
                    }
                }

                Assert.True(found, string.Format("Storage target {0} not found in the list response.", storageTarget.Name));
            }
        }

        /// <summary>
        /// The TestGetClfsStorageTarget.
        /// </summary>
        [Fact]
        public void TestGetClfsStorageTarget()
        {
            this.testOutputHelper.WriteLine($"Running in {HttpMockServer.GetCurrentMode()} mode.");
            using (StorageCacheTestContext context = new StorageCacheTestContext(this))
            {
                var client = context.GetClient<StorageCacheManagementClient>();
                client.ApiVersion = Constants.DefaultAPIVersion;
                this.fixture.CacheHelper.StoragecacheManagementClient = client;
                var storageTarget = this.AddClfsStorageAccount(context, "3");
                var response = this.fixture.CacheHelper.GetstorageTarget(this.fixture.Cache.Name, storageTarget.Name);
                Assert.Equal(storageTarget.Name, response.Name);
                Assert.Equal(storageTarget.Id, response.Id, ignoreCase: true);
                Assert.Equal(storageTarget.TargetType, response.TargetType);
                Assert.Equal(storageTarget.Clfs.Target, response.Clfs.Target);
                Assert.Equal(storageTarget.Name, response.Name);
            }
        }

        /// <summary>
        /// The TestDeleteClfsStorageTarget.
        /// </summary>
        [Fact]
        public void TestDeleteClfsStorageTarget()
        {
            this.testOutputHelper.WriteLine($"Running in {HttpMockServer.GetCurrentMode()} mode.");
            using (StorageCacheTestContext context = new StorageCacheTestContext(this))
            {
                var client = context.GetClient<StorageCacheManagementClient>();
                client.ApiVersion = Constants.DefaultAPIVersion;
                this.fixture.CacheHelper.StoragecacheManagementClient = client;
                var storageTarget = this.AddClfsStorageAccount(context, "4");
                this.fixture.CacheHelper.DeleteStorageTarget(this.fixture.Cache.Name, storageTarget.Name);
                TestUtilities.Wait(new TimeSpan(0, 0, 60));
                CloudErrorException ex = Assert.Throws<CloudErrorException>(() => this.fixture.CacheHelper.GetstorageTarget(this.fixture.Cache.Name, storageTarget.Name, true));
                this.testOutputHelper.WriteLine($"{ex.Body.Error.Message}");
                Assert.Contains("NotFound", ex.Body.Error.Code);
            }
        }

        /// <summary>
        /// Test clfs target with invalid subscription.
        /// </summary>
        [Fact]
        public void TestClfsTargetInvalidSubscription()
        {
            this.testOutputHelper.WriteLine($"Running in {HttpMockServer.GetCurrentMode()} mode.");
            using (StorageCacheTestContext context = new StorageCacheTestContext(this))
            {
                var client = context.GetClient<StorageCacheManagementClient>();
                client.ApiVersion = Constants.DefaultAPIVersion;
                this.fixture.CacheHelper.StoragecacheManagementClient = client;
                StorageManagementClient storageManagementClient = context.GetClient<StorageManagementClient>();
                StorageAccountsHelper storageAccountsHelper = new StorageAccountsHelper(storageManagementClient, this.fixture.ResourceGroup);
                var storageAccount = storageAccountsHelper.CreateStorageAccount(this.fixture.ResourceGroup.Name);
                var blobContainer = storageAccountsHelper.CreateBlobContainer(storageAccount.Name, this.fixture.ResourceGroup.Name);

                string invalidSubscription = Guid.NewGuid().ToString();
                StorageTarget storageTargetParameters = this.fixture.CacheHelper.CreateClfsStorageTargetParameters(
                    storageAccount.Name,
                    blobContainer.Name,
                    "/junction",
                    invalidSubscription);

                CloudErrorException ex = Assert.Throws<CloudErrorException>(
                    () =>
                    this.fixture.CacheHelper.CreateStorageTarget(
                        this.fixture.Cache.Name,
                        "invalidst",
                        storageTargetParameters,
                        this.testOutputHelper));
                this.testOutputHelper.WriteLine($"{ex.Body.Error.Message}");
                Assert.Contains("InvalidParameter", ex.Body.Error.Code);
                Assert.Equal("storageTarget.clfs.target", ex.Body.Error.Target);
            }
        }

        /// <summary>
        /// Test clfs target with invalid storage account.
        /// </summary>
        [Fact]
        public void TestClfsTargetInvalidStorageAccount()
        {
            this.testOutputHelper.WriteLine($"Running in {HttpMockServer.GetCurrentMode()} mode.");
            using (StorageCacheTestContext context = new StorageCacheTestContext(this))
            {
                var client = context.GetClient<StorageCacheManagementClient>();
                client.ApiVersion = Constants.DefaultAPIVersion;
                this.fixture.CacheHelper.StoragecacheManagementClient = client;
                StorageTarget storageTargetParameters = this.fixture.CacheHelper.CreateClfsStorageTargetParameters(
                    "invalidsa",
                    "invalidsc",
                    "/junction");

                CloudErrorException ex = Assert.Throws<CloudErrorException>(
                    () =>
                    this.fixture.CacheHelper.CreateStorageTarget(
                        this.fixture.Cache.Name,
                        "invalidst",
                        storageTargetParameters,
                        this.testOutputHelper));

                this.testOutputHelper.WriteLine($"{ex.Body.Error.Message}");
                this.testOutputHelper.WriteLine($"{ex.Body.Error.Code}");
                this.testOutputHelper.WriteLine($"{ex.Body.Error.Target}");
                Assert.Contains("InvalidParameter", ex.Body.Error.Code);
                Assert.Equal("storageTarget.clfs.target", ex.Body.Error.Target);
            }
        }

        /// <summary>
        /// Test clfs target with invalid storage container.
        /// </summary>
        [Fact]
        public void TestClfsTargetInvalidStorageContainer()
        {
            this.testOutputHelper.WriteLine($"Running in {HttpMockServer.GetCurrentMode()} mode.");
            using (StorageCacheTestContext context = new StorageCacheTestContext(this))
            {
                var client = context.GetClient<StorageCacheManagementClient>();
                client.ApiVersion = Constants.DefaultAPIVersion;
                this.fixture.CacheHelper.StoragecacheManagementClient = client;
                StorageManagementClient storageManagementClient = context.GetClient<StorageManagementClient>();
                StorageAccountsHelper storageAccountsHelper = new StorageAccountsHelper(storageManagementClient, this.fixture.ResourceGroup);
                var storageAccount = storageAccountsHelper.CreateStorageAccount(this.fixture.ResourceGroup.Name);
                StorageTarget storageTargetParameters = this.fixture.CacheHelper.CreateClfsStorageTargetParameters(
                    storageAccount.Name,
                    "invalidsc",
                    "/junction");

                CloudErrorException ex = Assert.Throws<CloudErrorException>(
                    () =>
                    this.fixture.CacheHelper.CreateStorageTarget(
                        this.fixture.Cache.Name,
                        "invalidst",
                        storageTargetParameters,
                        this.testOutputHelper));

                this.testOutputHelper.WriteLine($"{ex.Body.Error.Message}");
                this.testOutputHelper.WriteLine($"{ex.Body.Error.Code}");
                this.testOutputHelper.WriteLine($"{ex.Body.Error.Target}");
                Assert.Contains("InvalidParameter", ex.Body.Error.Code);
                Assert.Equal("storageTarget.clfs.target", ex.Body.Error.Target);
            }
        }

        /// <summary>
        /// Test clfs target with invalid resourcegroup.
        /// </summary>
        [Fact]
        public void TestClfsTargetInvalidResourceGroup()
        {
            this.testOutputHelper.WriteLine($"Running in {HttpMockServer.GetCurrentMode()} mode.");
            using (StorageCacheTestContext context = new StorageCacheTestContext(this))
            {
                var client = context.GetClient<StorageCacheManagementClient>();
                client.ApiVersion = Constants.DefaultAPIVersion;
                this.fixture.CacheHelper.StoragecacheManagementClient = client;
                StorageManagementClient storageManagementClient = context.GetClient<StorageManagementClient>();
                StorageAccountsHelper storageAccountsHelper = new StorageAccountsHelper(storageManagementClient, this.fixture.ResourceGroup);
                var storageAccount = storageAccountsHelper.CreateStorageAccount(this.fixture.ResourceGroup.Name);
                var blobContainer = storageAccountsHelper.CreateBlobContainer(storageAccount.Name, this.fixture.ResourceGroup.Name);
                StorageTarget storageTargetParameters = this.fixture.CacheHelper.CreateClfsStorageTargetParameters(
                    storageAccount.Name,
                    blobContainer.Name,
                    "/junction",
                    resourceGroupName: "invalidrs");

                CloudErrorException ex = Assert.Throws<CloudErrorException>(
                    () =>
                    this.fixture.CacheHelper.CreateStorageTarget(
                        this.fixture.Cache.Name,
                        "invalidst",
                        storageTargetParameters,
                        this.testOutputHelper));
                this.testOutputHelper.WriteLine($"{ex.Body.Error.Message}");
                this.testOutputHelper.WriteLine($"{ex.Body.Error.Code}");
                this.testOutputHelper.WriteLine($"{ex.Body.Error.Target}");
                Assert.Contains("InvalidParameter", ex.Body.Error.Code);
                Assert.Equal("storageTarget.clfs.target", ex.Body.Error.Target);
            }
        }

        /// <summary>
        /// Test clfs target with empty namespace.
        /// </summary>
        [Fact]
        public void TestClfsTargetEmptyNameSpace()
        {
            this.testOutputHelper.WriteLine($"Running in {HttpMockServer.GetCurrentMode()} mode.");
            using (StorageCacheTestContext context = new StorageCacheTestContext(this))
            {
                var client = context.GetClient<StorageCacheManagementClient>();
                client.ApiVersion = Constants.DefaultAPIVersion;
                this.fixture.CacheHelper.StoragecacheManagementClient = client;
                StorageManagementClient storageManagementClient = context.GetClient<StorageManagementClient>();
                StorageAccountsHelper storageAccountsHelper = new StorageAccountsHelper(storageManagementClient, this.fixture.ResourceGroup);
                var storageAccount = storageAccountsHelper.CreateStorageAccount(this.fixture.ResourceGroup.Name);
                var blobContainer = storageAccountsHelper.CreateBlobContainer(storageAccount.Name, this.fixture.ResourceGroup.Name);

                StorageTarget storageTargetParameters = this.fixture.CacheHelper.CreateClfsStorageTargetParameters(
                    storageAccount.Name,
                    blobContainer.Name,
                    "");
                storageTargetParameters.Junctions = new List<NamespaceJunction>() { };
                CloudErrorException ex = Assert.Throws<CloudErrorException>(
                    () =>
                    this.fixture.CacheHelper.CreateStorageTarget(
                        this.fixture.Cache.Name,
                        "invalidst",
                        storageTargetParameters,
                        this.testOutputHelper));

                this.testOutputHelper.WriteLine($"{ex.Body.Error.Message}");
                this.testOutputHelper.WriteLine($"{ex.Body.Error.Code}");
                this.testOutputHelper.WriteLine($"{ex.Body.Error.Target}");
                Assert.Contains("InvalidParameter", ex.Body.Error.Code);
                Assert.Equal("storageTarget.clfs.target", ex.Body.Error.Target);
            }
        }

        /// <summary>
        /// Test storage target with invalid target type.
        /// </summary>
        [Fact]
        public void TestStorageTargetInvalidTargetType()
        {
            this.testOutputHelper.WriteLine($"Running in {HttpMockServer.GetCurrentMode()} mode.");
            using (StorageCacheTestContext context = new StorageCacheTestContext(this))
            {
                var client = context.GetClient<StorageCacheManagementClient>();
                client.ApiVersion = Constants.DefaultAPIVersion;
                this.fixture.CacheHelper.StoragecacheManagementClient = client;
                StorageTarget storageTargetParameters = this.fixture.CacheHelper.CreateClfsStorageTargetParameters(
                    "storageAccount",
                    "blobContainer",
                    "junction");
                storageTargetParameters.TargetType = "invalid";
                CloudErrorException ex = Assert.Throws<CloudErrorException>(
                    () =>
                    this.fixture.CacheHelper.CreateStorageTarget(
                        this.fixture.Cache.Name,
                        "invalidst",
                        storageTargetParameters,
                        this.testOutputHelper));
                this.testOutputHelper.WriteLine($"{ex.Body.Error.Message}");
                this.testOutputHelper.WriteLine($"{ex.Body.Error.Code}");
                this.testOutputHelper.WriteLine($"{ex.Body.Error.Target}");
                Assert.Contains("InvalidParameter", ex.Body.Error.Code);
                Assert.Equal("storageTarget.targetType", ex.Body.Error.Target);
            }
        }

        /// <summary>
        /// Test clfs target with invalid namespace.
        /// </summary>
        [Fact]
        public void TestClfsTargetInvalidNameSpace()
        {
            this.testOutputHelper.WriteLine($"Running in {HttpMockServer.GetCurrentMode()} mode.");
            using (StorageCacheTestContext context = new StorageCacheTestContext(this))
            {
                var client = context.GetClient<StorageCacheManagementClient>();
                client.ApiVersion = Constants.DefaultAPIVersion;
                this.fixture.CacheHelper.StoragecacheManagementClient = client;
                StorageManagementClient storageManagementClient = context.GetClient<StorageManagementClient>();
                StorageAccountsHelper storageAccountsHelper = new StorageAccountsHelper(storageManagementClient, this.fixture.ResourceGroup);
                var storageAccount = storageAccountsHelper.CreateStorageAccount(this.fixture.ResourceGroup.Name);
                var blobContainer = storageAccountsHelper.CreateBlobContainer(storageAccount.Name, this.fixture.ResourceGroup.Name);

                StorageTarget storageTargetParameters = this.fixture.CacheHelper.CreateClfsStorageTargetParameters(
                    storageAccount.Name,
                    blobContainer.Name,
                    "Invalid#$%1");
                CloudErrorException ex = Assert.Throws<CloudErrorException>(
                    () =>
                    this.fixture.CacheHelper.CreateStorageTarget(
                        this.fixture.Cache.Name,
                        "invalidst",
                        storageTargetParameters,
                        this.testOutputHelper));

                this.testOutputHelper.WriteLine($"{ex.Body.Error.Message}");
                this.testOutputHelper.WriteLine($"{ex.Body.Error.Code}");
                this.testOutputHelper.WriteLine($"{ex.Body.Error.Target}");
                Assert.Contains("InvalidParameter", ex.Body.Error.Code);
                Assert.Equal("storageTarget.clfs.target", ex.Body.Error.Target);
            }
        }

        private StorageTarget AddClfsStorageAccount(StorageCacheTestContext context, string suffix = null)
        {
            StorageManagementClient storageManagementClient = context.GetClient<StorageManagementClient>();
            StorageAccountsHelper storageAccountsHelper = new StorageAccountsHelper(storageManagementClient, this.fixture.ResourceGroup);

            string prefix = string.IsNullOrEmpty(suffix) ? this.fixture.ResourceGroup.Name : this.fixture.ResourceGroup.Name + suffix;
            string storageAccountName = prefix;
            string blobContainerName = "bc-" + prefix;
            string storageTargetName = "st-" + prefix;
            string junction = prefix;
            var storageAccount = storageAccountsHelper.CreateStorageAccount(storageAccountName);
            var blobContainer = storageAccountsHelper.CreateBlobContainer(storageAccount.Name, blobContainerName);
            StorageTarget storageTargetParameters = this.fixture.CacheHelper.CreateClfsStorageTargetParameters(
                storageAccount.Name,
                blobContainer.Name,
                junction);
            StorageTarget storageTarget = this.fixture.CacheHelper.CreateStorageTarget(
                this.fixture.Cache.Name,
                storageTargetName,
                storageTargetParameters,
                this.testOutputHelper);

            this.testOutputHelper.WriteLine($"Storage target Name {storageTarget.Name}");
            this.testOutputHelper.WriteLine($"Storage target NamespacePath {storageTarget.Junctions[0].NamespacePath}");
            this.testOutputHelper.WriteLine($"Storage target TargetPath {storageTarget.Junctions[0].TargetPath}");
            this.testOutputHelper.WriteLine($"Storage target Id {storageTarget.Id}");
            this.testOutputHelper.WriteLine($"Storage target Target {storageTarget.Clfs.Target}");
            this.testOutputHelper.WriteLine($"Storage target ProvisioningState {storageTarget.ProvisioningState}");
            return storageTarget;
        }
    }
}