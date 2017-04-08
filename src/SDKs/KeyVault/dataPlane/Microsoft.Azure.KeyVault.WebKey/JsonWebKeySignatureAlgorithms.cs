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

        // RSASSA-PSS using SHA-256 and MGF1 with SHA-256
        // defined https://tools.ietf.org/html/draft-ietf-jose-json-web-algorithms
        public const string PS256   = "PS256";
        // RSASSA-PSS using SHA-384 and MGF1 with SHA-384
        public const string PS384   = "PS384";
        // RSASSA-PSS using SHA-512 and MGF1 with SHA-512
        public const string PS512   = "PS512";

        /// <summary>
        /// All algorithms names. Use clone to avoid FxCop violation
        /// </summary>
        public static string[] AllAlgorithms
        {
            get { return (string[])_allAlgorithms.Clone(); }
        }

        private static readonly string[] _allAlgorithms = { RS256, RS384, RS512, RSNULL, PS256, PS384, PS512 };
    }
 }
