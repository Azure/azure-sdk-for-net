// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Security.Cryptography;
using Azure.Storage.Common;
using Azure.Storage.Cryptography.Models;

namespace Azure.Storage.Cryptography;

internal class ForceSequentialNonceAuthenticatedCryptographicTransform : IAuthenticatedCryptographicTransform
{
    private enum AcceptedNoncePatterns
    {
        /// <summary>
        /// A full 12-byte integer, big endian.
        /// The first value is 0.
        /// </summary>
        ZeroIndexBigEndian12,

        /// <summary>
        /// An eight byte integer followed by four zeroes, big endian.
        /// The first value is 0.
        /// </summary>
        ZeroIndexBigEndianLeading8,

        /// <summary>
        /// Four zeroes followed by an eight byte integer, little endian.
        /// The first value is 1.
        /// </summary>
        OneIndexLittleEndianTrailing8,
    }

    private readonly IAuthenticatedCryptographicTransform _inner;
    private long _nextRegion;
    private AcceptedNoncePatterns? _noncePattern;

    public TransformMode TransformMode => _inner.TransformMode;

    public int NonceLength => _inner.NonceLength;

    public int TagLength => _inner.TagLength;

    public ForceSequentialNonceAuthenticatedCryptographicTransform(
        IAuthenticatedCryptographicTransform inner,
        long initialRegion)
    {
        Argument.AssertNotNull(inner, nameof(inner));
        if (inner.TransformMode != TransformMode.Decrypt)
        {
            throw new ArgumentException("This transform only valid for decryption.", nameof(inner));
        }
        Argument.AssertInRange(inner.NonceLength, sizeof(long), int.MaxValue, nameof(inner.NonceLength));
        _inner = inner;
        _nextRegion = initialRegion;
    }

    public void Dispose() => _inner.Dispose();

    public int TransformAuthenticationBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        AssertNonceAndIncrement(input.Slice(0, NonceLength));
        return _inner.TransformAuthenticationBlock(input, output);
    }

    private void AssertNonceAndIncrement(ReadOnlySpan<byte> actualBytes)
    {
        const int longLength = 8;
        if (_noncePattern.HasValue)
        {
            long actual = _noncePattern.Value switch
            {
                // we will never exceed 8 bytes. we can cast to a long just fine.
                AcceptedNoncePatterns.ZeroIndexBigEndian12 => BinaryPrimitives.ReadInt64BigEndian(actualBytes.Slice(NonceLength - longLength)),// we will never exceed 8 bytes. we can cast to a long just fine.
                AcceptedNoncePatterns.ZeroIndexBigEndianLeading8 => BinaryPrimitives.ReadInt64BigEndian(actualBytes.Slice(0, longLength)),
                AcceptedNoncePatterns.OneIndexLittleEndianTrailing8 => BinaryPrimitives.ReadInt64LittleEndian(actualBytes.Slice(NonceLength - longLength)),
                _ => throw new Exception("Missing switch case. Please report."),
            };
            long expected = _noncePattern.Value switch
            {
                AcceptedNoncePatterns.OneIndexLittleEndianTrailing8 => _nextRegion + 1,
                _ => _nextRegion,
            };
            if (expected != actual)
            {
                throw new CryptographicException($"Encountered out-of-order nonce in region {_nextRegion}.");
            }
        }
        else
        {
            using IDisposable _1 = ArrayPool<byte>.Shared.RentAsSpanDisposable(NonceLength, out Span<byte> zeroBig12);
            using IDisposable _2 = ArrayPool<byte>.Shared.RentAsSpanDisposable(NonceLength, out Span<byte> zeroBigLead8);
            using IDisposable _3 = ArrayPool<byte>.Shared.RentAsSpanDisposable(NonceLength, out Span<byte> oneLittleTrailing8);

            zeroBig12.Clear();
            zeroBigLead8.Clear();
            oneLittleTrailing8.Clear();

            BinaryPrimitives.WriteInt64BigEndian(zeroBig12.Slice(NonceLength - longLength), _nextRegion);
            BinaryPrimitives.WriteInt64BigEndian(zeroBigLead8.Slice(0, longLength), _nextRegion);
            BinaryPrimitives.WriteInt64LittleEndian(oneLittleTrailing8.Slice(NonceLength - longLength), _nextRegion + 1);

            List<AcceptedNoncePatterns> matches = new(3);
            if (actualBytes.SequenceEqual(zeroBig12))
            {
                matches.Add(AcceptedNoncePatterns.ZeroIndexBigEndian12);
            }
            if (actualBytes.SequenceEqual(zeroBigLead8))
            {
                matches.Add(AcceptedNoncePatterns.ZeroIndexBigEndianLeading8);
            }
            if (actualBytes.SequenceEqual(oneLittleTrailing8))
            {
                matches.Add(AcceptedNoncePatterns.OneIndexLittleEndianTrailing8);
            }

            _noncePattern = matches.Count switch
            {
                1 => matches[0],
                0 => throw new CryptographicException($"Encountered out-of-order nonce in region {_nextRegion}."),
                _ => null,
            };
        }
        _nextRegion += 1;
    }
}
