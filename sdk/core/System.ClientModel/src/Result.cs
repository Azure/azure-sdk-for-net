// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace System.ClientModel;

public abstract class Result
{
    public abstract PipelineResponse GetRawResponse();

    public static Result FromResponse(PipelineResponse response)
        => new SimpleResult(response);

    public static Result<T> FromValue<T>(T value, PipelineResponse response)
    {
        return new ValueResult<T>(value, response);
    }

    internal class SimpleResult : Result
    {
        public readonly PipelineResponse _response;

        public SimpleResult(PipelineResponse response)
            => _response = response;

        public override PipelineResponse GetRawResponse() => _response;
    }

    private class ValueResult<T> : Result<T>
    {
        public ValueResult(T value, PipelineResponse response) : base(value, response)
        {
        }
    }
}
