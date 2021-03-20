// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Storage.Blobs.Perf.Scenarios
{
    /// <summary>
    /// The performance test scenario focused on downloading blobs from the Azure blobs storage.
    /// </summary>
    /// <seealso cref="Azure.Test.Perf.PerfTest{StorageTransferOptionsOptions}" />
    public sealed class DownloadBlob : ContainerTest<StorageTransferOptionsOptions>
    {
        private readonly BlobClient _blobClient;

        public DownloadBlob(StorageTransferOptionsOptions options) : base(options)
        {
            _blobClient = BlobContainerClient.GetBlobClient("Azure.Storage.Blobs.Perf.Scenarios.DownloadBlob");
        }

        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();

            using Stream stream = RandomStream.Create(Options.Size);

            // No need to delete file in GlobalCleanup(), since ContainerTest.GlobalCleanup() deletes the whole container
            await _blobClient.UploadAsync(stream, overwrite: true);
        }

        public override async Task SetupAsync()
        {
            await base.SetupAsync();

            if (!string.IsNullOrEmpty(Options.Host))
            {
                var recordingFile = Guid.NewGuid().ToString();

                var message = new HttpRequestMessage(HttpMethod.Post, $"https://{Options.Host}:{Options.Port}/record/start");
                message.Headers.Add("x-recording-file", recordingFile);

                var response = await HttpClient.SendAsync(message);
                var recordingId = response.Headers.GetValues("x-recording-id").Single();

                Transport.RecordingId = recordingId;
                Transport.Mode = "record";

                await RunAsync(CancellationToken.None);

                message = new HttpRequestMessage(HttpMethod.Post, $"https://{Options.Host}:{Options.Port}/record/stop");
                message.Headers.Add("x-recording-id", recordingId);
                message.Headers.Add("x-recording-save", bool.TrueString);

                message = new HttpRequestMessage(HttpMethod.Post, $"https://{Options.Host}:{Options.Port}/playback/start");
                message.Headers.Add("x-recording-file", recordingFile);

                response = await HttpClient.SendAsync(message);
                recordingId = response.Headers.GetValues("x-recording-id").Single();

                Transport.Mode = "playback";
                Transport.RecordingId = recordingId;
            }
        }

        public override async Task CleanupAsync()
        {
            if (!string.IsNullOrEmpty(Options.Host))
            {
                var message = new HttpRequestMessage(HttpMethod.Post, $"https://{Options.Host}:{Options.Port}/playback/stop");
                message.Headers.Add("x-recording-id", Transport.RecordingId);
                await HttpClient.SendAsync(message);
            }

            await base.CleanupAsync();
        }

        public override void Run(CancellationToken cancellationToken)
        {
            _blobClient.DownloadTo(Stream.Null, transferOptions: Options.StorageTransferOptions, cancellationToken: cancellationToken);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await _blobClient.DownloadToAsync(Stream.Null, transferOptions: Options.StorageTransferOptions, cancellationToken: cancellationToken);
        }
    }
}
