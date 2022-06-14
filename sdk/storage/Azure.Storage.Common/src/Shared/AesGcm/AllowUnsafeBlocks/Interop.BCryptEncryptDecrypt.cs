// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using System;
using System.Runtime.InteropServices;

namespace Azure.Storage.Shared.AesGcm
{
#if !(NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER)
    /// <summary>
    /// From
    /// https://github.com/dotnet/runtime/blob/main/src/libraries/Common/src/Interop/Windows/BCrypt/Interop.BCryptEncryptDecrypt.cs
    ///
    /// SHOULD NOT BE CHANGED WITHOUT COORDINATING WITH BCL TEAM
    /// </summary>
    internal static partial class Interop
    {
        internal static partial class BCrypt
        {
            // Note: input and output are allowed to be the same buffer. BCryptEncrypt will correctly do the encryption in place according to CNG documentation.
            internal static int BCryptEncrypt(SafeKeyHandle hKey, ReadOnlySpan<byte> input, byte[] iv, Span<byte> output)
            {
                unsafe
                {
                    fixed (byte* pbInput = input)
                    fixed (byte* pbOutput = output)
                    {
                        int cbResult;
                        NTSTATUS ntStatus = BCryptEncrypt(hKey, pbInput, input.Length, IntPtr.Zero, iv, iv == null ? 0 : iv.Length, pbOutput, output.Length, out cbResult, 0);

                        if (ntStatus != NTSTATUS.STATUS_SUCCESS)
                        {
                            throw CreateCryptographicException(ntStatus);
                        }

                        return cbResult;
                    }
                }
            }

            // Note: input and output are allowed to be the same buffer. BCryptDecrypt will correctly do the decryption in place according to CNG documentation.
            internal static int BCryptDecrypt(SafeKeyHandle hKey, ReadOnlySpan<byte> input, byte[] iv, Span<byte> output)
            {
                unsafe
                {
                    fixed (byte* pbInput = input)
                    fixed (byte* pbOutput = output)
                    {
                        int cbResult;
                        NTSTATUS ntStatus = BCryptDecrypt(hKey, pbInput, input.Length, IntPtr.Zero, iv, iv == null ? 0 : iv.Length, pbOutput, output.Length, out cbResult, 0);

                        if (ntStatus != NTSTATUS.STATUS_SUCCESS)
                        {
                            throw CreateCryptographicException(ntStatus);
                        }

                        return cbResult;
                    }
                }
            }

            [DllImport(Constants.ClientSideEncryption.BCryptdll)]
            internal static extern unsafe NTSTATUS BCryptEncrypt(SafeKeyHandle hKey, byte* pbInput, int cbInput, IntPtr paddingInfo, byte[] pbIV, int cbIV, byte* pbOutput, int cbOutput, out int cbResult, int dwFlags);

            [DllImport(Constants.ClientSideEncryption.BCryptdll)]
            internal static extern unsafe NTSTATUS BCryptDecrypt(SafeKeyHandle hKey, byte* pbInput, int cbInput, IntPtr paddingInfo, byte[] pbIV, int cbIV, byte* pbOutput, int cbOutput, out int cbResult, int dwFlags);
        }
    }
#endif
}
