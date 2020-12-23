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
    ///   The performance test scenario focused on appending to an existing
    ///   file in Data Lake storage.
    /// </summary>
    ///
    /// <seealso cref="Azure.Test.Perf.PerfTest{SizeOptions}" />
    ///
    public sealed class Append : PerfTest<SizeOptions>
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
        ///   The client to use for interactions with the test file.
        /// </summary>
        ///
        private DataLakeFileClient FileClient { get; }

        /// <summary>
        ///   The payload to use with a file being uploaded.
        /// </summary>
        ///
        private Stream Payload { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="Append"/> class.
        /// </summary>
        ///
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        ///
        public Append(SizeOptions options) : base(options)
        {
            var serviceClient = new DataLakeServiceClient(TestEnvironment.DataLakeServiceUri, TestEnvironment.DataLakeCredential);

            FileSystemClient = serviceClient.GetFileSystemClient(FileSystemName);
            FileClient = FileSystemClient.GetFileClient(Path.GetRandomFileName());
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

            // Create the test file that will be used as the basis for uploading.

            using var randomStream = RandomStream.Create(1024);

            await FileClient.CreateAsync();
            await FileClient.UploadAsync(randomStream, true);
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
            Payload.Position = 0;
            FileClient.Append(Payload, 0, cancellationToken:cancellationToken);
        }

        /// <summary>
        ///   Executes the performance test scenario asynchronously.
        /// </summary>
        ///
        /// <param name="cancellationToken">The token used to signal when cancellation is requested.</param>
        ///
        public async override Task RunAsync(CancellationToken cancellationToken)
        {
            Payload.Position = 0;
            await FileClient.AppendAsync(Payload, 0, cancellationToken: cancellationToken);
        }
    }
}
