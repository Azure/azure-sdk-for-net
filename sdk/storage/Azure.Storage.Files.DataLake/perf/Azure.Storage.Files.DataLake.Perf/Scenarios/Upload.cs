// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Storage.Files.DataLake.Perf.Scenarios
{
    /// <summary>
    /// The performance test scenario focused on uploading to Data Lake storage.
    /// </summary>
    /// <seealso cref="Azure.Test.Perf.PerfTest{SizeOptions}" />
    public sealed class Upload : FileTest<Options.PartitionedTransferOptions>
    {
        private readonly Stream _stream;

        /// <summary>
        /// Initializes a new instance of the <see cref="Upload"/> class.
        /// </summary>
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        public Upload(Options.PartitionedTransferOptions options)
            : base(options, createFile: false, singletonFile: false)
        {
            _stream = RandomStream.Create(options.Size);
        }

        public override void Dispose(bool disposing)
        {
            _stream.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Executes the performance test scenario synchronously.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal when cancellation is requested.</param>
        public override void Run(CancellationToken cancellationToken)
        {
            _stream.Seek(0, SeekOrigin.Begin);
            FileClient.Upload(
                _stream,
                transferOptions: Options.StorageTransferOptions,
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Executes the performance test scenario asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal when cancellation is requested.</param>
        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            _stream.Seek(0, SeekOrigin.Begin);
            await FileClient.UploadAsync(
                _stream,
                transferOptions: Options.StorageTransferOptions,
                cancellationToken: cancellationToken);
        }
    }
}
