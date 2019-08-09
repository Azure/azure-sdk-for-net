// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    /// <summary>
    /// Describes the encryption algorithm
    /// </summary>
    public enum KeyWrapAlgorithm
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

    internal static class KeyWrapAlgorithmExtensions
    {
        public static string GetName(this KeyWrapAlgorithm algorithm)
        {
            switch (algorithm)
            {
                case KeyWrapAlgorithm.RSAOAEP:
                    return "RSA-OAEP";
                case KeyWrapAlgorithm.RSA15:
                    return "RSA1_5";
                case KeyWrapAlgorithm.RSAOAEP256:
                    return "RSA-OAEP-256";
                default:
                    return null;
            }
        }
    }
}
