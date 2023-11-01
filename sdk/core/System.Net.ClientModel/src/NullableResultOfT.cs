// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Net.ClientModel.Core;

namespace System.Net.ClientModel;

public class NullableResult<T> : Result
{
    private T? _value;
    private MessageResponse _response;

    internal NullableResult(T? value, MessageResponse response)
    {
        Debug.Assert(response != null);
        _response = response!;
        _value = value;
    }

    public virtual T? Value => _value;

    public virtual bool HasValue => _value != null;

    public override MessageResponse GetRawResponse() => _response;
}
