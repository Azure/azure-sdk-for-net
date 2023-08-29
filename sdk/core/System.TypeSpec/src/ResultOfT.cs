// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace System.ServiceModel.Rest;

/// <summary>
/// TBD.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class Result<T> : NullableResult<T>
{
    /// <summary>
    /// TBD.
    /// </summary>
    /// <param result=""></param>
    public Result(Result result) : base(result) {
    }

    /// <summary>
    /// TBD.
    /// </summary>
    public abstract override T Value { get; }

    /// <summary>
    /// TBD.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool HasValue => true;
}
