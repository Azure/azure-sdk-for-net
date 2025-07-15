// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// TODO.
/// </summary>
/// <typeparam name="T"></typeparam>
public class AsyncCollectionResultInterceptor<T> : IAsyncEnumerator<T>
        where T : class
{
    private ClientTestBase _testBase;
    private IAsyncEnumerator<T> _inner;

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="testBase"></param>
    /// <param name="inner"></param>
    public AsyncCollectionResultInterceptor(ClientTestBase testBase, IAsyncEnumerator<T> inner)
    {
        _testBase = testBase;
        _inner = inner;
    }

    /// <summary>
    /// TODO.
    /// </summary>
    public T Current => _testBase.InstrumentClient(_inner.Current.GetType(), _inner.Current, []) as T ?? throw new InvalidOperationException();

    /// <summary>
    /// TODO.
    /// </summary>
    /// <returns></returns>
    public ValueTask<bool> MoveNextAsync()
    {
        return _inner.MoveNextAsync();
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <returns></returns>
    public ValueTask DisposeAsync()
    {
        return _inner.DisposeAsync();
    }
}
