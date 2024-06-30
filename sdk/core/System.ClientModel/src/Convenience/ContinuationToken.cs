// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel;

#pragma warning disable CS1591

public class ContinuationToken
{
    private readonly BinaryData? _bytes;

    protected ContinuationToken() { }

    protected ContinuationToken(BinaryData bytes)
    {
        _bytes = bytes;
    }

    public static ContinuationToken FromBytes(BinaryData bytes) => new(bytes);

    public virtual BinaryData ToBytes() => _bytes ??
        throw new InvalidOperationException("Unable to write token as bytes.");
}

#pragma warning restore CS1591
