// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Azure.Core.TestFramework
{
    public class AsyncPageableInterceptor<T> : IAsyncEnumerator<T>
        where T : class
    {
        private ClientTestBase _testBase;
        private IAsyncEnumerator<T> _inner;

        public AsyncPageableInterceptor(ClientTestBase testBase, IAsyncEnumerator<T> inner)
        {
            _testBase = testBase;
            _inner = inner;
        }

        public T Current => _testBase.InstrumentClient(_inner.Current.GetType(), _inner.Current, new IInterceptor[] { new ManagementInterceptor(_testBase) }) as T;

        public ValueTask<bool> MoveNextAsync()
        {
            return _inner.MoveNextAsync();
        }

        public ValueTask DisposeAsync()
        {
            return _inner.DisposeAsync();
        }
    }
}
