// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.ClientModel.Tests.Pipeline;

public class ClientPipelineTests : SyncAsyncTestBase
{
    public ClientPipelineTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task CanEnumeratePipeline()
    {
        ClientPipelineOptions options = new();
        options.Transport = new ObservableTransport("Transport");
        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.AreEqual(1, observations.Count);
        Assert.AreEqual("Transport:Transport", observations[index++]);
    }
}
