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
    ///   The performance test scenario focused on reading from Data Lake storage.
    /// </summary>
    ///
    /// <seealso cref="Azure.Test.Perf.PerfTest{SizeOptions}" />
    ///
    public sealed class Read : PerfTest<SizeOptions>
    {
        /// <summary>
        ///   The ambient test environment associated with the current execution.
        /// </summary>
        ///
        private static PerfTestEnvironment TestEnvironment { get; } = PerfTestEnvironment.Instance;

        /// <summary>
        ///   The name of the file to use across parallel executions of the scenario.
        /// </summary>
        ///
        private static string Filename { get; } = Path.GetRandomFileName();

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
        ///   Initializes a new instance of the <see cref="Read"/> class.
        /// </summary>
        ///
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        ///
        public Read(SizeOptions options) : base(options)
        {
            var serviceClient = new DataLakeServiceClient(TestEnvironment.DataLakeServiceUri, TestEnvironment.DataLakeCredential);

            FileSystemClient = serviceClient.GetFileSystemClient(FileSystemName);
            FileClient = FileSystemClient.GetFileClient(Filename);
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

            // Create the test file that will be used for reading.

            using var randomStream = RandomStream.Create(Options.Size);

            await FileClient.CreateAsync();
            await FileClient.UploadAsync(randomStream, true);
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
        ///   Executes the performance test scenario synchronously.
        /// </summary>
        ///
        /// <param name="cancellationToken">The token used to signal when cancellation is requested.</param>
        ///
        public override void Run(CancellationToken cancellationToken)
        {
            FileClient.Read(cancellationToken);
        }

        /// <summary>
        ///   Executes the performance test scenario asynchronously.
        /// </summary>
        ///
        /// <param name="cancellationToken">The token used to signal when cancellation is requested.</param>
        ///
        public async override Task RunAsync(CancellationToken cancellationToken)
        {
            await FileClient.ReadAsync(cancellationToken);
        }
    }
}
