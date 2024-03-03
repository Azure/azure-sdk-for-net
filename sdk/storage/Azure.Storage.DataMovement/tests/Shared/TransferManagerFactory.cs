// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            if (options.CheckpointerOptions == null)
            {
                throw new ArgumentNullException(nameof(options.CheckpointerOptions));
            }
            _options = options;
        }

        public TransferManager BuildTransferManager(List<DataTransfer> dataTransfers = default)
        {
            if (dataTransfers != default)
            {
                // populate checkpointer
                if (_options.CheckpointerOptions.CheckpointerPath is null)
                {
                    throw new ArgumentNullException(nameof(dataTransfers));
                }
                if (string.IsNullOrWhiteSpace(_options.CheckpointerOptions.CheckpointerPath))
                {
                    throw new ArgumentException("Value cannot be empty or contain only white-space characters.", nameof(dataTransfers));
                }
                LocalTransferCheckpointerFactory checkpointerFactory = new LocalTransferCheckpointerFactory(_options.CheckpointerOptions.CheckpointerPath);
                checkpointerFactory.BuildCheckpointer(dataTransfers);
            }
            TransferManager transferManager = new TransferManager(_options);

            return transferManager;
        }
    }
}
