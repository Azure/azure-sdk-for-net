// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Microsoft.Azure.KeyVault.WebKey
{

    /// <summary>
    /// Supported JsonWebKey operations
    /// </summary>
    public static class JsonWebKeyOperation
    {
        public const string Encrypt = "encrypt";
        public const string Decrypt = "decrypt";
        public const string Sign    = "sign";
        public const string Verify  = "verify";
        public const string Wrap    = "wrapKey";
        public const string Unwrap  = "unwrapKey";

        private static Dictionary<CngKeyUsages, string[]> cngOperations;

        static JsonWebKeyOperation()
        {
            cngOperations = new Dictionary<CngKeyUsages, string[]>()
            {
                { CngKeyUsages.None, new string[0] },
                { CngKeyUsages.Signing, new[] { Sign, Verify } },
                { CngKeyUsages.Decryption, new[] { Encrypt, Decrypt, Wrap, Unwrap } },
                { CngKeyUsages.AllUsages, AllOperations }
            };
        }

        public static string[] GetKeyOperations(CngKeyUsages cngKeyUsages)
        {
            if (!cngOperations.ContainsKey(cngKeyUsages))
                throw new CryptographicException(string.Format("Unknown key usage {0}", cngKeyUsages));

            return cngOperations[cngKeyUsages];
        }

        /// <summary>
        /// All operations names. Use clone to avoid FxCop violation
        /// </summary>
        public static string[] AllOperations
        {
            get { return (string[])_allOperations.Clone(); }
        }

        private static readonly string[] _allOperations = new string[] { Encrypt, Decrypt, Sign, Verify, Wrap, Unwrap };
    }
}
