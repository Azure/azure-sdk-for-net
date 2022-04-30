// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Identity.Tests.Mock
{
    public class MockTokenCache : UnsafeTokenCacheOptions
    {
        private readonly Func<Task<ReadOnlyMemory<byte>>> _refreshCacheDelegate;
        private readonly Func<TokenCacheUpdatedArgs, Task> _cacheUpdatedDelegate;

        public MockTokenCache(Func<Task<ReadOnlyMemory<byte>>> refreshDelegate = default, Func<TokenCacheUpdatedArgs, Task> updatedDelegate = default)
        {
            _refreshCacheDelegate = refreshDelegate;

            _cacheUpdatedDelegate = updatedDelegate;
        }

        protected internal override Task<ReadOnlyMemory<byte>> RefreshCacheAsync()
        {
            return (_refreshCacheDelegate != null) ? _refreshCacheDelegate() : null;
        }

        protected internal override async Task TokenCacheUpdatedAsync(TokenCacheUpdatedArgs tokenCacheUpdatedArgs)
        {
            if (_cacheUpdatedDelegate != null)
            {
                await _cacheUpdatedDelegate(tokenCacheUpdatedArgs).ConfigureAwait(false);
            }
        }
    }
}
