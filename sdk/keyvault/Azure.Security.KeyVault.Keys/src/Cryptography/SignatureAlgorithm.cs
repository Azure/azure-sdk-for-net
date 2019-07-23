using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    public class SignatureAlgorithm
    {
        public static SignatureAlgorithm RS256 { get; }
        public static SignatureAlgorithm RS384 { get; }
        public static SignatureAlgorithm RS512 { get; }
        public static SignatureAlgorithm PS256 { get; }
        public static SignatureAlgorithm PS384 { get; }
        public static SignatureAlgorithm PS512 { get; }
        public static SignatureAlgorithm ES256 { get; }
        public static SignatureAlgorithm ES384 { get; }
        public static SignatureAlgorithm ES512 { get; }
        public static SignatureAlgorithm ES256K { get; }
    }
}
