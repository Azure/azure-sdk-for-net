// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class SyncAsyncEventHandlerTests : ClientTestBase
    {
        public SyncAsyncEventHandlerTests(bool isAsync) : base(isAsync) { }

        #region Helpers
        private TestClient GetClient(TimeSpan? workDelay = null) =>
            InstrumentClient<TestClient>(new TestClient(workDelay));

        private ClientDiagnostics GetEmptyDiagnostics() => new ClientDiagnostics(new TestClientOptions());

        public class TestClientOptions : ClientOptions { }

        public class TestSyncAsyncEventArgs : SyncAsyncEventArgs
        {
            public TestClient Client { get; }
            public int Result { get; }
            public TestSyncAsyncEventArgs(TestClient client, int result, bool isRunningSynchronously, CancellationToken cancellationToken = default)
                : base(isRunningSynchronously, cancellationToken)
            {
                Client = client;
                Result = result;
            }
        }

        public class TestClient
        {
            internal virtual ClientDiagnostics ClientDiagnostics { get; } = new ClientDiagnostics(new TestClientOptions());
            public TimeSpan? WorkDelay { get; }
            public TestClient() : this(null) { }
            public TestClient(TimeSpan? workDelay = null) => WorkDelay = workDelay;

            public virtual event SyncAsyncEventHandler<SyncAsyncEventArgs> Working;
            public virtual event SyncAsyncEventHandler<TestSyncAsyncEventArgs> WorkCompleted;

            protected virtual async Task OnWorkingAsync(bool isRunningSynchronously, CancellationToken cancellationToken) =>
                await Working.RaiseAsync(
                    new SyncAsyncEventArgs(isRunningSynchronously, cancellationToken),
                    nameof(TestClient),
                    nameof(Working),
                    ClientDiagnostics)
                    .ConfigureAwait(false);

            protected virtual async Task OnWorkCompletedAsync(int result, bool isRunningSynchronously, CancellationToken cancellationToken) =>
                await WorkCompleted.RaiseAsync(
                    new TestSyncAsyncEventArgs(this, result, isRunningSynchronously, cancellationToken),
                    nameof(TestClient),
                    nameof(Working),
                    ClientDiagnostics)
                    .ConfigureAwait(false);

            public virtual int DoWork(CancellationToken cancellationToken = default) =>
                DoWorkInternal(async: false, cancellationToken).EnsureCompleted();
            public virtual async Task<int> DoWorkAsync(CancellationToken cancellationToken = default) =>
                await DoWorkInternal(async: true, cancellationToken).ConfigureAwait(false);

            private async Task<int> DoWorkInternal(bool async, CancellationToken cancellationToken)
            {
                using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(TestClient)}.{nameof(DoWork)}");
                try
                {
                    scope.Start();
                    await OnWorkingAsync(!async, cancellationToken).ConfigureAwait(false);
                    int result = 42;
                    if (WorkDelay != null)
                    {
                        if (async)
                        {
                            await Task.Delay(WorkDelay.Value, cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            cancellationToken.WaitHandle.WaitOne(WorkDelay.Value);
                        }
                    }
                    await OnWorkCompletedAsync(result, !async, cancellationToken).ConfigureAwait(false);
                    return result;
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }
        }

        private class TestHandler<T> where T : SyncAsyncEventArgs
        {
            public TimeSpan? Delay { get; set; }
            public Func<bool, CancellationToken, Task> Callback { get; set; }
            public string Throws { get; set; }

            public T LastEventArgs { get; private set; }
            public bool Raised => RaisedCount > 0;
            public int RaisedCount { get; private set; } = 0;
            public bool Completed => CompletedCount > 0;
            public int CompletedCount { get; private set; } = 0;

            public async Task Handle(T e)
            {
                // This is expensive enough we're not doing it in RaiseAsync
                // between handlers, but customers could/should do it themselves
                // by passing the CancellationToken to any APIs that take it.
                e.CancellationToken.ThrowIfCancellationRequested();

                LastEventArgs = e;
                RaisedCount++;

                if (Delay != null)
                {
                    if (e.IsRunningSynchronously)
                    {
                        e.CancellationToken.WaitHandle.WaitOne(Delay.Value);
                    }
                    else
                    {
                        await Task.Delay(Delay.Value, e.CancellationToken);
                    }
                }

                Func<bool, CancellationToken, Task> callback = Callback;
                if (callback != null)
                {
                    await callback(e.IsRunningSynchronously, e.CancellationToken);
                }

                if (Throws != null)
                {
                    throw new InvalidOperationException(Throws);
                }

                e.CancellationToken.ThrowIfCancellationRequested();
                CompletedCount++;
            }
        }
        #endregion

        #region Basic Mechanics
        [Test]
        public void AddHandler()
        {
            TestClient client = GetClient();
            var test = new TestHandler<SyncAsyncEventArgs>();
            client.Working += test.Handle;
        }

        [Test]
        public void AddHandler_Null()
        {
            TestClient client = GetClient();
            client.Working += null;
        }

        [Test]
        public void AddHandler_Multiple()
        {
            TestClient client = GetClient();
            client.Working += new TestHandler<SyncAsyncEventArgs>().Handle;
            client.Working += new TestHandler<SyncAsyncEventArgs>().Handle;
            client.Working += new TestHandler<SyncAsyncEventArgs>().Handle;
            client.Working += new TestHandler<SyncAsyncEventArgs>().Handle;
        }

        [Test]
        public void RemoveHandler()
        {
            TestClient client = GetClient();
            var test = new TestHandler<SyncAsyncEventArgs>();
            client.Working += test.Handle;
            client.Working -= test.Handle;
        }

        [Test]
        public void RemoveHandler_Null()
        {
            TestClient client = GetClient();
            client.Working -= null;
        }

        [Test]
        public void RemoveHandler_NotAdded()
        {
            TestClient client = GetClient();
            var test = new TestHandler<SyncAsyncEventArgs>();
            client.Working -= test.Handle;
        }

        [Test]
        public async Task Raise()
        {
            var test = new TestHandler<SyncAsyncEventArgs>();

            TestClient client = GetClient();
            client.Working += test.Handle;
            await client.DoWorkAsync();

            Assert.IsTrue(test.Raised);
            Assert.IsTrue(test.Completed);
        }

        [Test]
        public async Task Raise_None()
        {
            TestClient client = GetClient();
            await client.DoWorkAsync();
        }

        [Test]
        public async Task Raise_Null()
        {
            TestClient client = GetClient();
            client.Working += null;
            await client.DoWorkAsync();
        }

        [Test]
        public async Task RemoveHandler_NotRaised()
        {
            var test = new TestHandler<SyncAsyncEventArgs>();

            TestClient client = GetClient();
            client.Working += test.Handle;
            client.Working -= test.Handle;
            await client.DoWorkAsync();

            Assert.IsFalse(test.Raised);
        }

        [Test]
        public async Task AddHandler_Duplicate()
        {
            var test = new TestHandler<SyncAsyncEventArgs>() { Delay = TimeSpan.FromMilliseconds(100) };

            TestClient client = GetClient();
            client.Working += test.Handle;
            client.Working += test.Handle;
            await client.DoWorkAsync();

            Assert.AreEqual(2, test.RaisedCount);
        }

        [Test]
        public async Task RemoveHandler_Duplicate()
        {
            var test = new TestHandler<SyncAsyncEventArgs>() { Delay = TimeSpan.FromMilliseconds(100) };

            TestClient client = GetClient();
            client.Working += test.Handle;
            client.Working += test.Handle;
            client.Working -= test.Handle;
            await client.DoWorkAsync();

            Assert.AreEqual(1, test.RaisedCount);
        }

        [Test]
        public async Task RemoveHandler_OthersUnaffected()
        {
            var first = new TestHandler<SyncAsyncEventArgs>();
            var second = new TestHandler<SyncAsyncEventArgs>();
            var third = new TestHandler<SyncAsyncEventArgs>();

            TestClient client = GetClient();
            client.Working += first.Handle;
            client.Working += second.Handle;
            client.Working += third.Handle;

            client.Working -= second.Handle;

            await client.DoWorkAsync();

            Assert.IsTrue(first.Completed);
            Assert.IsTrue(third.Completed);

            Assert.IsFalse(second.Raised);
        }

        [Test]
        public async Task Raise_DistributedTracing_SuppressesNestedSpan()
        {
            using ClientDiagnosticListener diagnosticListener =
                new ClientDiagnosticListener(
                    s => s.StartsWith("Azure."),
                    asyncLocal: true);
            TestClient client = GetClient();
            client.Working +=
                (SyncAsyncEventArgs e) =>
                {
                    ClientDiagnosticListener.ProducedDiagnosticScope scope =
                        diagnosticListener.Scopes.FirstOrDefault(
                            s => s.Name == $"{nameof(TestClient)}.{nameof(TestClient.Working)}");

                    Assert.AreEqual($"{nameof(TestClient)}.{nameof(TestClient.DoWork)}", Activity.Current.OperationName);
                    Assert.IsNull(scope);
                    return Task.CompletedTask;
                };
            await client.DoWorkAsync();
        }
        #endregion

        #region Control Flow
        [Test]
        public async Task Raise_Waits()
        {
            var test = new TestHandler<SyncAsyncEventArgs>() { Delay = TimeSpan.FromMilliseconds(100) };

            TestClient client = GetClient();
            client.Working += test.Handle;
            await client.DoWorkAsync();

            Assert.IsTrue(test.Raised);
            Assert.IsTrue(test.Completed);
        }

        [Test]
        public async Task Raise_All()
        {
            var first = new TestHandler<SyncAsyncEventArgs>();
            var second = new TestHandler<SyncAsyncEventArgs>();
            var third = new TestHandler<SyncAsyncEventArgs>();

            TestClient client = GetClient();
            client.Working += first.Handle;
            client.Working += second.Handle;
            client.Working += third.Handle;
            await client.DoWorkAsync();

            Assert.IsTrue(first.Completed);
            Assert.IsTrue(second.Completed);
            Assert.IsTrue(third.Completed);
        }

        [Test]
        public async Task Raise_Slowest_First()
        {
            var first = new TestHandler<SyncAsyncEventArgs>() { Delay = TimeSpan.FromMilliseconds(100) };
            var second = new TestHandler<SyncAsyncEventArgs>();
            var third = new TestHandler<SyncAsyncEventArgs>();

            TestClient client = GetClient();
            client.Working += first.Handle;
            client.Working += second.Handle;
            client.Working += third.Handle;
            await client.DoWorkAsync();

            Assert.IsTrue(first.Completed);
            Assert.IsTrue(second.Completed);
            Assert.IsTrue(third.Completed);
        }

        [Test]
        public async Task Raise_Slowest_Middle()
        {
            var first = new TestHandler<SyncAsyncEventArgs>();
            var second = new TestHandler<SyncAsyncEventArgs>() { Delay = TimeSpan.FromMilliseconds(100) };
            var third = new TestHandler<SyncAsyncEventArgs>();

            TestClient client = GetClient();
            client.Working += first.Handle;
            client.Working += second.Handle;
            client.Working += third.Handle;
            await client.DoWorkAsync();

            Assert.IsTrue(first.Completed);
            Assert.IsTrue(second.Completed);
            Assert.IsTrue(third.Completed);
        }

        [Test]
        public async Task Raise_Slowest_Last()
        {
            var first = new TestHandler<SyncAsyncEventArgs>();
            var second = new TestHandler<SyncAsyncEventArgs>();
            var third = new TestHandler<SyncAsyncEventArgs>() { Delay = TimeSpan.FromMilliseconds(100) };

            TestClient client = GetClient();
            client.Working += first.Handle;
            client.Working += second.Handle;
            client.Working += third.Handle;
            await client.DoWorkAsync();

            Assert.IsTrue(first.Completed);
            Assert.IsTrue(second.Completed);
            Assert.IsTrue(third.Completed);
        }

        [Test]
        public async Task ThreadSafe_NewNotRaised()
        {
            var first = new TestHandler<SyncAsyncEventArgs>() { Delay = TimeSpan.FromMilliseconds(100) };
            var second = new TestHandler<SyncAsyncEventArgs>() { Delay = TimeSpan.FromMilliseconds(100) };
            var third = new TestHandler<SyncAsyncEventArgs>() { Delay = TimeSpan.FromMilliseconds(100) };
            var fourth = new TestHandler<SyncAsyncEventArgs>();

            TestClient client = GetClient();
            client.Working += first.Handle;
            client.Working += second.Handle;
            client.Working += third.Handle;

            first.Callback = (_, _) => { client.Working += fourth.Handle; return Task.CompletedTask; };
            await client.DoWorkAsync();

            Assert.IsTrue(first.Completed);
            Assert.IsTrue(second.Completed);
            Assert.IsTrue(third.Completed);
            Assert.IsFalse(fourth.Raised);
        }

        [Test]
        public async Task ThreadSafe_OldStillRaised()
        {
            var first = new TestHandler<SyncAsyncEventArgs>() { Delay = TimeSpan.FromMilliseconds(100) };
            var second = new TestHandler<SyncAsyncEventArgs>() { Delay = TimeSpan.FromMilliseconds(100) };
            var third = new TestHandler<SyncAsyncEventArgs>() { Delay = TimeSpan.FromMilliseconds(100) };

            TestClient client = GetClient();
            client.Working += first.Handle;
            client.Working += second.Handle;
            client.Working += third.Handle;

            first.Callback = (_, _) => { client.Working -= first.Handle; return Task.CompletedTask; };
            await client.DoWorkAsync();

            Assert.IsTrue(first.Completed);
            Assert.IsTrue(second.Completed);
            Assert.IsTrue(third.Completed);

            await client.DoWorkAsync();
            Assert.AreEqual(1, first.CompletedCount);
            Assert.AreEqual(2, second.CompletedCount);
            Assert.AreEqual(2, third.CompletedCount);
        }

        [Test]
        public async Task SequentialProcessing()
        {
            TestClient client = GetClient();
            StringBuilder text = new StringBuilder();
            Func<string, string, SyncAsyncEventHandler<SyncAsyncEventArgs>> makeHandler =
                (string before, string after) =>
                    async (SyncAsyncEventArgs e) =>
                    {
                        text.Append(before);
                        TimeSpan delay = TimeSpan.FromMilliseconds(50);
                        if (e.IsRunningSynchronously)
                        {
                            e.CancellationToken.WaitHandle.WaitOne(delay);
                        }
                        else
                        {
                            await Task.Delay(delay, e.CancellationToken);
                        }
                        text.Append(after);
                    };
            client.Working += makeHandler("a", "b");
            client.Working += makeHandler("1", "2");
            client.Working += makeHandler("<", ">");
            await client.DoWorkAsync();
            Assert.AreEqual("ab12<>", text.ToString());
        }
        #endregion

        #region EventArgs
        [Test]
        public async Task Raise_EventArgs()
        {
            var test = new TestHandler<SyncAsyncEventArgs>();
            SyncAsyncEventArgs args = new SyncAsyncEventArgs(false);

            TestClient client = GetClient();
            client.Working += test.Handle;
            await client.DoWorkAsync();

            Assert.IsNotNull(test.LastEventArgs);
        }

        [Test]
        public async Task Raise_EventArgs_All()
        {
            var first = new TestHandler<SyncAsyncEventArgs>();
            var second = new TestHandler<SyncAsyncEventArgs>();
            var third = new TestHandler<SyncAsyncEventArgs>();
            SyncAsyncEventArgs args = new SyncAsyncEventArgs(false);

            TestClient client = GetClient();
            client.Working += first.Handle;
            client.Working += second.Handle;
            client.Working += third.Handle;
            await client.DoWorkAsync();

            Assert.AreSame(first.LastEventArgs, second.LastEventArgs);
            Assert.AreSame(first.LastEventArgs, third.LastEventArgs);
        }

        [Test]
        public async Task Raise_EventArgs_Custom()
        {
            var before = new TestHandler<SyncAsyncEventArgs>();
            var after = new TestHandler<TestSyncAsyncEventArgs>();
            TestClient original = new TestClient();
            TestClient client = InstrumentClient<TestClient>(original);
            client.Working += before.Handle;
            client.WorkCompleted += after.Handle;
            int result = await client.DoWorkAsync();
            Assert.True(before.Completed);
            Assert.True(after.Completed);
            Assert.AreSame(original, after.LastEventArgs.Client);
            Assert.AreEqual(result, after.LastEventArgs.Result);
        }
        #endregion

        #region Cancellation
        [Test]
        public async Task Cancels_AlreadyFinished()
        {
            var test = new TestHandler<SyncAsyncEventArgs>();
            CancellationTokenSource cancellation = new CancellationTokenSource();

            TestClient client = GetClient();
            client.Working += test.Handle;
            await client.DoWorkAsync(cancellation.Token);
            cancellation.Cancel();

            Assert.IsTrue(test.Raised);
            Assert.IsTrue(test.Completed);
        }

        [Test]
        public async Task Cancels_StillRunning()
        {
            var test = new TestHandler<SyncAsyncEventArgs>() { Delay = TimeSpan.FromMilliseconds(500) };
            CancellationTokenSource cancellation = new CancellationTokenSource();

            TestClient client = GetClient();
            client.Working += test.Handle;
            test.Callback = (_, _) => { cancellation.Cancel(); return Task.CompletedTask; };
            try
            {
                await client.DoWorkAsync(cancellation.Token);
            }
            catch (AggregateException)
            {
            }

            Assert.IsTrue(test.Raised);
            Assert.IsFalse(test.Completed);
        }

        [Test]
        public async Task Cancels_StopsRaising()
        {
            var first = new TestHandler<SyncAsyncEventArgs>() { Delay = TimeSpan.FromMilliseconds(500) };
            var second = new TestHandler<SyncAsyncEventArgs>() { Delay = TimeSpan.FromMilliseconds(500) };
            var third = new TestHandler<SyncAsyncEventArgs>() { Delay = TimeSpan.FromMilliseconds(500) };
            CancellationTokenSource cancellation = new CancellationTokenSource();

            TestClient client = GetClient();
            client.Working += first.Handle;
            client.Working += second.Handle;
            client.Working += third.Handle;

            first.Callback = (_, _) => { cancellation.Cancel(); return Task.CompletedTask; };
            try
            {
                await client.DoWorkAsync(cancellation.Token);
            }
            catch (AggregateException)
            {
            }

            Assert.IsTrue(first.Raised);
            Assert.IsFalse(first.Completed);
            Assert.IsFalse(second.Raised);
            Assert.IsFalse(second.Completed);
            Assert.IsFalse(third.Raised);
            Assert.IsFalse(third.Completed);
        }
        #endregion

        #region Exceptions
        [Test]
        public async Task Exception_Thrown()
        {
            var test = new TestHandler<SyncAsyncEventArgs>() { Throws = "Boom!" };

            TestClient client = GetClient();
            client.Working += test.Handle;
            try
            {
                await client.DoWorkAsync();
                Assert.Fail("Handler exception was not thrown!");
            }
            catch (AggregateException ex)
            {
                Assert.IsInstanceOf<InvalidOperationException>(ex.InnerException);
                Assert.AreEqual("Boom!", ex.InnerException.Message);
            }

            Assert.IsTrue(test.Raised);
            Assert.IsFalse(test.Completed);
        }

        [Test]
        public async Task Exception_OthersContinue()
        {
            var first = new TestHandler<SyncAsyncEventArgs>() { Throws = "Boom!" };
            var second = new TestHandler<SyncAsyncEventArgs>() { Delay = TimeSpan.FromMilliseconds(100) };
            var third = new TestHandler<SyncAsyncEventArgs>() { Delay = TimeSpan.FromMilliseconds(100) };
            CancellationTokenSource cancellation = new CancellationTokenSource();

            TestClient client = GetClient();
            client.Working += first.Handle;
            client.Working += second.Handle;
            client.Working += third.Handle;

            try
            {
                await client.DoWorkAsync();
                Assert.Fail("Handler exception was not thrown!");
            }
            catch (AggregateException ex)
            {
                Assert.IsInstanceOf<InvalidOperationException>(ex.InnerException);
                Assert.AreEqual("Boom!", ex.InnerException.Message);
            }

            Assert.IsTrue(first.Raised);
            Assert.IsFalse(first.Completed);
            Assert.IsTrue(second.Raised);
            Assert.IsTrue(second.Completed);
            Assert.IsTrue(third.Raised);
            Assert.IsTrue(third.Completed);
        }

        [Test]
        public async Task Exception_Multiple()
        {
            var first = new TestHandler<SyncAsyncEventArgs>() { Throws = nameof(TestClient.Working) };
            var second = new TestHandler<SyncAsyncEventArgs>() { Throws = "Bar" };
            var third = new TestHandler<SyncAsyncEventArgs>() { Throws = "Baz" };
            CancellationTokenSource cancellation = new CancellationTokenSource();

            TestClient client = GetClient();
            client.Working += first.Handle;
            client.Working += second.Handle;
            client.Working += third.Handle;

            try
            {
                await client.DoWorkAsync();
                Assert.Fail("Handler exception was not thrown!");
            }
            catch (AggregateException ex)
            {
                var messages = ex.InnerExceptions.Select(e => e.Message).ToList();
                Assert.Contains(nameof(TestClient.Working), messages);
                Assert.Contains("Bar", messages);
                Assert.Contains("Baz", messages);
                Assert.AreEqual(3, messages.Count);
            }

            Assert.IsTrue(first.Raised);
            Assert.IsFalse(first.Completed);
            Assert.IsTrue(second.Raised);
            Assert.IsFalse(second.Completed);
            Assert.IsTrue(third.Raised);
            Assert.IsFalse(third.Completed);
        }

        [Test]
        public async Task Exception_PreservesAggregateTree()
        {
            TestClient client = GetClient();
            client.Working += (SyncAsyncEventArgs e) =>
                throw new AggregateException(new InvalidOperationException("Nested oops."));
            try
            {
                await client.DoWorkAsync();
                Assert.Fail("Handler exception was not thrown!");
            }
            catch (AggregateException outer)
            {
                Assert.IsInstanceOf<AggregateException>(outer.InnerException);
                Assert.IsInstanceOf<InvalidOperationException>(outer.InnerException.InnerException);
            }
        }
        #endregion
    }
}
