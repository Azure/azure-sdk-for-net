// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    internal class ReadTimeoutStream : ReadOnlyStream
    {
        private readonly Stream _stream;
        private TimeSpan _readTimeout;
        private CancellationTokenSource _cancellationTokenSource;

        public ReadTimeoutStream(Stream stream, TimeSpan readTimeout)
        {
            _stream = stream;
            _readTimeout = readTimeout;
            UpdateReadTimeout();
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _stream.Read(buffer, offset, count);
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            var source = StartTimeout(cancellationToken, out bool dispose);
            try
            {
                return await _stream.ReadAsync(buffer, offset, count, source.Token).ConfigureAwait(false);
            }
            finally
            {
                StopTimeout(source, dispose);
            }
        }

        private CancellationTokenSource StartTimeout(CancellationToken additionalToken, out bool dispose)
        {
            if (_cancellationTokenSource.IsCancellationRequested)
            {
                _cancellationTokenSource = new CancellationTokenSource();
            }

            CancellationTokenSource source;
            if (additionalToken.CanBeCanceled)
            {
                source = CancellationTokenSource.CreateLinkedTokenSource(additionalToken, _cancellationTokenSource.Token);
                dispose = true;
            }
            else
            {
                source = _cancellationTokenSource;
                dispose = false;
            }

            _cancellationTokenSource.CancelAfter(_readTimeout);

            return source;
        }

        private void StopTimeout(CancellationTokenSource source, bool dispose)
        {
            _cancellationTokenSource.CancelAfter(Timeout.InfiniteTimeSpan);
            if (dispose)
            {
                source.Dispose();
            }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return _stream.Seek(offset, origin);
        }

        public override bool CanRead => _stream.CanRead;
        public override bool CanSeek => _stream.CanSeek;
        public override long Length => _stream.Length;

        public override long Position
        {
            get => _stream.Position;
            set => _stream.Position = value;
        }

        public override int ReadTimeout
        {
            get => _readTimeout.Milliseconds;
            set
            {
                _readTimeout = TimeSpan.FromMilliseconds(value);
                UpdateReadTimeout();
            }
        }

        private void UpdateReadTimeout()
        {
            try
            {
                _stream.ReadTimeout = _readTimeout.Milliseconds;
            }
            catch
            {
                // ignore
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _stream.Dispose();
        }
    }
}