// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Files.DataLake.Perf.Scenarios
{
    /// <summary>
    /// The performance test scenario focused on reading from Data Lake storage.
    /// </summary>
    public sealed class Read : FileTest<Options.PartitionedTransferOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Read"/> class.
        /// </summary>
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        public Read(Options.PartitionedTransferOptions options)
            : base(options, createFile: true, singletonFile: true)
        {
        }

        /// <summary>
        /// Executes the performance test scenario synchronously.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal when cancellation is requested.</param>
        public override void Run(CancellationToken cancellationToken)
        {
            FileClient.ReadTo(
                Stream.Null,
                conditions: default,
                transferOptions: Options.StorageTransferOptions,
                cancellationToken);
        }

        /// <summary>
        /// Executes the performance test scenario asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The token used to signal when cancellation is requested.</param>
        public async override Task RunAsync(CancellationToken cancellationToken)
        {
            await FileClient.ReadToAsync(
                Stream.Null,
                conditions: default,
                transferOptions: Options.StorageTransferOptions,
                cancellationToken);
        }
    }
}
