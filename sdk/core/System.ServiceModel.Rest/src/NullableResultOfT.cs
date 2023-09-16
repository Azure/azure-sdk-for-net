// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace System.ServiceModel.Rest;

/// <summary>
/// TBD.
/// </summary>
/// <typeparam name="T"></typeparam>
public class NullableResult<T>
{
    private T? _value;
    private Result _result;

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param result=""></param>
    public NullableResult(T? value, Result result)
    {
        _value = value;
        _result = result;
    }

    /// <summary>
    /// TBD.
    /// </summary>
    public virtual T? Value => _value;

    /// <summary>
    /// TBD.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual bool HasValue => _value != null;

    /// <summary>
    /// TBD.
    /// </summary>
    /// <returns></returns>
    public virtual Result GetRawResult() => _result;
}
