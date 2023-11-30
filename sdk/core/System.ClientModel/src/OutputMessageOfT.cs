// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ComponentModel;

namespace System.ClientModel;

public abstract class OutputMessage<T> : OptionalOutputMessage<T>
{
    internal OutputMessage(T value, PipelineResponse response) : base(value, response)
    {
        // Null values must use OptionalOutputMessage<T>
        if (value is null) throw new ArgumentNullException(nameof(value));
        if (response is null) throw new ArgumentNullException(nameof(response));
    }

    public override T Value => base.Value!;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool HasValue => true;
}
