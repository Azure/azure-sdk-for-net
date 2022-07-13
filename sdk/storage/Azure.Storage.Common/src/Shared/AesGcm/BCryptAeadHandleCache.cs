// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Security.Cryptography;
using System.Threading;

namespace Azure.Storage.Shared.AesGcm
{
#if !(NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER)
    /// <summary>
    /// From
    /// https://github.com/dotnet/runtime/blob/57bfe474518ab5b7cfe6bf7424a79ce3af9d6657/src/libraries/Common/src/Interop/Windows/BCrypt/BCryptAeadHandleCache.cs
    ///
    /// SHOULD NOT BE CHANGED WITHOUT COORDINATING WITH BCL TEAM
    /// </summary>
    internal static partial class Interop
    {
        internal static partial class BCrypt
        {
            internal static class BCryptAeadHandleCache
            {
                internal static SafeAlgorithmHandle AesGcm { get; } =
                    OpenAlgorithm(Constants.ClientSideEncryption.BCRYPT_AES_ALGORITHM, Constants.ClientSideEncryption.BCRYPT_CHAIN_MODE_GCM);

                private static SafeAlgorithmHandle OpenAlgorithm(string algId, string chainingMode = null)
                {
                    SafeAlgorithmHandle newHandle = BCryptOpenAlgorithmProvider(algId, null, 0);
                    if (chainingMode != null)
                    {
                        SetCipherMode(newHandle, chainingMode);
                    }

                    return newHandle;
                }
            }
        }
    }
#endif
}
