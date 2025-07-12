// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.OpenAI.Files;
using OpenAI.Batch;
using OpenAI.Chat;
using OpenAI.Files;
using OpenAI.TestFramework;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure.AI.OpenAI.Tests;

#pragma warning disable CS0618

public class BatchTests : AoaiTestBase<BatchClient>
{
    public BatchTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    [Category("Smoke")]
    public void CanCreateClient() => Assert.That(GetTestClient(), Is.InstanceOf<BatchClient>());

    [RecordedTest]
#if !AZURE_OPENAI_GA
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_12_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2025_01_01_Preview)]
#else
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_21)]
#endif
    [TestCase(null)]
    public async Task CanUploadFileForBatch(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        BatchClient batchClient = GetTestClient(GetTestClientOptions(version));
        OpenAIFileClient fileClient = GetTestClientFrom<OpenAIFileClient>(batchClient);

        OpenAIFile newFile = await fileClient.UploadFileAsync(
            BinaryData.FromString("this isn't valid input for batch"),
            "intentionally-bad-batch-input.jsonl",
            FileUploadPurpose.Batch);
        Validate(newFile);

        // In contrast to fine-tuning, files uploaded for batch will immediately enter -- and remain -- in a
        // 'processed' state. Validation is performed via the batch client directly.
        AzureOpenAIFileStatus azureStatus = newFile.GetAzureOpenAIFileStatus();
        Assert.That(azureStatus, Is.EqualTo(AzureOpenAIFileStatus.Processed));

        string createdFileId = newFile.Id;
        newFile = await fileClient.GetFileAsync(createdFileId);
        Validate(newFile);
        Assert.That(newFile.Id, Is.EqualTo(createdFileId));
        Assert.That(newFile.GetAzureOpenAIFileStatus(), Is.EqualTo(AzureOpenAIFileStatus.Processed));
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
    [Category("LongRunning")] // observed live runtime up to 5 minutes
    public async Task CanCancelBatch(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        BatchClient batchClient = GetTestClient(GetTestClientOptions(version));
        OpenAIFileClient fileClient = GetTestClientFrom<OpenAIFileClient>(batchClient);
        string deploymentName = TestConfig.GetConfig<BatchClient>()!.Deployment!;

        TimeSpan pollingInterval = Recording!.Mode == RecordedTestMode.Playback ? TimeSpan.FromMilliseconds(1) : TimeSpan.FromSeconds(15);

        BinaryData jsonlInputBytes = BinaryData.FromString($$$"""
            {"custom_id": "request-1", "method": "POST", "url": "/v1/chat/completions", "body": {"model": "{{{deploymentName}}}", "messages": [{"role": "system", "content": "You are a helpful assistant."},{"role": "user", "content": "Hello world!"}],"max_tokens": 1000}}
            {"custom_id": "request-2", "method": "POST", "url": "/v1/chat/completions", "body": {"model": "{{{deploymentName}}}", "messages": [{"role": "system", "content": "You are an unhelpful assistant."},{"role": "user", "content": "Hello world!"}],"max_tokens": 1000}}
            """);
        OpenAIFile batchInputFile = await fileClient.UploadFileAsync(jsonlInputBytes, "temp-test-batch-input.jsonl", FileUploadPurpose.Batch);
        Validate(batchInputFile);

        while (batchInputFile.Status.ToAzureOpenAIFileStatus() == AzureOpenAIFileStatus.Pending)
        {
            await Task.Delay(pollingInterval);
            batchInputFile = await fileClient.GetFileAsync(batchInputFile.Id);
        }
        Assert.That(batchInputFile.Status, Is.EqualTo(FileStatus.Processed));

        BinaryData createBatchRequestBytes = BinaryData.FromString($$"""
            {
              "input_file_id": "{{batchInputFile.Id}}",
              "endpoint": "/v1/chat/completions",
              "completion_window": "24h"
            }
            """);
        CreateBatchOperation createBatchOperation = await batchClient.CreateBatchAsync(BinaryContent.Create(createBatchRequestBytes), waitUntilCompleted: false);
        Validate(createBatchOperation);

        _ = await createBatchOperation.CancelAsync(default);
        _ = await createBatchOperation.UpdateStatusAsync();

        Assert.That(createBatchOperation!.GetRawResponse()!.Content.ToString().Replace(" ", ""), Does.Contain(@"""status"":""cancelling"""));

        while (!createBatchOperation.HasCompleted)
        {
            await Task.Delay(pollingInterval);
            _ = await createBatchOperation.UpdateStatusAsync();
        }

        Assert.That(createBatchOperation!.GetRawResponse()!.Content.ToString().Replace(" ", ""), Does.Contain(@"""status"":""cancelled"""));
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
    [Ignore("Disabled pending revisited long-running test recording strategy")]
    [Category("LongRunning")] // observed live runtime typically varies from 6 - 15 minutes
    public async Task SimpleBatchCompletionsTest(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        BatchClient batchClient = GetTestClient(GetTestClientOptions(version));
        OpenAIFileClient fileClient = GetTestClientFrom<OpenAIFileClient>(batchClient);
        string deploymentName = TestConfig.GetConfig<BatchClient>()!.Deployment!;

        TimeSpan pollingInterval = Recording!.Mode == RecordedTestMode.Playback ? TimeSpan.FromMilliseconds(1) : TimeSpan.FromSeconds(15);

        BinaryData jsonlInputBytes = BinaryData.FromString($$$"""
            {"custom_id": "request-1", "method": "POST", "url": "/v1/chat/completions", "body": {"model": "{{{deploymentName}}}", "messages": [{"role": "system", "content": "You are a helpful assistant."},{"role": "user", "content": "Hello world!"}],"max_tokens": 1000}}
            {"custom_id": "request-2", "method": "POST", "url": "/v1/chat/completions", "body": {"model": "{{{deploymentName}}}", "messages": [{"role": "system", "content": "You are an unhelpful assistant."},{"role": "user", "content": "Hello world!"}],"max_tokens": 1000}}
            """);
        OpenAIFile batchInputFile = await fileClient.UploadFileAsync(jsonlInputBytes, "temp-test-batch-input.jsonl", FileUploadPurpose.Batch);
        Validate(batchInputFile);

        while (batchInputFile.Status.ToAzureOpenAIFileStatus() == AzureOpenAIFileStatus.Pending)
        {
            await Task.Delay(pollingInterval);
            batchInputFile = await fileClient.GetFileAsync(batchInputFile.Id);
        }
        Assert.That(batchInputFile.Status, Is.EqualTo(FileStatus.Processed));

        BinaryData createBatchRequestBytes = BinaryData.FromString($$"""
            {
              "input_file_id": "{{batchInputFile.Id}}",
              "endpoint": "/v1/chat/completions",
              "completion_window": "24h"
            }
            """);
        CreateBatchOperation createBatchOperation = await batchClient.CreateBatchAsync(BinaryContent.Create(createBatchRequestBytes), waitUntilCompleted: false);
        Validate(createBatchOperation);

        BinaryData latestProtocolBatchBytes = createBatchOperation!.GetRawResponse()!.Content;

        while (!createBatchOperation.HasCompleted)
        {
            await Task.Delay(pollingInterval);
            _ = await createBatchOperation.UpdateStatusAsync();
            latestProtocolBatchBytes = createBatchOperation.GetRawResponse()!.Content;
            Assert.That(latestProtocolBatchBytes, Is.Not.Null);
        }

        string? resultBatchId = null;
        string? resultInputFileId = null;
        string? resultOutputFileId = null;
        string? resultStatus = null;

        using JsonDocument batchJsonDocument = JsonDocument.Parse(latestProtocolBatchBytes);
        foreach (JsonProperty batchJsonProperty in batchJsonDocument.RootElement.EnumerateObject())
        {
            if (batchJsonProperty.NameEquals("id"u8))
            {
                resultBatchId = batchJsonProperty.Value.GetString();
                continue;
            }
            if (batchJsonProperty.NameEquals("input_file_id"u8))
            {
                resultInputFileId = batchJsonProperty.Value.GetString();
                continue;
            }
            if (batchJsonProperty.NameEquals("output_file_id"u8))
            {
                resultOutputFileId = batchJsonProperty.Value.GetString();
                continue;
            }
            if (batchJsonProperty.NameEquals("status"u8))
            {
                resultStatus = batchJsonProperty.Value.GetString();
                continue;
            }
        }

        Assert.That(resultBatchId, Is.EqualTo(createBatchOperation.BatchId));
        Assert.That(resultInputFileId, Is.EqualTo(batchInputFile.Id));
        Assert.That(resultOutputFileId, Is.Not.Null.And.Not.Empty);
        Assert.That(resultStatus, Is.EqualTo("completed"));

        BinaryData batchOutputBytes = await fileClient.DownloadFileAsync(resultOutputFileId);
        Assert.That(batchOutputBytes, Is.Not.Null);

        List<ChatCompletion> batchCompletions = GetVerifiedBatchOutputsOf<ChatCompletion>(
            batchOutputBytes,
            ["request-1", "request-2"]);

        foreach (ChatCompletion batchCompletion in batchCompletions)
        {
            Assert.That(batchCompletion, Is.Not.Null);
            Assert.That(batchCompletion.Role, Is.EqualTo(ChatMessageRole.Assistant));
            Assert.That(batchCompletion.Content, Has.Count.EqualTo(1));
            Assert.That(batchCompletion.Content[0].Kind, Is.EqualTo(ChatMessageContentPartKind.Text));
            Assert.That(batchCompletion.Content[0].Text, Is.Not.Null.Or.Empty);
        }
    }

    private TestClientOptions GetTestClientOptions(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        return version is null ? new TestClientOptions() : new TestClientOptions(version.Value);
    }

    private List<T> GetVerifiedBatchOutputsOf<T>(
        BinaryData downloadBytes,
        IList<string> expectedCustomIds)
            where T : IJsonModel<T>
    {
        using Stream outputStream = downloadBytes.ToStream();
        using StreamReader outputReader = new(outputStream);

        List<T> deserializedBodyOutputs = [];

        for (string? line = outputReader.ReadLine(); !string.IsNullOrEmpty(line); line = outputReader.ReadLine())
        {
            string? customId = null;
            bool foundNullError = false;
            string? requestId = null;
            int? statusCode = null;
            T? deserializedResponseBody = default;

            using JsonDocument resultDocument = JsonDocument.Parse(line);
            foreach (JsonProperty documentProperty in resultDocument.RootElement.EnumerateObject())
            {
                if (documentProperty.NameEquals("custom_id"u8))
                {
                    customId = documentProperty.Value.GetString();
                }
                if (documentProperty.NameEquals("error"u8))
                {
                    Assert.IsTrue(documentProperty.Value.ValueKind == JsonValueKind.Null);
                    foundNullError = true;
                }
                if (documentProperty.NameEquals("response"u8))
                {
                    foreach (JsonProperty responseProperty in documentProperty.Value.EnumerateObject())
                    {
                        if (responseProperty.NameEquals("request_id"u8))
                        {
                            requestId = responseProperty.Value.GetString();
                        }
                        if (responseProperty.NameEquals("status_code"u8))
                        {
                            statusCode = responseProperty.Value.GetInt32();
                        }
                        if (responseProperty.NameEquals("body"u8))
                        {
                            BinaryData responseBodyBytes = BinaryData.FromObjectAsJson(responseProperty.Value);
                            deserializedResponseBody = ModelReaderWriter.Read<T>(responseBodyBytes);
                        }
                    }
                }
            }
            Assert.That(customId, Is.Not.Null.And.Not.Empty);
            if (expectedCustomIds is not null)
            {
                Assert.That(expectedCustomIds.Any(expectedId => expectedId == customId));
            }
            Assert.True(foundNullError);
            Assert.That(requestId, Is.Not.Null.And.Not.Empty);
            Assert.That(statusCode, Is.EqualTo(200));
            Assert.That(deserializedResponseBody, Is.Not.Null);
            deserializedBodyOutputs.Add(deserializedResponseBody!);
        }
        if (expectedCustomIds is not null)
        {
            Assert.That(deserializedBodyOutputs, Has.Count.EqualTo(expectedCustomIds.Count));
        }
        return deserializedBodyOutputs;
    }
}
