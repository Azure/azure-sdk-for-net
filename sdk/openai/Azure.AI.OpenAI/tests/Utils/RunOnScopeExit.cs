// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Threading.Tasks;

namespace Azure.AI.OpenAI.Tests.Utils
{
    public class RunOnScopeExit : IAsyncDisposable
    {
        private Func<Task> _asyncFunc;

        public RunOnScopeExit(Func<Task> asyncFunc)
        {
            _asyncFunc = asyncFunc ?? throw new ArgumentNullException(nameof(asyncFunc));
        }

        public async ValueTask DisposeAsync()
        {
            await _asyncFunc().ConfigureAwait(false);
        }
    }
}
