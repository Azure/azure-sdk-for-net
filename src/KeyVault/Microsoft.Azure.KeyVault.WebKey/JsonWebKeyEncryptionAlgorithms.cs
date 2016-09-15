// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

namespace Microsoft.Azure.KeyVault.WebKey
{
    /// <summary>
    /// Supported JsonWebKey algorithms
    /// </summary>
    public static class JsonWebKeyEncryptionAlgorithm
    {
        public const string RSAOAEP = "RSA-OAEP";
        public const string RSA15   = "RSA1_5";

        /// <summary>
        /// All algorithms names. Use clone to avoid FxCop violation
        /// </summary>
        public static string[] AllAlgorithms
        {
            get { return (string[])_allAlgorithms.Clone(); }
        }

        private static readonly string[] _allAlgorithms = { RSA15, RSAOAEP };
    }
 }
