// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs.Perf.Infrastructure;
using Azure.Storage.Blobs.Perf.Infrastructure.Models.ClientSideEncryption;
using Azure.Storage.Blobs.Specialized;
using Azure.Test.Perf;
using CommandLine;

namespace Azure.Storage.Blobs.Perf.Options
{
    public class StorageTransferOptionsOptions : SizeOptions, IBlobClientOptionsOptions
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
        public string EncryptionVersionString { get; set; }

        public StorageTransferOptions StorageTransferOptions { get; private set; }

        BlobClientOptions IBlobClientOptionsOptions.ClientOptions
        {
            get {
                static bool TryParseEncryptionVersion(
                    string versionString,
                    out ClientSideEncryptionVersion version)
                {
                    switch (versionString)
                    {
                        case "2.0":
                            version = ClientSideEncryptionVersion.V2_0;
                            return true;
                        case "1.0":
                            version = ClientSideEncryptionVersion.V1_0;
                            return true;
                        default:
                            version = 0;
                            return false;
                    }
                }
                return new SpecializedBlobClientOptions
                {
                    ClientSideEncryption = TryParseEncryptionVersion(EncryptionVersionString, out ClientSideEncryptionVersion version)
                        ? new ClientSideEncryptionOptions(version)
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