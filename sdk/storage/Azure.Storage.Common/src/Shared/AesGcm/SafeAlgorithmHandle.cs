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
    internal static partial class Interop
    {
        internal static partial class BCrypt
        {
            /// <summary>
            /// From
            /// https://github.com/dotnet/runtime/blob/main/src/libraries/Common/src/Interop/Windows/BCrypt/Cng.cs#L140
            ///
            /// SHOULD NOT BE CHANGED WITHOUT COORDINATING WITH BCL TEAM
            /// </summary>
            internal sealed partial class SafeAlgorithmHandle : SafeBCryptHandle
            {
                protected sealed override bool ReleaseHandle()
                {
                    uint ntStatus = BCryptCloseAlgorithmProvider(handle, 0);
                    return ntStatus == 0;
                }

                [DllImport(Constants.ClientSideEncryption.BCryptdll)]
                private static extern uint BCryptCloseAlgorithmProvider(IntPtr hAlgorithm, int dwFlags);
            }

            /// <summary>
            /// From https://github.com/dotnet/runtime/blob/c2ec86b1c552ac8a1749f9f98e012f707e325660/src/libraries/Common/src/Interop/Windows/BCrypt/Cng.cs#L92
            ///
            /// SHOULD NOT BE CHANGED WITHOUT COORDINATING WITH BCL TEAM
            /// </summary>
            /// <param name="hAlg"></param>
            /// <param name="cipherMode"></param>

            private static void SetCipherMode(SafeAlgorithmHandle hAlg, string cipherMode)
            {
                NTSTATUS ntStatus = BCryptSetProperty(hAlg, Constants.ClientSideEncryption.BCRYPT_CHAINING_MODE, cipherMode, (cipherMode.Length + 1) * 2, 0);

                if (ntStatus != NTSTATUS.STATUS_SUCCESS)
                {
                    throw CreateCryptographicException(ntStatus);
                }
            }
            /// <summary>
            /// From https://github.com/dotnet/runtime/blob/c2ec86b1c552ac8a1749f9f98e012f707e325660/src/libraries/Common/src/Interop/Windows/BCrypt/Cng.cs#L73
            ///
            /// SHOULD NOT BE CHANGED WITHOUT COORDINATING WITH BCL TEAM
            /// </summary>
            /// <param name="pszAlgId"></param>
            /// <param name="pszImplementation"></param>
            /// <param name="dwFlags"></param>
            /// <returns></returns>
            private static SafeAlgorithmHandle BCryptOpenAlgorithmProvider(string pszAlgId, string pszImplementation, int dwFlags)
            {
                SafeAlgorithmHandle hAlgorithm;
                NTSTATUS ntStatus = BCryptOpenAlgorithmProvider(out hAlgorithm, pszAlgId, pszImplementation, dwFlags);
                if (ntStatus != NTSTATUS.STATUS_SUCCESS)
                    throw CreateCryptographicException(ntStatus);
                return hAlgorithm;
            }

            /// <summary>
            /// From https://github.com/dotnet/runtime/blob/c2ec86b1c552ac8a1749f9f98e012f707e325660/src/libraries/Common/src/Interop/Windows/BCrypt/Cng.cs#L125
            ///
            /// SHOULD NOT BE CHANGED WITHOUT COORDINATING WITH BCL TEAM
            /// </summary>
            /// <param name="phAlgorithm"></param>
            /// <param name="pszAlgId"></param>
            /// <param name="pszImplementation"></param>
            /// <param name="dwFlags"></param>
            /// <returns></returns>
            [DllImport(Constants.ClientSideEncryption.BCryptdll, CharSet = CharSet.Unicode)]
            private static extern NTSTATUS BCryptOpenAlgorithmProvider(out SafeAlgorithmHandle phAlgorithm, string pszAlgId, string pszImplementation, int dwFlags);

            /// <summary>
            /// From
            /// https://github.com/dotnet/runtime/blob/c2ec86b1c552ac8a1749f9f98e012f707e325660/src/libraries/Common/src/Interop/Windows/BCrypt/Cng.cs#L128
            ///
            /// SHOULD NOT BE CHANGED WITHOUT COORDINATING WITH BCL TEAM
            /// </summary>
            /// <param name="hObject"></param>
            /// <param name="pszProperty"></param>
            /// <param name="pbInput"></param>
            /// <param name="cbInput"></param>
            /// <param name="dwFlags"></param>
            /// <returns></returns>
            [DllImport(Constants.ClientSideEncryption.BCryptdll, CharSet = CharSet.Unicode)]
            private static extern NTSTATUS BCryptSetProperty(SafeAlgorithmHandle hObject, string pszProperty, string pbInput, int cbInput, int dwFlags);
        }
    }
#endif
}
