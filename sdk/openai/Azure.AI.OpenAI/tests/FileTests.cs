// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.ClientModel.Primitives;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.AI.OpenAI.Files;
using OpenAI.Files;
using OpenAI.TestFramework;
using OpenAI.TestFramework.Mocks;

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
        CapturedResponse ValidFileResponse(CapturedRequest _) => new()
        {
            Status = System.Net.HttpStatusCode.OK,
            ReasonPhrase = "OK",
            Content = BinaryData.FromString(@"{
                ""id"": ""file-abc123"",
                ""bytes"": 100,
                ""created_at"": 1700000000,
                ""filename"": ""training.jsonl"",
                ""object"": ""file"",
                ""purpose"": ""fine-tune"",
                ""status"": ""processed""
            }"),
            Headers = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IReadOnlyList<string>>
            {
                ["Content-Type"] = ["application/json"]
            }
        };

        using var mockHandler = new MockHttpMessageHandler(ValidFileResponse);
        var pipelineOptions = new ClientPipelineOptions
        {
            Transport = mockHandler.Transport,
            RetryPolicy = new ClientRetryPolicy(maxRetries: 0)
        };
        var pipeline = ClientPipeline.Create(pipelineOptions);
        var client = new AzureFileClient(pipeline, new Uri("https://test.openai.azure.com/"), new AzureOpenAIClientOptions());

        // Test FineTune - should set Content-Type: text/plain on the file part
        using var fineTuneStream = new MemoryStream(Encoding.UTF8.GetBytes("training data"));
        client.UploadFile(fineTuneStream, "training.jsonl", FileUploadPurpose.FineTune);

        Assert.That(mockHandler.Requests, Has.Count.GreaterThan(0), "Expected at least one request for FineTune upload");
        string fineTuneFilePartContentType = GetFilePartContentType(mockHandler.Requests[0].Content);
        Assert.That(fineTuneFilePartContentType, Does.StartWith("text/plain"),
            "Azure OpenAI requires Content-Type: text/plain on the file part for FineTune uploads");

        // Test Batch - should set Content-Type: application/json on the file part
        using var batchStream = new MemoryStream(Encoding.UTF8.GetBytes("{\"test\":true}"));
        client.UploadFile(batchStream, "batch.jsonl", FileUploadPurpose.Batch);

        Assert.That(mockHandler.Requests, Has.Count.GreaterThan(1), "Expected at least two requests for Batch upload");
        string batchFilePartContentType = GetFilePartContentType(mockHandler.Requests[1].Content);
        Assert.That(batchFilePartContentType, Does.StartWith("application/json"),
            "Azure OpenAI requires Content-Type: application/json on the file part for Batch uploads");
    }

    /// <summary>
    /// Extracts the Content-Type header value from the file part (name="file") of a multipart body.
    /// </summary>
    private static string GetFilePartContentType(BinaryData multipartBody)
    {
        const string contentTypePrefix = "Content-Type:";
        string body = Encoding.UTF8.GetString(multipartBody.ToArray());

        // Split on boundary markers (lines starting with "--")
        string[] lines = body.Split(["\r\n", "\n"], StringSplitOptions.None);

        bool inFilePart = false;
        string? contentType = null;

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];

            // A boundary line starts a new part (has content after "--"); reset state
            if (line.StartsWith("--") && line.Length > 2)
            {
                inFilePart = false;
                contentType = null;
                continue;
            }

            // Empty line ends headers section
            if (line.Length == 0)
            {
                if (inFilePart && contentType is not null)
                {
                    return contentType;
                }
                continue;
            }

            // Check Content-Disposition to identify the file part by parsing semicolon-delimited attributes
            if (line.StartsWith("Content-Disposition:", StringComparison.OrdinalIgnoreCase))
            {
                string[] attributes = line.Split(';');
                bool isFilePart = attributes.Any(
                    a => a.Trim().Equals("name=file", StringComparison.OrdinalIgnoreCase));
                if (isFilePart)
                {
                    inFilePart = true;
                }
                continue;
            }

            // Capture Content-Type header value
            if (line.StartsWith(contentTypePrefix, StringComparison.OrdinalIgnoreCase))
            {
                contentType = line[contentTypePrefix.Length..].Trim();
                continue;
            }
        }

        return contentType ?? string.Empty;
    }
}
