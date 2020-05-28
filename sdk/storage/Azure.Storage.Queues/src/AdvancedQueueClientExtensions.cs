// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Queues.Specialized
{
    /// <summary>
    /// Provides advanced extensions for queue service clients.
    /// </summary>
    public static class AdvancedQueueClientExtensions
    {
        /// <summary>
        /// Creates a new instance of the <see cref="QueueClient"/> class, maintaining all the same
        /// internals but specifying new <see cref="ClientSideEncryptionOptions"/>.
        /// </summary>
        /// <param name="client">Client to base off of.</param>
        /// <param name="clientSideEncryptionOptions">New encryption options. Setting this to <code>default</code> will clear client-side encryption.</param>
        /// <param name="listener"></param>
        /// <returns>New instance with provided options and same internals otherwise.</returns>
        public static QueueClient WithClientSideEncryptionOptions(this QueueClient client, ClientSideEncryptionOptions clientSideEncryptionOptions, IClientSideDecryptionFailureListener listener = default)
            => new QueueClient(
                client.Uri,
                client.Pipeline,
                client.Version,
                client.ClientDiagnostics,
                clientSideEncryptionOptions,
                listener);
    }
}
