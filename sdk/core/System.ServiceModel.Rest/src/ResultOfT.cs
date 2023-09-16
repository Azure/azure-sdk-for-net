// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace System.ServiceModel.Rest;

/// <summary>
/// TBD.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Result<T> : NullableResult<T>
{
    /// <summary>
    /// TBD.
    /// </summary>
    /// <param result=""></param>
    public Result(T value, Result result) : base(value, result) {
    }

    /// <summary>
    /// TBD.
    /// </summary>
    public override T Value => base.Value!;

    /// <summary>
    /// TBD.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool HasValue => true;

    /// <summary>
    /// TBD.
    /// </summary>
    /// <returns></returns>
    public override Result GetRawResult() => base.GetRawResult();
}
