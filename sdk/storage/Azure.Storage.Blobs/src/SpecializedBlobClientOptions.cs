// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Specialized
{
    /// <summary>
    /// Provides advanced client configuration options for connecting to Azure Blob
    /// Storage.
    /// </summary>
#pragma warning disable AZC0008 // ClientOptions should have a nested enum called ServiceVersion; This is an extension of existing public options that obey this.
    public class SpecializedBlobClientOptions : BlobClientOptions
#pragma warning restore AZC0008 // ClientOptions should have a nested enum called ServiceVersion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlobClientOptions"/>
        /// class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="BlobClientOptions.ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
        public SpecializedBlobClientOptions(ServiceVersion version = LatestVersion) : base(version)
        {
        }

        /// <summary>
        /// Settings for data encryption when uploading and downloading with a <see cref="BlobClient"/>.
        /// Client-side encryption adds metadata to your blob which is necessary for decryption.
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
