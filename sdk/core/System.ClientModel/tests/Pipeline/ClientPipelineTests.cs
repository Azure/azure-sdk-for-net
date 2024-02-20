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
    public async Task CanSetCustomTransport()
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

    [Test]
    public async Task CanCreateWithPerCallPolicies()
    {
        ClientPipelineOptions options = new()
        {
            RetryPolicy = new ObservablePolicy("RetryPolicy"),
            Transport = new ObservableTransport("Transport")
        };

        PipelinePolicy[] perCallPolicies = new PipelinePolicy[]
        {
            new ObservablePolicy("PerCallPolicyA"),
            new ObservablePolicy("PerCallPolicyB"),
        };

        ClientPipeline pipeline = ClientPipeline.Create(options,
            perCallPolicies: perCallPolicies,
            perTryPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);

        PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.AreEqual(7, observations.Count);
        Assert.AreEqual("Request:PerCallPolicyA", observations[index++]);
        Assert.AreEqual("Request:PerCallPolicyB", observations[index++]);
        Assert.AreEqual("Request:RetryPolicy", observations[index++]);
        Assert.AreEqual("Transport:Transport", observations[index++]);
        Assert.AreEqual("Response:RetryPolicy", observations[index++]);
        Assert.AreEqual("Response:PerCallPolicyB", observations[index++]);
        Assert.AreEqual("Response:PerCallPolicyA", observations[index++]);
    }

    [Test]
    public async Task CanCreateWithPerTryPolicies()
    {
        ClientPipelineOptions options = new()
        {
            RetryPolicy = new ObservablePolicy("RetryPolicy"),
            Transport = new ObservableTransport("Transport")
        };

        PipelinePolicy[] perTryPolicies = new PipelinePolicy[]
        {
            new ObservablePolicy("PerTryPolicyA"),
            new ObservablePolicy("PerTryPolicyB"),
        };

        ClientPipeline pipeline = ClientPipeline.Create(options,
            perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            perTryPolicies: perTryPolicies,
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);

        PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.AreEqual(7, observations.Count);
        Assert.AreEqual("Request:RetryPolicy", observations[index++]);
        Assert.AreEqual("Request:PerTryPolicyA", observations[index++]);
        Assert.AreEqual("Request:PerTryPolicyB", observations[index++]);
        Assert.AreEqual("Transport:Transport", observations[index++]);
        Assert.AreEqual("Response:PerTryPolicyB", observations[index++]);
        Assert.AreEqual("Response:PerTryPolicyA", observations[index++]);
        Assert.AreEqual("Response:RetryPolicy", observations[index++]);
    }

    [Test]
    public async Task CanCreateWithBeforeTransportPolicies()
    {
        ClientPipelineOptions options = new()
        {
            RetryPolicy = new ObservablePolicy("RetryPolicy"),
            Transport = new ObservableTransport("Transport")
        };

        PipelinePolicy[] beforeTransportPolicies = new PipelinePolicy[]
        {
            new ObservablePolicy("BeforeTransportPolicyA"),
            new ObservablePolicy("BeforeTransportPolicyB"),
        };

        ClientPipeline pipeline = ClientPipeline.Create(options,
            perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            perTryPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            beforeTransportPolicies: beforeTransportPolicies);

        PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.AreEqual(7, observations.Count);
        Assert.AreEqual("Request:RetryPolicy", observations[index++]);
        Assert.AreEqual("Request:BeforeTransportPolicyA", observations[index++]);
        Assert.AreEqual("Request:BeforeTransportPolicyB", observations[index++]);
        Assert.AreEqual("Transport:Transport", observations[index++]);
        Assert.AreEqual("Response:BeforeTransportPolicyB", observations[index++]);
        Assert.AreEqual("Response:BeforeTransportPolicyA", observations[index++]);
        Assert.AreEqual("Response:RetryPolicy", observations[index++]);
    }

    [Test]
    public async Task CanCreateWithAllPolicyTypes()
    {
        ClientPipelineOptions options = new();
        options.Transport = new ObservableTransport("Transport");

        PipelinePolicy[] perCallPolicies = new PipelinePolicy[]
        {
            new ObservablePolicy("PerCallPolicyA"),
            new ObservablePolicy("PerCallPolicyB"),
        };

        PipelinePolicy[] perTryPolicies = new PipelinePolicy[]
        {
            new ObservablePolicy("PerTryPolicyA"),
            new ObservablePolicy("PerTryPolicyB"),
        };

        PipelinePolicy[] beforeTransportPolicies = new PipelinePolicy[]
        {
            new ObservablePolicy("BeforeTransportPolicyA"),
            new ObservablePolicy("BeforeTransportPolicyB"),
        };

        ClientPipeline pipeline = ClientPipeline.Create(options,
            perCallPolicies: perCallPolicies,
            perTryPolicies: perTryPolicies,
            beforeTransportPolicies: beforeTransportPolicies);

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
    public async Task CanCreateWithClientAuthorAndClientUserPolicies()
    {
        ClientPipelineOptions options = new()
        {
            RetryPolicy = new ObservablePolicy("RetryPolicy"),
            Transport = new ObservableTransport("Transport")
        };

        options.AddPolicy(new ObservablePolicy("UserPerCallPolicyA"), PipelinePosition.PerCall);
        options.AddPolicy(new ObservablePolicy("UserPerCallPolicyB"), PipelinePosition.PerCall);

        options.AddPolicy(new ObservablePolicy("UserPerTryPolicyA"), PipelinePosition.PerTry);
        options.AddPolicy(new ObservablePolicy("UserPerTryPolicyB"), PipelinePosition.PerTry);

        options.AddPolicy(new ObservablePolicy("UserBeforeTransportPolicyA"), PipelinePosition.BeforeTransport);
        options.AddPolicy(new ObservablePolicy("UserBeforeTransportPolicyB"), PipelinePosition.BeforeTransport);

        PipelinePolicy[] perCallPolicies = new PipelinePolicy[]
        {
            new ObservablePolicy("ClientPerCallPolicyA"),
            new ObservablePolicy("ClientPerCallPolicyB"),
        };

        PipelinePolicy[] perTryPolicies = new PipelinePolicy[]
        {
            new ObservablePolicy("ClientPerTryPolicyA"),
            new ObservablePolicy("ClientPerTryPolicyB"),
        };

        PipelinePolicy[] beforeTransportPolicies = new PipelinePolicy[]
        {
            new ObservablePolicy("ClientBeforeTransportPolicyA"),
            new ObservablePolicy("ClientBeforeTransportPolicyB"),
        };

        ClientPipeline pipeline = ClientPipeline.Create(options,
            perCallPolicies: perCallPolicies,
            perTryPolicies: perTryPolicies,
            beforeTransportPolicies: beforeTransportPolicies);

        PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.AreEqual(27, observations.Count);

        Assert.AreEqual("Request:ClientPerCallPolicyA", observations[index++]);
        Assert.AreEqual("Request:ClientPerCallPolicyB", observations[index++]);

        Assert.AreEqual("Request:UserPerCallPolicyA", observations[index++]);
        Assert.AreEqual("Request:UserPerCallPolicyB", observations[index++]);

        Assert.AreEqual("Request:RetryPolicy", observations[index++]);

        Assert.AreEqual("Request:ClientPerTryPolicyA", observations[index++]);
        Assert.AreEqual("Request:ClientPerTryPolicyB", observations[index++]);

        Assert.AreEqual("Request:UserPerTryPolicyA", observations[index++]);
        Assert.AreEqual("Request:UserPerTryPolicyB", observations[index++]);

        Assert.AreEqual("Request:ClientBeforeTransportPolicyA", observations[index++]);
        Assert.AreEqual("Request:ClientBeforeTransportPolicyB", observations[index++]);

        Assert.AreEqual("Request:UserBeforeTransportPolicyA", observations[index++]);
        Assert.AreEqual("Request:UserBeforeTransportPolicyB", observations[index++]);

        Assert.AreEqual("Transport:Transport", observations[index++]);

        Assert.AreEqual("Response:UserBeforeTransportPolicyB", observations[index++]);
        Assert.AreEqual("Response:UserBeforeTransportPolicyA", observations[index++]);

        Assert.AreEqual("Response:ClientBeforeTransportPolicyB", observations[index++]);
        Assert.AreEqual("Response:ClientBeforeTransportPolicyA", observations[index++]);

        Assert.AreEqual("Response:UserPerTryPolicyB", observations[index++]);
        Assert.AreEqual("Response:UserPerTryPolicyA", observations[index++]);

        Assert.AreEqual("Response:ClientPerTryPolicyB", observations[index++]);
        Assert.AreEqual("Response:ClientPerTryPolicyA", observations[index++]);

        Assert.AreEqual("Response:RetryPolicy", observations[index++]);

        Assert.AreEqual("Response:UserPerCallPolicyB", observations[index++]);
        Assert.AreEqual("Response:UserPerCallPolicyA", observations[index++]);

        Assert.AreEqual("Response:ClientPerCallPolicyB", observations[index++]);
        Assert.AreEqual("Response:ClientPerCallPolicyA", observations[index++]);
    }

    [Test]
    public async Task RequestOptionsCanCustomizePipeline()
    {
        ClientPipelineOptions pipelineOptions = new ClientPipelineOptions();
        pipelineOptions.RetryPolicy = new ObservablePolicy("RetryPolicy");
        pipelineOptions.Transport = new ObservableTransport("Transport");

        ClientPipeline pipeline = ClientPipeline.Create(pipelineOptions);

        RequestOptions requestOptions = new RequestOptions();
        requestOptions.AddPolicy(new ObservablePolicy("A"), PipelinePosition.PerCall);
        requestOptions.AddPolicy(new ObservablePolicy("B"), PipelinePosition.PerTry);
        requestOptions.AddPolicy(new ObservablePolicy("C"), PipelinePosition.BeforeTransport);

        PipelineMessage message = pipeline.CreateMessage();
        message.Apply(requestOptions);
        await pipeline.SendSyncOrAsync(message, IsAsync);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.AreEqual(9, observations.Count);
        Assert.AreEqual("Request:A", observations[index++]);
        Assert.AreEqual("Request:RetryPolicy", observations[index++]);
        Assert.AreEqual("Request:B", observations[index++]);
        Assert.AreEqual("Request:C", observations[index++]);
        Assert.AreEqual("Transport:Transport", observations[index++]);
        Assert.AreEqual("Response:C", observations[index++]);
        Assert.AreEqual("Response:B", observations[index++]);
        Assert.AreEqual("Response:RetryPolicy", observations[index++]);
        Assert.AreEqual("Response:A", observations[index++]);
    }
}
