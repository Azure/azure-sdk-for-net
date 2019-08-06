using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    public struct DecryptResult
    {
        public byte[] Plaintext { get; private set; }
    }
}
