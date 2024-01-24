// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ComponentModel;

namespace System.ClientModel;

public class ClientResult<T> : OptionalClientResult<T>
{
    protected internal ClientResult(T value, PipelineResponse response)
        : base(value, response)
    {
        // Null values must use OptionalClientResult<T>
        if (value is null)
        {
            string message = "ClientResult<T> contract guarantees that ClientResult<T>.Value is non-null. " +
                "If you need to return a ClientResult where the Value is null, please use OptionalClientResult<T> instead.";

            throw new ArgumentNullException(nameof(value), message);
        }
    }

    public sealed override T Value => base.Value!;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed override bool HasValue => true;
}
