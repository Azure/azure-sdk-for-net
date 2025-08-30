// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.Tests.MockClient;

/// <summary>
/// A fake client that sends multipart requests, similar to OpenAI's file upload functionality.
/// This client demonstrates the boundary mismatch issue that occurs during recording/playback.
/// </summary>
public class FakeFileClient
{
    private readonly ClientPipeline _pipeline;
    private readonly Uri _endpoint;

    public FakeFileClient()
    {
    }

    public FakeFileClient(ClientPipeline pipeline, Uri endpoint)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
    }

    public FakeFileClient(Uri endpoint, ClientPipelineOptions options) : this(ClientPipeline.Create(options), endpoint)
    {
    }

    /// <summary>
    /// Upload a single file (similar to OpenAI's UploadFileAsync).
    /// Each call creates a new MultiPartFormDataBinaryContent with a dynamically generated boundary,
    /// which is the source of the recording/playback mismatch issue.
    /// </summary>
    public virtual async Task<TestFile> UploadFileAsync(
        Stream fileStream,
        string fileName,
        FileUploadOptions options = null)
    {
        options ??= new FileUploadOptions();

        using var multipartContent = new MultiPartFormDataBinaryContent();

        // Add the file
        multipartContent.Add(fileStream, "file", fileName, "text/plain");

        // Add purpose
        multipartContent.Add(options.Purpose, "purpose");

        // Add metadata
        foreach (var kvp in options.Metadata)
        {
            multipartContent.Add(kvp.Value, $"metadata[{kvp.Key}]");
        }

        PipelineMessage message = await SendMultipartRequestAsync(multipartContent);

        if (message.Response.IsError)
        {
            throw new Exception($"Upload failed with status {message.Response.Status}");
        }

        return new TestFile
        {
            Id = Guid.NewGuid().ToString(),
            Name = fileName,
            Content = "uploaded",
            CreatedAt = DateTime.UtcNow
        };
    }

    /// <summary>
    /// Upload multiple files in a batch operation.
    /// Each call creates a new MultiPartFormDataBinaryContent with a dynamically generated boundary.
    /// </summary>
    public virtual async Task<UploadResult> UploadBatchAsync(IEnumerable<(Stream Stream, string FileName)> files)
    {
        using var multipartContent = new MultiPartFormDataBinaryContent();

        int fileCount = 0;
        foreach (var (stream, fileName) in files)
        {
            multipartContent.Add(stream, "files", fileName, "application/json");
            fileCount++;
        }

        // Add batch metadata
        multipartContent.Add("batch", "operation");
        multipartContent.Add(fileCount.ToString(), "count");

        PipelineMessage message = await SendMultipartRequestAsync(multipartContent);

        if (message.Response.IsError)
        {
            throw new Exception($"Batch upload failed with status {message.Response.Status}");
        }

        return new UploadResult
        {
            Id = Guid.NewGuid().ToString(),
            FilesProcessed = fileCount,
            Status = "completed",
            CompletedAt = DateTime.UtcNow
        };
    }

    private async Task<PipelineMessage> SendMultipartRequestAsync(MultiPartFormDataBinaryContent content)
    {
        PipelineMessage message = _pipeline.CreateMessage();
        message.Request.Method = "POST";
        message.Request.Uri = _endpoint;

        // Set the BinaryContent directly
        message.Request.Content = content;

        // Set the Content-Type header with boundary - this is where the dynamic boundary
        // gets set, and it's different every time MultiPartFormDataBinaryContent() is created
        message.Request.Headers.Add("Content-Type", content.ContentType);

        await _pipeline.SendAsync(message);
        return message;
    }
}
