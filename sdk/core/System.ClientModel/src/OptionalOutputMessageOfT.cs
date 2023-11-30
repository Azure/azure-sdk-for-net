// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace System.ClientModel;

public class OptionalOutputMessage<T> : OutputMessage
{
    private readonly T? _value;
    private readonly PipelineResponse _response;

    internal OptionalOutputMessage(T? value, PipelineResponse response)
    {
        if (response is null) throw new ArgumentNullException(nameof(response));

        _response = response;
        _value = value;
    }

    public virtual T? Value => _value;

    public virtual bool HasValue => _value != null;

    public override PipelineResponse GetRawResponse() => _response;
}
