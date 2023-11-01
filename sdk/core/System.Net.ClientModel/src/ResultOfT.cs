// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.ClientModel.Core;

namespace System.Net.ClientModel;

public class Result<T> : Result where T : notnull
{
    private readonly T _value;
    private readonly MessageResponse _response;

    internal Result(T value, MessageResponse response)
    {
        if (response is null) throw new ArgumentNullException(nameof(response));

        // We throw here because the Result<T> contract is that Value will always
        // be non-null.  This is because it is a convenience to client users that they
        // never need to check result.Value for null.  If a client author needs to return
        // a Result with a null Value, they a must use NullableResult<T> for the service
        // method return value.
        if (value is null)
        {
            throw new ArgumentException("Result<T> contract guarantees that Result<T>.Value is non-null.", nameof(value));
        }

        _value = value;
        _response = response;
    }

    public T Value => _value;

    public override MessageResponse GetRawResponse() => _response;
}
