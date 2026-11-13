// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.AI.Projects.Agents.Tests;

internal partial class TestPipelinePolicy : PipelinePolicy
{
    private Action<PipelineMessage> _processMessageAction;

    public TestPipelinePolicy(Action<PipelineMessage> processMessageAction)
    {
        _processMessageAction = processMessageAction;
    }

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        _processMessageAction(message); // for request
        System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
        try
        {
            ProcessNext(message, pipeline, currentIndex);
        }
        finally
        {
            Console.WriteLine($"Response time {stopwatch.Elapsed.TotalMilliseconds} ms");
        }
        _processMessageAction(message); // for response
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        _processMessageAction(message); // for request
        System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
        try
        {
            await ProcessNextAsync(message, pipeline, currentIndex);
        }
        finally
        {
            Console.WriteLine($"Response time {stopwatch.Elapsed.TotalMilliseconds} ms");
        }
        _processMessageAction(message); // for response
    }
}
