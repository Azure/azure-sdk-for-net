//Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Storage.Blobs.Perf.Scenarios
{
    /// <summary>
    /// The performance test scenario focused on uploading blobs to the Azure blobs storage.
    /// </summary>
    /// <seealso cref="Azure.Test.Perf.PerfTest{SizeOptions}" />
    public sealed class UploadBlob : BlobTest<StorageTransferOptionsOptions>
    {
        private readonly Stream _stream;

        public UploadBlob(StorageTransferOptionsOptions options) : base (options)
        {
            _stream = RandomStream.Create(options.Size);
        }

        public override void Dispose(bool disposing)
        {
            _stream.Dispose();
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
            await BlobClient.UploadAsync(_stream, transferOptions: Options.StorageTransferOptions, cancellationToken: cancellationToken);
        }
    }
}
