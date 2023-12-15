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

    //    MockMessageDelay delay = new MockMessageDelay(i => TimeSpan.FromSeconds(1));

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
        static TimeSpan delayFactory(int i) => TimeSpan.FromSeconds(i);

        MockMessageDelay delay = new MockMessageDelay(delayFactory);

        for (int i = 0; i < 10; i++)
        {
            Assert.AreEqual(delayFactory(i), delay.GetDelay(i));
        }
    }

    [Test]
    public async Task DelayCallsCompleteEvent()
    {
        ClientPipeline pipeline = ClientPipeline.Create();
        PipelineMessage message = pipeline.CreateMessage();

        MockMessageDelay delay = new MockMessageDelay();
        await delay.DelaySyncOrAsync(message, IsAsync);

        Assert.IsTrue(delay.IsComplete);
    }
}
