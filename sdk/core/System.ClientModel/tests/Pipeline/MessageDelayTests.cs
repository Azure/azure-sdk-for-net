// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Threading.Tasks;

namespace System.ClientModel.Tests.Pipeline;

public class MessageDelayTests : SyncAsyncTestBase
{
    public MessageDelayTests(bool isAsync) : base(isAsync)
    {
    }

    // TODO: Find a new approach here
    //[Test]
    //public async Task DelayWaitsForWaitCore()
    //{
    //    ClientPipeline pipeline = ClientPipeline.Create();
    //    PipelineMessage message = pipeline.CreateMessage();

    //    MockMessagDelay delay = new MockMessagDelay(i => TimeSpan.FromSeconds(1));

    //    await delay.ReleaseWait();
    //    Task task = delay.DelaySyncOrAsync(message, IsAsync);

    //    Assert.IsFalse(delay.IsComplete);

    //    await delay.ReleaseWait();
    //    await task;

    //    Assert.IsTrue(delay.IsComplete);
    //}

    [Test]
    public void DelayComputesDelayCore()
    {
        MockMessagDelay delay = new MockMessagDelay();
        Assert.AreEqual(TimeSpan.FromSeconds(1), delay.GetDelay(1));
        Assert.AreEqual(TimeSpan.FromSeconds(2), delay.GetDelay(2));
        Assert.AreEqual(TimeSpan.FromSeconds(3), delay.GetDelay(3));
    }

    [Test]
    public async Task DelayCallsCompleteEvent()
    {
        ClientPipeline pipeline = ClientPipeline.Create();
        PipelineMessage message = pipeline.CreateMessage();

        MockMessagDelay delay = new MockMessagDelay();
        await delay.DelaySyncOrAsync(message, IsAsync);

        Assert.IsTrue(delay.IsComplete);
    }
}
