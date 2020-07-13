// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.Host.Blobs
{
#pragma warning disable CS0618 // Type or member is obsolete
    internal class WatchableReadStream : DelegatingStream, IWatcher
#pragma warning restore CS0618 // Type or member is obsolete
    {
        private readonly Stopwatch _timeRead = new Stopwatch();
        private readonly long _totalLength;

        private long _countRead;

        public WatchableReadStream(Stream inner)
            : base(inner)
        {
            _totalLength = inner.Length;
        }

        public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
        {
            Task baseTask = base.CopyToAsync(destination, bufferSize, cancellationToken);
            return CopyToAsyncCore(baseTask);
        }

        private async Task CopyToAsyncCore(Task baseTask)
        {
            try
            {
                _timeRead.Start();
                await baseTask.ConfigureAwait(false);
                _countRead += _totalLength;
            }
            finally
            {
                _timeRead.Stop();
            }
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            Task<int> baseTask = Task<int>.Factory.FromAsync(base.BeginRead, base.EndRead, buffer, offset, count, state: null);
            return new TaskAsyncResult<int>(ReadAsyncCore(baseTask), callback, state);
        }

        public override int EndRead(IAsyncResult asyncResult)
        {
            TaskAsyncResult<int> taskResult = (TaskAsyncResult<int>)asyncResult;
            return taskResult.End();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            try
            {
                _timeRead.Start();
                var bytesRead = base.Read(buffer, offset, count);
                _countRead += bytesRead;
                return bytesRead;
            }
            finally
            {
                _timeRead.Stop();
            }
        }

        public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            Task<int> baseTask = base.ReadAsync(buffer, offset, count, cancellationToken);
            return ReadAsyncCore(baseTask);
        }

        private async Task<int> ReadAsyncCore(Task<int> baseTask)
        {
            try
            {
                _timeRead.Start();
#pragma warning disable AZC0100 // ConfigureAwait(false) must be used.
                // TODO: This fails tests if fixed...
                int bytesRead = await baseTask;
#pragma warning restore AZC0100 // ConfigureAwait(false) must be used.
                _countRead += bytesRead;
                return bytesRead;
            }
            finally
            {
                _timeRead.Stop();
            }
        }

        public override int ReadByte()
        {
            int read = base.ReadByte();

            if (read != -1)
            {
                _countRead++;
            }

            return read;
        }

        public ParameterLog GetStatus()
        {
            return new ReadBlobParameterLog
            {
                BytesRead = _countRead,
                Length = _totalLength,
                ElapsedTime = _timeRead.Elapsed
            };
        }
    }
}
