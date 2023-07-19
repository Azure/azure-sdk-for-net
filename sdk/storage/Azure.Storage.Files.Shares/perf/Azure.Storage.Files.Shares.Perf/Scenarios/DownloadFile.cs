// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Storage.Files.Shares.Perf.Scenarios
{
    /// <summary>
    /// The performance test scenario focused on downloading files from the Azure Files Shares storage.
    /// </summary>
    /// <seealso cref="Azure.Test.Perf.PerfTest{SizeOptions}" />
    public sealed class DownloadFile : FileTest<Options.FileTransferOptions>
    {
        /// <summary>
        /// Local stream uploaded to Azure storage.
        /// </summary>
        private readonly Stream _stream;

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadFile"/> class.
        /// </summary>
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        public DownloadFile(Options.FileTransferOptions options)
            : base(options, createFile: true, singletonFile: false)
        {
            _stream = RandomStream.Create(options.Size);
        }

        public override void Dispose(bool disposing)
        {
            _stream.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Downloads a file from the Azure Shares files storage by calling <see cref="ShareFileClient.Download(HttpRange, bool, CancellationToken)"/>.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal cancellation request.</param>
        public override void Run(CancellationToken cancellationToken)
        {
            Models.ShareFileDownloadInfo fileDownloadInfo = FileClient.Download(cancellationToken: cancellationToken);

            // Copy the stream so it is actually downloaded. We use a memory stream as destination to avoid the cost of copying to a file on disk.
            fileDownloadInfo.Content.CopyTo(Stream.Null);

#if DEBUG
            Console.WriteLine($"Downloaded file from {FileClient.Path}. Content length: {fileDownloadInfo.ContentLength}");
#endif
        }

        /// <summary>
        /// Downloads a file from the Azure Shares files storage by calling <see cref="ShareFileClient.DownloadAsync(HttpRange, bool, CancellationToken)"/>.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal cancellation request.</param>
        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            Models.ShareFileDownloadInfo fileDownloadInfo = await FileClient.DownloadAsync(cancellationToken: cancellationToken);

            // Copy the stream so it is actually downloaded. We use a local memory stream as destination to avoid the cost of copying to a file on disk.
            await fileDownloadInfo.Content.CopyToAsync(Stream.Null, (int)_stream.Length, cancellationToken: cancellationToken);

#if DEBUG
            Console.WriteLine($"Downloaded file from {FileClient.Path}. Content length: {fileDownloadInfo.ContentLength}");
#endif
        }
    }
}
