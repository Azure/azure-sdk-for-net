// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Elliptic Curve Cryptography (ECC) curve names.
    /// </summary>
    [Flags]
    public enum KeyCurveName : uint
    {
        P256 = 0x0001,
        P384 = 0x0002,
        P521 = 0x0004,
        P256K = 0x0008,
        Other = 0x0010,

        All = uint.MaxValue
    }

}
