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
        private string _checkpointerPath;

        public TransferManagerFactory(TransferManagerOptions options, string checkpointerPath)
        {
            Argument.CheckNotNull(options, nameof(options));
            Argument.AssertNotNullOrWhiteSpace(checkpointerPath, nameof(checkpointerPath));
            _options = options;
            _checkpointerPath = checkpointerPath;
        }

        public TransferManager BuildTransferManager(List<DataTransfer> dataTransfers = default)
        {
            if (dataTransfers != default)
            {
                // populate checkpointer
                LocalTransferCheckpointerFactory checkpointerFactory = new LocalTransferCheckpointerFactory(_checkpointerPath);
                LocalTransferCheckpointer checkpointer = checkpointerFactory.BuildCheckpointer(dataTransfers);
                _options.Checkpointer = checkpointer;
            }
            TransferManager transferManager = new TransferManager(_options);

            return transferManager;
        }
    }
}
