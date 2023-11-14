// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.ClientModel.Primitives;

namespace System.ClientModel;

public class NullableResult<T> : OutputMessage
{
    private T? _value;
    private PipelineResponse _response;

    internal NullableResult(T? value, PipelineResponse response)
    {
        Debug.Assert(response != null);
        _response = response!;
        _value = value;
    }

    public virtual T? Value => _value;

    public virtual bool HasValue => _value != null;

    public override PipelineResponse GetRawResponse() => _response;
}
