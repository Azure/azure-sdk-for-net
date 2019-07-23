using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    public struct SignResult 
    {
        public byte[] Signature { get; set; }

        public SignatureAlgorithm Algorithm { get; set; }
    }
}
