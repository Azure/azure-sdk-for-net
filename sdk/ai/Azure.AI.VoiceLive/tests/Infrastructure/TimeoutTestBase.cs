// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests.Infrastructure
{
    public abstract class TimeOutTestBase<TEnv> : RecordedTestBase<TEnv> where TEnv : TestEnvironment, new()
    {
        private static readonly TimeSpan _actionTimeout = Debugger.IsAttached ? TimeSpan.FromMinutes(15) : TimeSpan.FromSeconds(15);
        private static readonly TimeSpan _testTimeout = Debugger.IsAttached ? TimeSpan.FromMinutes(60) : TimeSpan.FromSeconds(60);

        private CancellationToken _timeoutToken = new CancellationTokenSource(_testTimeout).Token;

        protected TimeOutTestBase(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
        }

        protected async Task TimeoutTestAction(Task action, string message = "")
        {
            var t = await Task.WhenAny(action, Task.Delay(_actionTimeout, _timeoutToken)).ConfigureAwait(false);
            Assert.AreEqual(action, t, message);
        }

        protected Task TimeoutTestAction<T>(TaskCompletionSource<T> action, string message = "") =>
            TimeoutTestAction(action.Task, message);

        protected static TimeSpan ActionTimeout { get => _actionTimeout; }
        protected static TimeSpan TestTimeout { get => _testTimeout; }
        protected CancellationToken TimeoutToken { get => _timeoutToken; }
    }
}
