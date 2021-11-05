// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Bindings
{
    internal class NotifyingBlobStream : DelegatingStream
    {
        private readonly IBlobCommitedAction _committedAction;

        public NotifyingBlobStream(Stream inner, IBlobCommitedAction committedAction)
            : base(inner)
        {
            _committedAction = committedAction;
        }

        public override void Flush()
        {
            base.Flush();
            if (_committedAction != null)
            {
                _committedAction.Execute();
            }
        }

        public override async Task FlushAsync(CancellationToken cancellationToken)
        {
            await base.FlushAsync(cancellationToken).ConfigureAwait(false);
            if (_committedAction != null)
            {
                await _committedAction.ExecuteAsync(cancellationToken).ConfigureAwait(false);
            }
        }

        public override void Close()
        {
            base.Close();
            if (_committedAction != null)
            {
                _committedAction.Execute();
            }
        }
    }
}
