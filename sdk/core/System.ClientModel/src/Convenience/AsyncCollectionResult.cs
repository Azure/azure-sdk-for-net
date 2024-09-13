// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591 // public XML comments
public abstract class AsyncCollectionResult : ClientResult
{
    protected AsyncCollectionResult() : base()
    {
    }

    public abstract IAsyncEnumerable<ClientResult> GetRawPagesAsync();

    public abstract ContinuationToken GetContinuationToken(ClientResult result);
}
#pragma warning restore CS1591 // public XML comments
