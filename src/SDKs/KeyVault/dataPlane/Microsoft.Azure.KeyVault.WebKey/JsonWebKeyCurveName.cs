// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.KeyVault.WebKey
{
    /// <summary>
    /// Elliptic Curve Cryptography (ECC) curve names.
    /// </summary>
    public static class JsonWebKeyCurveName
    {
        public const string P256 = "P-256";
        public const string P384 = "P-384";
        public const string P521 = "P-521";
        public const string SECP256K1 = "SECP256K1";

        private static readonly string[] _allCurves = {P256, P384, P521, SECP256K1};

        /// <summary>
        /// All curves for EC. Use clone to avoid FxCop violation
        /// </summary>
        public static string[] AllCurves => (string[]) _allCurves.Clone();
    }
}