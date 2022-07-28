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

        [Option("client-encryption")]
        public string EncryptionVersionString { get; set; }

        public StorageTransferOptions StorageTransferOptions { get; private set; }

        BlobClientOptions IBlobClientOptionsProvider.ClientOptions
        {
            get
            {
                static bool TryParseEncryptionVersion(
                    string versionString,
                    out ClientSideEncryptionVersion version)
                {
                    switch (versionString)
                    {
                        case "2.0":
                            version = ClientSideEncryptionVersion.V2_0;
                            return true;
#pragma warning disable CS0618 // obsolete
                        case "1.0":
                            version = ClientSideEncryptionVersion.V1_0;
                            return true;
#pragma warning restore CS0618 // obsolete
                        default:
                            version = 0;
                            return false;
                    }
                }
                var result = new SpecializedBlobClientOptions
                {
                    ClientSideEncryption = TryParseEncryptionVersion(EncryptionVersionString, out ClientSideEncryptionVersion version)
                        ? new ClientSideEncryptionOptions(version)
                        {
                            KeyEncryptionKey = new LocalKeyEncryptionKey(),
                            KeyWrapAlgorithm = "foo"
                        }
                        : default
                };
                return result;
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