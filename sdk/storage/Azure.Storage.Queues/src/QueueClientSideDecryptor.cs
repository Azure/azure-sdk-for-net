// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Cryptography;
using Azure.Storage.Queues.Models;
using Azure.Storage.Queues.Specialized;
using Azure.Storage.Queues.Specialized.Models;

namespace Azure.Storage.Queues
{
    internal class QueueClientSideDecryptor
    {
        public QueueClientSideEncryptionOptions Options { get; }

        public QueueClientSideDecryptor(QueueClientSideEncryptionOptions options)
        {
            Options = options;
        }

        public async Task<QueueMessage[]> ClientSideDecryptMessagesInternal(QueueMessage[] messages, bool async, CancellationToken cancellationToken)
        {
            var filteredMessages = new List<QueueMessage>();
            foreach (var message in messages)
            {
                try
                {
                    message.Body = await ClientSideDecryptInternal(message.Body, async, cancellationToken).ConfigureAwait(false);
                    filteredMessages.Add(message);
                }
                catch (Exception e) when (Options.UsingDecryptionFailureHandler)
                {
                    Options.OnDecryptionFailed(message, e);
                }
            }
            return filteredMessages.ToArray();
        }
        public async Task<PeekedMessage[]> ClientSideDecryptMessagesInternal(PeekedMessage[] messages, bool async, CancellationToken cancellationToken)
        {
            var filteredMessages = new List<PeekedMessage>();
            foreach (var message in messages)
            {
                try
                {
                    message.Body = await ClientSideDecryptInternal(message.Body, async, cancellationToken).ConfigureAwait(false);
                    filteredMessages.Add(message);
                }
                catch (Exception e) when (Options.UsingDecryptionFailureHandler)
                {
                    Options.OnDecryptionFailed(message, e);
                }
            }
            return filteredMessages.ToArray();
        }

        private async Task<BinaryData> ClientSideDecryptInternal(BinaryData downloadedMessage, bool async, CancellationToken cancellationToken)
        {
            if (!EncryptedMessageSerializer.TryDeserialize(downloadedMessage, out var encryptedMessage))
            {
                return downloadedMessage; // not recognized as client-side encrypted message
            }

            var encryptedMessageStream = new MemoryStream(Convert.FromBase64String(encryptedMessage.EncryptedMessageText));
            // Each message has its own content encryption key, so a decryptor (and its key cache) must not be shared.
            var decryptedMessageStream = await new ClientSideDecryptor(Options).DecryptReadInternal(
                encryptedMessageStream,
                encryptedMessage.EncryptionData,
                ivInStream: false,
                noPadding: false,
                0,
                async: async,
                cancellationToken).ConfigureAwait(false);
            // if we got back the stream we put in, then we couldn't decrypt and are supposed to return the original
            // message to the user
            if (encryptedMessageStream == decryptedMessageStream)
            {
                return downloadedMessage;
            }

            return async ?
                await BinaryData.FromStreamAsync(decryptedMessageStream, cancellationToken).ConfigureAwait(false) :
                BinaryData.FromStream(decryptedMessageStream);
        }
    }
}
