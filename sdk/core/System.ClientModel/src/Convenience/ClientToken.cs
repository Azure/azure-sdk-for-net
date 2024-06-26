// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel;

#pragma warning disable CS1591

public class ClientToken
{
    private readonly BinaryData? _bytes;

    protected ClientToken() { }

    protected ClientToken(BinaryData bytes)
    {
        _bytes = bytes;
    }

    public virtual BinaryData ToBytes() => _bytes ??
        throw new InvalidOperationException("Unable to write token as bytes.");

    public static ClientToken FromBytes(BinaryData bytes) => new(bytes);
}

#pragma warning restore CS1591
