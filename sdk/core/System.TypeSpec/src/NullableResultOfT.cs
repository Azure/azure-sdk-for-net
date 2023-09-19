// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace System.ServiceModel.Rest;

public class NullableResult<T>
{
    private T? _value;
    private Result _result;

    public NullableResult(T? value, Result result)
    {
        _value = value;
        _result = result;
    }

    public virtual T? Value => _value;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual bool HasValue => _value != null;

    public virtual Result GetRawResult() => _result;
}
