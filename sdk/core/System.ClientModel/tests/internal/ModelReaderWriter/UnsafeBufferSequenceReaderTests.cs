// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal.ModelReaderWriterTests
{
    public class UnsafeBufferSequenceReaderTests
    {
        private const int _bufferSize = 100000000;

        [Test]
        public void UseAfterDispose()
        {
            UnsafeBufferSequence.Reader reader = UnsafeBufferSequenceHelper.SetUpBufferReader(totalSize: 4096);
            reader.Dispose();

            Assert.Throws<ObjectDisposedException>(() => _ = reader.Length);
            Assert.Throws<ObjectDisposedException>(() => reader.CopyTo(new MemoryStream(), default));
            Assert.ThrowsAsync<ObjectDisposedException>(async () => await reader.CopyToAsync(new MemoryStream(), default));
            Assert.Throws<ObjectDisposedException>(() => reader.ToBinaryData());
            Assert.DoesNotThrow(() => reader.Dispose());
        }

        [Test]
        public async Task CancellationToken()
        {
            using UnsafeBufferSequence.Reader reader = UnsafeBufferSequenceHelper.SetUpBufferReader();
            long length = reader.Length;
            using MemoryStream stream = new MemoryStream();
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            var task = Task.Run(() => reader.CopyTo(stream, tokenSource.Token));
            bool exceptionThrown = false;
            try
            {
                while (stream.Position == 0)
                { } // wait for the stream to start filling
                tokenSource.Cancel();
                await task;
            }
            catch (OperationCanceledException)
            {
                exceptionThrown = true;
            }
            Assert.That(exceptionThrown, Is.True);
            Assert.That(stream.Length, Is.GreaterThan(0));
            Assert.That(stream.Length, Is.LessThan(length));
        }

        [Test]
        public async Task CancellationTokenAsync()
        {
            using UnsafeBufferSequence.Reader reader = UnsafeBufferSequenceHelper.SetUpBufferReader();
            long length = reader.Length;
            using MemoryStream stream = new MemoryStream();
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            var task = Task.Run(() => reader.CopyToAsync(stream, tokenSource.Token));
            bool exceptionThrown = false;
            try
            {
                while (stream.Position == 0)
                { } // wait for the stream to start filling
                tokenSource.Cancel();
                await task;
            }
            catch (OperationCanceledException)
            {
                exceptionThrown = true;
            }
            Assert.That(exceptionThrown, Is.True);
            Assert.That(stream.Length, Is.GreaterThan(0));
            Assert.That(stream.Length, Is.LessThan(length));
        }

        [Test]
        public async Task DisposeWhileCopy()
        {
            using MemoryStream stream = new MemoryStream();
            using MemoryStream stream2 = new MemoryStream();

            UnsafeBufferSequence.Reader reader = UnsafeBufferSequenceHelper.SetUpBufferReader(totalSize: _bufferSize);

            //start the first copy before disposing
            var copyTask = StartAsyncTask(() => reader.CopyTo(stream, default));

            //wait for copy to start
            while (stream.Position == 0)
            {
                Thread.Sleep(0);
            }

            //start the dispose task
            var disposeTask = StartAsyncTask(reader.Dispose);

            //make sure the dispose bit has been flipped
            while (!UnsafeBufferSequenceHelper.IsDisposedField.GetValue(reader)!.Equals(true))
            {
                Thread.Sleep(0);
            }
            var copyTask2 = StartAsyncTask(() =>
            {
                Assert.Throws<ObjectDisposedException>(() => reader.CopyTo(stream2, default));
            });

            //wait for all tasks to complete
            await copyTask2;
            await disposeTask;
            await copyTask;
            VerifyStreams(stream.GetBuffer(), stream.Position, stream2.Position);
        }

        [Test]
        public async Task DisposeWhileGetBinaryData()
        {
            BinaryData? data = null;
            BinaryData? data2 = null;

            UnsafeBufferSequence.Reader reader = UnsafeBufferSequenceHelper.SetUpBufferReader(totalSize: _bufferSize);

            //start the first copy before disposing
            var copyTask = StartAsyncTask(() => data = reader.ToBinaryData());

            Thread.Sleep(10);

            //start the dispose task
            var disposeTask = StartAsyncTask(reader.Dispose);

            //make sure the dispose bit has been flipped
            while (!UnsafeBufferSequenceHelper.IsDisposedField.GetValue(reader)!.Equals(true))
            {
                Thread.Sleep(0);
            }
            var copyTask2 = StartAsyncTask(() =>
            {
                Assert.Throws<ObjectDisposedException>(() => data2 = reader.ToBinaryData());
            });

            //wait for all tasks to complete
            await copyTask2;
            await disposeTask;
            await copyTask;
            VerifyStreams(data!.ToArray(), data.ToMemory().Length, data2 is null ? 0 : data2.ToMemory().Length);
        }

        [Test]
        public async Task DisposeWhileCopyAsync()
        {
            using MemoryStream stream = new MemoryStream();
            using MemoryStream stream2 = new MemoryStream();

            UnsafeBufferSequence.Reader reader = UnsafeBufferSequenceHelper.SetUpBufferReader(totalSize: _bufferSize);

            //start the first copy before disposing
            var copyTask = StartAsyncTask(async () => await reader.CopyToAsync(stream, default));

            //wait for copy to start
            while (stream.Position == 0)
            {
                Thread.Sleep(0);
            }

            //start the dispose task
            var disposeTask = StartAsyncTask(reader.Dispose);

            //make sure the dispose bit has been flipped
            while (!UnsafeBufferSequenceHelper.IsDisposedField.GetValue(reader)!.Equals(true))
            {
                Thread.Sleep(0);
            }
            var copyTask2 = StartAsyncTask(() =>
            {
                Assert.ThrowsAsync<ObjectDisposedException>(async () => await reader.CopyToAsync(stream2, default));
            });

            //wait for all tasks to complete
            await copyTask2;
            await disposeTask;
            await copyTask;
            VerifyStreams(stream.GetBuffer(), stream.Position, stream2.Position);
        }

        private void VerifyStreams(byte[] buffer, long written1, long written2)
        {
            //verify the first copy completed successfully
            Assert.That(written1, Is.GreaterThan(0));
            Assert.That(written1, Is.LessThan(_bufferSize));
            Assert.That(buffer[written1 - 1], Is.EqualTo(0xFF));
            if (buffer.Length > written1)
            {
                Assert.That(buffer[written1], Is.EqualTo(0x00));
            }
            Assert.That(buffer[0], Is.EqualTo(0xFF));

            //verify the second copy did not happen
            Assert.That(written2, Is.EqualTo(0));
        }

        private Task StartAsyncTask(Func<Task> func)
        {
            var task = Task.Factory.StartNew(func);
            ValidateTaskStarted(task);
            return task;
        }

        private Task StartAsyncTask(Action action)
        {
            var task = Task.Factory.StartNew(action);
            ValidateTaskStarted(task);
            return task;
        }

        private static void ValidateTaskStarted(Task task)
        {
            //validate the task is running
            while (task.Status != TaskStatus.Running)
            {
                Thread.Sleep(0);
            }
            Assert.That(task.Status, Is.EqualTo(TaskStatus.Running));
            Assert.That(task.IsCompleted, Is.False);
        }
    }
}
