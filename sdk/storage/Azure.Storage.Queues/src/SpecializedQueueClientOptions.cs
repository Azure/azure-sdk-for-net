// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.Queues.Models;

namespace Azure.Storage.Queues.Specialized
{
    /// <summary>
    /// Provides advanced client configuration options for connecting to Azure Queue
    /// Storage.
    /// </summary>
#pragma warning disable AZC0008 // ClientOptions should have a nested enum called ServiceVersion; This is an extension of existing public options that obey this.
    public class SpecializedQueueClientOptions : QueueClientOptions
#pragma warning restore AZC0008 // ClientOptions should have a nested enum called ServiceVersion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueueClientOptions"/>
        /// class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="QueueClientOptions.ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
        public SpecializedQueueClientOptions(ServiceVersion version = LatestVersion) : base(version)
        {
        }

        /// <summary>
        /// Settings for data encryption within the SDK. Client-side encryption adds metadata to your queue
        /// messages which is necessary to maintain for decryption.
        ///
        /// For more information, see <a href="https://docs.microsoft.com/en-us/azure/storage/common/storage-client-side-encryption"/>.
        /// </summary>
        public ClientSideEncryptionOptions ClientSideEncryption
        {
            get => _clientSideEncryptionOptions;
            set => _clientSideEncryptionOptions = value;
        }
    }
}
