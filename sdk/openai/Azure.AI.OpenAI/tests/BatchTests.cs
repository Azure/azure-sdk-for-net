// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.AI.OpenAI.Tests.Models;
using Azure.AI.OpenAI.Tests.Utils;
using Azure.AI.OpenAI.Tests.Utils.Config;
using Azure.AI.OpenAI.Tests.Utils.Pipeline;
using Azure.Core.TestFramework;
using OpenAI.Batch;
using OpenAI.Chat;
using OpenAI.Embeddings;
using OpenAI.Files;

namespace Azure.AI.OpenAI.Tests;

public class BatchTests : AoaiTestBase<BatchClient>
{
    public BatchTests(bool isAsync) : base(isAsync)
    { }

    [Test]
    [Category("Smoke")]
    public void CanCreateClient() => Assert.That(GetTestClient(), Is.InstanceOf<BatchClient>());

    [RecordedTest]
    [Ignore("Azure OpenAI does not yet support batch file uploads")]
    public async Task SimpleBatchCompletionsTest()
    {
        BatchClient batchClient = GetTestClient(new TestClientOptions(AzureOpenAIClientOptions.ServiceVersion.V2024_06_01));
        await using BatchOperations ops = new(this, batchClient);

        // Create the batch operations to send and upload them
        ops.ChatClient.CompleteChat([new SystemChatMessage("You are a saccharine AI"), new UserChatMessage("Tell me about yourself")]);
        ops.ChatClient.CompleteChat([new UserChatMessage("Give me a large random number")]);
        Assert.That(ops.Operations, Has.Count.EqualTo(2));
        string inputFileId = await ops.UploadBatchFileAsync();

        // Create the batch operation
        using var requestContent = new BatchOptions()
        {
            InputFileId = inputFileId,
            Endpoint = ops.Operations.Select(o => o.Url).Distinct().First(),
            Metadata =
            {
                [ "description" ] = "Azure OpenAI .Net SDK integration test framework " + nameof(SimpleBatchCompletionsTest),
            }
        }.ToBinaryContent();

        ClientResult response = await batchClient.CreateBatchAsync(requestContent);
        BatchObject batchObj = ExtractAndValidateBatchObj(response);

        // Poll until we've completed, failed, or were canceled
        while ("completed" != batchObj.Status)
        {
            response = await batchClient.GetBatchAsync(batchObj.Id, new());
            batchObj = ExtractAndValidateBatchObj(response);
        }

        Assert.That(batchObj.OutputFileID, Is.Not.Null.Or.Empty);
        BinaryData outputData = await ops.DownloadAndValidateResultAsync(batchObj.OutputFileID!);
        var parsedOutput = BatchResult<ChatCompletion>.From(outputData);
        Assert.That(parsedOutput, Is.Not.Null);
        Assert.That(parsedOutput, Has.Count.EqualTo(ops.Operations.Count));
        for (int i = 0; i < parsedOutput.Count; i++)
        {
            Assert.That(parsedOutput[i].CustomId, Is.EqualTo(ops.Operations[i].CustomId), "Wrong custom ID at index {0}", i);
            var completion = parsedOutput[i].Response!;
            Assert.That(completion, Is.Not.Null);
            Assert.That(completion.Role, Is.EqualTo(ChatMessageRole.Assistant));
            Assert.That(completion.Content, Has.Count.EqualTo(1));
            Assert.That(completion.Content[0].Kind, Is.EqualTo(ChatMessageContentPartKind.Text));
            Assert.That(completion.Content[0].Text, Is.Not.Null.Or.Empty);
        }

    }

    #region helper methods

    private BinaryData ValidateHasRawJsonResponse(ClientResult result)
    {
        Assert.That(result, Is.Not.Null);
        PipelineResponse response = result.GetRawResponse();
        Assert.That(response, Is.Not.Null);
        Assert.That(response.Status, Is.GreaterThanOrEqualTo(200).And.LessThan(300));
        Assert.That(response.Headers.GetFirstValueOrDefault("Content-Type"), Does.StartWith("application/json"));

        return response.Content;
    }

    private void ValidateBatchResult(BatchObject batchObj)
    {
        Assert.That(batchObj, Is.Not.Null);
        Assert.That(batchObj.Id, Is.Not.Null.Or.Empty);
        Assert.That(batchObj.Status, Is.Not.Null);
        Assert.That(batchObj.Status, Is.AnyOf("validating", "in_progress", "finalizing", "completed"));
    }

    private BatchObject ExtractAndValidateBatchObj(ClientResult result)
    {
        var binaryData = ValidateHasRawJsonResponse(result);
        var batchObj = BatchObject.From(binaryData);
        ValidateBatchResult(batchObj);
        return batchObj;
    }

    #endregion

    #region helper classes

    private class BatchOperations : IAsyncDisposable
    {
        private MockPipeline _pipeline;
        private List<BatchOperation> _operations;
        private string? _uploadId;
        private FileClient _fileClient;

        public BatchOperations(AoaiTestBase<BatchClient> testBase, BatchClient batchClient)
        {
            _pipeline = new MockPipeline(MockPipeline.ReturnEmptyJson);
            _pipeline.OnRequest += HandleRequest;
            _operations = new();

            BatchFileName = "batch-" + Guid.NewGuid().ToString("D") + ".json";

            _fileClient = testBase.GetTestClientFrom<FileClient>(batchClient);

            // Generate the fake pipeline to capture requests and save them to a file later
            AzureOpenAIClient fakeTopLevel = new AzureOpenAIClient(
                new Uri("https://not.a.real.endpoint.fake"),
                new ApiKeyCredential("not.a.real.key"),
                new() { Transport = _pipeline.Transport });

            ChatClient = fakeTopLevel.GetChatClient(testBase.TestConfig.GetConfig<ChatClient>().DeploymentOrThrow("chat client"));
            EmbeddingClient = fakeTopLevel.GetEmbeddingClient(testBase.TestConfig.GetConfig<EmbeddingClient>().DeploymentOrThrow("embedding client"));
        }

        public string BatchFileName { get; }
        public IReadOnlyList<BatchOperation> Operations => _operations;
        public ChatClient ChatClient { get; }
        public EmbeddingClient EmbeddingClient { get; }

        public async Task<string> UploadBatchFileAsync()
        {
            if (Operations.Count == 0)
            {
                throw new InvalidOperationException();
            }

            using MemoryStream stream = new MemoryStream();
            JsonHelpers.Serialize(stream, _operations, JsonHelpers.OpenAIJsonOptions);
            stream.Seek(0, SeekOrigin.Begin);
            var data = BinaryData.FromStream(stream);

            using var content = BinaryContent.Create(data);

            OpenAIFileInfo file = await _fileClient.UploadFileAsync(data, BatchFileName, FileUploadPurpose.Batch);
            _uploadId = file.Id;
            Assert.That(_uploadId, Is.Not.Null.Or.Empty);
            return _uploadId;
        }

        public async Task<BinaryData> DownloadAndValidateResultAsync(string outputId)
        {
            ClientResult<BinaryData> response = await _fileClient.DownloadFileAsync(outputId);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.Not.Null);
            return response.Value;
        }

        public async ValueTask DisposeAsync()
        {
            // clean up any files
            if (_uploadId != null)
            {
                await _fileClient.DeleteFileAsync(_uploadId);
            }

            _pipeline.OnRequest -= HandleRequest;
            _pipeline.Dispose();
            _operations.Clear();
        }

        private void HandleRequest(object? sender, CapturedRequest request)
        {
            JsonElement? element = null;
            if (request.Content != null)
            {
                using var json = JsonDocument.Parse(request.Content.ToMemory());
                element = json.RootElement.Clone();
            }

            BatchOperation operation = new()
            {
                Method = request.Method,
                Url = request.Uri?.AbsolutePath ?? string.Empty,
                Body = element
            };

            _operations.Add(operation);
        }

        public class BatchOperation
        {
            public string CustomId { get; } = Guid.NewGuid().ToString();
            public HttpMethod Method { get; init; } = HttpMethod.Get;
            public string Url { get; init; } = string.Empty;
            public JsonElement? Body { get; init; }
        }
    }

    #endregion
}
