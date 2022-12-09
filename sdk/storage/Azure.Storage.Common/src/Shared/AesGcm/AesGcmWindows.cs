// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
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
    internal sealed partial class AesGcmWindows : IDisposable
    {
        private const int NonceSize = 12;
        internal static KeySizes NonceByteSizes { get; } = new KeySizes(NonceSize, NonceSize, 1);
        internal static KeySizes TagByteSizes { get; } = new KeySizes(12, 16, 1);

        internal AesGcmWindows(ReadOnlySpan<byte> key)
        {
            ThrowIfNotSupported();

            Errors.CheckCryptKeySize(key.Length);
            ImportKey(key);
        }

        internal AesGcmWindows(byte[] key)
        {
            ThrowIfNotSupported();

            Errors.ThrowIfParamNull(key, nameof(key));

            Errors.CheckCryptKeySize(key.Length);
            ImportKey(key);
        }

        internal void Encrypt(byte[] nonce, byte[] plaintext, byte[] ciphertext, byte[] tag, byte[] associatedData = null)
        {
            Errors.ThrowIfParamNull(nonce, nameof(nonce));
            Errors.ThrowIfParamNull(plaintext, nameof(plaintext));
            Errors.ThrowIfParamNull(ciphertext, nameof(ciphertext));
            Errors.ThrowIfParamNull(tag, nameof(tag));

            Encrypt((ReadOnlySpan<byte>)nonce, plaintext, ciphertext, tag, associatedData);
        }

        internal void Encrypt(
            ReadOnlySpan<byte> nonce,
            ReadOnlySpan<byte> plaintext,
            Span<byte> ciphertext,
            Span<byte> tag,
            ReadOnlySpan<byte> associatedData = default)
        {
            CheckParameters(plaintext, ciphertext, nonce, tag);
            EncryptCore(nonce, plaintext, ciphertext, tag, associatedData);
        }

        internal void Decrypt(byte[] nonce, byte[] ciphertext, byte[] tag, byte[] plaintext, byte[] associatedData = null)
        {
            Errors.ThrowIfParamNull(nonce, nameof(nonce));
            Errors.ThrowIfParamNull(ciphertext, nameof(ciphertext));
            Errors.ThrowIfParamNull(tag, nameof(tag));
            Errors.ThrowIfParamNull(plaintext, nameof(plaintext));

            Decrypt((ReadOnlySpan<byte>)nonce, ciphertext, tag, plaintext, associatedData);
        }

        internal void Decrypt(
            ReadOnlySpan<byte> nonce,
            ReadOnlySpan<byte> ciphertext,
            ReadOnlySpan<byte> tag,
            Span<byte> plaintext,
            ReadOnlySpan<byte> associatedData = default)
        {
            CheckParameters(plaintext, ciphertext, nonce, tag);
            DecryptCore(nonce, ciphertext, tag, plaintext, associatedData);
        }

        private static void CheckParameters(
            ReadOnlySpan<byte> plaintext,
            ReadOnlySpan<byte> ciphertext,
            ReadOnlySpan<byte> nonce,
            ReadOnlySpan<byte> tag)
        {
            if (plaintext.Length != ciphertext.Length)
                Errors.CryptographyPlaintextCiphertextLengthMismatch();

            if (!nonce.Length.IsLegalSize(NonceByteSizes))
                Errors.CryptographyInvalidNonceLength();

            if (!tag.Length.IsLegalSize(TagByteSizes))
                Errors.CryptographyInvalidTagLength();
        }

        private static void ThrowIfNotSupported()
        {
            // Always supported in this implementation.
            //if (!IsSupported)
            //{
            //    throw new PlatformNotSupportedException(SR.Format(SR.Cryptography_AlgorithmNotSupported, nameof(AesGcm)));
            //}
        }
    }

    internal partial class AesGcmWindows
    {
        private Interop.BCrypt.SafeKeyHandle _keyHandle;

        internal static bool IsSupported => true;

        //[MemberNotNull(nameof(_keyHandle))]
        private void ImportKey(ReadOnlySpan<byte> key)
        {
            _keyHandle = Interop.BCrypt.BCryptImportKey(Interop.BCrypt.BCryptAeadHandleCache.AesGcm, key);
        }

        private void EncryptCore(
            ReadOnlySpan<byte> nonce,
           ReadOnlySpan<byte> plaintext,
            Span<byte> ciphertext,
            Span<byte> tag,
            ReadOnlySpan<byte> associatedData = default)
        {
            AeadCommon.Encrypt(_keyHandle, nonce, associatedData, plaintext, ciphertext, tag);
        }

        private void DecryptCore(
            ReadOnlySpan<byte> nonce,
            ReadOnlySpan<byte> ciphertext,
            ReadOnlySpan<byte> tag,
            Span<byte> plaintext,
            ReadOnlySpan<byte> associatedData = default)
        {
            AeadCommon.Decrypt(_keyHandle, nonce, associatedData, ciphertext, tag, plaintext, clearPlaintextOnFailure: true);
        }

        public void Dispose()
        {
            _keyHandle.Dispose();
        }
    }
#endif
}
