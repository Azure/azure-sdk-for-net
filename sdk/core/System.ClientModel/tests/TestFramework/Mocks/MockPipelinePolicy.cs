// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientModel.Tests.Mocks;

public class MockPipelinePolicy : PipelinePolicy
{
    public bool CalledProcess { get; private set; }

    public Action ProcessDelegate { get; set; }

    public MockPipelinePolicy()
    {
        ProcessDelegate = () => { };
    }

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        CalledProcess = true;

        ProcessDelegate();
    }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        CalledProcess = true;

        ProcessDelegate();
    }

    public void ProcessNext(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex, bool isAsync)
        => ProcessNext(message, pipeline, currentIndex);

    public async Task ProcessNextAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex, bool isAsync)
        => await ProcessNextAsync(message, pipeline, currentIndex).ConfigureAwait(false);
}
