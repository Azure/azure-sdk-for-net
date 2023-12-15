// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.ClientModel.Tests.Pipeline;

public class RequestRetryPolicyTests : SyncAsyncTestBase
{
    public RequestRetryPolicyTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task RetriesErrorResponse()
    {
        PipelineOptions options = new()
        {
            Transport = new RetriableTransport("Transport", new int[] { 429, 200 })
        };
        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;

        // We visited the transport twice due to retries
        Assert.AreEqual(2, observations.Count);
        Assert.AreEqual("Transport:Transport", observations[index++]);
        Assert.AreEqual("Transport:Transport", observations[index++]);
    }

    [Test]
    public async Task DoesNotExceedRetryCount()
    {
        PipelineOptions options = new()
        {
            Transport = new RetriableTransport("Transport", i => 500)
        };
        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;

        // We visited the transport four times due to default max 3 retries
        Assert.AreEqual(4, observations.Count);
        Assert.AreEqual("Transport:Transport", observations[index++]);
        Assert.AreEqual("Transport:Transport", observations[index++]);
        Assert.AreEqual("Transport:Transport", observations[index++]);
        Assert.AreEqual("Transport:Transport", observations[index++]);
    }

    [Test]
    public async Task CanConfigureMaxRetryCount()
    {
        int maxRetryCount = 10;

        PipelineOptions options = new()
        {
            RetryPolicy = new RequestRetryPolicy(maxRetryCount, new MockMessagDelay(i => TimeSpan.FromMilliseconds(10))),
            Transport = new RetriableTransport("Transport", i => 500)
        };
        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        int observationCount = maxRetryCount + 1;

        Assert.AreEqual(observationCount, observations.Count);
        for (int i = 0; i < observationCount; i++)
        {
            Assert.AreEqual("Transport:Transport", observations[index++]);
        }
    }

    [Test]
    public async Task CanConfigureDelay()
    {
        int maxRetryCount = 3;
        MockMessagDelay delay = new MockMessagDelay(i => TimeSpan.FromMilliseconds(10));

        PipelineOptions options = new()
        {
            RetryPolicy = new RequestRetryPolicy(maxRetryCount, delay),
            Transport = new RetriableTransport("Transport", i => 500)
        };
        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);

        Assert.AreEqual(maxRetryCount, delay.CompletionCount);
    }

    //[Test]
    //public async Task OnlyRetriesRetriableCodes()
    //{
    //}
}
