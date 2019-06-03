// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Azure.Security.KeyVault.Keys
{
    [Flags]
    public enum KeyOperations : uint
    {
        Encrypt = 0x0001,
        Decrypt = 0x0002,
        Sign = 0x0004,
        Verify = 0x0008,
        Wrap = 0x0010,
        Unwrap = 0x0020,
        Other = 0x0040,

        All = uint.MaxValue
    }
}
