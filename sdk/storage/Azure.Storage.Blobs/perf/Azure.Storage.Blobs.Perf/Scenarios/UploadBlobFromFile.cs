// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Test.Perf;

namespace Azure.Storage.Blobs.Perf.Scenarios
{
    /// <summary>
    /// The performance test scenario focused on uploading blobs to the Azure blobs storage.
    /// </summary>
    /// <seealso cref="Azure.Test.Perf.PerfTest{SizeOptions}" />
    public sealed class UploadBlobFromFile : BlobTest<StorageTransferOptionsOptions>
    {
        private readonly string _filePath;
        private readonly long _fileSize;
        private Stream _stream;

        public UploadBlobFromFile(StorageTransferOptionsOptions options) : base(options)
        {
            _filePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            _fileSize = options.Size;
        }

        public override async Task SetupAsync()
        {
            using (var stream = File.OpenWrite(_filePath))
            {
                await RandomStream.Create(_fileSize).CopyToAsync(stream);
            }
            _stream = File.OpenRead(_filePath);

            await base.SetupAsync();
        }

        public override Task CleanupAsync()
        {
            _stream.Close();
            File.Delete(_filePath);
            return base.CleanupAsync();
        }

        public override void Dispose(bool disposing)
        {
            _stream.Close();
            base.Dispose(disposing);
        }

        public override void Run(CancellationToken cancellationToken)
        {
            _stream.Seek(0, SeekOrigin.Begin);
            BlobClient.Upload(_stream, transferOptions: Options.StorageTransferOptions, cancellationToken: cancellationToken);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            _stream.Seek(0, SeekOrigin.Begin);
            await BlobClient.UploadAsync(
                _stream,
                new BlobUploadOptions
                {
                    TransferOptions = Options.StorageTransferOptions,
                    TransferValidationOptions = Options.UploadValidationOptions
                },
                cancellationToken: cancellationToken);
        }
    }
}
