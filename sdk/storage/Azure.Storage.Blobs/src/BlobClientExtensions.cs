// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Specialized
{
    /// <summary>
    /// Provides advanced extensions for blob service clients.
    /// </summary>
    public static class BlobClientExtensions
    {
        /// <summary>
        /// Creates a new instance of the <see cref="BlobClient"/> class, maintaining all the same
        /// internals but specifying new <see cref="ClientSideEncryptionOptions"/>.
        /// </summary>
        /// <param name="client">Client to base off of.</param>
        /// <param name="clientSideEncryptionOptions">New encryption options. Setting this to <code>default</code> will clear client-side encryption.</param>
        /// <returns>New instance with provided options and same internals otherwise.</returns>
        public static BlobClient WithClientSideEncryptionOptions(this BlobClient client, ClientSideEncryptionOptions clientSideEncryptionOptions)
            => new BlobClient(
                client.Uri,
                client.Pipeline,
                client.Version,
                client.ClientDiagnostics,
                client.CustomerProvidedKey,
                clientSideEncryptionOptions,
                client.EncryptionScope);
    }
}
