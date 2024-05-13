// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;

namespace System.ClientModel;

#pragma warning disable CS1591 // public XML comments
public abstract class ClientPage<T> : ClientResult, IEnumerable<T> where T : notnull
{
    public string? ContinuationToken;

    public abstract IEnumerator<T> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
#pragma warning restore CS1591 // public XML comments
