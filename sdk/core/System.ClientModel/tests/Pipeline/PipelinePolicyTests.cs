// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.ClientModel.Tests.Pipeline;

public class PipelinePolicyTests : SyncAsyncTestBase
{
    public PipelinePolicyTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task ProcessNextCallsNext()
    {
        ClientPipelineOptions options = new ClientPipelineOptions()
        {
            Transport = new ObservableTransport("Transport")
        };

        ClientPipeline pipeline = ClientPipeline.Create(options);
        PipelineMessage message = pipeline.CreateMessage();

        MockPipelinePolicy first = new MockPipelinePolicy();
        MockPipelinePolicy last = new MockPipelinePolicy();

        IReadOnlyList<PipelinePolicy> policies = new List<PipelinePolicy>()
        {
            first,
            last
        };

        await first.ProcessNextSyncOrAsync(message, policies, 0, IsAsync).ConfigureAwait(false);

        Assert.IsFalse(first.CalledProcess);
        Assert.IsTrue(last.CalledProcess);
    }
}
