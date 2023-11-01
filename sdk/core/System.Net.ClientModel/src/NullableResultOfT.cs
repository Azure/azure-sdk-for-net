// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.ClientModel.Core;

namespace System.Net.ClientModel;

public class NullableResult<T> : Result
{
    private readonly T? _value;
    private readonly MessageResponse _response;

    internal NullableResult(T? value, MessageResponse response)
    {
        if (response is null) throw new ArgumentNullException(nameof(response));

        _response = response!;
        _value = value;
    }

    public virtual T? Value => _value;

    // TODO: Note that HasValue is needed if we decide we want to give callers
    // a way to check whether Value is null without actually calling the Value
    // getter.  We would want this if we decide to use an exploding response,
    // but if we decide not to use an exploding response, HasValue is not strictly
    // required because callers can always to do `response.Value is null` to check.
    //public virtual bool HasValue => _value != null;

    public override MessageResponse GetRawResponse() => _response;
}
