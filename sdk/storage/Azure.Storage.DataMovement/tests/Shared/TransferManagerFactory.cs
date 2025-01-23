// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.Storage.Common;

namespace Azure.Storage.DataMovement.Tests
{
    internal class TransferManagerFactory
    {
        private TransferManagerOptions _options;

        public TransferManagerFactory(TransferManagerOptions options)
        {
            Argument.CheckNotNull(options, nameof(options));
            Argument.CheckNotNull(options.CheckpointStoreOptions, nameof(options.CheckpointStoreOptions));
            _options = options;
        }

        public TransferManager BuildTransferManager(List<TransferOperation> transfers = default)
        {
            if (transfers != default)
            {
                // populate checkpointer
                Argument.AssertNotNullOrWhiteSpace(_options.CheckpointStoreOptions.CheckpointPath, nameof(transfers));
                LocalTransferCheckpointerFactory checkpointerFactory = new LocalTransferCheckpointerFactory(_options.CheckpointStoreOptions.CheckpointPath);
                checkpointerFactory.BuildCheckpointer(transfers);
            }
            TransferManager transferManager = new TransferManager(_options);

            return transferManager;
        }
    }
}
