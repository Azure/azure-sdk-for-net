// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI;
using OpenAI.Files;
using OpenAI.Responses;
using OpenAI.VectorStores;

namespace Azure.AI.Projects.OpenAI.Tests;

public class OtherOpenAIParityTests : ProjectsOpenAITestBase
{
    public OtherOpenAIParityTests(bool isAsync) : base(isAsync)
    {
    }

    [RecordedTest]
    [TestCase(OpenAIClientMode.UseExternalOpenAI, "assistants")]
    [TestCase(OpenAIClientMode.UseExternalOpenAI, "fine-tune")]
    [TestCase(OpenAIClientMode.UseFDPOpenAI, "assistants")]
    [TestCase(OpenAIClientMode.UseFDPOpenAI, "fine-tune")]
    public async Task FileUploadWorks(OpenAIClientMode clientMode, string rawPurpose)
    {
        OpenAIClient openAIClient = GetTestOpenAIClient(clientMode);
        OpenAIFileClient fileClient = openAIClient.GetOpenAIFileClient();

        (string filename, string rawFileData) = rawPurpose switch
        {
            "assistants" => ("test_data_delete_me.txt", "hello, world"),
            "fine-tune" => ("test_data_delete_me.jsonl", @"{""messages"": [{""role"": ""system"", ""content"": """"}]}"),
            _ => throw new NotImplementedException()
        };

        OpenAIFile newFile = await fileClient.UploadFileAsync(BinaryData.FromString(rawFileData), filename, rawPurpose);
        Assert.That(newFile.SizeInBytesLong, Is.GreaterThan(0));
#pragma warning disable CS0618 // Status is obsolete
        Assert.That(newFile.Status, Is.EqualTo(FileStatus.Processed));
#pragma warning restore
        if (rawPurpose == "fine-tune" && clientMode == OpenAIClientMode.UseFDPOpenAI)
        {
            Assert.That(newFile.GetAzureFileStatus(), Is.EqualTo("pending"));
        }

        OpenAIFile retrievedFile = await fileClient.GetFileAsync(newFile.Id);
#pragma warning disable CS0618 // Status is obsolete
        Assert.That(retrievedFile.Status, Is.EqualTo(newFile.Status).Or.EqualTo(FileStatus.Uploaded));
#pragma warning restore

        if (rawPurpose == "fine-tune" && clientMode == OpenAIClientMode.UseFDPOpenAI)
        {
            Assert.That(retrievedFile.GetAzureFileStatus(), Is.EqualTo(newFile.GetAzureFileStatus()).Or.EqualTo("processed").Or.EqualTo("running"));
        }
    }

    [RecordedTest]
    [TestCase(OpenAIClientMode.UseExternalOpenAI)]
    [TestCase(OpenAIClientMode.UseFDPOpenAI)]
    public async Task VectorStorePdfIndexingWorksWithFileSearch(OpenAIClientMode clientMode)
    {
        OpenAIClient openAIClient = GetTestOpenAIClient(clientMode);
        OpenAIFileClient fileClient = openAIClient.GetOpenAIFileClient();
        VectorStoreClient vectorStoreClient = openAIClient.GetVectorStoreClient();

        OpenAIFile pdfFile = await fileClient.UploadFileAsync(@"Assets/favorite_foods.pdf", FileUploadPurpose.Assistants);

        VectorStore vectorStore = await vectorStoreClient.CreateVectorStoreAsync(
            new VectorStoreCreationOptions()
            {
                FileIds = { pdfFile.Id },
            });

        TimeSpan pollingInterval = this.Mode == RecordedTestMode.Playback ? TimeSpan.FromMilliseconds(5) : TimeSpan.FromMilliseconds(500);

        for (int i = 0; i < 60; i++)
        {
            vectorStore = await vectorStoreClient.GetVectorStoreAsync(vectorStore.Id);
            if (vectorStore.Status != VectorStoreStatus.InProgress && vectorStore.FileCounts.Total == 1)
            {
                break;
            }
            await Task.Delay(pollingInterval);
        }

        Assert.That(vectorStore.Status, Is.EqualTo(VectorStoreStatus.Completed));
        Assert.That(vectorStore.FileCounts.Completed, Is.EqualTo(1));

        ResponsesClient responsesClient = openAIClient.GetResponsesClient(TestEnvironment.MODELDEPLOYMENTNAME);
        ResponseResult response = await responsesClient.CreateResponseAsync(
            new CreateResponseOptions()
            {
                InputItems = { ResponseItem.CreateUserMessageItem("Based on available file search documents, what's Travis's favorite food?") },
                Tools = { ResponseTool.CreateFileSearchTool(vectorStoreIds: [vectorStore.Id]) },
            });
        Assert.That(response.GetOutputText().ToLower(), Does.Contain("pizza"));
    }
}
