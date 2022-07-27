// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using CommandLine;

namespace Azure.Storage.Files.DataLake.Perf.Options
{
    public class PartitionedTransferOptions : SizeOptions, IDataLakeClientOptionsProvider, IStorageTransferOptionsProvider
    {
        private long? _maximumTransferSize;
        private long? _initialTransferSize;
        private int? _maximumConcurrency;

        [Option("transfer-block-size")]
        public long? MaximumTransferSize
        {
            get => _maximumTransferSize;
            set
            {
                _maximumTransferSize = value;
                UpdateStorageTransferOptions();
            }
        }

        [Option("transfer-initial-size")]
        public long? InitialTransferSize
        {
            get => _initialTransferSize;
            set
            {
                _initialTransferSize = value;
                UpdateStorageTransferOptions();
            }
        }

        [Option("transfer-concurrency")]
        public int? MaximumConcurrency
        {
            get => _maximumConcurrency;
            set
            {
                _maximumConcurrency = value;
                UpdateStorageTransferOptions();
            }
        }

        [Option("transfer-validation")]
        public StorageChecksumAlgorithm? ChecksumAlgorithm { get; set; }

        public StorageTransferOptions StorageTransferOptions { get; private set; }

        DataLakeClientOptions IDataLakeClientOptionsProvider.ClientOptions
        {
            get
            {
                var options = new DataLakeClientOptions();
                if (ChecksumAlgorithm.HasValue)
                {
                    options.TransferValidation.Upload.ChecksumAlgorithm = ChecksumAlgorithm.Value;
                    options.TransferValidation.Download.ChecksumAlgorithm = ChecksumAlgorithm.Value;
                }
                return options;
            }
        }

        private void UpdateStorageTransferOptions()
        {
            StorageTransferOptions = new StorageTransferOptions()
            {
                MaximumConcurrency = _maximumConcurrency,
                MaximumTransferSize = _maximumTransferSize,
                InitialTransferSize = _initialTransferSize,
            };
        }
    }
}