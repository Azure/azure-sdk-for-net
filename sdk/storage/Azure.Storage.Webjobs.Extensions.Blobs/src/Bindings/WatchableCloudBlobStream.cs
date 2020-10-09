// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;
using System.IO;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Bindings
{
#pragma warning disable CS0618 // Type or member is obsolete
    internal class WatchableCloudBlobStream : DelegatingStream, IWatcher
#pragma warning restore CS0618 // Type or member is obsolete
    {
        private readonly IBlobCommitedAction _committedAction;

        private long _countWritten;
        private bool _flushed;

        public WatchableCloudBlobStream(Stream inner, IBlobCommitedAction committedAction)
            : base(inner)
        {
            _committedAction = committedAction;
        }

        public override void Flush()
        {
            base.Flush();
            _flushed = true;
            if (_committedAction != null)
            {
                _committedAction.Execute();
            }
        }

        public override async Task FlushAsync(CancellationToken cancellationToken)
        {
            await base.FlushAsync(cancellationToken).ConfigureAwait(false);
            _flushed = true;
            if (_committedAction != null)
            {
                await _committedAction.ExecuteAsync(cancellationToken).ConfigureAwait(false);
            }
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            base.Write(buffer, offset, count);
            _countWritten += count;
        }

        public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            await base.WriteAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);
            _countWritten += count;
        }

        public override void WriteByte(byte value)
        {
            base.WriteByte(value);
            _countWritten++;
        }

        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            IAsyncResult res = base.BeginWrite(buffer, offset, count, callback, state);
            _countWritten += count;
            return res;
        }

        public override void EndWrite(IAsyncResult asyncResult)
        {
            base.EndWrite(asyncResult);
        }

        public ParameterLog GetStatus()
        {
            if (_countWritten > 0 || _flushed)
            {
                return new WriteBlobParameterLog { WasWritten = true, BytesWritten = _countWritten };
            }
            else
            {
                return new WriteBlobParameterLog { WasWritten = false, BytesWritten = 0 };
            }
        }
    }
}
