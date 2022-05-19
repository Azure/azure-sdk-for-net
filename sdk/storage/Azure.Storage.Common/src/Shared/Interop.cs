// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace Azure.Storage
{
    internal static partial class Interop
    {
        internal static partial class BCrypt
        {
            internal static CryptographicException CreateCryptographicException(NTSTATUS ntstatus)
            {
                return CreateCryptographicException((int)ntstatus);
            }

            internal static CryptographicException CreateCryptographicException(int hr)
            {
                return new CryptographicException(hr);
            }

            internal enum NTSTATUS : uint
            {
                STATUS_SUCCESS = 0x0,
                STATUS_NOT_FOUND = 0xc0000225,
                STATUS_INVALID_PARAMETER = 0xc000000d,
                STATUS_NO_MEMORY = 0xc0000017,
                STATUS_AUTH_TAG_MISMATCH = 0xc000a002,
            }

            internal static unsafe SafeKeyHandle BCryptImportKey(SafeAlgorithmHandle hAlg, ReadOnlySpan<byte> key)
            {
                const string BCRYPT_KEY_DATA_BLOB = "KeyDataBlob";
                int keySize = key.Length;
                int blobSize = sizeof(BCRYPT_KEY_DATA_BLOB_HEADER) + keySize;

                // 64 is large enough to hold a BCRYPT_KEY_DATA_BLOB_HEADER and an AES-256 key with room to spare.
                int MaxStackKeyBlob = 64;
                Span<byte> blob = stackalloc byte[MaxStackKeyBlob];

                if (blobSize > MaxStackKeyBlob)
                {
                    blob = new byte[blobSize];
                }
                else
                {
                    blob.Clear();
                }

                fixed (byte* pbBlob = blob)
                {
                    BCRYPT_KEY_DATA_BLOB_HEADER* pBlob = (BCRYPT_KEY_DATA_BLOB_HEADER*)pbBlob;
                    pBlob->dwMagic = BCRYPT_KEY_DATA_BLOB_HEADER.BCRYPT_KEY_DATA_BLOB_MAGIC;
                    pBlob->dwVersion = BCRYPT_KEY_DATA_BLOB_HEADER.BCRYPT_KEY_DATA_BLOB_VERSION1;
                    pBlob->cbKeyData = (uint)keySize;

                    key.CopyTo(blob.Slice(sizeof(BCRYPT_KEY_DATA_BLOB_HEADER)));
                    SafeKeyHandle hKey;
                    Interop.BCrypt.NTSTATUS ntStatus = BCryptImportKey(
                        hAlg,
                        IntPtr.Zero,
                        BCRYPT_KEY_DATA_BLOB,
                        out hKey,
                        IntPtr.Zero,
                        0,
                        pbBlob,
                        blobSize,
                        0);
                    if (ntStatus != Interop.BCrypt.NTSTATUS.STATUS_SUCCESS)
                    {
                        throw CreateCryptographicException(ntStatus);
                    }

                    return hKey;
                }
            }

            [StructLayout(LayoutKind.Sequential)]
            internal struct BCRYPT_KEY_DATA_BLOB_HEADER
            {
                public uint dwMagic;
                public uint dwVersion;
                public uint cbKeyData;

                public const uint BCRYPT_KEY_DATA_BLOB_MAGIC = 0x4d42444b;
                public const uint BCRYPT_KEY_DATA_BLOB_VERSION1 = 0x1;
            }

            [DllImport(Libraries.BCrypt, CharSet = CharSet.Unicode)]
            private static extern unsafe Interop.BCrypt.NTSTATUS BCryptImportKey(
                SafeAlgorithmHandle hAlgorithm,
                IntPtr hImportKey,
                string pszBlobType,
                out SafeKeyHandle hKey,
                IntPtr pbKeyObject,
                int cbKeyObject,
                byte* pbInput,
                int cbInput,
                int dwFlags);

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

            [DllImport(Libraries.BCrypt)]
            internal static extern unsafe NTSTATUS BCryptEncrypt(SafeKeyHandle hKey, byte* pbInput, int cbInput, IntPtr paddingInfo, byte[] pbIV, int cbIV, byte* pbOutput, int cbOutput, out int cbResult, int dwFlags);

            [DllImport(Libraries.BCrypt)]
            internal static extern unsafe NTSTATUS BCryptDecrypt(SafeKeyHandle hKey, byte* pbInput, int cbInput, IntPtr paddingInfo, byte[] pbIV, int cbIV, byte* pbOutput, int cbOutput, out int cbResult, int dwFlags);

            internal abstract class SafeBCryptHandle : SafeHandle, IDisposable
            {
                protected SafeBCryptHandle()
                    : base(IntPtr.Zero, true)
                {
                }

                public sealed override bool IsInvalid
                {
                    get
                    {
                        return handle == IntPtr.Zero;
                    }
                }

                protected abstract override bool ReleaseHandle();
            }

            internal sealed partial class SafeAlgorithmHandle : SafeBCryptHandle
            {
                protected sealed override bool ReleaseHandle()
                {
                    uint ntStatus = BCryptCloseAlgorithmProvider(handle, 0);
                    return ntStatus == 0;
                }

                [DllImport(Libraries.BCrypt)]
                private static extern uint BCryptCloseAlgorithmProvider(IntPtr hAlgorithm, int dwFlags);
            }

            internal sealed partial class SafeKeyHandle : SafeBCryptHandle
            {
                private SafeAlgorithmHandle _parentHandle;

                public void SetParentHandle(SafeAlgorithmHandle parentHandle)
                {
                    Debug.Assert(_parentHandle == null);
                    Debug.Assert(parentHandle != null);
                    Debug.Assert(!parentHandle.IsInvalid);

                    bool ignore = false;
                    parentHandle.DangerousAddRef(ref ignore);

                    _parentHandle = parentHandle;
                }

                protected sealed override bool ReleaseHandle()
                {
                    if (_parentHandle != null)
                    {
                        _parentHandle.DangerousRelease();
                        _parentHandle = null;
                    }

                    uint ntStatus = BCryptDestroyKey(handle);
                    return ntStatus == 0;
                }

                [DllImport(Libraries.BCrypt)]
                private static extern uint BCryptDestroyKey(IntPtr hKey);
            }

            internal static class BCryptAeadHandleCache
            {
                internal static SafeAlgorithmHandle AesGcm { get; } = OpenAlgorithm(BCRYPT_AES_ALGORITHM, BCRYPT_CHAIN_MODE_GCM);

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

            private const string BCRYPT_AES_ALGORITHM = "AES";
            private const string BCRYPT_CHAIN_MODE_GCM = "ChainingModeGCM";
            private const string BCRYPT_CHAINING_MODE = "ChainingMode";

            private static void SetCipherMode(SafeAlgorithmHandle hAlg, string cipherMode)
            {
                NTSTATUS ntStatus = BCryptSetProperty(hAlg, BCRYPT_CHAINING_MODE, cipherMode, (cipherMode.Length + 1) * 2, 0);

                if (ntStatus != NTSTATUS.STATUS_SUCCESS)
                {
                    throw CreateCryptographicException(ntStatus);
                }
            }

            private static SafeAlgorithmHandle BCryptOpenAlgorithmProvider(string pszAlgId, string pszImplementation, int dwFlags)
            {
                SafeAlgorithmHandle hAlgorithm;
                NTSTATUS ntStatus = BCryptOpenAlgorithmProvider(out hAlgorithm, pszAlgId, pszImplementation, dwFlags);
                if (ntStatus != NTSTATUS.STATUS_SUCCESS)
                    throw CreateCryptographicException(ntStatus);
                return hAlgorithm;
            }

            [DllImport(Libraries.BCrypt, CharSet = CharSet.Unicode)]
            private static extern NTSTATUS BCryptOpenAlgorithmProvider(out SafeAlgorithmHandle phAlgorithm, string pszAlgId, string pszImplementation, int dwFlags);

            [DllImport(Libraries.BCrypt, CharSet = CharSet.Unicode)]
            private static extern NTSTATUS BCryptSetProperty(SafeAlgorithmHandle hObject, string pszProperty, string pbInput, int cbInput, int dwFlags);
        }

        internal static partial class Libraries
        {
            internal const string BCrypt = "BCrypt.dll";
        }
    }
}
