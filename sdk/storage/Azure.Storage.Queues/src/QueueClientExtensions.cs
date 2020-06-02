// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Queues.Specialized
{
    /// <summary>
    /// Provides advanced extensions for queue service clients.
    /// </summary>
    public static class QueueClientExtensions
    {
        /// <summary>
        /// Creates a new instance of the <see cref="QueueClient"/> class, maintaining all the same
        /// internals but specifying new <see cref="ClientSideEncryptionOptions"/>.
        /// </summary>
        /// <param name="client">Client to base off of.</param>
        /// <param name="clientSideEncryptionOptions">New encryption options. Setting this to <code>default</code> will clear client-side encryption.</param>
        /// <returns>New instance with provided options and same internals otherwise.</returns>
        public static QueueClient WithClientSideEncryptionOptions(this QueueClient client, ClientSideEncryptionOptions clientSideEncryptionOptions)
            => new QueueClient(
                client.Uri,
                client.Pipeline,
                client.Version,
                client.ClientDiagnostics,
                clientSideEncryptionOptions,
                client.OnClientSideDecryptionFailure);

        /// <summary>
        /// Creates a new instance of the <see cref="QueueClient"/> class, maintaining all the same
        /// internals but specifying new <see cref="ClientSideEncryptionOptions"/>.
        /// </summary>
        /// <param name="client">Client to base off of.</param>
        /// <param name="listener">Listener for when decryption of a single message fails.</param>
        /// <returns>New instance with provided options and same internals otherwise.</returns>
        public static QueueClient WithClientSideEncryptionFailureListener(this QueueClient client, IClientSideDecryptionFailureListener listener)
            => new QueueClient(
                client.Uri,
                client.Pipeline,
                client.Version,
                client.ClientDiagnostics,
                client.ClientSideEncryption,
                listener);
    }
}
