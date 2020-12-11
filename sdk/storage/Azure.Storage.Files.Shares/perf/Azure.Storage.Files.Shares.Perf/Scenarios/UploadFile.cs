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
        /// Access manager to the Azure storage Share.
        /// This is shared across all instances of the test run.
        /// </summary>
        private static ShareClientManager s_shareClientManager;

        /// <summary>
        /// The path of the local file uploaded to Azure storage.
        /// </summary>
        private string _uploadFilePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadFile"/> class.
        /// </summary>
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        public UploadFile(SizeOptions options) : base(options)
        {
        }

        /// <summary>
        /// Instantiates and creates a <see cref="ShareClient"/> and a <see cref="ShareDirectoryClient"/> for the test.
        /// </summary>
        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();

            s_shareClientManager = new ShareClientManager();
            await s_shareClientManager.CreateShareClientAsync();

            _uploadFilePath = await ShareClientManager.CreateRandomFileAsync(Options.Size);
        }

        /// <summary>
        /// Marks the <see cref="ShareClient"/> used by the test for deletion.
        /// </summary>
        public override async Task GlobalCleanupAsync()
        {
            await base.GlobalCleanupAsync();

            await s_shareClientManager.DisposeAsync();
        }

        /// <summary>
        /// Creates a file of the appropriate size filled with random characters.
        /// The test will use a <see cref="ShareFileClient"/> to upload this file.
        /// </summary>
        public override async Task SetupAsync()
        {
            await base.SetupAsync();

            _uploadFilePath = await ShareClientManager.CreateRandomFileAsync(Options.Size);
        }

        /// <summary>
        /// Deletes the local file created by the test.
        /// </summary>
        public override async Task CleanupAsync()
        {
            await base.CleanupAsync();

            try
            {
                File.Delete(_uploadFilePath);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Uploads a file to Azure Shares files storage by calling <see cref="ShareFileClient.Upload(Stream, IProgress{long}, CancellationToken)"/>.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal cancellation request.</param>
        public override void Run(CancellationToken cancellationToken)
        {
            ShareFileClient fileClient = s_shareClientManager.DirectoryClient.GetFileClient(Path.GetRandomFileName());

            using (FileStream stream = File.OpenRead(_uploadFilePath))
            {
                fileClient.Create(stream.Length, cancellationToken: cancellationToken);

                Models.ShareFileUploadInfo fileUploadInfo = fileClient.Upload(stream, cancellationToken: cancellationToken);

#if DEBUG
                Console.WriteLine($"Uploaded file to {fileClient.Path}. Hash: {fileUploadInfo.ContentHash.Length}");
#endif
            }
        }

        /// <summary>
        /// Uploads a file to Azure Shares files storage by calling <see cref="ShareFileClient.UploadAsync(Stream, IProgress{long}, CancellationToken)"/>.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal cancellation request.</param>
        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            _ = await s_shareClientManager.UploadFileAsync(_uploadFilePath, cancellationToken);
        }
    }
}
