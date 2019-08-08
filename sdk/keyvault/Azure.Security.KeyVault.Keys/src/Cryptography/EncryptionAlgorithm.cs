using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Describes the encryption algorithm
    /// </summary>
    public enum EncryptionAlgorithm
    {
        /// <summary>
        /// RSA-OAEP
        /// </summary>
        RSAOAEP,

        /// <summary>
        /// RSA-15
        /// </summary>
        RSA15,

        /// <summary>
        /// RSA-OAEP256
        /// </summary>
        RSAOAEP256
    }

    internal static class EncryptionAlgorithmExtensions
    {
        public static string GetName(this EncryptionAlgorithm algorithm)
        {
            switch (algorithm)
            {
                case EncryptionAlgorithm.RSAOAEP:
                    return "RSA-OAEP";
                case EncryptionAlgorithm.RSA15:
                    return "RSA1_5";
                case EncryptionAlgorithm.RSAOAEP256:
                    return "RSA-OAEP-256";
                default:
                    return null;
            }
        }
    }
}
