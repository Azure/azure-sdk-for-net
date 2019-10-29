// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

using System.Linq;

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

        // ECDSA using P-256 and SHA-256 
        public const string ES256   = "ES256";
        // ECDSA using P-384 and SHA-384 
        public const string ES384   = "ES384";
        // ECDSA using P-521 and SHA-512 
        public const string ES512   = "ES512";
        // ECDSA using P-256K and SHA-256 (SECP256K1)
        public const string ES256K = "ES256K";

        public static string[] AllRsaAlgorithms => new[] { RS256, RS384, RS512, RSNULL, PS256, PS384, PS512 };

        public static string[] AllEcAlgorithms => new[] { ES256, ES384, ES512, ES256K };

        /// <summary>
        /// All algorithms names. Use clone to avoid FxCop violation
        /// </summary>
        public static string[] AllAlgorithms => AllRsaAlgorithms.Concat(AllEcAlgorithms).ToArray();
    }
 }
