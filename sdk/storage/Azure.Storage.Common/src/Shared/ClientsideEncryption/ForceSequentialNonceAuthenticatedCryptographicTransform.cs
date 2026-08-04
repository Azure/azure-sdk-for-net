// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Security.Cryptography;
using Azure.Storage.Common;
using Azure.Storage.Cryptography.Models;

namespace Azure.Storage.Cryptography;

internal class ForceSequentialNonceAuthenticatedCryptographicTransform : IAuthenticatedCryptographicTransform
{
    private readonly IAuthenticatedCryptographicTransform _inner;
    private long _next;

    public TransformMode TransformMode => _inner.TransformMode;

    public int NonceLength => _inner.NonceLength;

    public int TagLength => _inner.TagLength;

    public ForceSequentialNonceAuthenticatedCryptographicTransform(
        IAuthenticatedCryptographicTransform inner,
        long countStart)
    {
        Argument.AssertNotNull(inner, nameof(inner));
        if (inner.TransformMode != TransformMode.Decrypt)
        {
            throw new ArgumentException("This transform only valid for decryption.", nameof(inner));
        }
        Argument.AssertInRange(inner.NonceLength, sizeof(long), int.MaxValue, nameof(inner.NonceLength));
        _inner = inner;
        _next = countStart;
    }

    public void Dispose() => _inner.Dispose();

    public int TransformAuthenticationBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        AssertNonceAndIncrement(input.Slice(0, NonceLength));
        return _inner.TransformAuthenticationBlock(input, output);
    }

    private void AssertNonceAndIncrement(ReadOnlySpan<byte> actual)
    {
        var array = ArrayPool<byte>.Shared.Rent(NonceLength);
        Array.Clear(array, 0, array.Length);
        try
        {
            Span<byte> expected = new(array, 0, NonceLength);
            const int longBytes = 8;
            BitConverter.GetBytes(_next).CopyTo(expected.Slice(NonceLength - longBytes));
            if (!expected.SequenceEqual(actual))
            {
                string nonceToString(ReadOnlySpan<byte> span)
                {
                    return BitConverter.ToInt64(span.Slice(NonceLength - longBytes).ToArray(), 0).ToString();
                }
                throw new CryptographicException($"Encountered out-of-order authenticated region. Expected {nonceToString(expected)}, got {nonceToString(actual)}.");
            }
            _next += 1;
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(array);
        }
    }
}
