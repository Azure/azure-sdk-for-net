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
        public const string P256K = "P-256K";

        private static readonly string[] _allCurves = {P256, P384, P521, P256K};

        /// <summary>
        /// All curves for EC. Use clone to avoid FxCop violation
        /// </summary>
        public static string[] AllCurves => (string[]) _allCurves.Clone();

        /// <summary>
        /// Returns the required size, in bytes, of each key parameters (X, Y and D), or -1 if the curve is unsupported. 
        /// </summary>
        /// <param name="curve">The curve for which key parameter size is required.</param>
        /// <returns></returns>
        public static int GetKeyParameterSize( string curve )
        {
            switch ( curve )
            {
                case P256:
                case P256K:
                    return 32;

                case P384:
                    return 48;

                case P521:
                    return 66;

                default:
                    return -1;
            }
        }
    }
}