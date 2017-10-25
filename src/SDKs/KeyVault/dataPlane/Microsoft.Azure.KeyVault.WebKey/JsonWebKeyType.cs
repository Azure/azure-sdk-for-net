// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Collections.Generic;

namespace Microsoft.Azure.KeyVault.WebKey
{
    /// <summary>
    /// Supported JsonWebKey key types (kty)
    /// </summary>
    public static class JsonWebKeyType
    {
        public const string EllipticCurve /******/ = "EC";
        public const string EllipticCurveHsm /***/ = "EC-HSM";
        public const string Rsa /****************/ = "RSA";
        public const string RsaHsm /*************/ = "RSA-HSM";
        public const string Octet /**************/ = "oct";

        public static IReadOnlyList<string> AllTypes => _allTypes;

        private static readonly string[] _allTypes = {EllipticCurve, EllipticCurveHsm, Rsa, RsaHsm, Octet};
    }
}