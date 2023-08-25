// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Storage.DataMovement.Tests
{
    internal class TransferManagerFactory
    {
        private TransferManagerOptions _options;

        public TransferManagerFactory(TransferManagerOptions options)
        {
            Argument.CheckNotNull(options, nameof(options));
            Argument.CheckNotNull(options.CheckpointerOptions, nameof(options.CheckpointerOptions));
            _options = options;
        }

        public TransferManager BuildTransferManager(List<DataTransfer> dataTransfers = default)
        {
            if (dataTransfers != default)
            {
                // populate checkpointer
                Argument.AssertNotNullOrWhiteSpace(_options.CheckpointerOptions.CheckpointerPath, nameof(dataTransfers));
                LocalTransferCheckpointerFactory checkpointerFactory = new LocalTransferCheckpointerFactory(_options.CheckpointerOptions.CheckpointerPath);
                checkpointerFactory.BuildCheckpointer(dataTransfers);
            }
            TransferManager transferManager = new TransferManager(_options);

            return transferManager;
        }
    }
}
