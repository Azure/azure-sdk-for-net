﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the Event Hubs
    ///   migration guides.
    /// </summary>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    [SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Example assignments needed for snippet output content.")]
    public class MigrationGuideSnippetsLiveTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task MigrateCheckpoints()
        {
            await using var storageScope = await StorageScope.CreateAsync();

            #region Snippet:EventHubs_Migrate_Checkpoints

            var fullyQualifiedNamespace = "<< NAMESPACE (likely similar to {your-namespace}.servicebus.windows.net) >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var consumerGroup = "<< NAME OF THE EVENT HUB CONSUMER GROUP >>";
            /*@@*/
            /*@@*/ fullyQualifiedNamespace = EventHubsTestEnvironment.Instance.FullyQualifiedNamespace;
            /*@@*/ eventHubName = "fake-hub";
            /*@@*/ consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

            var storageConnectionString = "<< CONNECTION STRING FOR THE STORAGE ACCOUNT >>";
            var blobContainerName = "<< NAME OF THE BLOB CONTAINER  >>";
            var legacyBlobContainerName = "<< NAME OF THE BLOB CONTAINER THAT CONTAINS THE LEGACY DATA>>";
            /*@@*/
            /*@@*/ storageConnectionString = StorageTestEnvironment.Instance.StorageConnectionString;
            /*@@*/ blobContainerName = storageScope.ContainerName;

            using var cancellationSource = new CancellationTokenSource();

            // Read the legacy checkpoints; these are read eagerly, as the number of partitions
            // for an Event Hub is limited so the set should be a manageable size to hold in memory.
            //
            // Note: The ReadLegacyCheckpoints method will be defined in another snippet.

            /*@@*/ var legacyCheckpoints = ReadFakeLegacyCheckpoints(legacyBlobContainerName);
            /*@@*/
            //@@var legacyCheckpoints = await ReadLegacyCheckpoints(
                //@@storageConnectionString,
                //@@legacyBlobContainerName,
                //@@consumerGroup,
                //@@cancellationSource.Token);

            // The member names of MigrationCheckpoint match the names of the checkpoint
            // names of the checkpoint metadata keys.

            var offsetKey = nameof(MigrationCheckpoint.Offset).ToLowerInvariant();
            var sequenceKey = nameof(MigrationCheckpoint.SequenceNumber).ToLowerInvariant();

            // The checkpoint blobs require a specific naming scheme to be valid for use
            // with the EventProcessorClient.

            var prefix = string.Format(
                "{0}/{1}/{2}/checkpoint/",
                fullyQualifiedNamespace.ToLowerInvariant(),
                eventHubName.ToLowerInvariant(),
                consumerGroup.ToLowerInvariant());

            // Create the storage client to write the migrated checkpoints.  This example
            // assumes that the connection string grants the appropriate permissions to create a
            // container in the storage account.

            var storageClient = new BlobContainerClient(storageConnectionString, blobContainerName);
            await storageClient.CreateIfNotExistsAsync(cancellationToken: cancellationSource.Token);

            // Translate each of the legacy checkpoints, storing the offset and
            // sequence data into the correct blob for use with the EventProcesorClient.

            foreach (var checkpoint in legacyCheckpoints)
            {
                var metadata = new Dictionary<string, string>()
                {
                    { offsetKey, checkpoint.Offset.ToString(CultureInfo.InvariantCulture) },
                    { sequenceKey, checkpoint.SequenceNumber.ToString(CultureInfo.InvariantCulture) }
                };

                BlobClient blobClient = storageClient.GetBlobClient($"{ prefix }{ checkpoint.PartitionId }");

                using var content = new MemoryStream(Array.Empty<byte>());
                await blobClient.UploadAsync(content, metadata: metadata, cancellationToken: cancellationSource.Token);
            }

            #endregion
        }

        /// <summary>
        ///   Reads and parses a set of fake legacy checkpoint
        ///   data in JSON format.
        /// </summary>
        ///
        /// <param name="=fakeContainerName">The name of a fake container; used only to avoid warnings in the calling code.</param>
        ///
        /// <returns>The set of fake legacy checkpoints.</returns>
        ///
        private IEnumerable<MigrationCheckpoint> ReadFakeLegacyCheckpoints(string fakeContainerName)
        {
            var checkpointJson = @"[
            {
                ""PartitionId"":""1"",
                ""Owner"":""eecd42df-a253-49d1-bb04-e5f00c106cfc"",
                ""Token"":""6271aadb-801f-4ec7-a011-a008808a656c"",
                ""Epoch"":5,
                ""Offset"":""400"",
                ""SequenceNumber"":125
            },
            {
                ""PartitionId"":""2"",
                ""Owner"":""eecd42df-a253-49d1-bb04-e5f00c106cfc"",
                ""Token"":""6271aadb-801f-4ec7-a011-a008808a656c"",
                ""Epoch"":1,
                ""Offset"":""78"",
                ""SequenceNumber"":39
            }]";

            return JsonSerializer.Deserialize<MigrationCheckpoint[]>(checkpointJson);
        }

        #region Snippet:EventHubs_Migrate_LegacyCheckpoints

        private async Task<List<MigrationCheckpoint>> ReadLegacyCheckpoints(
            string connectionString,
            string container,
            string consumerGroup,
            CancellationToken cancellationToken)
        {
            var storageClient = new BlobContainerClient(connectionString, container);

            // If there is no container, no action can be taken.

            if (!(await storageClient.ExistsAsync(cancellationToken)))
            {
                throw new ArgumentException("The source container does not exist.", nameof(container));
            }

            // Read and process the legacy checkpoints.

            var checkpoints = new List<MigrationCheckpoint>();

            await foreach (var blobItem in storageClient.GetBlobsAsync(BlobTraits.All, BlobStates.All, consumerGroup, cancellationToken))
            {
                using var blobContentStream = new MemoryStream();
                await (storageClient.GetBlobClient(blobItem.Name)).DownloadToAsync(blobContentStream);

                var checkpoint = JsonSerializer.Deserialize<MigrationCheckpoint>(Encoding.UTF8.GetString(blobContentStream.ToArray()));
                checkpoints.Add(checkpoint);
            }

            return checkpoints;
        }

        #endregion

        #region Snippet:EventHubs_Migrate_CheckpointFormat

        private class MigrationCheckpoint
        {
            public string PartitionId { get; set; }
            public string Offset { get; set; }
            public long SequenceNumber { get; set; }
        }

        #endregion
    }
}
