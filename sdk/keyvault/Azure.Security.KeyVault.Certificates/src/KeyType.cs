// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Supported JsonWebKey key types (kty)
    /// </summary>
    [Flags]
    public enum KeyType : uint
    {
        EllipticCurve = 0x0001,
        EllipticCurveHsm = 0x0002,
        Rsa = 0x0004,
        RsaHsm = 0x0008,
        Octet = 0x0010,
        Other = 0x0020,

        All = uint.MaxValue
    }

}
