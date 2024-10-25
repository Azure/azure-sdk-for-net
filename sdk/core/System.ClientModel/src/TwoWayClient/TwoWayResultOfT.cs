// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Threading;

namespace System.ClientModel.Primitives.TwoWayClient;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class TwoWayResult<T> : TwoWayResult
{
    protected internal TwoWayResult(T value, TwoWayPipelineServiceMessage response)
        : base(response)
    {
        Value = value;
    }

    public T Value { get; }

    public static implicit operator T(TwoWayResult<T> result)
    {
        if (result == null)
        {
#pragma warning disable CA1065 // Don't throw from cast operators
            throw new ArgumentNullException(nameof(result), $"The implicit cast from TwoWayResult<{typeof(T)}> to {typeof(T)} failed because the ClientResult<{typeof(T)}> was null.");
#pragma warning restore CA1065
        }

        return result.Value!;
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
