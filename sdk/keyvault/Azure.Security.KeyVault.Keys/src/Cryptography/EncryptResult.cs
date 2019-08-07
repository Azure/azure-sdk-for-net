using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    public struct EncryptResult
    {
        public string KeyId { get; private set; }

        public byte[] Ciphertext { get; private set; }

        public byte[] AuthenticationTag { get; private set; }

        public EncryptionAlgorithm Algorithm { get; private set; }
    }
}
