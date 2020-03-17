// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class ProcessRunnerTests
    {
        public ProcessRunnerTests(bool isAsync)
        {
            IsAsync = isAsync;
        }

        public bool IsAsync { get; }

        [Test]
        public async Task ProcessRunnerSucceeded()
        {
            var output = "Test output";
            var process = new TestProcess { Output = output };
            var runner = new ProcessRunner(process, TimeSpan.FromSeconds(30), default);
            var result = await Run(runner);

            Assert.AreEqual(output, result);
        }

        [Test]
        public void ProcessRunnerCanceledByTimeout()
        {
            var cts = new CancellationTokenSource();
            var process = new TestProcess { Output =  "Test output", Timeout = 5000 };
            var runner = new ProcessRunner(process, TimeSpan.FromMilliseconds(100), cts.Token);

            var exception = Assert.CatchAsync<OperationCanceledException>(async () => await Run(runner));
            Assert.AreNotEqual(cts.Token, exception.CancellationToken);
        }

        [Test]
        public void ProcessRunnerCanceledByCancellationToken()
        {
            var cts = new CancellationTokenSource();
            var process = new TestProcess { Output =  "Test output", Timeout = 5000 };
            var runner = new ProcessRunner(process, TimeSpan.FromMilliseconds(5000), cts.Token);
            cts.CancelAfter(100);

            var exception = Assert.CatchAsync<OperationCanceledException>(async () => await Run(runner));
            Assert.AreEqual(cts.Token, exception.CancellationToken);
        }

        [Test]
        public void ProcessRunnerCreatedOnCanceled()
        {
            var process = new TestProcess { Output =  "Test output", Timeout = 5000 };
            var cancellationToken = new CancellationToken(true);
            var runner = new ProcessRunner(process, TimeSpan.FromMilliseconds(5000), cancellationToken);

            var exception = Assert.CatchAsync<OperationCanceledException>(async () => await Run(runner));
            Assert.AreEqual(cancellationToken, exception.CancellationToken);
        }

        [Test]
        public void ProcessRunnerCanceledBeforeRun()
        {
            var cts = new CancellationTokenSource();
            var process = new TestProcess { Output =  "Test output", Timeout = 5000 };
            var runner = new ProcessRunner(process, TimeSpan.FromMilliseconds(5000), cts.Token);

            cts.Cancel();

            var exception = Assert.CatchAsync<OperationCanceledException>(async () => await Run(runner));
            Assert.AreEqual(cts.Token, exception.CancellationToken);
        }

        [Test]
        public async Task ProcessRunnerCanceledFinished()
        {
            var cts = new CancellationTokenSource();
            var process = new TestProcess { Output =  "Test output" };
            var runner = new ProcessRunner(process, TimeSpan.FromSeconds(5000), cts.Token);
            await Run(runner);
            cts.Cancel();
        }

        [Test]
        public void ProcessRunnerFailedWithErrorMessage()
        {
            var error = "Test error";
            var process = new TestProcess { Error = error };
            var runner = new ProcessRunner(process, TimeSpan.FromSeconds(30), default);

            var exception = Assert.CatchAsync<InvalidOperationException>(async () => await Run(runner));
            Assert.AreEqual(error, exception.Message);
        }

        [Test]
        public void ProcessRunnerFailedOnKillProcess()
        {
            var output = "Test output";
            var process = new TestProcess { Output = output, ExceptionOnProcessKill = new Win32Exception(1), Timeout = 5000 };
            var runner = new ProcessRunner(process, TimeSpan.FromMilliseconds(50), default);

            var exception = Assert.CatchAsync<Win32Exception>(async () => await Run(runner));
            Assert.AreEqual(1, exception.NativeErrorCode);
        }

        private async Task<string> Run(ProcessRunner runner) => IsAsync ? await runner.RunAsync() : runner.Run();
    }
}
