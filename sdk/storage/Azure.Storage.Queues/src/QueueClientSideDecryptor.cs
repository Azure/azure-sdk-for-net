// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Cryptography;
using Azure.Storage.Queues.Models;
using Azure.Storage.Queues.Specialized;
using Azure.Storage.Queues.Specialized.Models;

namespace Azure.Storage.Queues
{
    internal class QueueClientSideDecryptor
    {
        private readonly ClientSideDecryptor _decryptor;
        public QueueClientSideEncryptionOptions Options { get; }

        public QueueClientSideDecryptor(QueueClientSideEncryptionOptions options)
        {
            _decryptor = new ClientSideDecryptor(options);
            Options = options;
        }

        public async Task<QueueMessage[]> ClientSideDecryptMessagesInternal(QueueMessage[] messages, bool async, CancellationToken cancellationToken)
        {
            var filteredMessages = new List<QueueMessage>();
            foreach (var message in messages)
            {
                try
                {
                    message.MessageText = await ClientSideDecryptInternal(message.MessageText, async, cancellationToken).ConfigureAwait(false);
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
                    message.MessageText = await ClientSideDecryptInternal(message.MessageText, async, cancellationToken).ConfigureAwait(false);
                    filteredMessages.Add(message);
                }
                catch (Exception e) when (Options.UsingDecryptionFailureHandler)
                {
                    Options.OnDecryptionFailed(message, e);
                }
            }
            return filteredMessages.ToArray();
        }

        private async Task<string> ClientSideDecryptInternal(string downloadedMessage, bool async, CancellationToken cancellationToken)
        {
            if (!EncryptedMessageSerializer.TryDeserialize(downloadedMessage, out var encryptedMessage))
            {
                return downloadedMessage; // not recognized as client-side encrypted message
            }

            var encryptedMessageStream = new MemoryStream(Convert.FromBase64String(encryptedMessage.EncryptedMessageText));
            var decryptedMessageStream = await _decryptor.DecryptInternal(
                encryptedMessageStream,
                encryptedMessage.EncryptionData,
                ivInStream: false,
                noPadding: false,
                async: async,
                cancellationToken).ConfigureAwait(false);
            // if we got back the stream we put in, then we couldn't decrypt and are supposed to return the original
            // message to the user
            if (encryptedMessageStream == decryptedMessageStream)
            {
                return downloadedMessage;
            }

            return new StreamReader(decryptedMessageStream, Encoding.UTF8).ReadToEnd();
        }
    }
}
