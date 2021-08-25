// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Cryptography.Models;

namespace Azure.Storage.Queues.Specialized.Models
{
    internal class EncryptedMessage
    {
        public string EncryptedMessageText { get; set; }

        public EncryptionData EncryptionData { get; set; }
    }
}
