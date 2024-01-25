// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal.ModelReaderWriterTests
{
    public class SequenceBufferReaderTests
    {
        private readonly FieldInfo _copyCountField = typeof(SequenceBufferReader).GetField("_copyCount", BindingFlags.NonPublic | BindingFlags.Instance)!;
        private const int _bufferSize = 100000000;

        [Test]
        public async Task DisposeWhileCopy()
        {
            using MemoryStream stream = new MemoryStream();
            using MemoryStream stream2 = new MemoryStream();

            SequenceBufferReader reader = SequenceBufferHelper.SetUpBufferReader(totalSize: _bufferSize);

            //start the first copy before disposing
            var copyTask = StartAsyncTask(() => reader.CopyTo(stream, default));

            //make sure the readcount was incremented
            while (!_copyCountField.GetValue(reader)!.Equals(1))
            {
                Thread.Sleep(0);
            }

            //start the dispose task
            var disposeTask = StartAsyncTask(reader.Dispose);

            //make sure the dispose bit has been flipped
            while (!SequenceBufferHelper.IsDisposedField.GetValue(reader)!.Equals(1))
            {
                Thread.Sleep(0);
            }

            var copyTask2 = StartAsyncTask(() =>
            {
                Assert.Throws<ObjectDisposedException>(() => reader.CopyTo(stream2, default));
            });

            //verify that the first copy and dispose tasks are still running
            Assert.IsFalse(copyTask.IsCompleted);
            Assert.IsFalse(disposeTask.IsCompleted);

            //wait for all tasks to complete
            await copyTask2;
            await disposeTask;
            await copyTask;

            VerifyStreams(stream, stream2);
        }

        [Test]
        public async Task DisposeWhileCopyAsync()
        {
            using MemoryStream stream = new MemoryStream();
            using MemoryStream stream2 = new MemoryStream();

            SequenceBufferReader reader = SequenceBufferHelper.SetUpBufferReader(totalSize: _bufferSize);

            //start the first copy before disposing
            var copyTask = StartAsyncTask(async () =>
            {
                await reader.CopyToAsync(stream, default);
            });

            //make sure the readcount was incremented
            while (!_copyCountField.GetValue(reader)!.Equals(1))
            {
                Thread.Sleep(0);
            }

            //start the dispose task
            var disposeTask = StartAsyncTask(reader.Dispose);

            //make sure the dispose bit has been flipped
            while (!SequenceBufferHelper.IsDisposedField.GetValue(reader)!.Equals(1))
            {
                Thread.Sleep(0);
            }

            var copyTask2 = StartAsyncTask(() =>
            {
                Assert.ThrowsAsync<ObjectDisposedException>(async () => await reader.CopyToAsync(stream2, default));
            });

            //verify that the first copy and dispose tasks are still running
            Assert.IsFalse(copyTask.IsCompleted);
            Assert.IsFalse(disposeTask.IsCompleted);

            //wait for all tasks to complete
            await copyTask2;
            await disposeTask;
            await copyTask;

            VerifyStreams(stream, stream2);
        }

        [Test]
        public async Task DisposeWhileConvertToBinaryData()
        {
            BinaryData? data = null;
            BinaryData? data2 = null;

            SequenceBufferReader reader = SequenceBufferHelper.SetUpBufferReader(totalSize: _bufferSize);

            //start the first copy before disposing
            var copyTask = StartAsyncTask(() => data = reader.ToBinaryData());

            //make sure the readcount was incremented
            while (!_copyCountField.GetValue(reader)!.Equals(1))
            {
                Thread.Sleep(0);
            }

            //start the dispose task
            var disposeTask = StartAsyncTask(reader.Dispose);

            //make sure the dispose bit has been flipped
            while (!SequenceBufferHelper.IsDisposedField.GetValue(reader)!.Equals(1))
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

            //verify the first copy completed successfully
            Assert.IsNotNull(data);
            byte[] dataArray = data!.ToArray();
            Assert.AreEqual(_bufferSize, dataArray.Length);
            Assert.AreEqual(0xFF, dataArray[dataArray.Length - 1]);
            Assert.AreEqual(0xFF, dataArray[0]);

            //verify the second copy did not happen
            Assert.IsNull(data2);
        }

        [Test]
        public void UseAfterDispose()
        {
            SequenceBufferReader reader = SequenceBufferHelper.SetUpBufferReader(totalSize: 4096);
            reader.Dispose();

            Assert.Throws<ObjectDisposedException>(() => reader.TryComputeLength(out var length));
            Assert.Throws<ObjectDisposedException>(() => reader.CopyTo(new MemoryStream(), default));
            Assert.ThrowsAsync<ObjectDisposedException>(async () => await reader.CopyToAsync(new MemoryStream(), default));
            Assert.Throws<ObjectDisposedException>(() => reader.ToBinaryData());
            Assert.Throws<ObjectDisposedException>(() => reader.Dispose());
        }

        [Test]
        public void ParallelComputLength()
        {
            int size = 100000;
            using SequenceBufferReader reader = SequenceBufferHelper.SetUpBufferReader();

            Parallel.For(0, 1000000, i =>
            {
                Assert.IsTrue(reader.TryComputeLength(out var length));
                Assert.AreEqual(size, length);
            });
        }

        [Test]
        public void ParallelCopy()
        {
            int size = 100000;
            using SequenceBufferReader reader = SequenceBufferHelper.SetUpBufferReader();

            Parallel.For(0, 10000, i =>
            {
                using MemoryStream stream = new MemoryStream(size);
                reader.CopyTo(stream, default);
                Assert.AreEqual(size, stream.Length);
            });
        }

        [Test]
        public void ParallelCopyAsync()
        {
            int size = 100000;
            using SequenceBufferReader reader = SequenceBufferHelper.SetUpBufferReader();

            Parallel.For(0, 10000, async i =>
            {
                using MemoryStream stream = new MemoryStream(size);
                await reader.CopyToAsync(stream, default);
                Assert.AreEqual(size, stream.Length);
            });
        }

        [Test]
        public async Task CancellationToken()
        {
            using SequenceBufferReader reader = SequenceBufferHelper.SetUpBufferReader();
            reader.TryComputeLength(out var length);
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
            Assert.IsTrue(exceptionThrown);
            Assert.Greater(stream.Length, 0);
            Assert.Less(stream.Length, length);
        }

        [Test]
        public async Task CancellationTokenAsync()
        {
            using SequenceBufferReader reader = SequenceBufferHelper.SetUpBufferReader();
            reader.TryComputeLength(out var length);
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
            Assert.IsTrue(exceptionThrown);
            Assert.Greater(stream.Length, 0);
            Assert.Less(stream.Length, length);
        }

        private void VerifyStreams(MemoryStream stream, MemoryStream stream2)
        {
            //verify the first copy completed successfully
            byte[] streamArray = stream.GetBuffer();
            Assert.AreEqual(_bufferSize, stream.Position);
            Assert.AreEqual(0xFF, streamArray[stream.Position - 1]);
            Assert.AreEqual(0xFF, streamArray[0]);

            //verify the second copy did not happen
            Assert.AreEqual(0, stream2.Position);
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
