using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    public class EncryptionAlgorithm
    {
        public static EncryptionAlgorithm RSAOAEP { get; }

        public static EncryptionAlgorithm RSA15 { get; }

        public static EncryptionAlgorithm RSAOAEP256 { get; }
    }
}
