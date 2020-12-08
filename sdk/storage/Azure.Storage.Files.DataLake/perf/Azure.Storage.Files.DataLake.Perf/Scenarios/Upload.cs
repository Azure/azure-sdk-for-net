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
    public sealed class Upload : PerfTest<SizeOptions>
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
        ///   The payload to use with a file being uploaded.
        /// </summary>
        ///
        private Stream Payload { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="Upload"/> class.
        /// </summary>
        ///
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        ///
        public Upload(SizeOptions options) : base(options)
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
            Payload = RandomStream.Create(Options.Size);
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
            Payload.Dispose();
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
            Payload.Position = 0;

            fileClient.Create(cancellationToken: cancellationToken);
            fileClient.Upload(Payload, true, cancellationToken);
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
            Payload.Position = 0;

            await fileClient.CreateAsync(cancellationToken: cancellationToken);
            await fileClient.UploadAsync(Payload, true, cancellationToken);
        }
    }
}
