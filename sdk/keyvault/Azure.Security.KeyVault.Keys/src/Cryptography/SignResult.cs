using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    public struct SignResult 
    {
        public string KeyId { get; private set; }

        public byte[] Signature { get; private set; }

        public SignatureAlgorithm Algorithm { get; private set; }
    }
}
