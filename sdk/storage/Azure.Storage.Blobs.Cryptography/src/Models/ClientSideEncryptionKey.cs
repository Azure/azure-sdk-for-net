using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core.Cryptography;

namespace Azure.Storage.Blobs.Specialized.Cryptography.Models
{
    public class ClientSideEncryptionKey
    {
        public IKeyEncryptionKey Key { get; }
        public IKeyEncryptionKeyResolver KeyResolver { get; }

        public ClientSideEncryptionKey(IKeyEncryptionKey key)
        {
            this.Key = key;
        }

        public ClientSideEncryptionKey(IKeyEncryptionKeyResolver keyResolver)
        {
            this.KeyResolver = keyResolver;
        }
    }
}
