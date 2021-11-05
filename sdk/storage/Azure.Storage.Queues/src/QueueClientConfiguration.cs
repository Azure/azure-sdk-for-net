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

        public QueueClientConfiguration(
            HttpPipeline pipeline,
            StorageSharedKeyCredential sharedKeyCredential,
            ClientDiagnostics clientDiagnostics,
            QueueClientOptions.ServiceVersion version,
            QueueClientSideEncryptionOptions clientSideEncryption,
            QueueMessageEncoding messageEncoding,
            SyncAsyncEventHandler<QueueMessageDecodingFailedEventArgs> queueMessageDecodingFailedHandlers)
            : base(pipeline, sharedKeyCredential, clientDiagnostics)
        {
            Version = version;
            ClientSideEncryption = clientSideEncryption;
            MessageEncoding = messageEncoding;
            QueueMessageDecodingFailedHandlers = queueMessageDecodingFailedHandlers;
        }
    }
}
