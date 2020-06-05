// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Cryptography;
using Azure.Storage.Cryptography.Models;
using Azure.Storage.Queues.Specialized.Models;

namespace Azure.Storage.Queues
{
    internal class QueueClientSideEncryptor
    {
        private readonly ClientSideEncryptor _encryptor;

        public QueueClientSideEncryptor(ClientSideEncryptor encryptor)
        {
            _encryptor = encryptor;
        }

        public async Task<string> ClientSideEncryptInternal(string messageToUpload, bool async, CancellationToken cancellationToken)
        {
            var bytesToEncrypt = Encoding.UTF8.GetBytes(messageToUpload);
            (byte[] ciphertext, EncryptionData encryptionData) = await _encryptor.BufferedEncryptInternal(
                new MemoryStream(bytesToEncrypt),
                async,
                cancellationToken).ConfigureAwait(false);

            return EncryptedMessageSerializer.Serialize(new EncryptedMessage
            {
                EncryptedMessageText = Convert.ToBase64String(ciphertext),
                EncryptionData = encryptionData
            });
        }
    }
}
