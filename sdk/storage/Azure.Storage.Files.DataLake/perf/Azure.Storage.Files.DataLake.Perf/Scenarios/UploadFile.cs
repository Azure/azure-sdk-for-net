// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Storage.Files.DataLake.Perf.Scenarios
{
    /// <summary>
    /// The performance test scenario focused on uploading to Data Lake storage.
    /// </summary>
    /// <seealso cref="Azure.Test.Perf.PerfTest{SizeOptions}" />
    public sealed class UploadFile : FileTest<Options.PartitionedTransferOptions>
    {
        /// <summary>
        /// The path of the file to be uploaded.
        /// </summary>
        private string UploadPath { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadFile"/> class.
        /// </summary>
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        public UploadFile(Options.PartitionedTransferOptions options)
            : base(options, createFile: false, singletonFile: false)
        {
        }

        /// <summary>
        /// Performs the tasks needed to initialize and set up the environment for an instance
        /// of the test scenario.  When multiple instances are run in parallel, setup will be
        /// run once for each prior to its execution.
        /// </summary>
        public override async Task SetupAsync()
        {
            await base.SetupAsync();
            UploadPath = Path.GetTempFileName();

            using var uploadFile = File.OpenWrite(UploadPath);
            using var randomStream = RandomStream.Create(Options.Size);

            await randomStream.CopyToAsync(uploadFile);
            uploadFile.Close();
        }

        /// <summary>
        /// Performs the tasks needed to clean up the environment for an instance
        /// of the test scenario.  When multiple instances are run in parallel, cleanup
        /// will be run once for each after execution has completed.
        /// </summary>
        public override async Task CleanupAsync()
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
        /// Executes the performance test scenario synchronously.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal when cancellation is requested.</param>
        public override void Run(CancellationToken cancellationToken)
        {
            FileClient.Upload(
                UploadPath,
                transferOptions: Options.StorageTransferOptions,
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Executes the performance test scenario asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal when cancellation is requested.</param>
        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await FileClient.UploadAsync(
                UploadPath,
                transferOptions: Options.StorageTransferOptions,
                cancellationToken: cancellationToken);
        }
    }
}
