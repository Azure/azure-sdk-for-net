// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Queues.Specialized
{
    /// <summary>
    /// The <see cref="EncryptedQueueClient"/> allows you to manipulate
    /// Azure Storage queues with client-side encryption.
    /// </summary>
    public class EncryptedQueueClient : QueueClient
    {
        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="EncryptedQueueClient"/>
        /// class for mocking.
        /// </summary>
        protected EncryptedQueueClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EncryptedQueueClient"/>
        /// class.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information, <see href="https://docs.microsoft.com/en-us/azure/storage/common/storage-configure-connection-string"/>.
        /// </param>
        /// <param name="queueName">
        /// The name of the encrypted queue in the storage account to reference.
        /// </param>
        public EncryptedQueueClient(string connectionString, string queueName)
            : base(connectionString, queueName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EncryptedQueueClient"/>
        /// class.
        /// </summary>
        /// <param name="connectionString">
        /// A connection string includes the authentication information
        /// required for your application to access data in an Azure Storage
        /// account at runtime.
        ///
        /// For more information, <see href="https://docs.microsoft.com/en-us/azure/storage/common/storage-configure-connection-string"/>.
        /// </param>
        /// <param name="queueName">
        /// The name of the encrypted queue in the storage account to reference.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public EncryptedQueueClient(string connectionString, string queueName, QueueClientOptions options)
            : base(connectionString, queueName, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EncryptedQueueClient"/>
        /// class.
        /// </summary>
        /// <param name="queueUri">
        /// A <see cref="Uri"/> referencing the encrypted queue that includes the
        /// name of the account, and the name of the queue.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public EncryptedQueueClient(Uri queueUri, QueueClientOptions options = default)
            : base(queueUri, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EncryptedQueueClient"/>
        /// class.
        /// </summary>
        /// <param name="queueUri">
        /// A <see cref="Uri"/> referencing the encrypted queue that includes the
        /// name of the account, and the name of the queue.
        /// </param>
        /// <param name="credential">
        /// The shared key credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public EncryptedQueueClient(Uri queueUri, StorageSharedKeyCredential credential, QueueClientOptions options = default)
            : base(queueUri, credential, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EncryptedQueueClient"/>
        /// class.
        /// </summary>
        /// <param name="queueUri">
        /// A <see cref="Uri"/> referencing the encrypted queue that includes the
        /// name of the account, and the name of the queue.
        /// </param>
        /// <param name="credential">
        /// The token credential used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public EncryptedQueueClient(Uri queueUri, TokenCredential credential, QueueClientOptions options = default)
            : base(queueUri, credential, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EncryptedQueueClient"/>
        /// class.
        /// </summary>
        /// <param name="queueUri">
        /// A <see cref="Uri"/> referencing the encrypted queue that includes the
        /// name of the account, and the name of the queue.
        /// </param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        /// <param name="clientDiagnostics"></param>
        internal EncryptedQueueClient(Uri queueUri, HttpPipeline pipeline, ClientDiagnostics clientDiagnostics)
            : base(queueUri, pipeline, clientDiagnostics)
        {
        }
        #endregion ctors
    }

    /// <summary>
    /// Add easy to discover methods to <see cref="QueueServiceClient"/> for
    /// creating <see cref="EncryptedQueueClient"/> instances.
    /// </summary>
    public static partial class SpecializedBlobExtensions
    {
        /// <summary>
        /// Create a new <see cref="EncryptedQueueClient"/> object by
        /// concatenating <paramref name="queueName"/> to
        /// the end of the <paramref name="client"/>'s
        /// <see cref="QueueServiceClient.Uri"/>. The new
        /// <see cref="EncryptedQueueClient"/>
        /// uses the same request policy pipeline as the
        /// <see cref="QueueServiceClient"/>.
        /// </summary>
        /// <param name="client">The <see cref="QueueServiceClient"/>.</param>
        /// <param name="queueName">The name of the encrypted block blob.</param>
        /// <returns>A new <see cref="EncryptedQueueClient"/> instance.</returns>
        public static EncryptedQueueClient GetEncryptedQueueClient(
            this QueueServiceClient client,
            string queueName)
            => new EncryptedQueueClient(client.Uri.AppendToPath(queueName), client.Pipeline, client.ClientDiagnostics);
    }
}
