//Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Storage.Files.DataLake.Perf.Scenarios
{
    /// <summary>
    ///   The performance test scenario focused on uploading to Data Lake storage.
    /// </summary>
    ///
    /// <seealso cref="Azure.Test.Perf.PerfTest{SizeOptions}" />
    ///
    public sealed class UploadFile : PerfTest<SizeOptions>
    {
        /// <summary>
        ///   The ambient test environment associated with the current execution.
        /// </summary>
        ///
        private static PerfTestEnvironment TestEnvironment { get; } = PerfTestEnvironment.Instance;

        /// <summary>
        ///   The name of the file system to use across parallel executions of the scenario.
        /// </summary>
        ///
        private static string FileSystemName { get; } = Guid.NewGuid().ToString();

        /// <summary>
        ///   The client for interaction with the Data Lake file system.
        /// </summary>
        ///
        private DataLakeFileSystemClient FileSystemClient { get; }

        /// <summary>
        ///   The path of the file to be uploaded.
        /// </summary>
        ///
        private string UploadPath { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="UploadFile"/> class.
        /// </summary>
        ///
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        ///
        public UploadFile(SizeOptions options) : base(options)
        {
            var serviceClient = new DataLakeServiceClient(TestEnvironment.DataLakeServiceUri, TestEnvironment.DataLakeCredential);
            FileSystemClient = serviceClient.GetFileSystemClient(FileSystemName);
        }

        /// <summary>
        ///   Performs the tasks needed to initialize and set up the environment for the test scenario.
        ///   When multiple instances are run in parallel, the setup will take place once, prior to the
        ///   execution of the first test instance.
        /// </summary>
        ///
        public async override Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();
            await FileSystemClient.CreateAsync();
        }

        /// <summary>
        ///   Performs the tasks needed to clean up the environment for the test scenario.
        ///   When multiple instances are run in parallel, the cleanup will take place once,
        ///   after the execution of all test instances.
        /// </summary>
        ///
        public async override Task GlobalCleanupAsync()
        {
            await base.GlobalCleanupAsync();
            await FileSystemClient.DeleteAsync();
        }

        /// <summary>
        ///   Performs the tasks needed to initialize and set up the environment for an instance
        ///   of the test scenario.  When multiple instances are run in parallel, setup will be
        ///   run once for each prior to its execution.
        /// </summary>
        ///
        public async override Task SetupAsync()
        {
            await base.SetupAsync();
            UploadPath = Path.GetTempFileName();

            using var uploadFile = File.OpenWrite(UploadPath);
            using var randomStream = RandomStream.Create(Options.Size);

            await randomStream.CopyToAsync(uploadFile);
            uploadFile.Close();
        }

        /// <summary>
        ///   Performs the tasks needed to clean up the environment for an instance
        ///   of the test scenario.  When multiple instances are run in parallel, cleanup
        ///   will be run once for each after execution has completed.
        /// </summary>
        ///
        public async override Task CleanupAsync()
        {
            await base.CleanupAsync();

            // Make a best effort to clean the upload file.  If there is an issue,
            // ignore it.  The file exists in the system temporary area and should
            // be cleaned up by the OS if necessary.

            try
            {
                File.Delete(UploadPath);
            }
            catch
            {
                // Ignore
            }
        }

        /// <summary>
        ///   Executes the performance test scenario synchronously.
        /// </summary>
        ///
        /// <param name="cancellationToken">The token used to signal when cancellation is requested.</param>
        ///
        public override void Run(CancellationToken cancellationToken)
        {
            var fileClient = FileSystemClient.GetFileClient(Path.GetRandomFileName());

            fileClient.Create(cancellationToken: cancellationToken);
            fileClient.Upload(UploadPath, true, cancellationToken: cancellationToken);
        }

        /// <summary>
        ///   Executes the performance test scenario asynchronously.
        /// </summary>
        ///
        /// <param name="cancellationToken">The token used to signal when cancellation is requested.</param>
        ///
        public async override Task RunAsync(CancellationToken cancellationToken)
        {
            var fileClient = FileSystemClient.GetFileClient(Path.GetRandomFileName());

            await fileClient.CreateAsync(cancellationToken: cancellationToken);
            await fileClient.UploadAsync(UploadPath, true, cancellationToken);
        }
    }
}
