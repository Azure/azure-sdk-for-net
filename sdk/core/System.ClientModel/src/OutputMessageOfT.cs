// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace System.ClientModel;

public class OutputMessage<T> : NullableOutputMessage<T>
    where T : class, IPersistableModel<T>
{
    internal OutputMessage(T value, PipelineResponse response) : base(value, response)
    {
        // Null values must use NullableOutputMessage<T>
        if (value is null) throw new ArgumentNullException(nameof(value));
        if (response is null) throw new ArgumentNullException(nameof(response));
    }

    public override T Value => base.Value!;
}
