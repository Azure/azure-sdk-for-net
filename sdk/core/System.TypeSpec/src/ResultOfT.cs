// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace System.ServiceModel.Rest;

public class Result<T> : NullableResult<T>
{
    public Result(T value, Result result) : base(value, result) {
    }

    public override T Value => base.Value!;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool HasValue => true;

    public override Result GetRawResult() => base.GetRawResult();
}
