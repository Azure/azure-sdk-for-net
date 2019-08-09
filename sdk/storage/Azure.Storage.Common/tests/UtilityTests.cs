// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Files;
using Azure.Storage.Files.Models;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Common.Test
{
    [TestFixture]
    public class UtilityTests
    {
        /// <summary>
        /// Our account periodically fills up with leftover "garbage" from
        /// tests that leak resources (or more likely from tests that are being
        /// debugged and stopped before cleanup) which complicates recording.
        ///
        /// This test is marked [Explicit] so it will only execute when
        /// explicitly run and will delete all the top level "container"s in
        /// your test storage tenants.
        /// </summary>
        [Test]
        [Explicit]
        public async Task CollectGarbage_Explicit()
        {
            // Get all of our configs
            var configs = new List<TenantConfiguration>();
            try { configs.Add(TestConfigurations.DefaultTargetTenant); } catch (InconclusiveException) { }
            try { configs.Add(TestConfigurations.DefaultSecondaryTargetTenant); } catch (InconclusiveException) { }
            try { configs.Add(TestConfigurations.DefaultTargetPremiumBlobTenant); } catch (InconclusiveException) { }
            try { configs.Add(TestConfigurations.DefaultTargetPreviewBlobTenant); } catch (InconclusiveException) { }
            try { configs.Add(TestConfigurations.DefaultTargetOAuthTenant); } catch (InconclusiveException) { }
            foreach (var config in configs)
            {
                // Blobs
                var blobs = new BlobServiceClient(config.ConnectionString);
                await foreach (var container in blobs.GetContainersAsync())
                {
                    try
                    {
                        await blobs.DeleteBlobContainerAsync(container.Value.Name);
                    }
                    catch (StorageRequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.LeaseIdMissing)
                    {
                        // Break any lingering leases
                        await blobs.GetBlobContainerClient(container.Value.Name).GetLeaseClient().BreakAsync();
                    }
                    catch (StorageRequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.ContainerBeingDeleted)
                    {
                        // Ignore anything already being deleted
                    }
                }

                // Queues
                var queues = new QueueServiceClient(config.ConnectionString);
                await foreach (var queue in queues.GetQueuesAsync())
                {
                    try
                    {
                        await queues.DeleteQueueAsync(queue.Value.Name);
                    }
                    catch (StorageRequestFailedException ex) when (ex.ErrorCode == QueueErrorCode.QueueBeingDeleted)
                    {
                        // Ignore anything already being deleted
                    }
                }

                // Files
                var files = new FileServiceClient(config.ConnectionString);
                await foreach (var share in files.GetSharesAsync())
                {
                    try
                    {
                        await files.DeleteShareAsync(share.Value.Name);
                    }
                    catch (StorageRequestFailedException ex) when (ex.ErrorCode == FileErrorCode.ShareBeingDeleted)
                    {
                        // Ignore anything already being deleted
                    }
                }
            }
        }
    }
}
