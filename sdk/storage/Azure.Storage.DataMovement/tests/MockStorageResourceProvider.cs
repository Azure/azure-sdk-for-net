// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Common;

namespace Azure.Storage.DataMovement.Tests
{
    /// <summary>
    /// Provider for a <see cref="StorageResource"/> configured for mocking.
    /// </summary>
    internal class MockStorageResourceProvider : StorageResourceProvider
    {
        /// <inheritdoc/>
        protected internal override string ProviderId => "mock";

        internal MemoryTransferCheckpointer checkpointer;

        /// <summary>
        /// Default constructor.
        /// </summary>
        internal MockStorageResourceProvider(
            MemoryTransferCheckpointer checkpter)
        {
            checkpointer = checkpter;
        }

        /// <inheritdoc/>
        protected internal override ValueTask<StorageResource> FromSourceAsync(TransferProperties properties, CancellationToken cancellationToken)
            => new(FromTransferProperties(properties, getSource: true));

        /// <inheritdoc/>
        protected internal override ValueTask<StorageResource> FromDestinationAsync(TransferProperties properties, CancellationToken cancellationToken)
            => new(FromTransferProperties(properties, getSource: false));

        private StorageResource FromTransferProperties(TransferProperties properties, bool getSource)
        {
            Argument.AssertNotNull(properties, nameof(properties));

            string transferId = properties.TransferId;
            if (!checkpointer.Jobs.TryGetValue(transferId, out var job))
            {
                throw new Exception("Job does not exist.");
            }

            if (getSource)
            {
                return job.Source;
            }
            else
            {
                return job.Destination;
            }
        }
    }
}
