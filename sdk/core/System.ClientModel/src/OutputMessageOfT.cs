// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ComponentModel;

namespace System.ClientModel;

public class OutputMessage<T> : NullableOutputMessage<T>
{
    internal OutputMessage(T value, PipelineResponse response) : base(value, response)
    {
        if (value is null) throw new ArgumentNullException(nameof(value));
        if (response is null) throw new ArgumentNullException(nameof(response));

        // Null values are required to use NullableOutputMessage<T>
        if (value is null)
        {
            throw new ArgumentException("OutputMessage<T> contract guarantees that OutputMessage<T>.Value is non-null.", nameof(value));
        }
    }

    public override T Value => base.Value!;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool HasValue => true;
}
