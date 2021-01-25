// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Search.Documents.Batching;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    public class AsyncEventExtensionsTests
    {
        private class TestHandler
        {
            public TimeSpan? Delay { get; set; }
            public string Throws { get; set; }

            public EventArgs LastEventArgs { get; private set; }
            public bool Raised => RaisedCount > 0;
            public int RaisedCount { get; private set; } = 0;
            public bool Completed => CompletedCount > 0;
            public int CompletedCount { get; private set; } = 0;

            public async Task Handle(EventArgs e, CancellationToken cancellationToken)
            {
                LastEventArgs = e;
                RaisedCount++;
                if (Delay != null)
                {
                    await Task.Delay(Delay.Value, cancellationToken);
                }
                if (Throws != null)
                {
                    throw new InvalidOperationException(Throws);
                }
                cancellationToken.ThrowIfCancellationRequested();
                CompletedCount++;
            }
        }

        private async Task Pause(Action action, TimeSpan? delay = null)
        {
            await Task.Delay(delay ?? TimeSpan.FromMilliseconds(10));
            action();
        }

        [Test]
        public void AddHandler()
        {
            Func<EventArgs, CancellationToken, Task> handler = null;
            TestHandler test = new TestHandler();
            handler += test.Handle;
        }

        [Test]
        public void AddHandler_Null()
        {
            Func<EventArgs, CancellationToken, Task> handler = null;
            handler += null;
        }

        [Test]
        public void AddHandler_Multiple()
        {
            Func<EventArgs, CancellationToken, Task> handler = null;
            handler += new TestHandler().Handle;
            handler += new TestHandler().Handle;
            handler += new TestHandler().Handle;
            handler += new TestHandler().Handle;
        }

        [Test]
        public void RemoveHandler()
        {
            Func<EventArgs, CancellationToken, Task> handler = null;
            TestHandler test = new TestHandler();
            handler += test.Handle;
            handler -= test.Handle;
        }

        [Test]
        public void RemoveHandler_Null()
        {
            Func<EventArgs, CancellationToken, Task> handler = null;
            handler -= null;
        }

        [Test]
        public void RemoveHandler_NotAdded()
        {
            Func<EventArgs, CancellationToken, Task> handler = null;
            TestHandler test = new TestHandler();
            handler -= test.Handle;
        }

        [Test]
        public async Task Raise()
        {
            TestHandler test = new TestHandler();

            Func<EventArgs, CancellationToken, Task> handler = null;
            handler += test.Handle;
            await handler.RaiseAsync(EventArgs.Empty, default);

            Assert.IsTrue(test.Raised);
            Assert.IsTrue(test.Completed);
        }

        [Test]
        public async Task Raise_None()
        {
            Func<EventArgs, CancellationToken, Task> handler = null;
            await handler.RaiseAsync(EventArgs.Empty, default);
        }

        [Test]
        public async Task Raise_Null()
        {
            Func<EventArgs, CancellationToken, Task> handler = null;
            handler += null;
            await handler.RaiseAsync(EventArgs.Empty, default);
        }

        [Test]
        public async Task Raise_Waits()
        {
            TestHandler test = new TestHandler() { Delay = TimeSpan.FromMilliseconds(100) };

            Func<EventArgs, CancellationToken, Task> handler = null;
            handler += test.Handle;
            await handler.RaiseAsync(EventArgs.Empty, default);

            Assert.IsTrue(test.Raised);
            Assert.IsTrue(test.Completed);
        }

        [Test]
        public async Task Raise_All()
        {
            TestHandler first = new TestHandler();
            TestHandler second = new TestHandler();
            TestHandler third = new TestHandler();

            Func<EventArgs, CancellationToken, Task> handler = null;
            handler += first.Handle;
            handler += second.Handle;
            handler += third.Handle;
            await handler.RaiseAsync(EventArgs.Empty, default);

            Assert.IsTrue(first.Completed);
            Assert.IsTrue(second.Completed);
            Assert.IsTrue(third.Completed);
        }

        [Test]
        public async Task Raise_Slowest_First()
        {
            TestHandler first = new TestHandler() { Delay = TimeSpan.FromMilliseconds(100) };
            TestHandler second = new TestHandler();
            TestHandler third = new TestHandler();

            Func<EventArgs, CancellationToken, Task> handler = null;
            handler += first.Handle;
            handler += second.Handle;
            handler += third.Handle;
            await handler.RaiseAsync(EventArgs.Empty, default);

            Assert.IsTrue(first.Completed);
            Assert.IsTrue(second.Completed);
            Assert.IsTrue(third.Completed);
        }

        [Test]
        public async Task Raise_Slowest_Middle()
        {
            TestHandler first = new TestHandler();
            TestHandler second = new TestHandler() { Delay = TimeSpan.FromMilliseconds(100) };
            TestHandler third = new TestHandler();

            Func<EventArgs, CancellationToken, Task> handler = null;
            handler += first.Handle;
            handler += second.Handle;
            handler += third.Handle;
            await handler.RaiseAsync(EventArgs.Empty, default);

            Assert.IsTrue(first.Completed);
            Assert.IsTrue(second.Completed);
            Assert.IsTrue(third.Completed);
        }

        [Test]
        public async Task Raise_Slowest_Last()
        {
            TestHandler first = new TestHandler();
            TestHandler second = new TestHandler();
            TestHandler third = new TestHandler() { Delay = TimeSpan.FromMilliseconds(100) };

            Func<EventArgs, CancellationToken, Task> handler = null;
            handler += first.Handle;
            handler += second.Handle;
            handler += third.Handle;
            await handler.RaiseAsync(EventArgs.Empty, default);

            Assert.IsTrue(first.Completed);
            Assert.IsTrue(second.Completed);
            Assert.IsTrue(third.Completed);
        }

        [Test]
        public async Task RemoveHandler_NotRaised()
        {
            TestHandler test = new TestHandler();

            Func<EventArgs, CancellationToken, Task> handler = null;
            handler += test.Handle;
            handler -= test.Handle;
            await handler.RaiseAsync(EventArgs.Empty, default);

            Assert.IsFalse(test.Raised);
        }

        [Test]
        public async Task AddHandler_Duplicate()
        {
            TestHandler test = new TestHandler() { Delay = TimeSpan.FromMilliseconds(100) };

            Func<EventArgs, CancellationToken, Task> handler = null;
            handler += test.Handle;
            handler += test.Handle;
            await handler.RaiseAsync(EventArgs.Empty, default);

            Assert.AreEqual(2, test.RaisedCount);
        }

        [Test]
        public async Task RemoveHandler_Duplicate()
        {
            TestHandler test = new TestHandler() { Delay = TimeSpan.FromMilliseconds(100) };

            Func<EventArgs, CancellationToken, Task> handler = null;
            handler += test.Handle;
            handler += test.Handle;
            handler -= test.Handle;
            await handler.RaiseAsync(EventArgs.Empty, default);

            Assert.AreEqual(1, test.RaisedCount);
        }

        [Test]
        public async Task RemoveHandler_OthersUnaffected()
        {
            TestHandler first = new TestHandler();
            TestHandler second = new TestHandler();
            TestHandler third = new TestHandler();

            Func<EventArgs, CancellationToken, Task> handler = null;
            handler += first.Handle;
            handler += second.Handle;
            handler += third.Handle;

            handler -= second.Handle;

            await handler.RaiseAsync(EventArgs.Empty, default);

            Assert.IsTrue(first.Completed);
            Assert.IsTrue(third.Completed);

            Assert.IsFalse(second.Raised);
        }

        [Test]
        public async Task Raise_EventArgs()
        {
            TestHandler test = new TestHandler();
            EventArgs args = new EventArgs();

            Func<EventArgs, CancellationToken, Task> handler = null;
            handler += test.Handle;
            await handler.RaiseAsync(args, default);

            Assert.AreSame(args, test.LastEventArgs);
        }

        [Test]
        public async Task Raise_EventArgs_All()
        {
            TestHandler first = new TestHandler();
            TestHandler second = new TestHandler();
            TestHandler third = new TestHandler();
            EventArgs args = new EventArgs();

            Func<EventArgs, CancellationToken, Task> handler = null;
            handler += first.Handle;
            handler += second.Handle;
            handler += third.Handle;
            await handler.RaiseAsync(args, default);

            Assert.AreSame(args, first.LastEventArgs);
            Assert.AreSame(args, second.LastEventArgs);
            Assert.AreSame(args, third.LastEventArgs);
        }

        [Test]
        public async Task ThreadSafe_NewNotRaised()
        {
            TestHandler first = new TestHandler() { Delay = TimeSpan.FromMilliseconds(100) };
            TestHandler second = new TestHandler() { Delay = TimeSpan.FromMilliseconds(100) };
            TestHandler third = new TestHandler() { Delay = TimeSpan.FromMilliseconds(100) };
            TestHandler fourth = new TestHandler();

            Func<EventArgs, CancellationToken, Task> handler = null;
            handler += first.Handle;
            handler += second.Handle;
            handler += third.Handle;

            await Task.WhenAll(
                Pause(() => handler += fourth.Handle),
                handler.RaiseAsync(EventArgs.Empty, default));

            Assert.IsTrue(first.Completed);
            Assert.IsTrue(second.Completed);
            Assert.IsTrue(third.Completed);
            Assert.IsFalse(fourth.Raised);
        }

        [Test]
        public async Task ThreadSafe_OldStillRaised()
        {
            TestHandler first = new TestHandler() { Delay = TimeSpan.FromMilliseconds(100) };
            TestHandler second = new TestHandler() { Delay = TimeSpan.FromMilliseconds(100) };
            TestHandler third = new TestHandler() { Delay = TimeSpan.FromMilliseconds(100) };

            Func<EventArgs, CancellationToken, Task> handler = null;
            handler += first.Handle;
            handler += second.Handle;
            handler += third.Handle;

            await Task.WhenAll(
                Pause(() => handler -= first.Handle),
                handler.RaiseAsync(EventArgs.Empty, default));

            Assert.IsTrue(first.Completed);
            Assert.IsTrue(second.Completed);
            Assert.IsTrue(third.Completed);

            await handler.RaiseAsync(EventArgs.Empty, default);
            Assert.AreEqual(1, first.CompletedCount);
            Assert.AreEqual(2, second.CompletedCount);
            Assert.AreEqual(2, third.CompletedCount);
        }

        [Test]
        public async Task Cancels_AlreadyFinished()
        {
            TestHandler test = new TestHandler();
            CancellationTokenSource cancellation = new CancellationTokenSource();

            Func<EventArgs, CancellationToken, Task> handler = null;
            handler += test.Handle;
            await handler.RaiseAsync(EventArgs.Empty, cancellation.Token);
            cancellation.Cancel();

            Assert.IsTrue(test.Raised);
            Assert.IsTrue(test.Completed);
        }

        [Test]
        public async Task Cancels_StillRunning()
        {
            TestHandler test = new TestHandler() { Delay = TimeSpan.FromMilliseconds(500) };
            CancellationTokenSource cancellation = new CancellationTokenSource();

            Func<EventArgs, CancellationToken, Task> handler = null;
            handler += test.Handle;
            try
            {
                await Task.WhenAll(
                    Pause(() => cancellation.Cancel()),
                    handler.RaiseAsync(EventArgs.Empty, cancellation.Token));
            }
            catch (TaskCanceledException)
            {
            }

            Assert.IsTrue(test.Raised);
            Assert.IsFalse(test.Completed);
        }

        [Test]
        public async Task Cancels_All()
        {
            TestHandler first = new TestHandler() { Delay = TimeSpan.FromMilliseconds(500) };
            TestHandler second = new TestHandler() { Delay = TimeSpan.FromMilliseconds(500) };
            TestHandler third = new TestHandler() { Delay = TimeSpan.FromMilliseconds(500) };
            CancellationTokenSource cancellation = new CancellationTokenSource();

            Func<EventArgs, CancellationToken, Task> handler = null;
            handler += first.Handle;
            handler += second.Handle;
            handler += third.Handle;

            try
            {
                await Task.WhenAll(
                Pause(() => cancellation.Cancel()),
                handler.RaiseAsync(EventArgs.Empty, cancellation.Token));
            }
            catch (TaskCanceledException)
            {
            }

            Assert.IsTrue(first.Raised);
            Assert.IsFalse(first.Completed);
            Assert.IsTrue(second.Raised);
            Assert.IsFalse(second.Completed);
            Assert.IsTrue(third.Raised);
            Assert.IsFalse(third.Completed);
        }

        [Test]
        public async Task Cancels_OnlySlow()
        {
            TestHandler first = new TestHandler() { Delay = TimeSpan.FromMilliseconds(20) };
            TestHandler second = new TestHandler() { Delay = TimeSpan.FromMilliseconds(500) };
            TestHandler third = new TestHandler() { Delay = TimeSpan.FromMilliseconds(500) };
            CancellationTokenSource cancellation = new CancellationTokenSource();

            Func<EventArgs, CancellationToken, Task> handler = null;
            handler += first.Handle;
            handler += second.Handle;
            handler += third.Handle;

            try
            {
                await Task.WhenAll(
                Pause(
                    delay: TimeSpan.FromMilliseconds(100),
                    action: () => cancellation.Cancel()),
                handler.RaiseAsync(EventArgs.Empty, cancellation.Token));
            }
            catch (TaskCanceledException)
            {
            }

            Assert.IsTrue(first.Raised);
            Assert.IsTrue(first.Completed);
            Assert.IsTrue(second.Raised);
            Assert.IsFalse(second.Completed);
            Assert.IsTrue(third.Raised);
            Assert.IsFalse(third.Completed);
        }

        [Test]
        public async Task Exception_Thrown()
        {
            TestHandler test = new TestHandler() { Throws = "Boom!" };

            Func<EventArgs, CancellationToken, Task> handler = null;
            handler += test.Handle;
            try
            {
                await handler.RaiseAsync(EventArgs.Empty, default);
                Assert.Fail("Handler exception was not thrown!");
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Boom!", ex.Message);
            }

            Assert.IsTrue(test.Raised);
            Assert.IsFalse(test.Completed);
        }

        [Test]
        public async Task Exception_OthersContinue()
        {
            TestHandler first = new TestHandler() { Throws = "Boom!" };
            TestHandler second = new TestHandler() { Delay = TimeSpan.FromMilliseconds(100) };
            TestHandler third = new TestHandler() { Delay = TimeSpan.FromMilliseconds(100) };
            CancellationTokenSource cancellation = new CancellationTokenSource();

            Func<EventArgs, CancellationToken, Task> handler = null;
            handler += first.Handle;
            handler += second.Handle;
            handler += third.Handle;

            try
            {
                await handler.RaiseAsync(EventArgs.Empty, default);
                Assert.Fail("Handler exception was not thrown!");
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Boom!", ex.Message);
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
            TestHandler first = new TestHandler() { Throws = "Foo" };
            TestHandler second = new TestHandler() { Throws = "Bar" };
            TestHandler third = new TestHandler() { Throws = "Baz" };
            CancellationTokenSource cancellation = new CancellationTokenSource();

            Func<EventArgs, CancellationToken, Task> handler = null;
            handler += first.Handle;
            handler += second.Handle;
            handler += third.Handle;

            try
            {
                await handler.RaiseAsync(EventArgs.Empty, default);
                Assert.Fail("Handler exception was not thrown!");
            }
            catch (AggregateException ex)
            {
                var messages = ex.InnerExceptions.Select(e => e.Message).ToList();
                Assert.Contains("Foo", messages);
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
        public async Task Args_Single()
        {
            int x = 0;
            Func<int, CancellationToken, Task> handler = null;
            handler += (i, c) => { x = i; return Task.CompletedTask; };
            await handler.RaiseAsync(7, default);
            Assert.AreEqual(7, x);
        }

        [Test]
        public async Task Args_Double()
        {
            int x = 0, y = 0;
            Func<int, int, CancellationToken, Task> handler = null;
            handler += (i, j, c) => { x = i; y = j; return Task.CompletedTask; };
            await handler.RaiseAsync(7, 8, default);
            Assert.AreEqual(7, x);
            Assert.AreEqual(8, y);
        }

        [Test]
        public async Task Args_Triple()
        {
            int x = 0, y = 0, z = 0;
            Func<int, int, int, CancellationToken, Task> handler = null;
            handler += (i, j, k, c) => { x = i; y = j; z = k; return Task.CompletedTask; };
            await handler.RaiseAsync(7, 8, 9, default);
            Assert.AreEqual(7, x);
            Assert.AreEqual(8, y);
            Assert.AreEqual(9, z);
        }
    }
}
