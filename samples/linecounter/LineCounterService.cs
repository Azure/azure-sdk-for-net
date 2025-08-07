// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs.Producer;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LineCounter;

/// <summary>
/// Hosted service that listens to uploads events hub and calculates line counts for the blobs in background updating blob metadata and posting a message into results event hub
/// </summary>
public class LineCounterService : IHostedService
{
    private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
    private readonly ILogger<LineCounterService> _logger;

    private readonly BlobContainerClient _blobContainerClient;
    private readonly EventHubProducerClient _resultsClient;

    private readonly EventProcessorClient _processor;

    public LineCounterService(
        IAzureClientFactory<EventHubProducerClient> producerFactory,
        BlobServiceClient blobServiceClient,
        ILogger<LineCounterService> logger,
        IConfiguration configuration)
    {
        _logger = logger;
        _blobContainerClient = blobServiceClient.GetBlobContainerClient("uploads");
        _resultsClient = producerFactory.CreateClient("Results");
        _processor = new EventProcessorClient(
            _blobContainerClient,
            EventHubConsumerClient.DefaultConsumerGroupName,
            configuration["Uploads:connectionString"],
            configuration["Uploads:eventHubName"]);
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting processor host");
        _processor.ProcessEventAsync += ProcessEvent;
        _processor.ProcessErrorAsync += (eventArgs) =>
        {
            _logger.LogError(eventArgs.Exception, "Error in " + eventArgs.PartitionId);
            return Task.CompletedTask;
        };
        await _processor.StartProcessingAsync();
    }

    private async Task ProcessEvent(ProcessEventArgs eventArgs)
    {
        if (eventArgs.HasEvent)
        {
            var totalCount = 0;
            var cancellationToken = _cancellationTokenSource.Token;

            var blobName = Encoding.UTF8.GetString(eventArgs.Data.Body.Span);

            var blobClient = _blobContainerClient.GetBlobClient(blobName);
            var downloadInfo = await blobClient.DownloadAsync(cancellationToken);

            _logger.LogInformation("Processing {blob}", blobName);

            var newLineCountingStream = new NewLineCountingStream();
            await downloadInfo.Value.Content.CopyToAsync(newLineCountingStream, cancellationToken);
            var newLineCount = newLineCountingStream.NewLineCount;

            await blobClient.SetMetadataAsync(
                new Dictionary<string, string>()
                {
                    { "whitespacecount", newLineCount.ToString()}
                },
                cancellationToken: cancellationToken);

            _logger.LogInformation("{blob} had {lines} lines", blobName, newLineCount);

            totalCount += newLineCount;

            using EventDataBatch eventBatch = await _resultsClient.CreateBatchAsync();
            eventBatch.TryAdd(new EventData(BitConverter.GetBytes(totalCount)));
            await _resultsClient.SendAsync(eventBatch, cancellationToken);
            await eventArgs.UpdateCheckpointAsync();
        }
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        _cancellationTokenSource.Cancel();
        await _processor.StopProcessingAsync();
    }

    private class NewLineCountingStream : Stream
    {
        public int NewLineCount { get; private set; }

        public override void Flush()
        {
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            foreach (var b in buffer)
            {
                if (b == (byte)'\n')
                {
                    NewLineCount++;
                }
            }
        }

        public override bool CanRead { get; }
        public override bool CanSeek { get; }
        public override bool CanWrite => true;
        public override long Length { get; }
        public override long Position { get; set; }
    }
}