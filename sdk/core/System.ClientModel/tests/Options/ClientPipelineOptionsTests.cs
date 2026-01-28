// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

namespace System.ClientModel.Tests.Options;

public class ClientPipelineOptionsTests : SyncAsyncTestBase
{
    public ClientPipelineOptionsTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task CanAddPerCallPolicy()
    {
        ClientPipelineOptions options = new()
        {
            RetryPolicy = new ObservablePolicy("RetryPolicy"),
            Transport = new ObservableTransport("Transport")
        };

        options.AddPolicy(new ObservablePolicy("PerCallPolicy"), PipelinePosition.PerCall);

        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.That(observations.Count, Is.EqualTo(5));
        Assert.That(observations[index++], Is.EqualTo("Request:PerCallPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Request:RetryPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Transport:Transport"));
        Assert.That(observations[index++], Is.EqualTo("Response:RetryPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:PerCallPolicy"));
    }

    [Test]
    public async Task CanAddPerTryPolicy()
    {
        ClientPipelineOptions options = new()
        {
            RetryPolicy = new ObservablePolicy("RetryPolicy"),
            Transport = new ObservableTransport("Transport")
        };

        options.AddPolicy(new ObservablePolicy("PerTryPolicy"), PipelinePosition.PerTry);

        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.That(observations.Count, Is.EqualTo(5));
        Assert.That(observations[index++], Is.EqualTo("Request:RetryPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Request:PerTryPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Transport:Transport"));
        Assert.That(observations[index++], Is.EqualTo("Response:PerTryPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:RetryPolicy"));
    }

    [Test]
    public async Task CanAddBeforeTransportPolicy()
    {
        ClientPipelineOptions options = new()
        {
            RetryPolicy = new ObservablePolicy("RetryPolicy"),
            Transport = new ObservableTransport("Transport")
        };

        options.AddPolicy(new ObservablePolicy("BeforeTransportPolicy"), PipelinePosition.BeforeTransport);

        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.That(observations.Count, Is.EqualTo(5));
        Assert.That(observations[index++], Is.EqualTo("Request:RetryPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Request:BeforeTransportPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Transport:Transport"));
        Assert.That(observations[index++], Is.EqualTo("Response:BeforeTransportPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:RetryPolicy"));
    }

    [Test]
    public async Task CanAddPoliciesAtAllPositions()
    {
        ClientPipelineOptions options = new()
        {
            Transport = new ObservableTransport("Transport")
        };

        options.AddPolicy(new ObservablePolicy("BeforeTransportPolicyA"), PipelinePosition.BeforeTransport);
        options.AddPolicy(new ObservablePolicy("BeforeTransportPolicyB"), PipelinePosition.BeforeTransport);

        options.AddPolicy(new ObservablePolicy("PerTryPolicyA"), PipelinePosition.PerTry);
        options.AddPolicy(new ObservablePolicy("PerTryPolicyB"), PipelinePosition.PerTry);

        options.AddPolicy(new ObservablePolicy("PerCallPolicyA"), PipelinePosition.PerCall);
        options.AddPolicy(new ObservablePolicy("PerCallPolicyB"), PipelinePosition.PerCall);

        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.That(observations.Count, Is.EqualTo(13));

        Assert.That(observations[index++], Is.EqualTo("Request:PerCallPolicyA"));
        Assert.That(observations[index++], Is.EqualTo("Request:PerCallPolicyB"));

        Assert.That(observations[index++], Is.EqualTo("Request:PerTryPolicyA"));
        Assert.That(observations[index++], Is.EqualTo("Request:PerTryPolicyB"));

        Assert.That(observations[index++], Is.EqualTo("Request:BeforeTransportPolicyA"));
        Assert.That(observations[index++], Is.EqualTo("Request:BeforeTransportPolicyB"));

        Assert.That(observations[index++], Is.EqualTo("Transport:Transport"));

        Assert.That(observations[index++], Is.EqualTo("Response:BeforeTransportPolicyB"));
        Assert.That(observations[index++], Is.EqualTo("Response:BeforeTransportPolicyA"));

        Assert.That(observations[index++], Is.EqualTo("Response:PerTryPolicyB"));
        Assert.That(observations[index++], Is.EqualTo("Response:PerTryPolicyA"));

        Assert.That(observations[index++], Is.EqualTo("Response:PerCallPolicyB"));
        Assert.That(observations[index++], Is.EqualTo("Response:PerCallPolicyA"));
    }

    [Test]
    public void CannotModifyOptionsAfterFrozen()
    {
        ClientPipelineOptions options = new();
        options.ClientLoggingOptions = new();
        ClientPipeline pipeline = ClientPipeline.Create(options);

        Assert.Throws<InvalidOperationException>(()
            => options.RetryPolicy = new MockRetryPolicy());
        Assert.Throws<InvalidOperationException>(()
            => options.MessageLoggingPolicy = new MockPipelinePolicy());
        Assert.Throws<InvalidOperationException>(()
            => options.Transport = new MockPipelineTransport("Transport"));
        Assert.Throws<InvalidOperationException>(()
            => options.NetworkTimeout = TimeSpan.MinValue);
        Assert.Throws<InvalidOperationException>(()
            => options.AddPolicy(new ObservablePolicy("A"), PipelinePosition.PerCall));
        Assert.Throws<InvalidOperationException>(()
            => options.ClientLoggingOptions = new());
        Assert.Throws<InvalidOperationException>(()
            => options.ClientLoggingOptions.EnableLogging = true);
        Assert.Throws<InvalidOperationException>(()
            => options.EnableDistributedTracing = true);
    }

    [Test]
    public void CannotModifyOptionsAfterExplicitlyFrozen()
    {
        ClientPipelineOptions options = new();
        options.ClientLoggingOptions = new();
        options.Freeze();

        Assert.Throws<InvalidOperationException>(()
            => options.RetryPolicy = new MockRetryPolicy());
        Assert.Throws<InvalidOperationException>(()
            => options.MessageLoggingPolicy = new MockPipelinePolicy());
        Assert.Throws<InvalidOperationException>(()
            => options.Transport = new MockPipelineTransport("Transport"));
        Assert.Throws<InvalidOperationException>(()
            => options.NetworkTimeout = TimeSpan.MinValue);
        Assert.Throws<InvalidOperationException>(()
            => options.AddPolicy(new ObservablePolicy("A"), PipelinePosition.PerCall));
        Assert.Throws<InvalidOperationException>(()
            => options.ClientLoggingOptions = new());
        Assert.Throws<InvalidOperationException>(()
            => options.ClientLoggingOptions.EnableLogging = true);
        Assert.Throws<InvalidOperationException>(()
            => options.EnableDistributedTracing = true);
    }

    #region Helpers

    #endregion
}
