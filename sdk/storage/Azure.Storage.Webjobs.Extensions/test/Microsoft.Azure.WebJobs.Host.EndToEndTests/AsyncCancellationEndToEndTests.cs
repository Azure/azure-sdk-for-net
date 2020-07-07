// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.EndToEndTests
{
    public class AsyncCancellationEndToEndTests : IDisposable
    {
        private const string TestArtifactPrefix = "asynccancele2e";
        private const string QueueName = TestArtifactPrefix + "%rnd%";
        private const int DefaultTimeout = 5 * 1000;

        private static Action _invokeInFunction;
        private static bool _invokeInFunctionInvoked;
        private static EventWaitHandle _functionStarted;
        private static EventWaitHandle _functionCompleted;
        private static bool _tokenCancelled;

        private readonly CloudStorageAccount _storageAccount;
        private readonly RandomNameResolver _resolver;
        private readonly IHost _host;

        public AsyncCancellationEndToEndTests()
        {
            _resolver = new RandomNameResolver();

            _host = new HostBuilder()
                .ConfigureDefaultTestHost<AsyncCancellationEndToEndTests>(b =>
                {
                    b.AddAzureStorage();
                })
                .ConfigureServices(services =>
                {
                    services.AddSingleton<INameResolver, RandomNameResolver>();
                })
                .Build();

            var accountProvider = _host.Services.GetService<StorageAccountProvider>();
            _storageAccount = accountProvider.GetHost().SdkObject;

            _invokeInFunction = () => { };
            _tokenCancelled = false;
            _functionStarted = new ManualResetEvent(initialState: false);
            _functionCompleted = new ManualResetEvent(initialState: false);
        }

        public void Dispose()
        {
            _functionStarted.Dispose();
            _functionCompleted.Dispose();

            if (_storageAccount != null)
            {
                CloudQueueClient queueClient = _storageAccount.CreateCloudQueueClient();
                foreach (var testQueue in queueClient.ListQueuesSegmentedAsync(TestArtifactPrefix, null).Result.Results)
                {
                    testQueue.DeleteAsync().Wait();
                }
            }
        }

        [NoAutomaticTrigger]
        public static void InfiniteRunningFunctionUnlessCancelledManual(
            CancellationToken token)
        {
            FunctionBody(token);
        }

        [NoAutomaticTrigger]
        public static void WriteQueueMessage(
            [Queue(QueueName)] out string message)
        {
            message = "test";
        }

        public static void InfiniteRunningFunctionUnlessCancelledTriggered(
            [QueueTrigger(QueueName)] string message,
            CancellationToken token)
        {
            FunctionBody(token);
        }

        private static void FunctionBody(CancellationToken token)
        {
            try
            {
                // If the token is cancelled here, something is not right
                if (!token.IsCancellationRequested)
                {
                    _functionStarted.Set();

                    _invokeInFunction();
                    _invokeInFunctionInvoked = true;

                    if (token.WaitHandle.WaitOne(DefaultTimeout))
                    {
                        _tokenCancelled = token.IsCancellationRequested;

                        // The function must throw in order for the calling 
                        // Task to be canceled, which the tests expect.
                        token.ThrowIfCancellationRequested();
                    }
                }
            }
            finally
            {
                _functionCompleted.Set();
            }
        }

        [Fact]
        public void WebJobsShutdown_WhenUsingHostCall_TriggersCancellationToken()
        {
            // Run test in multithreaded environment
            var oldContext = SynchronizationContext.Current;
            try
            {
                SynchronizationContext.SetSynchronizationContext(null);
                using (WebJobsShutdownContext shutdownContext = new WebJobsShutdownContext())
                using (_host)
                {
                    _invokeInFunction = () => { shutdownContext.NotifyShutdown(); };

                    Task callTask = InvokeNoAutomaticTriggerFunction(_host.GetJobHost());

                    EvaluateNoAutomaticTriggerCancellation(callTask, expectedCancellation: true);
                }
            }
            finally
            {
                SynchronizationContext.SetSynchronizationContext(oldContext);
            }
        }

        [Fact]
        public async Task WebJobsShutdown_WhenUsingTriggeredFunction_TriggersCancellationToken()
        {
            using (WebJobsShutdownContext shutdownContext = new WebJobsShutdownContext())
            using (_host)
            {
                JobHost jobHost = _host.GetJobHost();
                _invokeInFunction = () => { shutdownContext.NotifyShutdown(); };

                await PrepareHostForTriggerAsync(jobHost, startHost: true);

                EvaluateTriggeredCancellation(expectedCancellation: true);
            }
        }

        [Fact]
        public async Task Stop_WhenUsingHostCall_DoesNotTriggerCancellationToken()
        {
            // Run test in multithreaded environment
            var oldContext = SynchronizationContext.Current;
            try
            {
                SynchronizationContext.SetSynchronizationContext(null);
                using (_host)
                {
                    _host.Start();

                    Task callTask = InvokeNoAutomaticTriggerFunction(_host.GetJobHost());

                    await _host.StopAsync();

                    EvaluateNoAutomaticTriggerCancellation(callTask, expectedCancellation: false);
                }
            }
            finally
            {
                SynchronizationContext.SetSynchronizationContext(oldContext);
            }
        }

        [Fact]
        public async Task StopAsync_WhenUsingTriggeredFunction_TriggersCancellationToken()
        {
            // Note: Calling IHost.StopAsync() does not stop registered IHostedServices. The host must
            //       be disposed in order to stop those.
            using (_host)
            {
                JobHost jobHost = _host.GetJobHost();
                await PrepareHostForTriggerAsync(jobHost, startHost: true);
                await jobHost.StopAsync();

                EvaluateTriggeredCancellation(expectedCancellation: true);
            }
        }

        // $$$ This should be a JobHost.Unit test. It doesn't actually need any external bindings. 
        [Fact]
        public void Dispose_WhenUsingHostCall_TriggersCancellationToken()
        {
            Task callTask;
            // Run test in multithreaded environment
            var oldContext = SynchronizationContext.Current;
            try
            {
                SynchronizationContext.SetSynchronizationContext(null);
                using (_host)
                {
                    // The function invocation gets an operation cancelled exception, which should cause this task to be marked as cancelled. 
                    callTask = InvokeNoAutomaticTriggerFunction(_host.GetJobHost());
                } // calls host.Dispose() while a function instance is still running 

                EvaluateNoAutomaticTriggerCancellation(callTask, expectedCancellation: true);
            }
            finally
            {
                SynchronizationContext.SetSynchronizationContext(oldContext);
            }
        }

        [Fact]
        public async Task Dispose_WhenUsingTriggeredFunction_TriggersCancellationToken()
        {
            using (_host)
            {
                JobHost jobHost = _host.GetJobHost();
                await PrepareHostForTriggerAsync(jobHost, startHost: true);
            }

            EvaluateTriggeredCancellation(expectedCancellation: true);
        }

        [Fact]
        public void CallCancellationToken_WhenUsingHostCall_TriggersCancellationToken()
        {
            // Run test in multithreaded environment
            var oldContext = SynchronizationContext.Current;
            try
            {
                SynchronizationContext.SetSynchronizationContext(null);
                using (CancellationTokenSource tokenSource = new CancellationTokenSource())
                using (_host)
                {
                    JobHost jobHost = _host.GetJobHost();
                    _invokeInFunction = () => { tokenSource.Cancel(); };

                    Task callTask = InvokeNoAutomaticTriggerFunction(jobHost, tokenSource.Token);

                    EvaluateNoAutomaticTriggerCancellation(callTask, expectedCancellation: true);
                }
            }
            finally
            {
                SynchronizationContext.SetSynchronizationContext(oldContext);
            }
        }

        [Fact]
        public async Task CallCancellationToken_WhenUsingTriggeredFunction_DoesNotTriggerCancellationToken()
        {
            // Run test in multithreaded environment
            var oldContext = SynchronizationContext.Current;
            try
            {
                SynchronizationContext.SetSynchronizationContext(null);

                using (CancellationTokenSource tokenSource = new CancellationTokenSource())
                using (_host)
                {
                    _invokeInFunction = () => { tokenSource.Cancel(); };

                await PrepareHostForTriggerAsync(_host.GetJobHost(), startHost: false);
                Assert.True(_host.StartAsync(tokenSource.Token).WaitUntilCompleted(DefaultTimeout));

                    EvaluateTriggeredCancellation(expectedCancellation: false);
                }
            }
            finally
            {
                SynchronizationContext.SetSynchronizationContext(oldContext);
            }
        }

        private async Task PrepareHostForTriggerAsync(JobHost host, bool startHost)
        {
            await host.CallAsync(typeof(AsyncCancellationEndToEndTests).GetMethod(nameof(WriteQueueMessage)));

            if (startHost)
            {
                await host.StartAsync();
                Assert.True(_functionStarted.WaitOne(DefaultTimeout));
            }
        }

        private Task InvokeNoAutomaticTriggerFunction(JobHost host)
        {
            return InvokeNoAutomaticTriggerFunction(host, CancellationToken.None);
        }

        private Task InvokeNoAutomaticTriggerFunction(JobHost host, CancellationToken token)
        {
            Task callTask = host.CallAsync(
                typeof(AsyncCancellationEndToEndTests).GetMethod(nameof(InfiniteRunningFunctionUnlessCancelledManual)),
                token);
            Assert.True(_functionStarted.WaitOne(DefaultTimeout));

            return callTask;
        }

        private void EvaluateTriggeredCancellation(bool expectedCancellation)
        {
            // Wait for the function to complete
            Assert.True(_functionCompleted.WaitOne(2 * DefaultTimeout));
            Assert.Equal(expectedCancellation, _tokenCancelled);
            Assert.True(_invokeInFunctionInvoked);
        }

        private void EvaluateNoAutomaticTriggerCancellation(Task task, bool expectedCancellation)
        {
            bool taskCompleted = task.WaitUntilCompleted(2 * DefaultTimeout);
            bool taskCompletedBeforeFunction = !_functionCompleted.WaitOne(0);

            Assert.True(taskCompleted);
            Assert.False(taskCompletedBeforeFunction);

            // task.IsCancelled explicitly expects a cancellation, 
            // task.IsFaulted allows any other exception (such as a Object Disposed).
            Assert.Equal(expectedCancellation, task.IsCanceled || task.IsFaulted);
            Assert.Equal(expectedCancellation, _tokenCancelled);
            Assert.True(_invokeInFunctionInvoked);
        }
    }
}
