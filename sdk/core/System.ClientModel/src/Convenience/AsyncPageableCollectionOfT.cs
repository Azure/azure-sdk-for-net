// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace System.ClientModel;

#pragma warning disable CS1591 // public XML comments
public abstract class AsyncPageableCollection<T> : AsyncResultCollection<T> where T : notnull
{
    protected internal AsyncPageableCollection() : base()
    {
    }

    // Note: we don't have a constructor that takes response because
    // pageables delay the first request so they don't need to be disposed.

    public abstract IAsyncEnumerable<ClientPage<T>> AsPages(string? continuationToken, int? pageSizeHint);
}
#pragma warning restore CS1591 // public XML comments
