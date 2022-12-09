// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Security.Cryptography;

namespace Azure.Storage.Shared.AesGcm
{
#if !(NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER)
    /// <summary>
    /// Taken from
    /// https://github.com/dotnet/runtime/blob/main/src/libraries/Common/src/Interop/Windows/BCrypt/Interop.CreateCryptographicException.cs
    ///
    /// SHOULD NOT BE CHANGED WITHOUT COORDINATING WITH BCL TEAM
    /// </summary>
    internal static partial class Interop
    {
        internal static partial class BCrypt
        {
            /// <param name="ntstatus"></param>
            /// <returns></returns>
            internal static CryptographicException CreateCryptographicException(NTSTATUS ntstatus)
            {
                return CreateCryptographicException((int)ntstatus);
            }

            internal static CryptographicException CreateCryptographicException(int hr)
            {
                return new CryptographicException(hr);
            }
        }
    }
#endif
}
