// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.ClientModel.Core;
using System.Net.ClientModel.Internal;

namespace System.Net.ClientModel;

public abstract class Result
{
    public abstract PipelineResponse GetRawResponse();

    public static Result FromResponse(PipelineResponse response)
        => new SimpleResult(response);

    public static Result<T> FromValue<T>(T value, PipelineResponse response)
    {
        // Null values are required to go through NullableResult<T>
        if (value is null)
        {
            throw new ArgumentException("Result<T> contract guarantees that Result<T>.Value is non-null.  Please call Result.FromNullableValue instead.", nameof(value));
        }

        ClientUtilities.AssertNotNull(response, nameof(response));

        return new ValueResult<T>(value, response);
    }

    public static NullableResult<T> FromNullableValue<T>(T? value, PipelineResponse response)
    {
        ClientUtilities.AssertNotNull(response, nameof(response));

        return new NullableResult<T>(value, response);
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
