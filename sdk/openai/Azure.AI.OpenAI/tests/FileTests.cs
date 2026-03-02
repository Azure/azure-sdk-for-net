// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.AI.OpenAI.Files;
using OpenAI.Files;
using OpenAI.TestFramework;
using OpenAI.TestFramework.Mocks;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.Tests;

public class FileTests : AoaiTestBase<OpenAIFileClient>
{
    public FileTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    [Category("Smoke")]
    public void CanCreateClient() => Assert.That(GetTestClient(), Is.InstanceOf<OpenAIFileClient>());

    [RecordedTest]
#if !AZURE_OPENAI_GA
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_01_Preview)]
    //[TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_12_01_Preview)]
    //[TestCase(AzureOpenAIClientOptions.ServiceVersion.V2025_01_01_Preview)]
#else
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_21)]
#endif
    [TestCase(null)]
    public async Task CanUploadAndDeleteFiles(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        OpenAIFileClient client = GetTestClient(GetTestClientOptions(version));
        OpenAIFile file = await client.UploadFileAsync(
            BinaryData.FromString("hello, world!"),
            "test_file_delete_me.txt",
            FileUploadPurpose.Assistants);
        Validate(file);
        FileDeletionResult deletionResult = await client.DeleteFileAsync(file.Id);
        Assert.That(deletionResult.FileId, Is.EqualTo(file.Id));
        Assert.IsTrue(deletionResult.Deleted);

        file = await client.UploadFileAsync(
            BinaryData.FromString(@"{""text"":""hello, world!""}"),
            "test_file_delete_me.jsonl",
            FileUploadPurpose.Batch);
        Validate(file);
    }

    [RecordedTest]
#if !AZURE_OPENAI_GA
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_12_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2025_01_01_Preview)]
#else
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_21)]
#endif
    [TestCase(null)]
    public async Task CanListFiles(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        OpenAIFileClient client = GetTestClient(GetTestClientOptions(version));
        OpenAIFileCollection files = await client.GetFilesAsync();
        Assert.That(files, Has.Count.GreaterThan(0));
    }

    [RecordedTest]
    [TestCase(null)]
    public async Task CanUploadWithExpiration(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        OpenAIFileClient client = GetTestClient(GetTestClientOptions(version));
        AzureFileExpirationOptions expirationOptions = new(3600, AzureFileExpirationAnchor.CreatedAt);
        OpenAIFile file = await client.UploadFileAsync(
            BinaryData.FromString(@"{""text"":""hello, there, world!""}"),
            "test_file_delete_me_please.jsonl",
            FileUploadPurpose.Batch,
            expirationOptions);
        Validate(file);
        Assert.That(file.GetAzureOpenAIFileStatus(), Is.EqualTo(AzureOpenAIFileStatus.Processed));
    }

    private static TestClientOptions GetTestClientOptions(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        return version is null ? new TestClientOptions() : new TestClientOptions(version.Value);
    }

    [Test]
    [Category("Smoke")]
    public void FineTuneFileUploadIncludesContentType()
    {
        // Regression test: Azure OpenAI requires a Content-Type header on the file part of multipart
        // uploads for fine-tune and batch purposes. Verify that the request includes it.
        using var mockHandler = new MockHttpMessageHandler(MockHttpMessageHandler.ReturnEmptyJson);
        var pipelineOptions = new ClientPipelineOptions
        {
            Transport = mockHandler.Transport,
            RetryPolicy = new ClientRetryPolicy(maxRetries: 0)
        };
        var pipeline = ClientPipeline.Create(pipelineOptions);
        var client = new AzureFileClient(pipeline, new Uri("https://test.openai.azure.com/"), new AzureOpenAIClientOptions());

        // Test FineTune - should set Content-Type: text/plain on the file part
        using var fineTuneStream = new MemoryStream(Encoding.UTF8.GetBytes("training data"));
        try
        {
            client.UploadFile(fineTuneStream, "training.jsonl", FileUploadPurpose.FineTune);
        }
        catch (Exception)
        {
            // The mock returns "{}" which may fail to deserialize as an OpenAIFile.
            // We only care about verifying the request content, not the response.
        }

        Assert.That(mockHandler.Requests, Has.Count.GreaterThan(0), "Expected at least one request for FineTune upload");
        string fineTuneBody = Encoding.UTF8.GetString(mockHandler.Requests[0].Content.ToArray());
        Assert.That(fineTuneBody, Does.Contain("Content-Type: text/plain"),
            "Azure OpenAI requires Content-Type header on file part for FineTune uploads");

        // Test Batch - should set Content-Type: application/json on the file part
        using var batchStream = new MemoryStream(Encoding.UTF8.GetBytes("{\"test\":true}"));
        try
        {
            client.UploadFile(batchStream, "batch.jsonl", FileUploadPurpose.Batch);
        }
        catch (Exception)
        {
            // The mock returns "{}" which may fail to deserialize as an OpenAIFile.
            // We only care about verifying the request content, not the response.
        }

        Assert.That(mockHandler.Requests, Has.Count.GreaterThan(1), "Expected at least two requests for Batch upload");
        string batchBody = Encoding.UTF8.GetString(mockHandler.Requests[1].Content.ToArray());
        Assert.That(batchBody, Does.Contain("Content-Type: application/json"),
            "Azure OpenAI requires Content-Type header on file part for Batch uploads");
    }
}
