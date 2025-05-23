// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Storage.Cryptography.Models;

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
using System.Security.Cryptography;
#else
using Azure.Storage.Shared.AesGcm;
#endif

namespace Azure.Storage.Cryptography
{
    internal class GcmAuthenticatedCryptographicTransform : IAuthenticatedCryptographicTransform
    {
        // except for class name, these classes have the same API surface, as they are the same source code
        // declaration and instantiation is the only thing that needs conditional compilation
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
        private AesGcm _gcm;
#else
        private AesGcmWindows _gcm;
#endif
        private long _nonceCounter = 1;

        public TransformMode TransformMode { get; }

        public int NonceLength => Constants.ClientSideEncryption.V2.NonceSize;

        public int TagLength => Constants.ClientSideEncryption.V2.TagSize;

        public GcmAuthenticatedCryptographicTransform(byte[] key, TransformMode mode)
        {
            TransformMode = mode;

#if NET8_0_OR_GREATER
            _gcm = new AesGcm(key, TagLength);
#elif NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
            _gcm = new AesGcm(key);
#else
            _gcm = new AesGcmWindows(key);
#endif
        }

        /// <summary>
        /// Applies a GCM encryption or decryption to the <paramref name="input"/>, decided by <see cref="TransformMode"/>,
        /// and writes the result to <paramref name="output"/>.
        /// <para />
        /// An encrypted input or output contains the nonce, then ciphertext, then tag, while the unencrypted input or
        /// output only contains plaintext. Plaintext and ciphertext have equal length when using GCM, though the input
        /// and output will not, given one has the nonce and tag attached.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="output"/> is not large enough to contain the transformed result of <paramref name="input"/>.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if this instance's <see cref="TransformMode"/> is invalid.
        /// </exception>
        public int TransformAuthenticationBlock(ReadOnlySpan<byte> input, Span<byte> output)
        {
            switch (TransformMode)
            {
                case TransformMode.Encrypt:
                    ReadOnlySpan<byte> nonce = GetNewNonce();
                    Span<byte> tag = new Span<byte>(new byte[TagLength]);

                    nonce.CopyTo(output.Slice(0, NonceLength));
                    _gcm.Encrypt(nonce, input, output.Slice(NonceLength, input.Length), tag);
                    tag.CopyTo(output.Slice(NonceLength + input.Length, TagLength));
                    return NonceLength + input.Length + TagLength;

                case TransformMode.Decrypt:
                    int dataLength = input.Length - NonceLength - TagLength;
                    _gcm.Decrypt(
                        input.Slice(0, NonceLength),
                        input.Slice(NonceLength, dataLength),
                        input.Slice(input.Length - TagLength, TagLength),
                        output.Slice(0, dataLength));
                    return input.Length - NonceLength - TagLength;

                default: throw new InvalidOperationException("TransformMode invalid for this operation.");
            }
        }

        public void Dispose()
        {
            _gcm.Dispose();
        }

        private ReadOnlySpan<byte> GetNewNonce()
        {
            var result = new Span<byte>(new byte[NonceLength]);

            // long is 8 bytes, nonce is 12. pad the nonce with remaining 4 zeroes.
            const int bytesInLong = 8;
            int remainingNonceBytes = NonceLength - bytesInLong;
            new byte[] { 0, 0, 0, 0 }.CopyTo(result.Slice(0, remainingNonceBytes));

            // write nonce to span and increment counter
            BitConverter.GetBytes(_nonceCounter++).CopyTo(result.Slice(remainingNonceBytes, bytesInLong));

            return result;
        }
    }
}
