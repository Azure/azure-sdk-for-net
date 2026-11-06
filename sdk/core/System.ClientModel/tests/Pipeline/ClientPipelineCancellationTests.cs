// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Pipeline;

public class ClientPipelineCancellationTests : SyncAsyncTestBase
{
    public ClientPipelineCancellationTests(bool isAsync) : base(isAsync)
    {
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task SendReplacesAppliedToken(bool useDefaultToken)
    {
        using CancellationTokenSource originalSource = new();
        using CancellationTokenSource overrideSource = new();
        originalSource.Cancel();
        CancellationToken token = useDefaultToken ? CancellationToken.None : overrideSource.Token;
        RequestOptions options = new() { CancellationToken = originalSource.Token };
        options.AddPolicy(new TokenObservingPolicy("PerCall", token), PipelinePosition.PerCall);
        options.AddPolicy(new TokenObservingPolicy("PerTry", token), PipelinePosition.PerTry);
        options.AddPolicy(new TokenObservingPolicy("BeforeTransport", token), PipelinePosition.BeforeTransport);
        ClientPipeline pipeline = ClientPipeline.Create(new ClientPipelineOptions
        {
            Transport = new MockPipelineTransport("Transport", message =>
            {
                Assert.False(message.CancellationToken.IsCancellationRequested);
                return new MockPipelineResponse(200);
            })
        });

        using PipelineMessage message = pipeline.CreateMessage();
        message.Apply(options);
        await pipeline.SendSyncOrAsync(message, token, IsAsync);

        Assert.AreEqual(token, message.CancellationToken);
        Assert.AreEqual(originalSource.Token, options.CancellationToken);
        CollectionAssert.AreEqual(new[]
        {
            "Request:PerCall", "Request:PerTry", "Request:BeforeTransport",
            "Transport:Transport",
            "Response:BeforeTransport", "Response:PerTry", "Response:PerCall"
        }, ObservablePolicy.GetData(message));
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task SendUsesExplicitTokenWithoutOptions(bool useDefaultToken)
    {
        using CancellationTokenSource source = new();
        CancellationToken token = useDefaultToken ? CancellationToken.None : source.Token;
        ClientPipelineOptions options = new() { Transport = new MockPipelineTransport("Transport", 200) };
        options.AddPolicy(new TokenObservingPolicy("PerCall", token), PipelinePosition.PerCall);
        ClientPipeline pipeline = ClientPipeline.Create(options);
        using PipelineMessage message = pipeline.CreateMessage();

        await pipeline.SendSyncOrAsync(message, token, IsAsync);

        Assert.AreEqual(token, message.CancellationToken);
        Assert.AreEqual(200, message.Response!.Status);
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task ExistingSendPreservesMessageToken(bool applyOptions)
    {
        using CancellationTokenSource source = new();
        CancellationToken token = applyOptions ? source.Token : CancellationToken.None;
        ClientPipelineOptions pipelineOptions = new() { Transport = new MockPipelineTransport("Transport", 200) };
        pipelineOptions.AddPolicy(new TokenObservingPolicy("PerCall", token), PipelinePosition.PerCall);
        ClientPipeline pipeline = ClientPipeline.Create(pipelineOptions);
        using PipelineMessage message = pipeline.CreateMessage();
        if (applyOptions)
        {
            message.Apply(new RequestOptions { CancellationToken = token });
        }

        await pipeline.SendSyncOrAsync(message, IsAsync);

        Assert.AreEqual(token, message.CancellationToken);
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task SendPreservesAppliedRequestOptions(bool bufferResponse)
    {
        using CancellationTokenSource originalSource = new();
        using CancellationTokenSource overrideSource = new();
        CustomRequestOptions options = new()
        {
            CancellationToken = originalSource.Token,
            BufferResponse = bufferResponse,
            ErrorOptions = ClientErrorBehaviors.NoThrow
        };
        options.AddHeader("Custom-Add", "first");
        options.AddHeader("Custom-Add", "second");
        options.SetHeader("Custom-Set", "updated");
        options.AddPolicy(new ObservablePolicy("PerCall"), PipelinePosition.PerCall);
        options.AddPolicy(new ObservablePolicy("PerTry"), PipelinePosition.PerTry);
        options.AddPolicy(new ObservablePolicy("BeforeTransport"), PipelinePosition.BeforeTransport);
        ClientPipeline pipeline = ClientPipeline.Create(new ClientPipelineOptions
        {
            Transport = new MockPipelineTransport("Transport", 400)
        });
        using PipelineMessage message = pipeline.CreateMessage();
        message.Request.Headers.Set("Custom-Set", "original");
        message.Apply(options);
        PipelineMessageClassifier classifier = message.ResponseClassifier;
        TimeSpan? networkTimeout = message.NetworkTimeout;

        await pipeline.SendSyncOrAsync(message, overrideSource.Token, IsAsync);

        Assert.AreEqual(overrideSource.Token, message.CancellationToken);
        Assert.AreEqual(originalSource.Token, options.CancellationToken);
        Assert.AreEqual(ClientErrorBehaviors.NoThrow, options.ErrorOptions);
        Assert.AreEqual(bufferResponse, message.BufferResponse);
        Assert.AreEqual(networkTimeout, message.NetworkTimeout);
        Assert.AreSame(classifier, message.ResponseClassifier);
        Assert.False(message.Response!.IsError);
        Assert.True(message.Request.Headers.TryGetValue("Custom-Add", out string? added));
        Assert.AreEqual("first,second", added);
        Assert.True(message.Request.Headers.TryGetValue("Custom-Set", out string? updated));
        Assert.AreEqual("updated", updated);
        Assert.True(message.TryGetProperty(typeof(CustomRequestOptions), out object? property));
        Assert.AreSame(options, property);
        Assert.AreEqual(1, options.ApplyCount);
        Assert.Throws<InvalidOperationException>(() => options.CancellationToken = overrideSource.Token);
        CollectionAssert.AreEqual(new[]
        {
            "Request:PerCall", "Request:PerTry", "Request:BeforeTransport",
            "Transport:Transport",
            "Response:BeforeTransport", "Response:PerTry", "Response:PerCall"
        }, ObservablePolicy.GetData(message));
    }

    [Test]
    public void SendRejectsNullMessage()
    {
        ClientPipeline pipeline = ClientPipeline.Create();

        ArgumentNullException? exception = Assert.ThrowsAsync<ArgumentNullException>(
            async () => await pipeline.SendSyncOrAsync(null!, CancellationToken.None, IsAsync));

        Assert.AreEqual("message", exception!.ParamName);
    }

    [TestCase(false)]
    [TestCase(true)]
    public void SendHonorsPreCanceledToken(bool useOverride)
    {
        using CancellationTokenSource source = new();
        source.Cancel();
        int requests = 0;
        using HttpClient client = new(new MockHttpClientHandler((_, token) =>
        {
            Interlocked.Increment(ref requests);
            Assert.True(token.IsCancellationRequested);
            token.ThrowIfCancellationRequested();
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }));
        ClientPipeline pipeline = ClientPipeline.Create(new ClientPipelineOptions
        {
            Transport = new HttpClientPipelineTransport(client)
        });
        RequestOptions options = new() { CancellationToken = useOverride ? CancellationToken.None : source.Token };
        using PipelineMessage message = pipeline.CreateMessage(new Uri("https://example.com"), "GET");
        message.Apply(options);

        OperationCanceledException? exception = Assert.CatchAsync<OperationCanceledException>(
            async () =>
            {
                if (useOverride)
                {
                    await pipeline.SendSyncOrAsync(message, source.Token, IsAsync);
                }
                else
                {
                    await pipeline.SendSyncOrAsync(message, IsAsync);
                }
            });

#if NETCOREAPP2_1_OR_GREATER
        Assert.AreEqual(source.Token, exception!.CancellationToken);
#endif
        Assert.AreEqual(source.Token, message.CancellationToken);
        Assert.AreEqual(useOverride ? CancellationToken.None : source.Token, options.CancellationToken);
        Assert.AreEqual(1, requests);
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task SendPreservesResponseBuffering(bool bufferResponse)
    {
        using CancellationTokenSource source = new();
        using HttpClient client = new(new MockHttpClientHandler(_ =>
            Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("Response content")
            })));
        ClientPipeline pipeline = ClientPipeline.Create(new ClientPipelineOptions
        {
            Transport = new HttpClientPipelineTransport(client)
        });
        RequestOptions options = new() { BufferResponse = bufferResponse };
        using PipelineMessage message = pipeline.CreateMessage(new Uri("https://example.com"), "GET");
        message.Apply(options);

        await pipeline.SendSyncOrAsync(message, source.Token, IsAsync);

        Assert.AreEqual(bufferResponse, message.BufferResponse);
        if (bufferResponse)
        {
            Assert.AreEqual("Response content", message.Response!.Content.ToString());
        }
        else
        {
            Assert.Throws<InvalidOperationException>(() => _ = message.Response!.Content);
            Assert.IsNotNull(message.Response!.ContentStream);
        }
    }

    [Test]
    public async Task SendCancelsInFlightWithoutRetry()
    {
        using CancellationTokenSource originalSource = new();
        using CancellationTokenSource overrideSource = new(TimeSpan.FromSeconds(30));
        TaskCompletionSource<bool> started = new(TaskCreationOptions.RunContinuationsAsynchronously);
        int requests = 0;
        using HttpClient client = new(new MockHttpClientHandler(async (_, token) =>
        {
            Interlocked.Increment(ref requests);
            started.TrySetResult(true);
            await Task.Delay(Timeout.Infinite, token);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }));
        ClientPipeline pipeline = ClientPipeline.Create(new ClientPipelineOptions
        {
            Transport = new HttpClientPipelineTransport(client)
        });
        RequestOptions options = new() { CancellationToken = originalSource.Token };
        using PipelineMessage message = pipeline.CreateMessage(new Uri("https://example.com"), "GET");
        message.Apply(options);
        Task send = Task.Run(() => pipeline.SendSyncOrAsync(message, overrideSource.Token, IsAsync));

        try
        {
            await AssertCompletes(started.Task);
            originalSource.Cancel();
            Assert.False(message.CancellationToken.IsCancellationRequested);
            overrideSource.Cancel();
            await AssertCompletes(send);

            OperationCanceledException? exception = Assert.CatchAsync<OperationCanceledException>(async () => await send);
#if NETCOREAPP2_1_OR_GREATER
            Assert.AreEqual(overrideSource.Token, exception!.CancellationToken);
#endif
            Assert.AreEqual(overrideSource.Token, message.CancellationToken);
            Assert.AreEqual(originalSource.Token, options.CancellationToken);
            Assert.AreEqual(1, requests);
        }
        finally
        {
            overrideSource.Cancel();
        }
    }

    [Test]
    public async Task SharedFrozenOptionsSupportIndependentConcurrentSends()
    {
        using CancellationTokenSource originalSource = new();
        using CancellationTokenSource firstSource = new(TimeSpan.FromSeconds(30));
        using CancellationTokenSource secondSource = new(TimeSpan.FromSeconds(30));
        TaskCompletionSource<bool> firstStarted = new(TaskCreationOptions.RunContinuationsAsynchronously);
        TaskCompletionSource<bool> secondStarted = new(TaskCreationOptions.RunContinuationsAsynchronously);
        TaskCompletionSource<bool> releaseSecond = new(TaskCreationOptions.RunContinuationsAsynchronously);
        using HttpClient client = new(new MockHttpClientHandler(async (request, token) =>
        {
            if (request.RequestUri!.AbsolutePath == "/first")
            {
                firstStarted.TrySetResult(true);
                await Task.Delay(Timeout.Infinite, token);
            }
            else
            {
                secondStarted.TrySetResult(true);
                await releaseSecond.Task;
                token.ThrowIfCancellationRequested();
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }));
        ClientPipeline pipeline = ClientPipeline.Create(new ClientPipelineOptions
        {
            Transport = new HttpClientPipelineTransport(client)
        });
        RequestOptions options = new() { CancellationToken = originalSource.Token };
        options.SetHeader("Shared-Header", "shared");
        options.AddPolicy(new ObservablePolicy("SharedPolicy"), PipelinePosition.PerCall);
        using PipelineMessage first = pipeline.CreateMessage(new Uri("https://example.com/first"), "GET");
        using PipelineMessage second = pipeline.CreateMessage(new Uri("https://example.com/second"), "GET");
        first.Apply(options);
        second.Apply(options);

        Task firstSend = Task.Run(() => pipeline.SendSyncOrAsync(first, firstSource.Token, IsAsync));
        Task secondSend = Task.Run(() => pipeline.SendSyncOrAsync(second, secondSource.Token, IsAsync));

        try
        {
            await AssertCompletes(Task.WhenAll(firstStarted.Task, secondStarted.Task));
            firstSource.Cancel();
            await AssertCompletes(firstSend);
            Assert.CatchAsync<OperationCanceledException>(async () => await firstSend);
            Assert.False(second.CancellationToken.IsCancellationRequested);
            Assert.False(secondSend.IsCompleted);
            releaseSecond.SetResult(true);
            await AssertCompletes(secondSend);
            await secondSend;

            Assert.AreEqual(firstSource.Token, first.CancellationToken);
            Assert.AreEqual(secondSource.Token, second.CancellationToken);
            Assert.AreEqual(originalSource.Token, options.CancellationToken);
            Assert.Throws<InvalidOperationException>(() => options.CancellationToken = secondSource.Token);
            foreach (PipelineMessage message in new[] { first, second })
            {
                Assert.True(message.Request.Headers.TryGetValue("Shared-Header", out string? header));
                Assert.AreEqual("shared", header);
                CollectionAssert.Contains(ObservablePolicy.GetData(message), "Request:SharedPolicy");
            }
        }
        finally
        {
            firstSource.Cancel();
            secondSource.Cancel();
            releaseSecond.TrySetResult(true);
        }
    }

    private static async Task AssertCompletes(Task task)
    {
        Assert.AreSame(task, await Task.WhenAny(task, Task.Delay(TimeSpan.FromSeconds(10))));
    }

    private sealed class CustomRequestOptions : RequestOptions
    {
        public int ApplyCount { get; private set; }

        protected internal override void Apply(PipelineMessage message)
        {
            base.Apply(message);
            ApplyCount++;
            message.SetProperty(typeof(CustomRequestOptions), this);
            message.ResponseClassifier = PipelineMessageClassifier.Create(stackalloc ushort[] { 400 });
        }
    }

    private sealed class TokenObservingPolicy : ObservablePolicy
    {
        private readonly CancellationToken _expectedToken;

        public TokenObservingPolicy(string id, CancellationToken expectedToken) : base(id)
        {
            _expectedToken = expectedToken;
        }

        public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            Assert.AreEqual(_expectedToken, message.CancellationToken);
            base.Process(message, pipeline, currentIndex);
        }

        public override ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            Assert.AreEqual(_expectedToken, message.CancellationToken);
            return base.ProcessAsync(message, pipeline, currentIndex);
        }
    }
}
