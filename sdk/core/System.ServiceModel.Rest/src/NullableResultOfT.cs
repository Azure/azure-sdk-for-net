// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace System.ServiceModel.Rest;

/// <summary>
/// TBD.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class NullableResult<T>
{
    /// <summary>
    /// TBD.
    /// </summary>
    public abstract T? Value { get; }

    /// <summary>
    /// TBD.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract bool HasValue {get;}

    /// <summary>
    /// TBD.
    /// </summary>
    /// <returns></returns>
    public abstract Result GetRawResult();
}
