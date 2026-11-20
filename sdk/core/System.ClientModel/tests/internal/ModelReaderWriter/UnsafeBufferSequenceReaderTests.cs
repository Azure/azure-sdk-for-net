// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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

        [Test]
        public void DisposeWhileCopy()
        {
            using CancellationOnFirstWriteStream stream = new CancellationOnFirstWriteStream();
            using MemoryStream stream2 = new MemoryStream();

            UnsafeBufferSequence.Reader reader = UnsafeBufferSequenceHelper.SetUpBufferReader(totalSize: _bufferSize);
            stream.OnFirstWrite = reader.Dispose;

            reader.CopyTo(stream, default);

            Assert.Throws<ObjectDisposedException>(() => reader.CopyTo(stream2, default));
            VerifyStreams(stream.GetBuffer(), stream.Position, stream2.Position);
        }

        [Test]
        public async Task DisposeWhileCopyAsync()
        {
            using CancellationOnFirstWriteStream stream = new CancellationOnFirstWriteStream();
            using MemoryStream stream2 = new MemoryStream();

            UnsafeBufferSequence.Reader reader = UnsafeBufferSequenceHelper.SetUpBufferReader(totalSize: _bufferSize);
            stream.OnFirstWrite = reader.Dispose;

            await reader.CopyToAsync(stream, default);

            Assert.ThrowsAsync<ObjectDisposedException>(() => reader.CopyToAsync(stream2, default));
            VerifyStreams(stream.GetBuffer(), stream.Position, stream2.Position);
        }

        [Test]
        public void DisposeWhileGetBinaryDataDuringAllocation()
        {
            UnsafeBufferSequence.Reader reader = UnsafeBufferSequenceHelper.SetUpBufferReader(totalSize: _bufferSize);

            // Dispose after the length has been calculated and while the destination stream is being allocated.
            Assert.Throws<ObjectDisposedException>(() => reader.ToBinaryData(capacity =>
            {
                reader.Dispose();
                return new MemoryStream(capacity);
            }));
            Assert.Throws<ObjectDisposedException>(() => reader.ToBinaryData());
        }

        [Test]
        public void DisposeWhileGetBinaryDataDuringCopy()
        {
            UnsafeBufferSequence.Reader reader = UnsafeBufferSequenceHelper.SetUpBufferReader(totalSize: _bufferSize);

            // Dispose from within the first write performed by ToBinaryData's internal copy.
            BinaryData data = reader.ToBinaryData(capacity => new CancellationOnFirstWriteStream(capacity) { OnFirstWrite = reader.Dispose });

            Assert.Greater(data.ToMemory().Length, 0);
            Assert.Less(data.ToMemory().Length, _bufferSize);
            Assert.AreEqual(0xFF, data.ToMemory().Span[0]);
            Assert.Throws<ObjectDisposedException>(() => reader.ToBinaryData());
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

        private class CancellationOnFirstWriteStream : MemoryStream
        {
            private bool _didWrite;

            public CancellationOnFirstWriteStream()
            {
            }

            public CancellationOnFirstWriteStream(int capacity)
                : base(capacity)
            {
            }

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
    }
}
