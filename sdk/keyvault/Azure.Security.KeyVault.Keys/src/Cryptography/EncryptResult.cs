using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    public struct EncryptResult
    {
        public byte[] Ciphertext { get; set; }

        public byte[] AuthenticationTag { get; set; }

        public EncryptionAlgorithm Algorithm { get; set; }
    }
}
