// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.Management.StorageCache.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.StorageCache.Models;
    using Microsoft.Azure.Management.StorageCache.Tests.Fixtures;
    using Microsoft.Azure.Management.StorageCache.Tests.Utilities;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// Defines the <see cref="StorageCacheTest" />.
    /// </summary>
    [Collection("StorageCacheCollection")]
    public class StorageTargetTests : IClassFixture<StorageAccountsFixture>
    {
        /// <summary>
        /// Defines the testOutputHelper.
        /// </summary>
        private readonly ITestOutputHelper testOutputHelper;

        /// <summary>
        /// Defines the Fixture.
        /// </summary>
        private readonly StorageCacheTestFixture fixture;

        private readonly StorageAccountsFixture storageAccountsFixture;

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageTargetTests"/> class.
        /// </summary>
        /// <param name="testOutputHelper">The testOutputHelper<see cref="ITestOutputHelper"/>.</param>
        /// <param name="fixture">The Fixture<see cref="StorageCacheTestFixture"/>.</param>
        /// <param name="storageAccountsFixture">Storage account fixture<see cref="StorageAccountsFixture"/>.</param>
        public StorageTargetTests(ITestOutputHelper testOutputHelper, StorageCacheTestFixture fixture, StorageAccountsFixture storageAccountsFixture)
        {
            this.fixture = fixture;
            this.testOutputHelper = testOutputHelper;
            this.storageAccountsFixture = storageAccountsFixture;
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
                client.ApiVersion = StorageCacheTestEnvironmentUtilities.APIVersion;
                this.fixture.CacheHelper.StoragecacheManagementClient = client;
                StorageTarget storageTarget;
                var suffix = "cre";
                storageTarget = this.storageAccountsFixture.AddClfsStorageAccount(context, suffix: suffix, waitForPermissions: false, testOutputHelper: this.testOutputHelper);
                string id =
                    $"/subscriptions/{this.fixture.SubscriptionID}" +
                    $"/resourceGroups/{this.fixture.ResourceGroup.Name}" +
                    $"/providers/Microsoft.StorageCache/caches/{this.fixture.Cache.Name}" +
                    $"/storageTargets/{this.fixture.ResourceGroup.Name + suffix}";

                string clfsTarget =
                    $"/subscriptions/{this.fixture.SubscriptionID}" +
                    $"/resourceGroups/{this.fixture.ResourceGroup.Name}" +
                    $"/providers/Microsoft.Storage/storageAccounts/{this.fixture.ResourceGroup.Name + suffix}" +
                    $"/blobServices/default/containers/{this.fixture.ResourceGroup.Name + suffix}";
                Assert.Equal(this.fixture.ResourceGroup.Name + suffix, storageTarget.Name);
                Assert.Equal(id, storageTarget.Id, ignoreCase: true);
                Assert.Equal("clfs", storageTarget.TargetType);
                Assert.Equal(clfsTarget, storageTarget.Clfs.Target);
                Assert.Equal("/junction" + suffix, storageTarget.Junctions[0].NamespacePath);
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
                client.ApiVersion = StorageCacheTestEnvironmentUtilities.APIVersion;
                this.fixture.CacheHelper.StoragecacheManagementClient = client;
                StorageTarget storageTarget;
                try
                {
                    storageTarget = this.fixture.CacheHelper.GetStorageTarget(this.fixture.Cache.Name, this.fixture.ResourceGroup.Name);
                }
                catch (CloudErrorException)
                {
                    storageTarget = this.storageAccountsFixture.AddClfsStorageAccount(context, waitForStorageTarget: false, waitForPermissions: false);
                }

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
                client.ApiVersion = StorageCacheTestEnvironmentUtilities.APIVersion;
                this.fixture.CacheHelper.StoragecacheManagementClient = client;
                StorageTarget storageTarget;
                try
                {
                    storageTarget = this.fixture.CacheHelper.GetStorageTarget(this.fixture.Cache.Name, this.fixture.ResourceGroup.Name);
                }
                catch (CloudErrorException)
                {
                    storageTarget = this.storageAccountsFixture.AddClfsStorageAccount(context, waitForStorageTarget: false, waitForPermissions: false, testOutputHelper: this.testOutputHelper);
                }

                var response = this.fixture.CacheHelper.GetStorageTarget(this.fixture.Cache.Name, storageTarget.Name);
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
                client.ApiVersion = StorageCacheTestEnvironmentUtilities.APIVersion;
                this.fixture.CacheHelper.StoragecacheManagementClient = client;
                var storageTarget = this.storageAccountsFixture.AddClfsStorageAccount(context, suffix: "del", waitForPermissions: false, testOutputHelper: this.testOutputHelper);
                TestUtilities.Wait(new TimeSpan(0, 0, 60));
                this.fixture.CacheHelper.DeleteStorageTarget(this.fixture.Cache.Name, storageTarget.Name, this.testOutputHelper);
                TestUtilities.Wait(new TimeSpan(0, 0, 60));
                CloudErrorException ex = Assert.Throws<CloudErrorException>(() => this.fixture.CacheHelper.GetStorageTarget(this.fixture.Cache.Name, storageTarget.Name, true));
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
                client.ApiVersion = StorageCacheTestEnvironmentUtilities.APIVersion;
                this.fixture.CacheHelper.StoragecacheManagementClient = client;
                var storageAccount = this.storageAccountsFixture.AddStorageAccount(context, this.fixture.ResourceGroup, testOutputHelper: this.testOutputHelper);
                var blobContainer = this.storageAccountsFixture.AddBlobContainer(context, this.fixture.ResourceGroup, storageAccount);

                string invalidSubscription = "AAAAAAAA-BBBB-CCCC-DDDD-AAAAAAAAAAAA";
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
                        this.testOutputHelper,
                        maxRequestTries: 0));
                this.testOutputHelper.WriteLine($"{ex.Body.Error.Message}");
                Assert.Contains("LinkedAuthorizationFailed", ex.Body.Error.Code);
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
                client.ApiVersion = StorageCacheTestEnvironmentUtilities.APIVersion;
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
                        this.testOutputHelper,
                        maxRequestTries: 0));

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
                client.ApiVersion = StorageCacheTestEnvironmentUtilities.APIVersion;
                this.fixture.CacheHelper.StoragecacheManagementClient = client;
                var storageAccount = this.storageAccountsFixture.AddStorageAccount(context, this.fixture.ResourceGroup, testOutputHelper: this.testOutputHelper);

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
                        this.testOutputHelper,
                        maxRequestTries: 0));

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
                client.ApiVersion = StorageCacheTestEnvironmentUtilities.APIVersion;
                this.fixture.CacheHelper.StoragecacheManagementClient = client;
                var storageAccount = this.storageAccountsFixture.AddStorageAccount(context, this.fixture.ResourceGroup, testOutputHelper: this.testOutputHelper);
                var blobContainer = this.storageAccountsFixture.AddBlobContainer(context, this.fixture.ResourceGroup, storageAccount);

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
                        this.testOutputHelper,
                        maxRequestTries: 0));
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
                client.ApiVersion = StorageCacheTestEnvironmentUtilities.APIVersion;
                this.fixture.CacheHelper.StoragecacheManagementClient = client;
                var storageAccount = this.storageAccountsFixture.AddStorageAccount(context, this.fixture.ResourceGroup, testOutputHelper: this.testOutputHelper);
                var blobContainer = this.storageAccountsFixture.AddBlobContainer(context, this.fixture.ResourceGroup, storageAccount, testOutputHelper: this.testOutputHelper);

                StorageTarget storageTargetParameters = this.fixture.CacheHelper.CreateClfsStorageTargetParameters(
                    storageAccount.Name,
                    blobContainer.Name,
                    string.Empty);
                storageTargetParameters.Junctions = new List<NamespaceJunction>() { };
                var exceptionTarget = string.Empty;
                CloudErrorException ex;
                DateTimeOffset startTime = DateTimeOffset.Now;
                do
                {
                    ex = Assert.Throws<CloudErrorException>(
                    () =>
                    this.fixture.CacheHelper.CreateStorageTarget(
                        this.fixture.Cache.Name,
                        "invalidst",
                        storageTargetParameters,
                        this.testOutputHelper,
                        maxRequestTries: 0));
                    exceptionTarget = ex.Body.Error.Target;
                    if (DateTimeOffset.Now.Subtract(startTime).TotalSeconds > 600)
                    {
                        throw new TimeoutException();
                    }
                }
                while (exceptionTarget != "storageTarget.junctions");

                this.testOutputHelper.WriteLine($"{ex.Body.Error.Message}");
                this.testOutputHelper.WriteLine($"{ex.Body.Error.Code}");
                this.testOutputHelper.WriteLine($"{ex.Body.Error.Target}");
                Assert.Contains("InvalidParameter", ex.Body.Error.Code);
                Assert.Equal("storageTarget.junctions", ex.Body.Error.Target);
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
                client.ApiVersion = StorageCacheTestEnvironmentUtilities.APIVersion;
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
                        this.testOutputHelper,
                        maxRequestTries: 0));
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
                client.ApiVersion = StorageCacheTestEnvironmentUtilities.APIVersion;
                this.fixture.CacheHelper.StoragecacheManagementClient = client;
                var storageAccount = this.storageAccountsFixture.AddStorageAccount(context, this.fixture.ResourceGroup, testOutputHelper: this.testOutputHelper);
                var blobContainer = this.storageAccountsFixture.AddBlobContainer(context, this.fixture.ResourceGroup, storageAccount, testOutputHelper: this.testOutputHelper);

                StorageTarget storageTargetParameters = this.fixture.CacheHelper.CreateClfsStorageTargetParameters(
                    storageAccount.Name,
                    blobContainer.Name,
                    "Invalid#$%1");
                var exceptionTarget = string.Empty;
                CloudErrorException ex;
                DateTimeOffset startTime = DateTimeOffset.Now;
                do
                {
                    ex = Assert.Throws<CloudErrorException>(
                    () =>
                    this.fixture.CacheHelper.CreateStorageTarget(
                        this.fixture.Cache.Name,
                        "invalidst",
                        storageTargetParameters,
                        this.testOutputHelper,
                        maxRequestTries: 0));
                    exceptionTarget = ex.Body.Error.Target;
                    if (DateTimeOffset.Now.Subtract(startTime).TotalSeconds > 600)
                    {
                        throw new TimeoutException();
                    }
                }
                while (exceptionTarget != "storageTarget.junctions.namespacePath");
                this.testOutputHelper.WriteLine($"{ex.Body.Error.Message}");
                this.testOutputHelper.WriteLine($"{ex.Body.Error.Code}");
                this.testOutputHelper.WriteLine($"{ex.Body.Error.Target}");
                Assert.Contains("InvalidParameter", ex.Body.Error.Code);
                Assert.Equal("storageTarget.junctions.namespacePath", ex.Body.Error.Target);
            }
        }

        /// <summary>
        /// Test storage account permission.
        /// </summary>
        [Fact]
        public void TestStorageAccountPermission()
        {
            this.testOutputHelper.WriteLine($"Running in {HttpMockServer.GetCurrentMode()} mode.");
            using (StorageCacheTestContext context = new StorageCacheTestContext(this))
            {
                var client = context.GetClient<StorageCacheManagementClient>();
                client.ApiVersion = StorageCacheTestEnvironmentUtilities.APIVersion;
                this.fixture.CacheHelper.StoragecacheManagementClient = client;
                CloudErrorException ex = Assert.Throws<CloudErrorException>(
                    () =>
                    this.storageAccountsFixture.AddClfsStorageAccount(
                        context,
                        "perm",
                        waitForStorageTarget: false,
                        addPermissions: false,
                        testOutputHelper: this.testOutputHelper,
                        waitForPermissions: false,
                        maxRequestTries: 0));
                this.testOutputHelper.WriteLine($"{ex.Body.Error.Message}");
                this.testOutputHelper.WriteLine($"{ex.Body.Error.Code}");
                this.testOutputHelper.WriteLine($"{ex.Body.Error.Target}");
                Assert.Contains("InvalidParameter", ex.Body.Error.Code);
                Assert.Equal("storageTarget.clfs.target", ex.Body.Error.Target);
                Assert.Contains("hasn't sufficient permissions", ex.Body.Error.Message);
            }
        }
    }
}