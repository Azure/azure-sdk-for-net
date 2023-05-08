// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DevCenter.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DevCenter.Tests
{
    public class CatalogOperationsTests : DevCenterManagementTestBase
    {
        public CatalogOperationsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        [PlaybackOnly("")]
        public async Task CatalogResourceFull()
        {
            ResourceIdentifier devCenterId = new ResourceIdentifier(TestEnvironment.DefaultDevCenterId);

            var devCenterResponse = await Client.GetDevCenterResource(devCenterId).GetAsync();
            var devCenterResource = devCenterResponse.Value;

            CatalogCollection resourceCollection = devCenterResource.GetCatalogs();

            string resourceName = "sdktest-catalog";

            // Create a DevBox Definition resource

            var catalogData = new CatalogData()
            {
                GitHub = new GitCatalog
                {
                    Uri = new Uri(TestEnvironment.GitHubRepoUri),
                    Path = TestEnvironment.GitHubRepoPath,
                    Branch = "main",
                    SecretIdentifier = TestEnvironment.CatalogKeyVaultSecretIdentifier,
                }
            };
            CatalogResource createdResource
                = (await resourceCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, catalogData)).Value;

            Assert.NotNull(createdResource);
            Assert.NotNull(createdResource.Data);

            // List
            List<CatalogResource> resources = await resourceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(resources.Any(r => r.Id == createdResource.Id));

            // Get
            Response<CatalogResource> retrievedResource = await resourceCollection.GetAsync(resourceName);
            Assert.NotNull(retrievedResource.Value);
            Assert.NotNull(retrievedResource.Value.Data);

            // Delete
            ArmOperation deleteOp = await retrievedResource.Value.DeleteAsync(WaitUntil.Completed);
        }
    }
}
