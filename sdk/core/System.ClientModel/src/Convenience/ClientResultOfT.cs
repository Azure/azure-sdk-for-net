// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.ClientModel.Primitives;
using System.ComponentModel;

namespace System.ClientModel;

public abstract class ClientResult<T> : OptionalClientResult<T>
{
    protected ClientResult(T value, PipelineResponse response)
        : base(value, response)
    {
        // Null values must use OptionalClientResult<T>
        ClientUtilities.AssertNotNull(value, nameof(value));
    }

    public sealed override T Value => base.Value!;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed override bool HasValue => true;
}
