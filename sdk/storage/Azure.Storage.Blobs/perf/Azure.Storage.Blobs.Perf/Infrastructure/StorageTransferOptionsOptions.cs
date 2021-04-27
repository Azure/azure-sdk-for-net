//Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using CommandLine;

namespace Azure.Storage.Blobs.Perf
{
    public class StorageTransferOptionsOptions : SizeOptions
    {
        private int? _maximumTransferLength;
        private int? _maximumConcurrency;

        [Option('l', "maximumTransferLength")]
        public int? MaximumTransferLength
        {
            get => _maximumTransferLength;
            set
            {
                _maximumTransferLength = value;
                UpdateStorageTransferOptions();
            }
        }

        [Option('t', "MaximumConcurrency")]
        public int? MaximumConcurrency
        {
            get => _maximumConcurrency;
            set
            {
                _maximumConcurrency = value;
                UpdateStorageTransferOptions();
            }
        }

        public StorageTransferOptions StorageTransferOptions { get; private set; }

        private void UpdateStorageTransferOptions()
        {
            StorageTransferOptions = new StorageTransferOptions()
            {
                MaximumConcurrency = MaximumConcurrency,
                MaximumTransferLength = MaximumTransferLength
            };
        }
    }
}
