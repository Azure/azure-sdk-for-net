// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Cryptography;
using Azure.Storage.Cryptography;
using Azure.Storage.Cryptography.Models;
using Azure.Storage.Queues.Specialized.Models;

namespace Azure.Storage.Queues
{
    internal class QueueClientSideEncryptor
    {
        private readonly IKeyEncryptionKey _keyEncryptionKey;
        private readonly string _keyWrapAlgorithm;

        public QueueClientSideEncryptor(ClientSideEncryptionOptions options)
        {
            _keyEncryptionKey = options.KeyEncryptionKey;
            _keyWrapAlgorithm = options.KeyWrapAlgorithm;
        }

        public async Task<string> ClientSideEncryptInternal(string messageToUpload, bool async, CancellationToken cancellationToken)
        {
            var bytesToEncrypt = Encoding.UTF8.GetBytes(messageToUpload);
            (byte[] ciphertext, EncryptionData encryptionData) = await ClientSideEncryptor.BufferedEncryptInternal(
                new MemoryStream(bytesToEncrypt),
                _keyEncryptionKey,
                _keyWrapAlgorithm,
                async,
                cancellationToken).ConfigureAwait(false);

            return EncryptedMessageSerializer.Serialize(new EncryptedMessage
            {
                EncryptedMessageContents = Convert.ToBase64String(ciphertext),
                EncryptionData = encryptionData
            });
        }
    }
}
