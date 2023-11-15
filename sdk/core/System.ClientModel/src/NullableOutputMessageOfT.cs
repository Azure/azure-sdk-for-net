// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace System.ClientModel;

public class NullableOutputMessage<T> : OutputMessage
    where T : class, IPersistableModel<T>
{
    private readonly T? _value;
    private readonly PipelineResponse _response;

    internal NullableOutputMessage(T? value, PipelineResponse response)
    {
        if (response is null) throw new ArgumentNullException(nameof(response));

        _value = value;
        _response = response;
    }

    public virtual T? Value => _value;

    public override PipelineResponse GetRawResponse() => _response;
}
