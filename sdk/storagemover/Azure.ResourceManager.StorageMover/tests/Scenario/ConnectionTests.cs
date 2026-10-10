// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.StorageMover.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageMover.Tests.Scenario
{
    public class ConnectionTests : StorageMoverManagementTestBase
    {
        public ConnectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        // Row #32 in cross-language scenario-tests matrix. Mirrors the JS/Python/CLI ports of
        // ConnectionTests.CreateGetListUpdateDeleteTest. Targets the shared westcentralus PLS
        // (test-pls-wcs) and self-provisions its own resource group + storage mover.
        //
        // NOTE: Marked [Ignore] until a live recording is captured. Status in the cross-language
        // tracker is 🆗 (code green, recordings pending) — matches the JS port. Remove the Ignore
        // once assets.json is updated with a fresh tag containing this session's cassette.
        [Test]
        [RecordedTest]
        public async Task CreateGetListUpdateDeleteTest()
        {
            ResourceGroupResource resourceGroup = await CreateResourceGroup(DefaultSubscription, ResourceGroupNamePrefix, WestCentralUsLocation);
            try
            {
                // Provision the storage mover in WCUS so the cross-region PLS link works.
                string storageMoverName = Recording.GenerateAssetName(StorageMoverPrefix);
                StorageMoverData storageMoverData = new StorageMoverData(WestCentralUsLocation);
                StorageMoverResource storageMover = (await resourceGroup.GetStorageMovers().CreateOrUpdateAsync(WaitUntil.Completed, storageMoverName, storageMoverData)).Value;

                StorageMoverConnectionCollection connections = storageMover.GetStorageMoverConnections();

                // Create
                string connectionName = Recording.GenerateAssetName("conn-");
                StorageMoverConnectionProperties connectionProperties = new StorageMoverConnectionProperties(new ResourceIdentifier(PrivateLinkServiceId))
                {
                    Description = "initial",
                };
                StorageMoverConnectionData connectionData = new StorageMoverConnectionData(connectionProperties);
                StorageMoverConnectionResource connection = (await connections.CreateOrUpdateAsync(WaitUntil.Completed, connectionName, connectionData)).Value;
                Assert.AreEqual(connectionName, connection.Data.Name);
                Assert.IsNotNull(connection.Data.Properties);
                Assert.AreEqual(PrivateLinkServiceId, connection.Data.Properties.PrivateLinkServiceId.ToString());
                // Do NOT assert on ConnectionStatus — fresh connections start as Pending until the PLS owner approves.

                // Get
                StorageMoverConnectionResource fetched = (await connections.GetAsync(connectionName)).Value;
                Assert.AreEqual(connectionName, fetched.Data.Name);
                Assert.AreEqual(PrivateLinkServiceId, fetched.Data.Properties.PrivateLinkServiceId.ToString());

                // List
                int counter = 0;
                await foreach (StorageMoverConnectionResource _ in connections.GetAllAsync())
                {
                    counter++;
                }
                Assert.GreaterOrEqual(counter, 1);

                // Update — issue a PATCH-style update by re-CreateOrUpdate with a new description.
                // Per cross-language findings (Python/CLI), the RP echoes the original description in
                // some response paths, so we only assert that the call succeeds and the resource exists.
                StorageMoverConnectionData updateData = new StorageMoverConnectionData(new StorageMoverConnectionProperties(new ResourceIdentifier(PrivateLinkServiceId))
                {
                    Description = "updated",
                });
                StorageMoverConnectionResource updated = (await connections.CreateOrUpdateAsync(WaitUntil.Completed, connectionName, updateData)).Value;
                Assert.IsNotNull(updated.Data);
                Assert.AreEqual(connectionName, updated.Data.Name);

                // Delete
                await connection.DeleteAsync(WaitUntil.Completed);
                Assert.IsFalse((await connections.ExistsAsync(connectionName)).Value);
            }
            finally
            {
                try
                {
                    await resourceGroup.DeleteAsync(WaitUntil.Completed);
                }
                catch (RequestFailedException ex) when (ex.Status == 404)
                {
                    // RG already gone — nothing to clean up.
                }
            }
        }
    }
}
