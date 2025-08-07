// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;

namespace System.ClientModel;

/// <summary>
/// A token that can be passed to a client method to request or rehydrate a
/// subclient from the state represented by the token.
/// </summary>
public class ContinuationToken
{
    private readonly BinaryData? _bytes;

    /// <summary>
    /// Create a new instance of <see cref="ContinuationToken"/>.
    /// </summary>
    /// <remarks>This constructor is used by derived types to create an
    /// instance from values held by the client.</remarks>
    protected ContinuationToken() { }

    /// <summary>
    /// Create a new instance of <see cref="ContinuationToken"/>.
    /// </summary>
    /// <param name="bytes">Bytes that can be deserialized into a subtype of
    /// <see cref="ContinuationToken"/>.</param>
    protected ContinuationToken(BinaryData bytes)
    {
        Argument.AssertNotNull(bytes, nameof(bytes));

        _bytes = bytes;
    }

    /// <summary>
    /// Create a new instance of <see cref="ContinuationToken"/> from the
    /// provided <paramref name="bytes"/>.
    /// </summary>
    /// <param name="bytes">Bytes obtained from calling <see cref="ToBytes"/>
    /// on a <see cref="ContinuationToken"/>.</param>
    /// <returns>A <see cref="ContinuationToken"/> that can be passed to a
    /// client method to request or rehydrate a subclient equivalent to the one
    /// from which the original <see cref="ContinuationToken"/> bytes were
    /// obtained.
    /// </returns>
    public static ContinuationToken FromBytes(BinaryData bytes) => new(bytes);

    /// <summary>
    /// Write the bytes of this <see cref="ContinuationToken"/>.
    /// </summary>
    /// <returns>The bytes of this <see cref="ContinuationToken"/>.</returns>
    /// <exception cref="InvalidOperationException">Thrown if not implemented
    /// in a derived type.</exception>
    public virtual BinaryData ToBytes() => _bytes ??
        throw new InvalidOperationException("Unable to write token as bytes.");
}
