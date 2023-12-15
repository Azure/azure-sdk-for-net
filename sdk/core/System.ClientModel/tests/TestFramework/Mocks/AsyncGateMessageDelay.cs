// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ClientModel.Tests.Mocks;

public class AsyncGateMessageDelay : MockMessageDelay
{
    private readonly AsyncGate<TimeSpan, object> _asyncGate;

    public AsyncGateMessageDelay() : base()
    {
        _asyncGate = new AsyncGate<TimeSpan, object>();
    }

    public void ReleaseWait() { }

    public async Task ReleaseWaitAsync() => await _asyncGate.Cycle();

    protected override void WaitCore(TimeSpan duration, CancellationToken cancellationToken)
        => _asyncGate.WaitForRelease(duration).GetAwaiter().GetResult();

    protected override async Task WaitCoreAsync(TimeSpan duration, CancellationToken cancellationToken)
        => await _asyncGate.WaitForRelease(duration).ConfigureAwait(false);
}
