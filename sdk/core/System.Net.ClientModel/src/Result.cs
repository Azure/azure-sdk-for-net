// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.ClientModel.Core;
using System.Net.ClientModel.Internal;

namespace System.Net.ClientModel;

public abstract class Result
{
    public abstract MessageResponse GetRawResponse();

    public static Result FromResponse(MessageResponse response)
        => new NoModelResult(response);

    public static Result<T> FromValue<T>(T value, MessageResponse response) where T : notnull
    {
        // Null values are required to use NullableResult<T>
        if (value is null)
        {
            throw new ArgumentException("Result<T> contract guarantees that Result<T>.Value is non-null.  Please call Result.FromNullableValue instead.", nameof(value));
        }

        ClientUtilities.AssertNotNull(response, nameof(response));

        return new Result<T>(value, response);
    }

    public static NullableResult<T> FromNullableValue<T>(T? value, MessageResponse response)
    {
        ClientUtilities.AssertNotNull(response, nameof(response));

        return new NullableResult<T>(value, response);
    }

    private class NoModelResult : Result
    {
        public readonly MessageResponse _response;

        public NoModelResult(MessageResponse response)
            => _response = response;

        public override MessageResponse GetRawResponse() => _response;
    }
}
