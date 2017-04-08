// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

namespace Microsoft.Azure.KeyVault.WebKey
{
    /// <summary>
    /// Supported JsonWebKey key types (kty)
    /// </summary>
    public static class JsonWebKeyType
    {
        public const string EllipticCurve = "EC";
        public const string Rsa           = "RSA";
        public const string RsaHsm        = "RSA-HSM";
        public const string Octet         = "oct";

        /// <summary>
        /// All types names. Use clone to avoid FxCop violation
        /// </summary>
        public static string[] AllTypes
        {
            get { return (string[])_allTypes.Clone(); }
        }

        private static readonly string[] _allTypes = { EllipticCurve, Rsa, RsaHsm, Octet };
    }
}
