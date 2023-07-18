// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Queues.Specialized;
using Azure.Storage.Shared;

namespace Azure.Storage.Queues
{
    internal class QueueClientConfiguration : StorageClientConfiguration
    {
        public QueueClientOptions.ServiceVersion Version { get; internal set; }

        public QueueClientSideEncryptionOptions ClientSideEncryption { get; internal set; }

        public QueueMessageEncoding MessageEncoding { get; internal set; }

        public SyncAsyncEventHandler<QueueMessageDecodingFailedEventArgs> QueueMessageDecodingFailedHandlers { get; internal set; }

        /// <summary>
        /// Create a <see cref="QueueClientConfiguration"/> with shared key authentication.
        /// </summary>
        public QueueClientConfiguration(
            HttpPipeline pipeline,
            StorageSharedKeyCredential sharedKeyCredential,
            ClientDiagnostics clientDiagnostics,
            QueueClientOptions.ServiceVersion version,
            QueueClientSideEncryptionOptions clientSideEncryption,
            QueueMessageEncoding messageEncoding,
            SyncAsyncEventHandler<QueueMessageDecodingFailedEventArgs> queueMessageDecodingFailedHandlers)
            : this(
                  pipeline,
                  sharedKeyCredential,
                  default,
                  clientDiagnostics,
                  version,
                  clientSideEncryption,
                  messageEncoding,
                  queueMessageDecodingFailedHandlers)
        {
        }

        /// <summary>
        /// Create a <see cref="QueueClientConfiguration"/> with SAS authentication.
        /// </summary>
        public QueueClientConfiguration(
            HttpPipeline pipeline,
            AzureSasCredential sasCredential,
            ClientDiagnostics clientDiagnostics,
            QueueClientOptions.ServiceVersion version,
            QueueClientSideEncryptionOptions clientSideEncryption,
            QueueMessageEncoding messageEncoding,
            SyncAsyncEventHandler<QueueMessageDecodingFailedEventArgs> queueMessageDecodingFailedHandlers)
            : this(
                  pipeline,
                  default,
                  sasCredential,
                  clientDiagnostics,
                  version,
                  clientSideEncryption,
                  messageEncoding,
                  queueMessageDecodingFailedHandlers)
        {
        }

        /// <summary>
        /// Create a <see cref="QueueClientConfiguration"/> without authentication,
        /// or with SAS that was provided as part of the URL.
        /// </summary>
        public QueueClientConfiguration(
            HttpPipeline pipeline,
            ClientDiagnostics clientDiagnostics,
            QueueClientOptions.ServiceVersion version,
            QueueClientSideEncryptionOptions clientSideEncryption,
            QueueMessageEncoding messageEncoding,
            SyncAsyncEventHandler<QueueMessageDecodingFailedEventArgs> queueMessageDecodingFailedHandlers)
            : this(
                  pipeline,
                  default,
                  default,
                  clientDiagnostics,
                  version,
                  clientSideEncryption,
                  messageEncoding,
                  queueMessageDecodingFailedHandlers)
        {
        }

        private QueueClientConfiguration(
            HttpPipeline pipeline,
            StorageSharedKeyCredential sharedKeyCredential,
            AzureSasCredential sasCredential,
            ClientDiagnostics clientDiagnostics,
            QueueClientOptions.ServiceVersion version,
            QueueClientSideEncryptionOptions clientSideEncryption,
            QueueMessageEncoding messageEncoding,
            SyncAsyncEventHandler<QueueMessageDecodingFailedEventArgs> queueMessageDecodingFailedHandlers)
            : base(pipeline, sharedKeyCredential, sasCredential, default, clientDiagnostics)
        {
            Version = version;
            ClientSideEncryption = clientSideEncryption;
            MessageEncoding = messageEncoding;
            QueueMessageDecodingFailedHandlers = queueMessageDecodingFailedHandlers;
        }
    }
}
