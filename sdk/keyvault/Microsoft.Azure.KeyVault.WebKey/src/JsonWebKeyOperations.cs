// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

namespace Microsoft.Azure.KeyVault.WebKey
{
    /// <summary>
    /// Supported JsonWebKey operations
    /// </summary>
    public static class JsonWebKeyOperation
    {
        public const string Encrypt = "encrypt";
        public const string Decrypt = "decrypt";
        public const string Sign = "sign";
        public const string Verify = "verify";
        public const string Wrap = "wrapKey";
        public const string Unwrap = "unwrapKey";

        /// <summary>
        /// All operations names.
        /// </summary>
        public static string[] AllOperations => (string[]) _allOperations.Clone();

        private static readonly string[] _allOperations = {Encrypt, Decrypt, Sign, Verify, Wrap, Unwrap};

        public static bool IsValidOperation( string operation )
        {
            foreach ( var validOperation in _allOperations )
                if ( operation == validOperation )
                    return true;
            return false;
        }
    }
}