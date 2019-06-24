// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Common;
using Azure.Storage.Queues.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Queues
{
    /// <summary>
    /// A QueueClient represents a URI to the Azure Storage Queue service allowing you to manipulate a queue.
    /// </summary>
    public class QueueClient
    {
        /// <summary>
        /// The Uri endpoint used by the object.
        /// </summary>
        public Uri Uri { get; }

        /// <summary>
        /// The HttpPipeline used to send REST requests.
        /// </summary>
        private readonly HttpPipeline _pipeline;

        /// <summary>
        /// QueueMaxMessagesDequeue indicates the maximum number of messages
        /// you can retrieve with each call to Dequeue.
        /// </summary>
        public const int MaxMessagesDequeue = 32;

        /// <summary>
        /// QueueMaxMessagesPeek indicates the maximum number of messages
        /// you can retrieve with each call to Peek.
        /// </summary>
        public const int MaxMessagesPeek = MaxMessagesDequeue;

        /// <summary>
        /// QueueMessageMaxBytes indicates the maximum number of bytes allowed for a message's UTF-8 text.
        /// </summary>
        public const int MessageMaxBytes = 64 * Constants.KB;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueClient"/>
        /// class.
        /// </summary>
        protected QueueClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueClient"/>
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
        /// The name of the queue in the storage account to reference.
        /// </param>
        public QueueClient(string connectionString, string queueName)
            : this(connectionString, queueName, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueClient"/>
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
        /// The name of the queue in the storage account to reference.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public QueueClient(string connectionString, string queueName, QueueClientOptions options)
        {
            var conn = StorageConnectionString.Parse(connectionString);
            var builder =
                new QueueUriBuilder(conn.QueueEndpoint)
                {
                    QueueName = queueName
                };
            this.Uri = builder.ToUri();
            this._pipeline = (options ?? new QueueClientOptions()).Build(conn.Credentials);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueClient"/>
        /// class.
        /// </summary>
        /// <param name="queueUri">
        /// A <see cref="Uri"/> referencing the queue that includes the
        /// name of the account, and the name of the queue.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        public QueueClient(Uri queueUri, QueueClientOptions options = default)
            : this(queueUri, (HttpPipelinePolicy)null, options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueClient"/>
        /// class.
        /// </summary>
        /// <param name="queueUri">
        /// A <see cref="Uri"/> referencing the queue that includes the
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
        public QueueClient(Uri queueUri, StorageSharedKeyCredential credential, QueueClientOptions options = default)
            : this(queueUri, credential.AsPolicy(), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueClient"/>
        /// class.
        /// </summary>
        /// <param name="queueUri">
        /// A <see cref="Uri"/> referencing the queue that includes the
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
        public QueueClient(Uri queueUri, TokenCredential credential, QueueClientOptions options = default)
            : this(queueUri, credential.AsPolicy(), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueClient"/>
        /// class.
        /// </summary>
        /// <param name="queueUri">
        /// A <see cref="Uri"/> referencing the queue that includes the
        /// name of the account, and the name of the queue.
        /// </param>
        /// <param name="authentication">
        /// An optional authentication policy used to sign requests.
        /// </param>
        /// <param name="options">
        /// Optional client options that define the transport pipeline
        /// policies for authentication, retries, etc., that are applied to
        /// every request.
        /// </param>
        internal QueueClient(Uri queueUri, HttpPipelinePolicy authentication, QueueClientOptions options)
        {
            this.Uri = queueUri;
            this._pipeline = (options ?? new QueueClientOptions()).Build(authentication);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueClient"/>
        /// class.
        /// </summary>
        /// <param name="queueUri">
        /// A <see cref="Uri"/> referencing the queue that includes the
        /// name of the account, and the name of the queue.
        /// </param>
        /// <param name="pipeline">
        /// The transport pipeline used to send every request.
        /// </param>
        internal QueueClient(Uri queueUri, HttpPipeline pipeline)
        {
            this.Uri = queueUri;
            this._pipeline = pipeline;
        }

        Lazy<MessagesClient> MessagesClientInstance => new Lazy<MessagesClient>(() => new MessagesClient(this.Uri.AppendToPath("messages"), this._pipeline));

        /// <summary>
        /// Create a new <see cref="MessagesClient"/> object by appending
        /// "messages" to the end of <see cref="Uri"/>.  The
        /// new <see cref="MessagesClient"/> uses the same request policy
        /// pipeline as the <see cref="QueueClient"/>.
        /// </summary>
        public MessagesClient GetMessagesClient() => this.MessagesClientInstance.Value;

        /// <summary>
        /// Creates a queue.
        /// 
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/create-queue4"/>.
        /// </summary>
        /// <param name="metadata">
        /// Optional <see cref="Metadata"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Task{Response}"/>
        /// </returns>
        public async Task<Response> CreateAsync(
            Metadata metadata = default,
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await QueueRestClient.Queue.CreateAsync(
                        this._pipeline,
                        this.Uri,
                        metadata: metadata,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(QueueClient));
                }
            }
        }

        /// <summary>
        /// Deletes a queue.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/delete-queue3"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Task{Response}"/>
        /// </returns>
        public async Task<Response> DeleteAsync(
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await QueueRestClient.Queue.DeleteAsync(
                        this._pipeline,
                        this.Uri,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(QueueClient));
                }
            }
        }

        /// <summary>
        /// Retrieves queue properties and user-defined metadata and properties on the specified queue.
        /// Metadata is associated with the queue as name-values pairs.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-queue-metadata"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Task{Response{QueueProperties}}"/>
        /// </returns>
        public async Task<Response<QueueProperties>> GetPropertiesAsync(
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await QueueRestClient.Queue.GetPropertiesAsync(
                        this._pipeline,
                        this.Uri,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(QueueClient));
                }
            }
        }

        /// <summary>
        /// Sets user-defined metadata on the specified queue. Metadata is associated with the queue as name-value pairs.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/set-queue-metadata"/>.
        /// </summary>
        /// <param name="metadata">
        /// <see cref="Metadata"/>
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Task{Response}"/>
        /// </returns>
        public async Task<Response> SetMetadataAsync(
            Metadata metadata,
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await QueueRestClient.Queue.SetMetadataAsync(
                        this._pipeline,
                        this.Uri,
                        metadata: metadata,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(QueueClient));
                }
            }
        }

        /// <summary>
        /// Returns details about any stored access policies specified on the queue that may be used with
        /// Shared Access Signatures.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/get-queue-acl"/>.
        /// </summary>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// IEnumerable of <see cref="Task{Response{IEnumerable{SignedIdentifier}}}"/>
        /// </returns>
        public async Task<Response<IEnumerable<SignedIdentifier>>> GetAccessPolicyAsync(
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await QueueRestClient.Queue.GetAccessPolicyAsync(
                        this._pipeline,
                        this.Uri,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(QueueClient));
                }
            }
        }

        /// <summary>
        /// SetAccessPolicyAsync sets stored access policies for the queue that may be used with Shared Access Signatures.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/set-queue-acl"/>.
        /// </summary>
        /// <param name="permissions">
        /// IEnumerable of <see cref="SignedIdentifier"/>
        /// </param>
        /// <param name="cancellationToken">
        /// <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// <see cref="Task{Response}"/>
        /// </returns>
        public async Task<Response> SetAccessPolicyAsync(
            IEnumerable<SignedIdentifier> permissions,
            CancellationToken cancellationToken = default)
        {
            using (this._pipeline.BeginLoggingScope(nameof(QueueClient)))
            {
                this._pipeline.LogMethodEnter(
                    nameof(QueueClient),
                    message: $"{nameof(this.Uri)}: {this.Uri}");
                try
                {
                    return await QueueRestClient.Queue.SetAccessPolicyAsync(
                        this._pipeline,
                        this.Uri,
                        permissions: permissions,
                        cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    this._pipeline.LogException(ex);
                    throw;
                }
                finally
                {
                    this._pipeline.LogMethodExit(nameof(QueueClient));
                }
            }
        }
    }
}
