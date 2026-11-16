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
        public void CancellationToken()
        {
            using UnsafeBufferSequence.Reader reader = UnsafeBufferSequenceHelper.SetUpBufferReader();
            long length = reader.Length;
            using CancellationOnFirstWriteStream stream = new CancellationOnFirstWriteStream();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            stream.OnFirstWrite = tokenSource.Cancel;

            Assert.Throws<OperationCanceledException>(() => reader.CopyTo(stream, tokenSource.Token));
            Assert.Greater(stream.Length, 0);
            Assert.Less(stream.Length, length);
        }

        [Test]
        public void CancellationTokenAsync()
        {
            using UnsafeBufferSequence.Reader reader = UnsafeBufferSequenceHelper.SetUpBufferReader();
            long length = reader.Length;
            using CancellationOnFirstWriteStream stream = new CancellationOnFirstWriteStream();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            stream.OnFirstWrite = tokenSource.Cancel;

            Assert.ThrowsAsync<OperationCanceledException>(async () => await reader.CopyToAsync(stream, tokenSource.Token));
            Assert.Greater(stream.Length, 0);
            Assert.Less(stream.Length, length);
        }

        private class CancellationOnFirstWriteStream : MemoryStream
        {
            private bool _didWrite;

            public Action? OnFirstWrite { get; set; }

            public override void Write(byte[] buffer, int offset, int count)
            {
                base.Write(buffer, offset, count);
                CancelAfterFirstWrite();
            }

            public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            {
                await base.WriteAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);
                CancelAfterFirstWrite();
            }

            private void CancelAfterFirstWrite()
            {
                if (!_didWrite)
                {
                    _didWrite = true;
                    OnFirstWrite?.Invoke();
                }
            }
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
            Assert.Greater(written1, 0);
            Assert.Less(written1, _bufferSize);
            Assert.AreEqual(0xFF, buffer[written1 - 1]);
            if (buffer.Length > written1)
            {
                Assert.AreEqual(0x00, buffer[written1]);
            }
            Assert.AreEqual(0xFF, buffer[0]);

            //verify the second copy did not happen
            Assert.AreEqual(0, written2);
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
            Assert.AreEqual(TaskStatus.Running, task.Status);
            Assert.IsFalse(task.IsCompleted);
        }
    }
}
