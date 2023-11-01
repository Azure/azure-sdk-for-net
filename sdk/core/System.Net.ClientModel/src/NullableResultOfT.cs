// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Net.ClientModel.Core;

namespace System.Net.ClientModel;

public class NullableResult<T> : Result<T>
{
    internal NullableResult(T? value, MessageResponse response) : base(value!, response)
    {
        Debug.Assert(response != null);
    }

    public virtual new T? Value => base.Value;

    public virtual bool HasValue => base.Value != null;
}
