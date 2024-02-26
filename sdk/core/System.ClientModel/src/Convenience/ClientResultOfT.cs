// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace System.ClientModel;

public class ClientResult<T> : ClientResult
{
    protected internal ClientResult(T value, PipelineResponse response)
        : base(response)
    {
        Value = value;
    }

    /// <summary>
    /// TBD.  Needed for inheritdoc.
    /// </summary>
    public virtual T Value { get; }

    /// <summary>
    /// Returns the value of this <see cref="ClientResult{T}"/> object.
    /// </summary>
    /// <param name="result">The <see cref="ClientResult{T}"/> instance.</param>
    public static implicit operator T(ClientResult<T> result)
    {
        if (result == null)
        {
#pragma warning disable CA1065 // Don't throw from cast operators
            throw new ArgumentNullException(nameof(result), $"The implicit cast from ClientResult<{typeof(T)}> to {typeof(T)} failed because the ClientResult<{typeof(T)}> was null.");
#pragma warning restore CA1065
        }

        return result.Value!;
    }
}
