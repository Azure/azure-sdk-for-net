// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.ClientModel.Core;
using System.Net.ClientModel.Internal;

namespace System.Net.ClientModel;

public abstract class Result
{
    public abstract PipelineResponse GetRawResponse();

    public static Result FromResponse(PipelineResponse response)
        => new NoModelResult(response);

    public static Result<T> FromValue<T>(T value, PipelineResponse response)
    {
        // Null values are required to use NullableResult<T>
        if (value is null)
        {
            throw new ArgumentException("Result<T> contract guarantees that Result<T>.Value is non-null.  Please call Result.FromNullableValue instead.", nameof(value));
        }

        ClientUtilities.AssertNotNull(response, nameof(response));

        return new Result<T>(value, response);
    }

    public static NullableResult<T> FromNullableValue<T>(T? value, PipelineResponse response)
    {
        ClientUtilities.AssertNotNull(response, nameof(response));

        return new NullableResult<T>(value, response);
    }

    private class NoModelResult : Result
    {
        public readonly PipelineResponse _response;

        public NoModelResult(PipelineResponse response)
            => _response = response;

        public override PipelineResponse GetRawResponse() => _response;
    }
}
