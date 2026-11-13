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
        Assert.AreEqual(5, observations.Count);
        Assert.AreEqual("Request:PerCallPolicy", observations[index++]);
        Assert.AreEqual("Request:RetryPolicy", observations[index++]);
        Assert.AreEqual("Transport:Transport", observations[index++]);
        Assert.AreEqual("Response:RetryPolicy", observations[index++]);
        Assert.AreEqual("Response:PerCallPolicy", observations[index++]);
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
        Assert.AreEqual(5, observations.Count);
        Assert.AreEqual("Request:RetryPolicy", observations[index++]);
        Assert.AreEqual("Request:PerTryPolicy", observations[index++]);
        Assert.AreEqual("Transport:Transport", observations[index++]);
        Assert.AreEqual("Response:PerTryPolicy", observations[index++]);
        Assert.AreEqual("Response:RetryPolicy", observations[index++]);
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
        Assert.AreEqual(5, observations.Count);
        Assert.AreEqual("Request:RetryPolicy", observations[index++]);
        Assert.AreEqual("Request:BeforeTransportPolicy", observations[index++]);
        Assert.AreEqual("Transport:Transport", observations[index++]);
        Assert.AreEqual("Response:BeforeTransportPolicy", observations[index++]);
        Assert.AreEqual("Response:RetryPolicy", observations[index++]);
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
        Assert.AreEqual(13, observations.Count);

        Assert.AreEqual("Request:PerCallPolicyA", observations[index++]);
        Assert.AreEqual("Request:PerCallPolicyB", observations[index++]);

        Assert.AreEqual("Request:PerTryPolicyA", observations[index++]);
        Assert.AreEqual("Request:PerTryPolicyB", observations[index++]);

        Assert.AreEqual("Request:BeforeTransportPolicyA", observations[index++]);
        Assert.AreEqual("Request:BeforeTransportPolicyB", observations[index++]);

        Assert.AreEqual("Transport:Transport", observations[index++]);

        Assert.AreEqual("Response:BeforeTransportPolicyB", observations[index++]);
        Assert.AreEqual("Response:BeforeTransportPolicyA", observations[index++]);

        Assert.AreEqual("Response:PerTryPolicyB", observations[index++]);
        Assert.AreEqual("Response:PerTryPolicyA", observations[index++]);

        Assert.AreEqual("Response:PerCallPolicyB", observations[index++]);
        Assert.AreEqual("Response:PerCallPolicyA", observations[index++]);
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

    [Test]
    public void IsReadOnlyIsFalseByDefault()
    {
        ClientPipelineOptions options = new();
        Assert.IsFalse(options.IsReadOnly);
    }

    [Test]
    public void IsReadOnlyIsTrueAfterPipelineCreation()
    {
        ClientPipelineOptions options = new();
        ClientPipeline.Create(options);
        Assert.IsTrue(options.IsReadOnly);
    }

    [Test]
    public void IsReadOnlyIsTrueAfterExplicitFreeze()
    {
        ClientPipelineOptions options = new();
        options.Freeze();
        Assert.IsTrue(options.IsReadOnly);
    }

    [Test]
    public void CloneCreatesModifiableCopy()
    {
        MockRetryPolicy retryPolicy = new();
        MockPipelinePolicy loggingPolicy = new();
        MockPipelineTransport transport = new MockPipelineTransport("Transport");
        TimeSpan networkTimeout = TimeSpan.FromSeconds(30);
        ClientLoggingOptions loggingOptions = new();
        loggingOptions.EnableLogging = false;

        ClientPipelineOptions original = new()
        {
            RetryPolicy = retryPolicy,
            MessageLoggingPolicy = loggingPolicy,
            Transport = transport,
            NetworkTimeout = networkTimeout,
            ClientLoggingOptions = loggingOptions,
            EnableDistributedTracing = false,
        };
        original.AddPolicy(new ObservablePolicy("PerCall"), PipelinePosition.PerCall);
        original.AddPolicy(new ObservablePolicy("PerTry"), PipelinePosition.PerTry);
        original.AddPolicy(new ObservablePolicy("BeforeTransport"), PipelinePosition.BeforeTransport);
        original.Freeze();

        Assert.IsTrue(original.IsReadOnly);

        // Create a mutable copy from the frozen original
        ClientPipelineOptions copy = original.Clone();

        Assert.IsFalse(copy.IsReadOnly);
        Assert.AreEqual(retryPolicy, copy.RetryPolicy);
        Assert.AreEqual(loggingPolicy, copy.MessageLoggingPolicy);
        Assert.AreEqual(transport, copy.Transport);
        Assert.AreEqual(networkTimeout, copy.NetworkTimeout);
        Assert.AreEqual(false, copy.EnableDistributedTracing);
        Assert.IsNotNull(copy.ClientLoggingOptions);
        Assert.IsFalse(copy.ClientLoggingOptions!.IsReadOnly);
        Assert.AreEqual(false, copy.ClientLoggingOptions!.EnableLogging);

        // The copy should be modifiable
        Assert.DoesNotThrow(() => copy.RetryPolicy = new MockRetryPolicy());
        Assert.DoesNotThrow(() => copy.NetworkTimeout = TimeSpan.FromSeconds(60));
        Assert.DoesNotThrow(() => copy.ClientLoggingOptions!.EnableLogging = true);

        // Original should remain unaffected
        Assert.AreEqual(retryPolicy, original.RetryPolicy);
        Assert.AreEqual(networkTimeout, original.NetworkTimeout);
    }

    [Test]
    public void CloneOfFrozenOptionsIsNotFrozen()
    {
        ClientPipelineOptions options = new();
        ClientPipeline.Create(options);

        Assert.IsTrue(options.IsReadOnly);

        ClientPipelineOptions clone = options.Clone();
        Assert.IsFalse(clone.IsReadOnly);
    }

    #region Helpers

    #endregion
}
