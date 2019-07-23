using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    public class KeyWrapAlgorithm
    {
        public static KeyWrapAlgorithm RSAOAEP { get; }

        public static KeyWrapAlgorithm RSA15 { get; }

        public static KeyWrapAlgorithm RSAOAEP256 { get; }
    }
}
