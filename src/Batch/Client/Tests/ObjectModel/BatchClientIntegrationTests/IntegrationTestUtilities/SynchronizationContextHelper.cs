// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿namespace BatchClientIntegrationTests.IntegrationTestUtilities
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Threading;
    using Xunit;

    public static class SynchronizationContextHelper
    {
        private static void SetSynchronizationContext()
        {
            //Note that XUnit sets the sync context and we want to make sure not to pollute that - this means that
            //we cannot use the Assert.<> functions which take a lamdba and do an await inside XUnit code because it 
            //will cause a deadlock...
            DispatcherSynchronizationContext synchronizationContext = new DispatcherSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(synchronizationContext);
        }

        public static void RunTest(Action test, TimeSpan timeout)
        {
            //Since the user did not give us an async test, we must fabricate one
            Task t = Task.Factory.StartNew(test);

            SynchronizationContextHelper.RunTestAsync(() => t, timeout).Wait();
        }

        public async static Task RunTestAsync(Func<Task> test, TimeSpan timeout)
        {
            SetSynchronizationContext();

            TaskCompletionSource<bool> timeoutTaskSource = new TaskCompletionSource<bool>();
            using (CancellationTokenSource tokenSource = new CancellationTokenSource(timeout))
            {
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
}
