// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core.Samples
{
    public class AlarmClient
    {
        private ClientDiagnostics _clientDiagnostics = new ClientDiagnostics(new AlarmClientOptions());

        public event SyncAsyncEventHandler<SyncAsyncEventArgs> Ring;

        public void Snooze(CancellationToken cancellationToken = default) =>
            SnoozeInternal(true, cancellationToken).GetAwaiter().GetResult();

        public async Task SnoozeAsync(CancellationToken cancellationToken = default) =>
            await SnoozeInternal(false, cancellationToken).ConfigureAwait(false);

        protected virtual async Task SnoozeInternal(bool isRunningSynchronously, CancellationToken cancellationToken)
        {
            // Why does snoozing an alarm always wait 9 minutes?
            TimeSpan delay = TimeSpan.FromMilliseconds(900);
            if (isRunningSynchronously)
            {
                cancellationToken.WaitHandle.WaitOne(delay);
            }
            else
            {
                await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
            }
            SyncAsyncEventArgs e = new SyncAsyncEventArgs(isRunningSynchronously, cancellationToken);
            await Ring.RaiseAsync(e, nameof(AlarmClient), nameof(Ring), _clientDiagnostics).ConfigureAwait(false);
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "<Pending>")]
    public class AlarmClientOptions : ClientOptions { }
}
