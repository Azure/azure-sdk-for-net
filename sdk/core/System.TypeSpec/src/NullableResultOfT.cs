// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    /// <param result=""></param>
    public NullableResult(Result result) {
    }

    /// <summary>
    /// TBD.
    /// </summary>
    public abstract bool HasValue { get; }

    /// <summary>
    /// TBD.
    /// </summary>
    public abstract T? Value { get; }

    /// <summary>
    /// TBD.
    /// </summary>
    public abstract Result GetRawResult();
}
