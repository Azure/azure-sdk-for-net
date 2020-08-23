// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LineCounter
{
    /// <summary>
    /// Hosted service that listens to uploads events hub and calculates line counts for the blobs in background updating blob metadata and posting a message into results event hub
    /// </summary>
    public class LineCounterService : IHostedService
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private readonly ILogger<LineCounterService> _logger;

        private readonly BlobContainerClient _blobContainerClient;
        private readonly ServiceBusClient _serviceBusClient;
        private readonly ServiceBusProcessor _serviceBusProcessor;

        public LineCounterService(
            ServiceBusClient serviceBusClient,
            BlobServiceClient blobServiceClient,
            ILogger<LineCounterService> logger)
        {
            _logger = logger;
            _blobContainerClient = blobServiceClient.GetBlobContainerClient("uploads");
            _serviceBusClient = serviceBusClient;
            _serviceBusProcessor = _serviceBusClient.CreateProcessor("uploads");
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting processor host");
            _serviceBusProcessor.ProcessErrorAsync += (eventArgs) =>
            {
                _logger.LogError(eventArgs.Exception, $"Error during {eventArgs.ErrorSource}");
                return Task.CompletedTask;
            };

            _serviceBusProcessor.ProcessMessageAsync += ProcessMessageAsync;
            await _serviceBusProcessor.StartProcessingAsync();
        }

        private async Task ProcessMessageAsync(ProcessMessageEventArgs args)
        {
            var cancellationToken = _cancellationTokenSource.Token;

            var blobName = args.Message.Body.ToString();

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
        }


        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _cancellationTokenSource.Cancel();
            await _serviceBusProcessor.StopProcessingAsync();
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
}