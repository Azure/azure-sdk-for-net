// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;
using System.IO;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Bindings
{
#pragma warning disable CS0618 // Type or member is obsolete
    internal class WatchableCloudBlobStream : DelegatingCloudBlobStream, IWatcher
#pragma warning restore CS0618 // Type or member is obsolete
    {
        private readonly IBlobCommitedAction _committedAction;

        // private bool _committed;
        private bool _completed;
        private long _countWritten;
        private bool _flushed;

        public WatchableCloudBlobStream(Stream inner, IBlobCommitedAction committedAction)
            : base(inner)
        {
            _committedAction = committedAction;
        }

        public override bool CanWrite
        {
            get
            {
                // Be nicer than the SDK. Return false when calling Write would throw.
                return base.CanWrite /*&& !_committed */;
            }
        }

        /*
        public bool HasCommitted
        {
            get { return_committed; }
        }
        */

        // TODO (kasobol-msft) find replacement
        /*
        public override Task CommitAsync() => CommitAsync(CancellationToken.None);

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            _committed = true;

            await base.CommitAsync().ConfigureAwait(false);

            if (_committedAction != null)
            {
                await _committedAction.ExecuteAsync(cancellationToken).ConfigureAwait(false);
            }
        }
        */

        public override void Close()
        {
            // TODO (kasobol-msft) find replacement
            /*
            if (!_committed)
            {
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
                Task.Run(async () => await CommitAsync().ConfigureAwait(false)).GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
            }
            */

            base.Close();
        }

        public override void Flush()
        {
            base.Flush();
            _flushed = true;
        }

        public override Task FlushAsync(CancellationToken cancellationToken)
        {
            Task baskTask = base.FlushAsync(cancellationToken);
            return FlushAsyncCore(baskTask);
        }

        private async Task FlushAsyncCore(Task task)
        {
            await task.ConfigureAwait(false);
            _flushed = true;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            base.Write(buffer, offset, count);
            _countWritten += count;
        }

        public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            Task baseTask = base.WriteAsync(buffer, offset, count, cancellationToken);
            return WriteAsyncCore(baseTask, count);
        }

        private async Task WriteAsyncCore(Task task, int count)
        {
#pragma warning disable AZC0100 // ConfigureAwait(false) must be used.
            // TODO: This fails tests if fixed...
            await task;
#pragma warning restore AZC0100 // ConfigureAwait(false) must be used.
            _countWritten += count;
        }

        public override void WriteByte(byte value)
        {
            base.WriteByte(value);
            _countWritten++;
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            Task baseTask = new TaskFactory().FromAsync(base.BeginWrite, base.EndWrite, buffer, offset, count, state: null);
            return new TaskAsyncResult(WriteAsyncCore(baseTask, count), callback, state);
        }

        public override void EndWrite(IAsyncResult asyncResult)
        {
            TaskAsyncResult result = (TaskAsyncResult)asyncResult;
            result.End();
        }

        /// <summary>Commits the stream as appropriate (when written to or flushed) and finalizes status.</summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>
        /// A <see cref="Task"/> that commits the stream as appropriate and finalizes status. The result of the task is
        /// <see langword="true"/> when the stream was committed (either by this method or previously); otherwise,
        /// <see langword="false"/>
        /// </returns>
        public async Task<bool> CompleteAsync(CancellationToken cancellationToken)
        {
            // TODO (kasobol-msft) find replacement
            /*
            if (!_committed && (_countWritten > 0 || _flushed))
            {
                await CommitAsync(cancellationToken).ConfigureAwait(false);
            }
            */

            //TODO (kasobol-msft) this is added artificailly
            cancellationToken.ThrowIfCancellationRequested();

            _completed = true;

            return await Task.FromResult(false /*_committed*/).ConfigureAwait(false);
        }

        public ParameterLog GetStatus()
        {
            if (/* _committed || */ _countWritten > 0 || _flushed)
            {
                return new WriteBlobParameterLog { WasWritten = true, BytesWritten = _countWritten };
            }
            else if (_completed)
            {
                return new WriteBlobParameterLog { WasWritten = false, BytesWritten = 0 };
            }
            else
            {
                return null;
            }
        }
    }
}
