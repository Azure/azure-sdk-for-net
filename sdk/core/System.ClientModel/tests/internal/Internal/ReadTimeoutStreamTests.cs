// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Internal;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace System.ClientModel.Tests.Internal;

public class ReadTimeoutStreamTests
{
    private readonly byte[] _buffer = new byte[1];
    private readonly TimeSpan _defaultTimeout = TimeSpan.FromSeconds(0.1);

    [Test]
    public void StreamIsDisposedForTimeoutInSyncRead()
    {
        var testStream = new TestStream();
        var timeoutStream = new ReadTimeoutStream(testStream, _defaultTimeout);

        Assert.Throws<TaskCanceledException>(() => timeoutStream.Read(_buffer, 0, 1));
    }

    [Test]
    public void StreamIsDisposedForTimeoutInAsyncReadWhenTokenIsIgnored()
    {
        var testStream = new TestStream(true);
        var timeoutStream = new ReadTimeoutStream(testStream, _defaultTimeout);

        Assert.ThrowsAsync<TaskCanceledException>(() => timeoutStream.ReadAsync(_buffer, 0, 1));
    }

    [Test]
    public void ReadIsCancelledOnTimeout()
    {
        var testStream = new TestStream(true);
        var timeoutStream = new ReadTimeoutStream(testStream, _defaultTimeout);

        Assert.ThrowsAsync<TaskCanceledException>(() => timeoutStream.ReadAsync(_buffer, 0, 1));
    }

    [Test]
    public void ReadIsCancelledOnTimeoutWithAdditionalToken()
    {
        var testStream = new TestStream(true);
        var timeoutStream = new ReadTimeoutStream(testStream, _defaultTimeout);
        var cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.CancelAfter(1000000);

        var cancellationToken = cancellationTokenSource.Token;

        Assert.ThrowsAsync<TaskCanceledException>(() => timeoutStream.ReadAsync(_buffer, 0, 1, cancellationToken));
    }

    [Test]
    public void DisposeDisposesInnerStream()
    {
        var testStream = new TestStream(true);
        var timeoutStream = new ReadTimeoutStream(testStream, _defaultTimeout);
        timeoutStream.Dispose();

        Assert.True(testStream.IsDisposed);
    }

    #region Helpers
    private class TestStream : ReadOnlyStream
    {
        private readonly bool _ignoreToken;
        private TaskCompletionSource<object> _disposeTCS;

        public TestStream(bool ignoreToken = false)
        {
            _ignoreToken = ignoreToken;
            _disposeTCS = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);
        }

        public bool IsDisposed { get; set; }

        protected override void Dispose(bool disposing)
        {
            IsDisposed = true;
            _disposeTCS.SetException(new ObjectDisposedException(nameof(TestStream)));
            base.Dispose(disposing);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            _disposeTCS.Task.GetAwaiter().GetResult();
            return 0;
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            await _disposeTCS.Task.AwaitWithCancellation(_ignoreToken ? default : cancellationToken);
            return 0;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new System.NotImplementedException();
        }

        public override bool CanRead { get; }
        public override bool CanSeek { get; }
        public override long Length { get; }
        public override long Position { get; set; }
    }
    internal abstract class ReadOnlyStream : Stream
    {
        public override bool CanWrite => false;

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Flush()
        {
            // Flush is allowed on read-only stream
        }
    }
    #endregion
}