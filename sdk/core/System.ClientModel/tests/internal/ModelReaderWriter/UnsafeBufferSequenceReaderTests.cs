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
            Assert.IsTrue(exceptionThrown);
            Assert.Greater(stream.Length, 0);
            Assert.Less(stream.Length, length);
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
            Assert.IsTrue(exceptionThrown);
            Assert.Greater(stream.Length, 0);
            Assert.Less(stream.Length, length);
        }
    }
}
