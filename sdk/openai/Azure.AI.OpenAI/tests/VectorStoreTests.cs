// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.OpenAI.Tests.Utils.Config;
using NUnit.Framework;
using OpenAI;
using OpenAI.Assistants;
using OpenAI.Files;
using OpenAI.TestFramework;
using OpenAI.VectorStores;

namespace Azure.AI.OpenAI.Tests;

public class VectorStoreTests : AoaiTestBase<VectorStoreClient>
{
    public VectorStoreTests(bool isAsync) : base(isAsync)
    { }

    [Test]
    [Category("Smoke")]
    public void CanCreateClient()
    {
        VectorStoreClient client = GetTestClient();
        Assert.That(client, Is.Not.Null);
    }

    [RecordedTest]
    public async Task CanCreateGetAndDeleteVectorStores()
    {
        VectorStoreClient client = GetTestClient();

        VectorStore vectorStore = await client.CreateVectorStoreAsync();
        Validate(vectorStore);
        VectorStoreDeletionResult deletionResult = await client.DeleteVectorStoreAsync(vectorStore);
        Assert.That(deletionResult.VectorStoreId, Is.EqualTo(vectorStore.Id));
        Assert.That(deletionResult.Deleted, Is.True);

        IReadOnlyList<OpenAIFileInfo> testFiles = await GetNewTestFilesAsync(client.GetConfigOrThrow(), 5);

        vectorStore = await client.CreateVectorStoreAsync(new VectorStoreCreationOptions()
        {
            FileIds = { testFiles[0].Id },
            Name = "test vector store",
            ExpirationPolicy = new VectorStoreExpirationPolicy()
            {
                Anchor = VectorStoreExpirationAnchor.LastActiveAt,
                Days = 3,
            },
            Metadata =
            {
                ["test-key"] = "test-value",
            },
        });
        Validate(vectorStore);
        Assert.Multiple(() =>
        {
            Assert.That(vectorStore.Name, Is.EqualTo("test vector store"));
            Assert.That(vectorStore.ExpirationPolicy?.Anchor, Is.EqualTo(VectorStoreExpirationAnchor.LastActiveAt));
            Assert.That(vectorStore.ExpirationPolicy?.Days, Is.EqualTo(3));
            Assert.That(vectorStore.FileCounts.Total, Is.EqualTo(1));
            Assert.That(vectorStore.CreatedAt, Is.GreaterThan(s_2024));
            Assert.That(vectorStore.ExpiresAt, Is.GreaterThan(s_2024));
            Assert.That(vectorStore.Status, Is.EqualTo(VectorStoreStatus.InProgress));
            Assert.That(vectorStore.Metadata?.TryGetValue("test-key", out string metadataValue) == true && metadataValue == "test-value");
        });
        vectorStore = await client.GetVectorStoreAsync(vectorStore);
        Assert.Multiple(() =>
        {
            Assert.That(vectorStore.Name, Is.EqualTo("test vector store"));
            Assert.That(vectorStore.ExpirationPolicy?.Anchor, Is.EqualTo(VectorStoreExpirationAnchor.LastActiveAt));
            Assert.That(vectorStore.ExpirationPolicy?.Days, Is.EqualTo(3));
            Assert.That(vectorStore.FileCounts.Total, Is.EqualTo(1));
            Assert.That(vectorStore.CreatedAt, Is.GreaterThan(s_2024));
            Assert.That(vectorStore.ExpiresAt, Is.GreaterThan(s_2024));
            Assert.That(vectorStore.Metadata?.TryGetValue("test-key", out string metadataValue) == true && metadataValue == "test-value");
        });

        deletionResult = await client.DeleteVectorStoreAsync(vectorStore.Id);
        Assert.That(deletionResult.VectorStoreId, Is.EqualTo(vectorStore.Id));
        Assert.That(deletionResult.Deleted, Is.True);

        var options = new VectorStoreCreationOptions();
        foreach (var file in testFiles)
        {
            options.FileIds.Add(file.Id);
        }
        vectorStore = await client.CreateVectorStoreAsync(options);
        Validate(vectorStore);
        Assert.Multiple(() =>
        {
            Assert.That(vectorStore.Name, Is.Null.Or.Empty);
            Assert.That(vectorStore.FileCounts.Total, Is.EqualTo(5));
        });
    }

    [RecordedTest]
    public async Task CanEnumerateVectorStores()
    {
        VectorStoreClient client = GetTestClient();
        for (int i = 0; i < 10; i++)
        {
            VectorStore vectorStore = await client.CreateVectorStoreAsync(new VectorStoreCreationOptions()
            {
                Name = $"Test Vector Store {i}",
            });
            Validate(vectorStore);
            Assert.That(vectorStore.Name, Is.EqualTo($"Test Vector Store {i}"));
        }

        AsyncCollectionResult<VectorStore> response = client.GetVectorStoresAsync(new VectorStoreCollectionOptions() { Order = VectorStoreCollectionOrder.Descending });
        Assert.That(response, Is.Not.Null);

        int lastIdSeen = int.MaxValue;
        int count = 0;
        await foreach (VectorStore vectorStore in response)
        {
            Assert.That(vectorStore.Id, Is.Not.Null);
            if (vectorStore.Name?.StartsWith("Test Vector Store ") == true)
            {
                string idString = vectorStore.Name.Substring("Test Vector Store ".Length);

                Assert.That(int.TryParse(idString, out int seenId), Is.True);
                Assert.That(seenId, Is.LessThan(lastIdSeen));
                lastIdSeen = seenId;
            }
            if (lastIdSeen == 0 || ++count >= 100)
            {
                break;
            }
        }

        Assert.That(lastIdSeen, Is.EqualTo(0));
    }

    [RecordedTest]
    public async Task CanAssociateFiles()
    {
        VectorStoreClient client = GetTestClient();
        VectorStore vectorStore = await client.CreateVectorStoreAsync();
        Validate(vectorStore);

        IReadOnlyList<OpenAIFileInfo> files = await GetNewTestFilesAsync(client.GetConfigOrThrow(), 3);

        foreach (OpenAIFileInfo file in files)
        {
            VectorStoreFileAssociation association = await client.AddFileToVectorStoreAsync(vectorStore, file);
            Validate(association);
            Assert.Multiple(() =>
            {
                Assert.That(association.FileId, Is.EqualTo(file.Id));
                Assert.That(association.VectorStoreId, Is.EqualTo(vectorStore.Id));
                Assert.That(association.LastError, Is.Null);
                Assert.That(association.CreatedAt, Is.GreaterThan(s_2024));
                Assert.That(association.Status, Is.AnyOf(VectorStoreFileAssociationStatus.InProgress, VectorStoreFileAssociationStatus.Completed));
            });
        }

        FileFromStoreRemovalResult removalResult = await client.RemoveFileFromStoreAsync(vectorStore, files[0]);
        Assert.That(removalResult.FileId, Is.EqualTo(files[0].Id));
        Assert.True(removalResult.Removed);

        // Errata: removals aren't immediately reflected when requesting the list
        Thread.Sleep(1000);

        int count = 0;
        AsyncCollectionResult<VectorStoreFileAssociation> response = client.GetFileAssociationsAsync(vectorStore);
        await foreach (VectorStoreFileAssociation association in response)
        {
            count++;
            Assert.That(association.FileId, Is.Not.EqualTo(files[0].Id));
            Assert.That(association.VectorStoreId, Is.EqualTo(vectorStore.Id));
        }

        Assert.That(count, Is.EqualTo(2));
    }

    [RecordedTest]
    public async Task CanUseBatchIngestion()
    {
        VectorStoreClient client = GetTestClient();
        VectorStore vectorStore = await client.CreateVectorStoreAsync();
        Validate(vectorStore);

        IReadOnlyList<OpenAIFileInfo> testFiles = await GetNewTestFilesAsync(client.GetConfigOrThrow(), 3);

        VectorStoreBatchFileJob batchJob = await client.CreateBatchFileJobAsync(vectorStore, testFiles);
        Assert.Multiple(() =>
        {
            Assert.That(batchJob.BatchId, Is.Not.Null);
            Assert.That(batchJob.VectorStoreId, Is.EqualTo(vectorStore.Id));
            Assert.That(batchJob.Status, Is.EqualTo(VectorStoreBatchFileJobStatus.InProgress));
        });

        batchJob = await WaitUntilReturnLast(
            batchJob,
            () => client.GetBatchFileJobAsync(batchJob),
            b => b.Status != VectorStoreBatchFileJobStatus.InProgress);
        Assert.That(batchJob.Status, Is.EqualTo(VectorStoreBatchFileJobStatus.Completed));

        AsyncCollectionResult<VectorStoreFileAssociation> response = client.GetFileAssociationsAsync(batchJob);
        await foreach (VectorStoreFileAssociation association in response)
        {
            Assert.Multiple(() =>
            {
                Assert.That(association.FileId, Is.Not.Null);
                Assert.That(association.VectorStoreId, Is.EqualTo(vectorStore.Id));
                Assert.That(association.Status, Is.EqualTo(VectorStoreFileAssociationStatus.Completed));
                // Assert.That(association.Size, Is.GreaterThan(0));
                Assert.That(association.CreatedAt, Is.GreaterThan(s_2024));
                Assert.That(association.LastError, Is.Null);
            });
        }
    }

    private async Task<IReadOnlyList<OpenAIFileInfo>> GetNewTestFilesAsync(IConfiguration config, int count)
    {
        AzureOpenAIClient azureClient = GetTestTopLevelClient(config, new()
        {
            ShouldOutputRequests = false,
            ShouldOutputResponses = false,
        });
        FileClient client = GetTestClient<FileClient>(azureClient, config);

        List<OpenAIFileInfo> files = [];
        for (int i = 0; i < count; i++)
        {
            OpenAIFileInfo file = await client.UploadFileAsync(
                BinaryData.FromString("This is a test file").ToStream(),
                $"test_file_{i.ToString().PadLeft(3, '0')}.txt",
                FileUploadPurpose.Assistants)
                .ConfigureAwait(false);
            Validate(file);
            files.Add(file);
        }

        return files;
    }

    private static readonly DateTimeOffset s_2024 = new(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);
}
