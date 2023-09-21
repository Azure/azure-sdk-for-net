// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel.Rest.Core;

namespace System.ServiceModel.Rest;

public abstract class Result
{
    public abstract PipelineResponse GetRawResponse();

    public static Result Create(PipelineResponse response) => new SimpleResult(response);

    internal class SimpleResult : Result
    {
        public readonly PipelineResponse _response;
        public SimpleResult(PipelineResponse response)
            => _response = response;
        public override PipelineResponse GetRawResponse() => _response;
    }
}

public class NullableResult<T> : Result
{
    private T? _value;
    private PipelineResponse _response;

    public NullableResult(T? value, PipelineResponse response)
    {
        Debug.Assert(response != null);
        _response = response!;
        _value = value;
    }

    public virtual T? Value => _value;

    public virtual bool HasValue => _value != null;

    public override PipelineResponse GetRawResponse() => _response;
}

public class Result<T> : NullableResult<T>
{
    public Result(T value, PipelineResponse response) : base(value, response)
    {
        Debug.Assert(value != null);
        Debug.Assert(response != null);
    }

    public override T Value => base.Value!;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool HasValue => true;
}
