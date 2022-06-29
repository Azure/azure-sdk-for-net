// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Perf.Infrastructure.Models.ClientSideEncryption;
using Azure.Storage.Blobs.Specialized;
using Azure.Test.Perf;
using CommandLine;

namespace Azure.Storage.Blobs.Perf.Options
{
    public class PartitionedTransferOptions : SizeOptions, IBlobClientOptionsProvider, IStorageTransferOptionsProvider
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

        [Option("clientEncryptionVersion")]
        public ClientSideEncryptionVersion? EncryptionVersion { get; set; }

        public StorageTransferOptions StorageTransferOptions { get; private set; }

        BlobClientOptions IBlobClientOptionsProvider.ClientOptions
        {
            get {
                return new SpecializedBlobClientOptions
                {
                    ClientSideEncryption = EncryptionVersion.HasValue
                        ? new ClientSideEncryptionOptions(EncryptionVersion.Value)
                        {
                            KeyEncryptionKey = new LocalKeyEncryptionKey(),
                            KeyWrapAlgorithm = "foo"
                        }
                        : default
                };
            }
        }

        private void UpdateStorageTransferOptions()
        {
            StorageTransferOptions = new StorageTransferOptions()
            {
                MaximumConcurrency = MaximumConcurrency,
                MaximumTransferLength = MaximumTransferLength,
                InitialTransferLength = MaximumTransferLength,
            };
        }
    }
}