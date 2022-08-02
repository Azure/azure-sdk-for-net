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
    /// The performance test scenario focused on uploading files to the Azure Files Shares storage.
    /// </summary>
    public sealed class UploadFile : FileTest<Options.FileTransferOptions>
    {
        /// <summary>
        /// Local stream uploaded to Azure storage.
        /// </summary>
        private readonly Stream _stream;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadFile"/> class.
        /// </summary>
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        public UploadFile(Options.FileTransferOptions options)
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
        /// Uploads a file to Azure Shares files storage by calling <see cref="ShareFileClient.Upload(Stream, IProgress{long}, CancellationToken)"/>.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal cancellation request.</param>
        public override void Run(CancellationToken cancellationToken)
        {
            _stream.Seek(0, SeekOrigin.Begin);

            Models.ShareFileUploadInfo fileUploadInfo = FileClient.Upload(_stream, cancellationToken: cancellationToken);

#if DEBUG
            Console.WriteLine($"Uploaded stream to {FileClient.Path}. Hash: {fileUploadInfo.ContentHash.Length}");
#endif
        }

        /// <summary>
        /// Uploads a file to Azure Shares files storage by calling <see cref="ShareFileClient.UploadAsync(Stream, IProgress{long}, CancellationToken)"/>.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal cancellation request.</param>
        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            _stream.Seek(0, SeekOrigin.Begin);

            Models.ShareFileUploadInfo fileUploadInfo = await FileClient.UploadAsync(_stream, cancellationToken: cancellationToken);

#if DEBUG
            Console.WriteLine($"Uploaded stream to {FileClient.Path}. Hash: {fileUploadInfo.ContentHash.Length}");
#endif
        }
    }
}
