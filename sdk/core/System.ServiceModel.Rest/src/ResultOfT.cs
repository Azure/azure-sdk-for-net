﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel.Rest.Core;

namespace System.ServiceModel.Rest;

public class Result<T> : NullableResult<T>
{
    public Result(T value, PipelineResponse response) : base(value, response)
    {
        Debug.Assert(value != null);
        Debug.Assert(response != null);
    }

    public override T Value => base.Value!;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool HasValue => true;
}
