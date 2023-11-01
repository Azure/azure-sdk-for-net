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

    public virtual bool HasValue => _value != null;

    public override MessageResponse GetRawResponse() => _response;
}
