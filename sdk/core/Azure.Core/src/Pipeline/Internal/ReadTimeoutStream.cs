// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Read-only Stream that will throw a <see cref="OperationCanceledException"/> if it has to wait longer than a configurable timeout to read more data
    /// </summary>
    internal class ReadTimeoutStream : ReadOnlyStream
    {
        private readonly Stream _stream;
        private TimeSpan _readTimeout;
        private CancellationTokenSource _cancellationTokenSource = null!;

        public ReadTimeoutStream(Stream stream, TimeSpan readTimeout)
        {
            _stream = stream;
            _readTimeout = readTimeout;
            UpdateReadTimeout();
            InitializeTokenSource();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var source = StartTimeout(default, out bool dispose);
            try
            {
                return _stream.Read(buffer, offset, count);
            }
            // We dispose stream on timeout so catch and check if cancellation token was cancelled
            catch (ObjectDisposedException)
            {
                source.Token.ThrowIfCancellationRequested();
                throw;
            }
            finally
            {
                StopTimeout(source, dispose);
            }
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            var source = StartTimeout(cancellationToken, out bool dispose);
            try
            {
#pragma warning disable CA1835 // ReadAsync(Memory<>) overload is not available in all targets
                return await _stream.ReadAsync(buffer, offset, count, source.Token).ConfigureAwait(false);
#pragma warning restore // ReadAsync(Memory<>) overload is not available in all targets
            }
            // We dispose stream on timeout so catch and check if cancellation token was cancelled
            catch (ObjectDisposedException)
            {
                source.Token.ThrowIfCancellationRequested();
                throw;
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
                InitializeTokenSource();
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

        private void InitializeTokenSource()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationTokenSource.Token.Register(() => DisposeStream());
        }

        private void DisposeStream()
        {
            _stream.Dispose();
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
            get => (int) _readTimeout.TotalMilliseconds;
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
                if (_stream.CanTimeout)
                {
                    _stream.ReadTimeout = (int) _readTimeout.TotalMilliseconds;
                }
            }
            catch
            {
                // ignore
            }
        }

        public override void Close()
        {
            _stream.Close();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _stream.Dispose();
            _cancellationTokenSource.Dispose();
        }
    }
}
