// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;

namespace Azure.AI.OpenAI.Tests.Utils
{
    public class RunOnScopeExit : IDisposable
    {
        private Action _action;

        public RunOnScopeExit(Action action)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public void Dispose()
        {
            _action();
        }
    }
}
