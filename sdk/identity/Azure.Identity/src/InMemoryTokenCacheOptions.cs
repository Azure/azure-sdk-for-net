// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Identity
{
    internal class InMemoryTokenCacheOptions : UnsafeTokenCacheOptions
    {
        public override Task<ReadOnlyMemory<byte>> RefreshCacheAsync()
        {
            return Task.FromResult(new ReadOnlyMemory<byte>());
        }

        public override Task TokenCacheUpdatedAsync(TokenCacheUpdatedArgs tokenCacheUpdatedArgs)
        {
            return Task.CompletedTask;
        }
    }
}
