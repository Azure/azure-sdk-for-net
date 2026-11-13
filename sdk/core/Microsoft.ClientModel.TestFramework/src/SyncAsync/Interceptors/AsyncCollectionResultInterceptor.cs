// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Microsoft.ClientModel.TestFramework;

internal class AsyncCollectionResultInterceptor<T> : IAsyncEnumerator<T>
        where T : class
{
    private ClientTestBase _testBase;
    private IAsyncEnumerator<T> _inner;

    public AsyncCollectionResultInterceptor(ClientTestBase testBase, IAsyncEnumerator<T> inner)
    {
        _testBase = testBase;
        _inner = inner;
    }

    public T Current => _testBase.CreateProxyFromClient(_inner.Current.GetType(), _inner.Current, []) as T ?? throw new InvalidOperationException();

    public ValueTask<bool> MoveNextAsync()
    {
        return _inner.MoveNextAsync();
    }

    public ValueTask DisposeAsync()
    {
        return _inner.DisposeAsync();
    }
}
