// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azure.Storage.DataMovement
{
    internal class TransferManagerFactory
    {
        private List<DataTransfer> _dataTransfers;

        public TransferManagerFactory(List<DataTransfer> dataTransfers)
        {
            _dataTransfers = dataTransfers;
        }

        public TransferManager BuildTransferManager()
        {
            TransferManager transferManager = new TransferManager();

            transferManager._dataTransfers = _dataTransfers.ToDictionary(d => d.Id);

            return transferManager;
        }
    }
}
