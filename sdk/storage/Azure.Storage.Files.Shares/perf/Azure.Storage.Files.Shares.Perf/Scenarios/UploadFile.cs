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
    /// The performance test scenario focused on uploading files to the Azure Files Shares storage.
    /// </summary>
    /// <seealso cref="Azure.Test.Perf.PerfTest{SizeOptions}" />
    public sealed class UploadFile : PerfTest<SizeOptions>
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
        /// Initializes a new instance of the <see cref="UploadFile"/> class.
        /// </summary>
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        public UploadFile(SizeOptions options) : base(options)
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
        }

        public override async Task CleanupAsync()
        {
            await _shareClient.DeleteAsync();
            await base.CleanupAsync();
        }

        /// <summary>
        /// Uploads a file to Azure Shares files storage by calling <see cref="ShareFileClient.Upload(Stream, IProgress{long}, CancellationToken)"/>.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal cancellation request.</param>
        public override void Run(CancellationToken cancellationToken)
        {
            _stream.Seek(0, SeekOrigin.Begin);

            Models.ShareFileUploadInfo fileUploadInfo = _fileClient.Upload(_stream, cancellationToken: cancellationToken);

#if DEBUG
            Console.WriteLine($"Uploaded stream to {_fileClient.Path}. Hash: {fileUploadInfo.ContentHash.Length}");
#endif
        }

        /// <summary>
        /// Uploads a file to Azure Shares files storage by calling <see cref="ShareFileClient.UploadAsync(Stream, IProgress{long}, CancellationToken)"/>.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal cancellation request.</param>
        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            _stream.Seek(0, SeekOrigin.Begin);

            Models.ShareFileUploadInfo fileUploadInfo = await _fileClient.UploadAsync(_stream, cancellationToken: cancellationToken);

#if DEBUG
            Console.WriteLine($"Uploaded stream to {_fileClient.Path}. Hash: {fileUploadInfo.ContentHash.Length}");
#endif
        }
    }
}
