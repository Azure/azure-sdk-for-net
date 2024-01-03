// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

namespace ClientModel.Tests.Mocks;

public class MockMessageDelay : MessageDelay
{
    private int _completionCount;

    private static readonly Func<int, TimeSpan> DefaultDelayFactory =
        count => TimeSpan.FromMilliseconds(count * 10);

    private readonly Func<int, TimeSpan> _delayFactory;

    public MockMessageDelay() : this(DefaultDelayFactory) { }

    public MockMessageDelay(Func<int, TimeSpan> delayFactory)
    {
        _delayFactory = delayFactory;
    }

    public bool IsComplete => _completionCount > 0;

    public int CompletionCount => _completionCount;

    public TimeSpan GetDelay(int count) => GetDelayCore(null!, count);

    protected override TimeSpan GetDelayCore(PipelineMessage message, int delayCount)
        => _delayFactory(delayCount);

    protected override void OnDelayComplete(PipelineMessage message)
        => _completionCount++;

    protected override void WaitCore(TimeSpan duration, CancellationToken cancellationToken)
        => Task.Delay(duration, cancellationToken).GetAwaiter().GetResult();

    protected override async Task WaitCoreAsync(TimeSpan duration, CancellationToken cancellationToken)
        => await Task.Delay(duration, cancellationToken).ConfigureAwait(false);
}
