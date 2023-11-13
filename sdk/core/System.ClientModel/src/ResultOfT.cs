// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Diagnostics;
using System.ClientModel.Core;

namespace System.ClientModel;

public class Result<T> : NullableResult<T>
{
    internal Result(T value, MessageResponse response) : base(value, response)
    {
        Debug.Assert(value != null);
        Debug.Assert(response != null);

        // Null values are required to use NullableResult<T>
        if (value is null)
        {
            throw new ArgumentException("Result<T> contract guarantees that Result<T>.Value is non-null.", nameof(value));
        }
    }

    public override T Value => base.Value!;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool HasValue => true;
}
