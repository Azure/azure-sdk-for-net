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
        /// Access manager to the Azure storage Share.
        /// This is shared across all instances of the test run.
        /// </summary>
        private static ShareClientManager s_shareClientManager;

        /// <summary>
        /// The path of the local file uploaded to Azure storage.
        /// This is shared across all instances of the test run.
        /// </summary>
        private static string s_uploadFilePath;

        /// <summary>
        /// Name of the <see cref="ShareFileClient"/> where the file is uploaded.
        /// This is shared across all instances of the test run.
        /// </summary>
        private static string s_fileClientName;

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadFile"/> class.
        /// </summary>
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        public DownloadFile(SizeOptions options) : base(options)
        {
        }

        /// <summary>
        /// Instantiates and creates a <see cref="ShareClient"/> and a <see cref="ShareDirectoryClient"/> for the test.
        /// Also, creates a local file and uploads it to Azure File storage.
        /// </summary>
        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();

            s_shareClientManager = new ShareClientManager();
            await s_shareClientManager.CreateShareClientAsync();

            s_uploadFilePath = await ShareClientManager.CreateRandomFileAsync(Options.Size);
            s_fileClientName = await s_shareClientManager.UploadFileAsync(s_uploadFilePath, CancellationToken.None);
        }

        /// <summary>
        /// Marks the <see cref="ShareClient"/> used by the test for deletion.
        /// Also, deletes the local file created at setup.
        /// </summary>
        public override async Task GlobalCleanupAsync()
        {
            await base.GlobalCleanupAsync();

            await s_shareClientManager.DisposeAsync();

            try
            {
                File.Delete(s_uploadFilePath);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Downloads a file from the Azure Shares files storage by calling <see cref="ShareFileClient.Download(HttpRange, bool, CancellationToken)"/>.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal cancellation request.</param>
        public override void Run(CancellationToken cancellationToken)
        {
            ShareFileClient fileClient = s_shareClientManager.DirectoryClient.GetFileClient(s_fileClientName);

            Models.ShareFileDownloadInfo fileDownloadInfo = fileClient.Download(cancellationToken: cancellationToken);

            // Copy the stream so it is actually downloaded. We use a memory stream as destination to avoid the cost of copying to a file on disk.
            using (var localStream = new MemoryStream())
            {
                fileDownloadInfo.Content.CopyTo(localStream);

#if DEBUG
                Console.WriteLine($"Downloaded file from {fileClient.Path}. Stream length: {localStream.Length}");
#endif
            }
        }

        /// <summary>
        /// Downloads a file from the Azure Shares files storage by calling <see cref="ShareFileClient.DownloadAsync(HttpRange, bool, CancellationToken)"/>.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal cancellation request.</param>
        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            ShareFileClient fileClient = s_shareClientManager.DirectoryClient.GetFileClient(s_fileClientName);

            Models.ShareFileDownloadInfo fileDownloadInfo = await fileClient.DownloadAsync(cancellationToken: cancellationToken);

            // Copy the stream so it is actually downloaded. We use a local memory stream as destination to avoid the cost of copying to a file on disk.
            using (var localStream = new MemoryStream())
            {
                fileDownloadInfo.Content.CopyTo(localStream);

#if DEBUG
                Console.WriteLine($"Downloaded file from {fileClient.Path}. Stream length: {localStream.Length}");
#endif
            }
        }
    }
}
