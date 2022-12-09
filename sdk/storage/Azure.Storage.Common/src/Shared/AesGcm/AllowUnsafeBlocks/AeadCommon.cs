// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Azure.Storage.Shared.AesGcm
{
#if !(NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER)
    /// <summary>
    /// Taken from
    /// https://github.com/dotnet/runtime/blob/main/src/libraries/System.Security.Cryptography/src/System/Security/Cryptography/AeadCommon.Windows.cs
    ///
    /// SHOULD NOT BE CHANGED WITHOUT COORDINATING WITH BCL TEAM
    /// </summary>
    internal static partial class AeadCommon
    {
        internal static unsafe void Encrypt(
            Interop.BCrypt.SafeKeyHandle keyHandle,
            ReadOnlySpan<byte> nonce,
            ReadOnlySpan<byte> associatedData,
            ReadOnlySpan<byte> plaintext,
            Span<byte> ciphertext,
            Span<byte> tag)
        {
            // bcrypt sometimes misbehaves when given nullptr buffers; ensure non-nullptr
            fixed (byte* plaintextBytes = &GetNonNullPinnableReference(plaintext))
            fixed (byte* nonceBytes = &GetNonNullPinnableReference(nonce))
            fixed (byte* ciphertextBytes = &GetNonNullPinnableReference(ciphertext))
            fixed (byte* tagBytes = &GetNonNullPinnableReference(tag))
            fixed (byte* associatedDataBytes = &GetNonNullPinnableReference(associatedData))
            {
                var authInfo = Interop.BCrypt.BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO.Create();
                authInfo.pbNonce = nonceBytes;
                authInfo.cbNonce = nonce.Length;
                authInfo.pbTag = tagBytes;
                authInfo.cbTag = tag.Length;
                authInfo.pbAuthData = associatedDataBytes;
                authInfo.cbAuthData = associatedData.Length;

                Interop.BCrypt.NTSTATUS ntStatus = Interop.BCrypt.BCryptEncrypt(
                    keyHandle,
                   plaintextBytes,
                    plaintext.Length,
                    new IntPtr(&authInfo),
                    null,
                    0,
                    ciphertextBytes,
                    ciphertext.Length,
                    out int ciphertextBytesWritten,
                    0);

                Debug.Assert(plaintext.Length == ciphertextBytesWritten);

                if (ntStatus != Interop.BCrypt.NTSTATUS.STATUS_SUCCESS)
                {
                    throw Interop.BCrypt.CreateCryptographicException(ntStatus);
                }
            }
        }

        internal static unsafe void Decrypt(
            Interop.BCrypt.SafeKeyHandle keyHandle,
            ReadOnlySpan<byte> nonce,
            ReadOnlySpan<byte> associatedData,
            ReadOnlySpan<byte> ciphertext,
            ReadOnlySpan<byte> tag,
            Span<byte> plaintext,
            bool clearPlaintextOnFailure)
        {
            // bcrypt sometimes misbehaves when given nullptr buffers; ensure non-nullptr
            fixed (byte* plaintextBytes = &GetNonNullPinnableReference(plaintext))
            fixed (byte* nonceBytes = &GetNonNullPinnableReference(nonce))
            fixed (byte* ciphertextBytes = &GetNonNullPinnableReference(ciphertext))
            fixed (byte* tagBytes = &GetNonNullPinnableReference(tag))
            fixed (byte* associatedDataBytes = &GetNonNullPinnableReference(associatedData))
            {
                var authInfo = Interop.BCrypt.BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO.Create();
                authInfo.pbNonce = nonceBytes;
                authInfo.cbNonce = nonce.Length;
                authInfo.pbTag = tagBytes;
                authInfo.cbTag = tag.Length;
                authInfo.pbAuthData = associatedDataBytes;
                authInfo.cbAuthData = associatedData.Length;

                Interop.BCrypt.NTSTATUS ntStatus = Interop.BCrypt.BCryptDecrypt(
                    keyHandle,
                    ciphertextBytes,
                    ciphertext.Length,
                    new IntPtr(&authInfo),
                    null,
                    0,
                    plaintextBytes,
                    plaintext.Length,
                    out int plaintextBytesWritten,
                    0);

                Debug.Assert(ciphertext.Length == plaintextBytesWritten);

                switch (ntStatus)
                {
                    case Interop.BCrypt.NTSTATUS.STATUS_SUCCESS:
                        return;
                    case Interop.BCrypt.NTSTATUS.STATUS_AUTH_TAG_MISMATCH:
                        if (clearPlaintextOnFailure)
                        {
                            plaintext.Clear();
                            //CryptographicOperations.ZeroMemory(plaintext);
                        }
                        Errors.CryptographyAuthTagMismatch();
                        return;
                    default:
                        //throw CreateCryptographicException(ntStatus);
                        throw new CryptographicException($"Error: 0x{(int)ntStatus:X8}");
                }
            }
        }

        // Implementations below based on internal MemoryMarshal.GetNonNullPinnableReference methods.

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static unsafe ref readonly byte GetNonNullPinnableReference(ReadOnlySpan<byte> buffer)
            => ref buffer.Length != 0 ? ref MemoryMarshal.GetReference(buffer) : ref Unsafe.AsRef<byte>((void*)1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static unsafe ref byte GetNonNullPinnableReference(Span<byte> buffer)
            => ref buffer.Length != 0 ? ref MemoryMarshal.GetReference(buffer) : ref Unsafe.AsRef<byte>((void*)1);
    }
#endif
}
