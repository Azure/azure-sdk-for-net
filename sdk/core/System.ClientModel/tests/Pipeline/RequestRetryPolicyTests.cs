﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
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

        Assert.AreEqual(200, message.Response!.Status);
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

        Assert.AreEqual(500, message.Response!.Status);
    }

    [Test]
    public async Task CanConfigureMaxRetryCount()
    {
        int maxRetryCount = 10;

        PipelineOptions options = new()
        {
            RetryPolicy = new RequestRetryPolicy(maxRetryCount, new MockMessageDelay(i => TimeSpan.FromMilliseconds(10))),
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

        Assert.AreEqual(500, message.Response!.Status);
    }

    [Test]
    public async Task CanConfigureDelay()
    {
        int maxRetryCount = 3;
        MockMessageDelay delay = new MockMessageDelay(i => TimeSpan.FromMilliseconds(10));

        PipelineOptions options = new()
        {
            RetryPolicy = new RequestRetryPolicy(maxRetryCount, delay),
            Transport = new RetriableTransport("Transport", i => 500)
        };
        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);

        Assert.AreEqual(maxRetryCount, delay.CompletionCount);
        Assert.AreEqual(500, message.Response!.Status);
    }

    [Test]
    public async Task OnlyRetriesRetriableCodes()
    {
        // Retriable codes are hard-coded into the ClientModel retry policy today:
        // 408, 429, 500, 502, 503, and 504.  501 should not be retried.

        PipelineOptions options = new()
        {
            RetryPolicy = new RequestRetryPolicy(maxRetries: 10, new MockMessageDelay()),
            Transport = new RetriableTransport("Transport",
                new int[] { 408, 429, 500, 502, 503, 504, 501 })
        };
        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);

        List<string> observations = ObservablePolicy.GetData(message);

        int observationCount = 7;
        int index = 0;

        // We visited the transport seven times and stopped on the 501 response.
        Assert.AreEqual(observationCount, observations.Count);
        for (int i = 0; i < observationCount; i++)
        {
            Assert.AreEqual("Transport:Transport", observations[index++]);
        }

        Assert.AreEqual(501, message.Response!.Status);
    }

    [Test]
    public async Task ShouldRetryIsCalledOnlyForErrors()
    {
        Exception retriableException = new IOException();

        MockRetryPolicy retryPolicy = new MockRetryPolicy();
        RetriableTransport transport = new RetriableTransport("Transport", responseFactory);

        int responseFactory(int i)
            => i switch
            {
                0 => 500,
                1 => throw retriableException,
                2 => 200,
                _ => throw new InvalidOperationException(),
            };

        PipelineOptions options = new()
        {
            RetryPolicy = retryPolicy,
            Transport = transport,
        };
        ClientPipeline pipeline = ClientPipeline.Create(options);

        // Validate the state of the retry policy at the transport.
        transport.OnSendingRequest = i =>
        {
            switch (i)
            {
                case 0:
                    Assert.IsFalse(retryPolicy.ShouldRetryCalled);
                    Assert.IsNull(retryPolicy.LastException);
                    break;
                case 1:
                    Assert.IsTrue(retryPolicy.ShouldRetryCalled);
                    Assert.IsNull(retryPolicy.LastException);
                    retryPolicy.Reset();
                    break;
                case 2:
                    Assert.IsTrue(retryPolicy.ShouldRetryCalled);
                    Assert.AreSame(retriableException, retryPolicy.LastException);
                    retryPolicy.Reset();
                    break;
                default:
                    throw new InvalidOperationException();
            }
        };

        PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);

        // Validate last iteration through retry policy handling, i.e. after 200 response
        Assert.IsFalse(retryPolicy.ShouldRetryCalled);
        Assert.IsNull(retryPolicy.LastException);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;

        // We visited the transport three times due to retries
        Assert.AreEqual(3, observations.Count);
        Assert.AreEqual("Transport:Transport", observations[index++]);
        Assert.AreEqual("Transport:Transport", observations[index++]);
        Assert.AreEqual("Transport:Transport", observations[index++]);

        Assert.AreEqual(200, message.Response!.Status);
    }

    [Test]
    public async Task CallbacksAreCalledForErrorResponseAndException()
    {
        Exception retriableException = new IOException();

        MockRetryPolicy retryPolicy = new MockRetryPolicy();
        RetriableTransport transport = new RetriableTransport("Transport", responseFactory);

        int responseFactory(int i)
            => i switch
            {
                0 => 500,
                1 => throw retriableException,
                2 => 200,
                _ => throw new InvalidOperationException(),
            };

        PipelineOptions options = new()
        {
            RetryPolicy = retryPolicy,
            Transport = transport,
        };
        ClientPipeline pipeline = ClientPipeline.Create(options);

        // Validate the state of the retry policy at the transport.
        transport.OnSendingRequest = i =>
        {
            switch (i)
            {
                case 0:
                    Assert.IsTrue(retryPolicy.OnSendingRequestCalled);
                    Assert.IsFalse(retryPolicy.OnRequestSentCalled);
                    Assert.IsNull(retryPolicy.LastException);
                    break;
                case 1:
                    Assert.IsTrue(retryPolicy.OnSendingRequestCalled);
                    Assert.IsTrue(retryPolicy.OnRequestSentCalled);
                    Assert.IsNull(retryPolicy.LastException);
                    retryPolicy.Reset();
                    break;
                case 2:
                    Assert.IsTrue(retryPolicy.OnSendingRequestCalled);
                    Assert.IsTrue(retryPolicy.OnRequestSentCalled);
                    Assert.AreSame(retriableException, retryPolicy.LastException);
                    retryPolicy.Reset();
                    break;
                default:
                    throw new InvalidOperationException();
            }
        };

        PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);

        // Validate last iteration through retry policy handling, i.e. after 200 response
        Assert.IsFalse(retryPolicy.OnSendingRequestCalled);
        Assert.IsTrue(retryPolicy.OnRequestSentCalled);
        Assert.IsNull(retryPolicy.LastException);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;

        // We visited the transport three times due to retries
        Assert.AreEqual(3, observations.Count);
        Assert.AreEqual("Transport:Transport", observations[index++]);
        Assert.AreEqual("Transport:Transport", observations[index++]);
        Assert.AreEqual("Transport:Transport", observations[index++]);

        Assert.AreEqual(200, message.Response!.Status);
    }

    [Test]
    public async Task RetriesWithPolly()
    {
        PipelineOptions options = new()
        {
            RetryPolicy = new PollyRetryPolicy(),
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

        Assert.AreEqual(200, message.Response!.Status);
    }

    [Test]
    public void RethrowsAggregateExceptionAfterMaxRetryCount()
    {
        List<Exception> exceptions = new() {
            new IOException(),
            new IOException(),
            new IOException(),
            new IOException() };

        MockRetryPolicy retryPolicy = new MockRetryPolicy();
        RetriableTransport transport = new RetriableTransport("Transport", responseFactory);

        int responseFactory(int i)
            => i switch
            {
                0 => throw exceptions[i],
                1 => throw exceptions[i],
                2 => throw exceptions[i],
                3 => throw exceptions[i],
                _ => throw new InvalidOperationException(),
            };

        PipelineOptions options = new()
        {
            RetryPolicy = retryPolicy,
            Transport = transport,
        };
        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        AggregateException? exception = Assert.ThrowsAsync<AggregateException>(async ()
            => await pipeline.SendSyncOrAsync(message, IsAsync));

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;

        // We visited the transport four times due to retries
        Assert.AreEqual(4, observations.Count);
        Assert.AreEqual("Transport:Transport", observations[index++]);
        Assert.AreEqual("Transport:Transport", observations[index++]);
        Assert.AreEqual("Transport:Transport", observations[index++]);
        Assert.AreEqual("Transport:Transport", observations[index++]);

        StringAssert.StartsWith("Retry failed after 4 tries.", exception!.Message);
        CollectionAssert.AreEqual(exceptions, exception.InnerExceptions);
    }
}