// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

namespace Microsoft.Azure.KeyVault.WebKey
{
    /// <summary>
    /// Supported JsonWebKey algorithms
    /// </summary>
    public static class JsonWebKeySignatureAlgorithm
    {
        public const string RS256   = "RS256";
        public const string RS384   = "RS384";
        public const string RS512   = "RS512";
        public const string RSNULL  = "RSNULL";

        /// <summary>
        /// All algorithms names. Use clone to avoid FxCop violation
        /// </summary>
        public static string[] AllAlgorithms
        {
            get { return (string[])_allAlgorithms.Clone(); }
        }

        private static readonly string[] _allAlgorithms = { RS256, RS384, RS512, RSNULL };
    }
 }
