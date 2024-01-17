// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Threading.Tasks;

namespace System.ClientModel.Tests.Pipeline;

//public class MessageDelayTests : SyncAsyncTestBase
//{
//    //public MessageDelayTests(bool isAsync) : base(isAsync)
//    //{
//    //}

//    //[Test]
//    //public void DelayComputesDelayCore()
//    //{
//    //    static TimeSpan delayFactory(int i) => TimeSpan.FromSeconds(i);

//    //    MockMessageDelay delay = new MockMessageDelay(delayFactory);

//    //    for (int i = 0; i < 10; i++)
//    //    {
//    //        Assert.AreEqual(delayFactory(i), delay.GetDelay(i));
//    //    }
//    //}

//    //[Test]
//    //public async Task DelayCallsCompleteEvent()
//    //{
//    //    ClientPipeline pipeline = ClientPipeline.Create();
//    //    PipelineMessage message = pipeline.CreateMessage();

//    //    MockMessageDelay delay = new MockMessageDelay();
//    //    await delay.WaitSyncOrAsync(message, IsAsync);

//    //    Assert.IsTrue(delay.IsComplete);
//    //}
//}
