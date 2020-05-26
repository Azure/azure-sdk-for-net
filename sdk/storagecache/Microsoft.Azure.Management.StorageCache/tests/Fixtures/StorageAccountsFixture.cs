// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.Management.StorageCache.Tests.Fixtures
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.Management.Storage;
    using Microsoft.Azure.Management.Storage.Models;
    using Microsoft.Azure.Management.StorageCache.Models;
    using Microsoft.Azure.Management.StorageCache.Tests.Helpers;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// Storage account fixture to share created storage accounts between the tests in same class.
    /// </summary>
    [Collection("StorageCacheCollection")]
    public class StorageAccountsFixture : IDisposable
    {
        /// <summary>
        /// Defines the Fixture.
        /// </summary>
        private readonly StorageCacheTestFixture fixture;

        /// <summary>
        /// Defines the storage accounts cache.
        /// </summary>
        private readonly Dictionary<string, StorageAccount> storageAccountsCache = new Dictionary<string, StorageAccount>();

        /// <summary>
        /// Defines the blob containers cache.
        /// </summary>
        private readonly Dictionary<string, BlobContainer> blobContainersCache = new Dictionary<string, BlobContainer>();

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageAccountsFixture"/> class.
        /// </summary>
        /// <param name="fixture">StorageCacheTestFixture.</param>
        public StorageAccountsFixture(StorageCacheTestFixture fixture)
        {
            this.fixture = fixture;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            // We do not create anything in this fixture but
            // just use the StorageCacheTestFixture which has its own disposal method.
        }

        /// <summary>
        /// Adds storage account in given resource group and applies required roles.
        /// </summary>
        /// <param name="context">StorageCacheTestContext.</param>
        /// <param name="resourceGroup">Object representing a resource group.</param>
        /// <param name="suffix">suffix.</param>
        /// <param name="addPermissions">Whether to add storage account contributor roles.</param>
        /// <param name="testOutputHelper">testOutputHelper.</param>
        /// <param name="sleep">Sleep time for permissions to get propagated.</param>
        /// <param name="waitForPermissions">Whether to wait for permissions to be propagated.</param>
        /// <returns>StorageAccount.</returns>
        public StorageAccount AddStorageAccount(
            StorageCacheTestContext context,
            ResourceGroup resourceGroup,
            string suffix = null,
            bool addPermissions = true,
            ITestOutputHelper testOutputHelper = null,
            int sleep = 300,
            bool waitForPermissions = true)
        {
            if (this.storageAccountsCache.TryGetValue(resourceGroup.Name + suffix, out StorageAccount storageAccount))
            {
                if (testOutputHelper != null)
                {
                    testOutputHelper.WriteLine($"Using existing storage account {resourceGroup.Name + suffix}");
                }

                return storageAccount;
            }

            StorageManagementClient storageManagementClient = context.GetClient<StorageManagementClient>();
            StorageAccountsHelper storageAccountsHelper = new StorageAccountsHelper(storageManagementClient, resourceGroup);
            storageAccount = storageAccountsHelper.CreateStorageAccount(resourceGroup.Name + suffix);
            if (addPermissions)
            {
                this.AddStorageAccountAccessRules(context, storageAccount);
            }

            if (waitForPermissions && HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                testOutputHelper.WriteLine($"Sleeping {sleep.ToString()} seconds while permissions propagates.");
                TestUtilities.Wait(new TimeSpan(0, 0, sleep));
            }

            this.storageAccountsCache.Add(storageAccount.Name, storageAccount);
            return storageAccount;
        }

        /// <summary>
        /// Adds blob container.
        /// </summary>
        /// <param name="context">StorageCacheTestContext.</param>
        /// <param name="resourceGroup">Object representing a resource group.</param>
        /// <param name="storageAccount">Object representing a storage account.</param>
        /// <param name="suffix">suffix.</param>
        /// <param name="testOutputHelper">testOutputHelper.</param>
        /// <returns>BlobContainer.</returns>
        public BlobContainer AddBlobContainer(
            StorageCacheTestContext context,
            ResourceGroup resourceGroup,
            StorageAccount storageAccount,
            string suffix = null,
            ITestOutputHelper testOutputHelper = null)
        {
            if (this.blobContainersCache.TryGetValue(resourceGroup.Name + suffix, out BlobContainer blobContainer))
            {
                if (testOutputHelper != null)
                {
                    testOutputHelper.WriteLine($"Using existing blob container {resourceGroup.Name + suffix}");
                }

                return blobContainer;
            }

            StorageManagementClient storageManagementClient = context.GetClient<StorageManagementClient>();
            StorageAccountsHelper storageAccountsHelper = new StorageAccountsHelper(storageManagementClient, resourceGroup);
            blobContainer = storageAccountsHelper.CreateBlobContainer(storageAccount.Name, resourceGroup.Name + suffix);
            this.blobContainersCache.Add(blobContainer.Name, blobContainer);
            return blobContainer;
        }

        /// <summary>
        /// Creates storage account, blob container and adds CLFS storage account to cache.
        /// </summary>
        /// <param name="context">StorageCacheTestContext.</param>
        /// <param name="suffix">suffix.</param>
        /// <param name="waitForStorageTarget">Whether to wait for storage target to deploy.</param>
        /// <param name="addPermissions">Whether to add storage account contributor roles.</param>
        /// <param name="testOutputHelper">testOutputHelper.</param>
        /// <param name="sleep">Sleep time for permissions to get propagated.</param>
        /// <param name="waitForPermissions">Whether to wait for permissions to be propagated.</param>
        /// <param name="maxRequestTries">Max retries.</param>
        /// <returns>StorageTarget.</returns>
        public StorageTarget AddClfsStorageAccount(
            StorageCacheTestContext context,
            string suffix = null,
            bool waitForStorageTarget = true,
            bool addPermissions = true,
            ITestOutputHelper testOutputHelper = null,
            int sleep = 300,
            bool waitForPermissions = true,
            int maxRequestTries = 25)
        {
            string storageTargetName = string.IsNullOrEmpty(suffix) ? this.fixture.ResourceGroup.Name : this.fixture.ResourceGroup.Name + suffix;
            string junction = "/junction" + suffix;
            var storageAccount = this.AddStorageAccount(
                context,
                this.fixture.ResourceGroup,
                suffix,
                addPermissions,
                testOutputHelper,
                sleep: sleep,
                waitForPermissions: waitForPermissions);
            var blobContainer = this.AddBlobContainer(context, this.fixture.ResourceGroup, storageAccount, suffix, testOutputHelper);
            StorageTarget storageTargetParameters = this.fixture.CacheHelper.CreateClfsStorageTargetParameters(
                storageAccount.Name,
                blobContainer.Name,
                junction);
            StorageTarget storageTarget = this.fixture.CacheHelper.CreateStorageTarget(
                this.fixture.Cache.Name,
                storageTargetName,
                storageTargetParameters,
                testOutputHelper,
                waitForStorageTarget,
                maxRequestTries);

            if (testOutputHelper != null)
            {
                testOutputHelper.WriteLine($"Storage target Name {storageTarget.Name}");
                testOutputHelper.WriteLine($"Storage target NamespacePath {storageTarget.Junctions[0].NamespacePath}");
                testOutputHelper.WriteLine($"Storage target TargetPath {storageTarget.Junctions[0].TargetPath}");
                testOutputHelper.WriteLine($"Storage target Id {storageTarget.Id}");
                testOutputHelper.WriteLine($"Storage target Target {storageTarget.Clfs.Target}");
            }

            return storageTarget;
        }

        /// <summary>
        /// Adds storage account access roles.
        /// Storage Account Contributor or Storage blob Contributor.
        /// </summary>
        /// <param name="context">Object representing a StorageCacheTestContext.</param>
        /// <param name="storageAccount">Object representing a storage account.</param>
        /// <param name="testOutputHelper">Object representing a testOutputHelper.</param>
        private void AddStorageAccountAccessRules(
            StorageCacheTestContext context,
            StorageAccount storageAccount,
            ITestOutputHelper testOutputHelper = null)
        {
            try
            {
                string role1 = "Storage Account Contributor";
                context.AddRoleAssignment(context, storageAccount.Id, role1, TestUtilities.GenerateGuid().ToString());

                // string role2 = "Storage Blob Data Contributor";
                // context.AddRoleAssignment(context, storageAccount.Id, role2, TestUtilities.GenerateGuid().ToString());
                if (testOutputHelper != null)
                {
                    testOutputHelper.WriteLine($"Added {role1} role to storage account {storageAccount.Name}.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
