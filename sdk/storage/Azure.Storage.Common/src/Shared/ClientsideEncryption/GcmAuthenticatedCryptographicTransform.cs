// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Storage.Cryptography.Models;

namespace Azure.Storage.Cryptography
{
    // TODO pull in GCM exposure to fill out this class
    internal class GcmAuthenticatedCryptographicTransform : IAuthenticatedCryptographicTransform
    {
        //private AesGcm _gcm;
        private readonly byte[] _key;

        public TransformMode TransformMode { get; }

        public int NonceLength => Constants.ClientSideEncryption.V2.NonceSize;

        public int TagLength => Constants.ClientSideEncryption.V2.TagSize;

        public GcmAuthenticatedCryptographicTransform(byte[] key, TransformMode mode)
        {
            _key = key;
            TransformMode = mode;
        }

        // TODO actually encrypt, not this placeholder
        public int TransformAuthenticationBlock(ReadOnlySpan<byte> input, Span<byte> output)
        {
            switch (TransformMode)
            {
                case TransformMode.Encrypt:
                    if (output.Length < input.Length + NonceLength + TagLength)
                    {
                        throw new ArgumentException("Span to small for encrypted contents.", nameof(output));
                    }
                    new ReadOnlySpan<byte>(Enumerable.Repeat((byte)'A', NonceLength).ToArray())
                        .CopyTo(output);
                    input.CopyTo(output.Slice(NonceLength));
                    new ReadOnlySpan<byte>(Enumerable.Repeat((byte)'a', TagLength).ToArray())
                        .CopyTo(output.Slice(NonceLength + input.Length));
                    return NonceLength + input.Length + TagLength;

                case TransformMode.Decrypt:
                    if (output.Length < input.Length - NonceLength - TagLength)
                    {
                        throw new ArgumentException("Span to small for decrypted contents.", nameof(output));
                    }
                    input.Slice(NonceLength, input.Length - NonceLength - TagLength).CopyTo(output);
                    return input.Length - NonceLength - TagLength;

                default: throw new InvalidOperationException("TransformMode invalid for this operation.");
            }
        }

        public void Dispose()
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
