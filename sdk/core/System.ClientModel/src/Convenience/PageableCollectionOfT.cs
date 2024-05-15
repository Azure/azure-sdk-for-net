// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace System.ClientModel;

#pragma warning disable CS1591 // public XML comments
public abstract class PageableCollection<T> : ResultCollection<T>
{
    protected internal PageableCollection() : base()
    {
    }

    // Note: we don't have a constructor that takes response because
    // pageables delay the first request so they don't need to be disposed.

    public abstract IEnumerable<ResultPage<T>> AsPages(string? continuationToken = default, int? pageSizeHint = default);

    public override IEnumerator<T> GetEnumerator()
    {
        foreach (ResultPage<T> page in AsPages())
        {
            foreach (T value in page)
            {
                yield return value;
            }
        }
    }
}
#pragma warning restore CS1591 // public XML comments
