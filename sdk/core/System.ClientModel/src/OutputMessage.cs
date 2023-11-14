// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Internal;

namespace System.ClientModel;

public abstract class OutputMessage
{
    public abstract PipelineResponse GetRawResponse();

    public static OutputMessage FromResponse(PipelineResponse response)
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

    private class NoModelResult : OutputMessage
    {
        public readonly PipelineResponse _response;

        public NoModelResult(PipelineResponse response)
            => _response = response;

        public override PipelineResponse GetRawResponse() => _response;
    }
}
