// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using ClientModel.Tests.Mocks;
using NUnit.Framework;
using SyncAsyncTestBase = ClientModel.Tests.SyncAsyncTestBase;

namespace System.ClientModel.Tests.Message;

public class PipelineMessageTests : SyncAsyncTestBase
{
    public PipelineMessageTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public void ApplyAddsRequestHeaders()
    {
        ClientPipeline pipeline = ClientPipeline.Create();
        PipelineMessage message = pipeline.CreateMessage();

        RequestOptions options = new RequestOptions();
        options.AddHeader("MockHeader", "MockValue");
        message.Apply(options);

        Assert.That(message.Request.Headers.TryGetValue("MockHeader", out string? value), Is.True);
        Assert.That(value, Is.EqualTo("MockValue"));
    }

    [Test]
    public void ApplySetsCancellationToken()
    {
        ClientPipeline pipeline = ClientPipeline.Create();
        PipelineMessage message = pipeline.CreateMessage();

        int msDelay = 234567;
        CancellationTokenSource cts = new CancellationTokenSource(msDelay);

        RequestOptions options = new RequestOptions();
        options.CancellationToken = cts.Token;
        message.Apply(options);

        Assert.That(cts.Token, Is.EqualTo(message.CancellationToken));
        Assert.That(message.CancellationToken.IsCancellationRequested, Is.False);

        cts.Cancel();

        Assert.That(message.CancellationToken.IsCancellationRequested, Is.True);
    }

    [Test]
    public void NullOptionsIsNoOp()
    {
        ClientPipeline pipeline = ClientPipeline.Create();
        PipelineMessage message = pipeline.CreateMessage();
        Assert.DoesNotThrow(() => message.Apply(null));
    }

    [Test]
    public void CanSetAndGetMessageProperties()
    {
        ClientPipeline pipeline = ClientPipeline.Create();
        PipelineMessage message = pipeline.CreateMessage();

        message.SetProperty(GetType(), "MockProperty");

        Assert.That(message.TryGetProperty(GetType(), out object? property), Is.True);
        Assert.That(property, Is.EqualTo("MockProperty"));
    }

    [Test]
    public void TryGetPropertyReturnsFalseIfNotExist()
    {
        ClientPipeline pipeline = ClientPipeline.Create();
        PipelineMessage message = pipeline.CreateMessage();

        Assert.That(message.TryGetProperty(GetType(), out _), Is.False);
    }

    [Test]
    public void TryGetPropertyReturnsValueIfSet()
    {
        ClientPipeline pipeline = ClientPipeline.Create();
        PipelineMessage message = pipeline.CreateMessage();

        message.SetProperty(GetType(), "value");

        Assert.That(message.TryGetProperty(GetType(), out object? value), Is.True);
        Assert.That(value, Is.EqualTo("value"));
    }

    [Test]
    public void TryGetTypeKeyedPropertyReturnsCorrectValues()
    {
        ClientPipeline pipeline = ClientPipeline.Create();
        PipelineMessage message = pipeline.CreateMessage();

        int readLoops = 10;
        var t3 = new T3() { Value = 1234 };
        message.SetProperty(typeof(T1), new T1() { Value = 1111 });
        message.SetProperty(typeof(T2), new T2() { Value = 2222 });
        message.SetProperty(typeof(T3), new T3() { Value = 3333 });
        message.SetProperty(typeof(T4), new T4() { Value = 4444 });

        message.TryGetProperty(typeof(T1), out var value);
        Assert.That(((T1)value!).Value, Is.EqualTo(1111));
        message.TryGetProperty(typeof(T2), out value);
        Assert.That(((T2)value!).Value, Is.EqualTo(2222));
        message.TryGetProperty(typeof(T3), out value);
        Assert.That(((T3)value!).Value, Is.EqualTo(3333));
        message.TryGetProperty(typeof(T4), out value);
        Assert.That(((T4)value!).Value, Is.EqualTo(4444));

        for (int i = 0; i < readLoops; i++)
        {
            t3.Value = i;
            message.SetProperty(typeof(T3), t3);
            message.TryGetProperty(typeof(T3), out value);
            Assert.That(((T3)value!).Value, Is.EqualTo(i));
        }

        message.TryGetProperty(typeof(T4), out value);
        Assert.That(((T4)value!).Value, Is.EqualTo(4444));
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public async Task ResponseStreamAccessibleAfterMessageDisposed(bool buffer)
    {
        byte[] serverBytes = new byte[1000];
        new Random().NextBytes(serverBytes);

        ClientPipelineOptions options = new() { NetworkTimeout = Timeout.InfiniteTimeSpan };
        ClientPipeline pipeline = ClientPipeline.Create(options);

        using TestServer testServer = new(async context =>
        {
            await context.Response.Body.WriteAsync(serverBytes, 0, serverBytes.Length).ConfigureAwait(false);
        });

        PipelineResponse? response;
        using (PipelineMessage message = pipeline.CreateMessage())
        {
            message.Request.Uri = testServer.Address;
            message.BufferResponse = buffer;

            await pipeline.SendSyncOrAsync(message, IsAsync);

            response = message.ExtractResponse();

            Assert.That(message.Response, Is.Null);
        }

        Assert.That(response!.ContentStream, Is.Not.Null);

        byte[] clientBytes = new byte[serverBytes.Length];
        int readLength = 0;
        while (readLength < serverBytes.Length)
        {
            readLength += await response.ContentStream!.ReadAsync(clientBytes, 0, serverBytes.Length);
        }

        Assert.That(readLength, Is.EqualTo(serverBytes.Length));
        Assert.That(clientBytes, Is.EqualTo(serverBytes).AsCollection);
    }

    #region Helpers
    private struct T1
    {
        public int Value { get; set; }
    }

    private struct T2
    {
        public int Value { get; set; }
    }

    private struct T3
    {
        public int Value { get; set; }
    }

    private struct T4
    {
        public int Value { get; set; }
    }

    private struct T5
    {
        public int Value { get; set; }
    }
    #endregion
}
