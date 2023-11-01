// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Diagnostics;
using System.Net.ClientModel.Core;

namespace System.Net.ClientModel;

public class Result<T> : Result
{
    private T _value;
    private MessageResponse _response;

    internal Result(T value, MessageResponse response)// : base(value, response)
    {
        _value = value;
        _response = response!;

        // TODO: note this will throw in the current implementation
        // And we do want to keep this validation for correctness of this type.

        // Null values are required to use NullableResult<T>
        if (value is null)
        {
            throw new ArgumentException("Result<T> contract guarantees that Result<T>.Value is non-null.", nameof(value));
        }
    }

    public T Value => _value;

    public override MessageResponse GetRawResponse() => _response;
}
