// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

namespace ClientModel.Tests.Mocks;

public class MockMessagDelay : MessageDelay
{
    private static readonly Func<int, TimeSpan> DefaultDelayFactory =
        count => TimeSpan.FromSeconds(count);

    private readonly Func<int, TimeSpan> _delayFactory;
    private readonly AsyncGate<TimeSpan, object> _asyncGate;

    public MockMessagDelay() : this(DefaultDelayFactory) { }

    public MockMessagDelay(Func<int, TimeSpan> delayFactory)
    {
        _delayFactory = delayFactory;
        _asyncGate = new AsyncGate<TimeSpan, object>();
    }

    public bool IsComplete { get; private set; }

    public TimeSpan GetDelay(int count) => GetDelayCore(null!, count);

    public void ReleaseWait() { }

    public async Task ReleaseWaitAsync() => await _asyncGate.Cycle();

    protected override TimeSpan GetDelayCore(PipelineMessage message, int delayCount)
        => _delayFactory(delayCount);

    protected override void OnDelayComplete(PipelineMessage message)
        => IsComplete = true;

    protected override void WaitCore(TimeSpan duration, CancellationToken cancellationToken)
        => _asyncGate.WaitForRelease(duration).GetAwaiter().GetResult();

    protected override async Task WaitCoreAsync(TimeSpan duration, CancellationToken cancellationToken)
        => await _asyncGate.WaitForRelease(duration).ConfigureAwait(false);
}
