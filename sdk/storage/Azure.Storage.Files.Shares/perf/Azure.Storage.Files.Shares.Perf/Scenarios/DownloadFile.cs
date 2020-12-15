//Copyright (c) Microsoft Corporation. All rights reserved.
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
    public sealed class DownloadFile : PerfTest<SizeOptions>
    {
        /// <summary>
        /// The client to interact with an Azure storage share.
        /// </summary>
        private ShareClient _shareClient;

        /// <summary>
        /// The client to interact with an Azure storage file inside an Azure storage share.
        /// </summary>
        private ShareFileClient _fileClient;

        /// <summary>
        /// Local stream uploaded to Azure storage.
        /// </summary>
        private readonly Stream _stream;

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadFile"/> class.
        /// </summary>
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        public DownloadFile(SizeOptions options) : base(options)
        {
            _stream = RandomStream.Create(options.Size);
        }

        public override void Dispose(bool disposing)
        {
            _stream.Dispose();
            base.Dispose(disposing);
        }

        public override async Task SetupAsync()
        {
            await base.SetupAsync();

            // See https://docs.microsoft.com/en-us/rest/api/storageservices/naming-and-referencing-shares--directories--files--and-metadata for
            // restrictions on file share naming.
            _shareClient = new ShareClient(PerfTestEnvironment.Instance.FileSharesConnectionString, Guid.NewGuid().ToString());
            await _shareClient.CreateAsync();

            ShareDirectoryClient DirectoryClient = _shareClient.GetDirectoryClient(Path.GetRandomFileName());
            await DirectoryClient.CreateAsync();

            _fileClient = DirectoryClient.GetFileClient(Path.GetRandomFileName());
            await _fileClient.CreateAsync(_stream.Length, cancellationToken: CancellationToken.None);

            await _fileClient.UploadAsync(_stream, cancellationToken: CancellationToken.None);
        }

        public override async Task CleanupAsync()
        {
            await _shareClient.DeleteAsync();
            await base.CleanupAsync();
        }

        /// <summary>
        /// Downloads a file from the Azure Shares files storage by calling <see cref="ShareFileClient.Download(HttpRange, bool, CancellationToken)"/>.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal cancellation request.</param>
        public override void Run(CancellationToken cancellationToken)
        {
            Models.ShareFileDownloadInfo fileDownloadInfo = _fileClient.Download(cancellationToken: cancellationToken);

            // Copy the stream so it is actually downloaded. We use a memory stream as destination to avoid the cost of copying to a file on disk.
            fileDownloadInfo.Content.CopyTo(Stream.Null);

#if DEBUG
            Console.WriteLine($"Downloaded file from {_fileClient.Path}. Content length: {fileDownloadInfo.ContentLength}");
#endif
        }

        /// <summary>
        /// Downloads a file from the Azure Shares files storage by calling <see cref="ShareFileClient.DownloadAsync(HttpRange, bool, CancellationToken)"/>.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal cancellation request.</param>
        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            Models.ShareFileDownloadInfo fileDownloadInfo = await _fileClient.DownloadAsync(cancellationToken: cancellationToken);

            // Copy the stream so it is actually downloaded. We use a local memory stream as destination to avoid the cost of copying to a file on disk.
            await fileDownloadInfo.Content.CopyToAsync(Stream.Null, (int)_stream.Length, cancellationToken: cancellationToken);

#if DEBUG
            Console.WriteLine($"Downloaded file from {_fileClient.Path}. Content length: {fileDownloadInfo.ContentLength}");
#endif
        }
    }
}
