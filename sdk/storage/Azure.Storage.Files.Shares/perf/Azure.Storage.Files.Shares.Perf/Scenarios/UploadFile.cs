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
    /// The performance test scenario focused on uploading files to the Files Shares storage.
    /// </summary>
    /// <seealso cref="Azure.Test.Perf.PerfTest{SizeOptions}" />
    public sealed class UploadFile : PerfTest<SizeOptions>
    {
        /// <summary>
        /// Name of the directory client.
        /// </summary>
        internal string DirectoryClientName { get; private set; }

        /// <summary>
        /// Name of the file client.
        /// </summary>
        internal string FileClientName { get; private set; }

        /// <summary>
        /// The client for interaction with the Files Shares file system.
        /// </summary>
        internal ShareClient FilesShareClient { get; private set; }

        /// <summary>
        /// The path of the local file that is uploaded.
        /// </summary>
        private string UploadFilePath { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadFile"/> class.
        /// </summary>
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        public UploadFile(SizeOptions options) : base(options)
        {
        }

        /// <summary>
        /// Performs the tasks needed to initialize and set up the environment for the test scenario.
        /// When multiple instances are run in parallel, the setup will take place once, prior to the
        /// execution of the first test instance.
        /// </summary>
        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();

            // See https://docs.microsoft.com/en-us/rest/api/storageservices/naming-and-referencing-shares--directories--files--and-metadata for
            // restrictions on file share naming.
            FilesShareClient = new ShareClient(PerfTestEnvironment.Instance.FileSharesConnectionString, Guid.NewGuid().ToString());
            await FilesShareClient.CreateAsync();
        }

        /// <summary>
        /// Performs the tasks needed to clean up the environment for the test scenario.
        /// When multiple instances are run in parallel, the cleanup will take place once,
        /// after the execution of all test instances.
        /// </summary>
        public override async Task GlobalCleanupAsync()
        {
            await base.GlobalCleanupAsync();

            await FilesShareClient.DeleteAsync();
        }

        /// <summary>
        /// Performs the tasks needed to initialize and set up the environment for an instance of the test scenario.
        /// When multiple instances are run in parallel, setup will be run once for each prior to its execution.
        /// </summary>
        public override async Task SetupAsync()
        {
            await base.SetupAsync();

            // Create a temporary file and fill it with random characters.
            // The test will use 'ShareClient' to upload this file.
            UploadFilePath = Path.GetTempFileName();

            using FileStream uploadFileStream = File.OpenWrite(UploadFilePath);
            using Stream randomStream = RandomStream.Create(Options.Size);

            await randomStream.CopyToAsync(uploadFileStream);

#if DEBUG
            Console.WriteLine($"Created local file {UploadFilePath}. Length: {uploadFileStream.Length}");
#endif
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
                File.Delete(UploadFilePath);
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
            DirectoryClientName = Path.GetRandomFileName();

            ShareDirectoryClient directoryClient = FilesShareClient.GetDirectoryClient(DirectoryClientName);
            directoryClient.Create(cancellationToken: cancellationToken);

            FileClientName = Path.GetFileName(UploadFilePath);

            ShareFileClient fileClient = directoryClient.GetFileClient(FileClientName);

            using (FileStream stream = File.OpenRead(UploadFilePath))
            {
                fileClient.Create(stream.Length, cancellationToken: cancellationToken);

                Models.ShareFileUploadInfo fileUploadInfo = fileClient.Upload(stream, cancellationToken: cancellationToken);

#if DEBUG
                Console.WriteLine($"Uploaded file to {fileClient.Path}. Hash: {fileUploadInfo.ContentHash.Length}");
#endif
            }
        }

        /// <summary>
        /// Executes the performance test scenario asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal when cancellation is requested.</param>
        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            DirectoryClientName = Path.GetRandomFileName();

            ShareDirectoryClient directoryClient = FilesShareClient.GetDirectoryClient(DirectoryClientName);
            await directoryClient.CreateAsync(cancellationToken: cancellationToken);

            FileClientName = Path.GetFileName(UploadFilePath);

            ShareFileClient fileClient = directoryClient.GetFileClient(FileClientName);

            using (FileStream stream = File.OpenRead(UploadFilePath))
            {
                await fileClient.CreateAsync(stream.Length, cancellationToken: cancellationToken);

                Models.ShareFileUploadInfo fileUploadInfo = await fileClient.UploadAsync(stream, cancellationToken: cancellationToken);

#if DEBUG
                Console.WriteLine($"Uploaded file to {fileClient.Path}. Hash: {fileUploadInfo.ContentHash.Length}");
#endif
            }
        }

        /// <summary>
        /// Utility method to upload a file to a Storage Files Shares client.
        /// </summary>
        internal async Task<(ShareClient fileShareClient, string diectoryClientName, string fileClientName)> UploadARandomFileAsync()
        {
            await SetupAsync();
            await RunAsync(CancellationToken.None);

            return (FilesShareClient, DirectoryClientName, FileClientName);
        }
    }
}
