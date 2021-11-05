// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace BatchClientIntegrationTests.IntegrationTestUtilities
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
#if FullNetFx
    using System.Windows.Threading;
#endif
    using Xunit;

    public static class SynchronizationContextHelper
    {
        private static void SetSynchronizationContext()
        {
            //Note that XUnit sets the sync context and we want to make sure not to pollute that - this means that
            //we cannot use the Assert.<> functions which take a lamdba and do an await inside XUnit code because it 
            //will cause a deadlock...
#if FullNetFx
            DispatcherSynchronizationContext synchronizationContext = new DispatcherSynchronizationContext();
#else
            SynchronizationContext synchronizationContext = new SynchronizationContext();
#endif
            SynchronizationContext.SetSynchronizationContext(synchronizationContext);
        }

        public static void RunTest(Action test, TimeSpan timeout)
        {
            //Since the user did not give us an async test, we must fabricate one
            Task t = Task.Factory.StartNew(test);

            RunTestAsync(() => t, timeout).Wait();
        }

        public async static Task RunTestAsync(Func<Task> test, TimeSpan timeout)
        {
            SetSynchronizationContext();

            TaskCompletionSource<bool> timeoutTaskSource = new TaskCompletionSource<bool>();
            using CancellationTokenSource tokenSource = new CancellationTokenSource(timeout);
            //In the case the a debugger is attached, we do not want to enforce timeout because a breakpoint may
            //cause a test which is supposed to run for 1 second to in fact run for 1 minute, and we want to
            //allow that.
            if (!Debugger.IsAttached)
            {
                tokenSource.Token.Register(() =>
                    {
                        timeoutTaskSource.SetResult(false);
                    });
            }

            Task testTask = test(); //Start running the actual test

            await Task.WhenAny(testTask, timeoutTaskSource.Task).ConfigureAwait(false);

            if (testTask.IsCompleted)
            {
                await testTask.ConfigureAwait(false); //Propagate exceptions
            }
            else
            {
                //Force an assertion failure to fail the test with a timeout
                Assert.False(true, string.Format("SynchronizationContextHelper has terminated this test due to extreme tardiness. Test timed out after {0}", timeout));
            }
        }
    }
}
