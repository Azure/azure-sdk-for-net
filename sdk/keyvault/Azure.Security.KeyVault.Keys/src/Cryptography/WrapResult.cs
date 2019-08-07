using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    public struct WrapResult
    {
        public string KeyId { get; private set; }

        public byte[] EncryptedKey { get; set; }

        public KeyWrapAlgorithm Algorithm { get; set; }
    }
}
