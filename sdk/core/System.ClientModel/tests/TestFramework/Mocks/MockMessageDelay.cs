// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

    public MockMessagDelay() : this(DefaultDelayFactory) { }

    public MockMessagDelay(Func<int, TimeSpan> delayFactory)
    {
        _delayFactory = delayFactory;
    }

    public bool IsComplete { get; private set; }

    public TimeSpan GetDelay(int count) => GetDelayCore(null!, count);

    protected override TimeSpan GetDelayCore(PipelineMessage message, int delayCount)
        => _delayFactory(delayCount);

    protected override void OnDelayComplete(PipelineMessage message)
        => IsComplete = true;

    protected override void WaitCore(TimeSpan duration, CancellationToken cancellationToken)
        => Task.Delay(duration, cancellationToken).GetAwaiter().GetResult();

    protected override async Task WaitCoreAsync(TimeSpan duration, CancellationToken cancellationToken)
        => await Task.Delay(duration, cancellationToken).ConfigureAwait(false);
}
