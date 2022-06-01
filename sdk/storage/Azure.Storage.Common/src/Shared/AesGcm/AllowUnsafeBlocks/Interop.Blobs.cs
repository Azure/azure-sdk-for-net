// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace Azure.Storage.Shared.AesGcm
{
#if !(NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER)
    /// <summary>
    /// Taken from
    /// https://github.com/dotnet/runtime/blob/57bfe474518ab5b7cfe6bf7424a79ce3af9d6657/src/libraries/Common/src/Interop/Windows/BCrypt/Interop.Blobs.cs#L302
    ///
    /// SHOULD NOT BE CHANGED WITHOUT COORDINATING WITH BCL TEAM
    /// </summary>
    internal static partial class Interop
    {
        internal static partial class BCrypt
        {
            [StructLayout(LayoutKind.Sequential)]
            internal unsafe struct BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO
            {
                private int cbSize;
                private uint dwInfoVersion;
                internal byte* pbNonce;
                internal int cbNonce;
                internal byte* pbAuthData;
                internal int cbAuthData;
                internal byte* pbTag;
                internal int cbTag;
                internal byte* pbMacContext;
                internal int cbMacContext;
                internal int cbAAD;
                internal ulong cbData;
                internal uint dwFlags;

                public static BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO Create()
                {
                    BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO ret = default;

                    ret.cbSize = sizeof(BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO);

                    const uint BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO_VERSION = 1;
                    ret.dwInfoVersion = BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO_VERSION;

                    return ret;
                }
            }
        }
    }
#endif
}
