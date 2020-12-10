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
    /// The performance test scenario focused on downloading files from the Files Shares storage.
    /// </summary>
    /// <seealso cref="Azure.Test.Perf.PerfTest{SizeOptions}" />
    public sealed class DownloadFile : PerfTest<SizeOptions>
    {
        /// <summary>
        /// Name of the directory client.
        /// </summary>
        private string DirectoryClientName { get; set; }

        /// <summary>
        /// Name of the file client.
        /// </summary>
        private string FileClientName { get; set; }

        /// <summary>
        /// The client for interaction with the Files Shares file system.
        /// </summary>
        private ShareClient FilesShareClient { get; set; }

        /// <summary>
        /// The path of the file that is created locally from the downloaded data.
        /// </summary>
        private string DownloadFilePath { get; set; }

        /// <summary>
        /// File uploader.
        /// </summary>
        private readonly UploadFile _fileUploader;

        /// <summary>
        /// Initializes a new instance of the <see cref="DownloadFile"/> class.
        /// </summary>
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        public DownloadFile(SizeOptions options) : base(options)
        {
            _fileUploader = new UploadFile(options);
            FilesShareClient = _fileUploader.FilesShareClient;
        }

        /// <summary>
        /// Performs the tasks needed to initialize and set up the environment for the test scenario.
        /// When multiple instances are run in parallel, the setup will take place once, prior to the
        /// execution of the first test instance.
        /// </summary>
        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();

            await _fileUploader.GlobalSetupAsync();
        }

        /// <summary>
        /// Performs the tasks needed to clean up the environment for the test scenario.
        /// When multiple instances are run in parallel, the cleanup will take place once,
        /// after the execution of all test instances.
        /// </summary>
        public override async Task GlobalCleanupAsync()
        {
            await base.GlobalCleanupAsync();

            await _fileUploader.GlobalCleanupAsync();
        }

        /// <summary>
        /// Performs the tasks needed to initialize and set up the environment for an instance of the test scenario.
        /// When multiple instances are run in parallel, setup will be run once for each prior to its execution.
        /// </summary>
        public override async Task SetupAsync()
        {
            await base.SetupAsync();

            // Upload a file to the share storage. The test will use 'ShareClient' to download this file.
            (FilesShareClient, DirectoryClientName, FileClientName) = await _fileUploader.UploadARandomFileAsync();
        }

        /// <summary>
        /// Performs the tasks needed to clean up the environment for an instance of the test scenario.
        /// When multiple instances are run in parallel, cleanup will be run once for each after execution has completed.
        /// </summary>
        public override async Task CleanupAsync()
        {
            await base.CleanupAsync();

            try
            {
                await _fileUploader.CleanupAsync();
                File.Delete(DownloadFilePath);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Executes the performance test scenario synchronously.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal when cancellation is requested.</param>
        public override void Run(CancellationToken cancellationToken)
        {
            ShareDirectoryClient directoryClient = FilesShareClient.GetDirectoryClient(DirectoryClientName);
            ShareFileClient fileClient = directoryClient.GetFileClient(FileClientName);

            Models.ShareFileDownloadInfo fileDownloadInfo = fileClient.Download(cancellationToken: cancellationToken);

            // We only want to measure the download operation. So, skip the part of creating a local file with the downloaded stream.
            //using (FileStream stream = File.OpenWrite(DownloadFilePath))
            //{
            //    fileDownloadInfo.Content.CopyTo(stream);
            //}

#if DEBUG
            Console.WriteLine($"Downloaded file from {fileClient.Path}. Length: {fileDownloadInfo.ContentLength}");
#endif
        }

        /// <summary>
        /// Executes the performance test scenario asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal when cancellation is requested.</param>
        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            ShareDirectoryClient directoryClient = FilesShareClient.GetDirectoryClient(DirectoryClientName);
            ShareFileClient fileClient = directoryClient.GetFileClient(FileClientName);

            Models.ShareFileDownloadInfo fileDownloadInfo = await fileClient.DownloadAsync(cancellationToken: cancellationToken);

            // We only want to measure the download operation. So, skip the part of creating a local file with the downloaded stream.
            //using (FileStream stream = File.OpenWrite(DownloadFilePath))
            //{
            //  fileDownloadInfo.Content.CopyTo(stream);
            //}

#if DEBUG
            Console.WriteLine($"Downloaded file from {fileClient.Path}. Length: {fileDownloadInfo.ContentLength}");
#endif
        }
    }
}
