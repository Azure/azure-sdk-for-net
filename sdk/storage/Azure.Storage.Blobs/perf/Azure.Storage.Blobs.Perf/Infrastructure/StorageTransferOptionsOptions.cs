// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Test.Perf;
using CommandLine;

namespace Azure.Storage.Blobs.Perf
{
    public class StorageTransferOptionsOptions : SizeOptions
    {
        private long? _maximumTransferSize;
        private long? _initialTransferSize;
        private int? _maximumConcurrency;

        private string _validationAlgorithm;

        [Option('l', "MaximumTransferSize", HelpText = "Size of partitioned transfer chunk.")]
        public long? MaximumTransferSize
        {
            get => _maximumTransferSize;
            set
            {
                _maximumTransferSize = value;
                UpdateStorageTransferOptions();
            }
        }

        [Option("InitialTransferSize", HelpText = "Size of first partitioned transfer chunk.")]
        public long? InitialTransferSize
        {
            get => _initialTransferSize;
            set
            {
                _initialTransferSize = value;
                UpdateStorageTransferOptions();
            }
        }

        [Option('t', "MaximumConcurrency", HelpText = "Max parallel chunk transferes in partitioned transfer.")]
        public int? MaximumConcurrency
        {
            get => _maximumConcurrency;
            set
            {
                _maximumConcurrency = value;
                UpdateStorageTransferOptions();
            }
        }

        [Option("validationAlgorithm", HelpText = "Checksum algorithm to use for SDK-managed transfer validation.")]
        public string ValidationAlgorithm
        {
            get => _validationAlgorithm;
            set
            {
                _validationAlgorithm = value;
                UpdateTransferValidationOptions();
            }
        }

        public StorageTransferOptions StorageTransferOptions { get; private set; }

        public UploadTransferValidationOptions UploadValidationOptions { get; private set; }

        private void UpdateStorageTransferOptions()
        {
            StorageTransferOptions = new StorageTransferOptions()
            {
                MaximumConcurrency = MaximumConcurrency,
                MaximumTransferSize = MaximumTransferSize,
                InitialTransferSize = InitialTransferSize
            };
        }

        private void UpdateTransferValidationOptions()
        {
            UploadValidationOptions = _validationAlgorithm == null
                ? null
                : new UploadTransferValidationOptions
                {
                    Algorithm = (ValidationAlgorithm)Enum.Parse(typeof(ValidationAlgorithm), _validationAlgorithm, ignoreCase: true)
                };
        }
    }
}
