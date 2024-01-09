// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            Transport = new ObservableTransport("Transport")
        };

        options.AddPolicy(new ObservablePolicy("PerCallPolicy"), PipelinePosition.PerCall);

        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.AreEqual(3, observations.Count);
        Assert.AreEqual("Request:PerCallPolicy", observations[index++]);

        // TODO: Validate that per call policy comes before retry policy

        Assert.AreEqual("Transport:Transport", observations[index++]);
        Assert.AreEqual("Response:PerCallPolicy", observations[index++]);
    }

    [Test]
    public async Task CanAddPerTryPolicy()
    {
        ClientPipelineOptions options = new()
        {
            Transport = new ObservableTransport("Transport")
        };

        options.AddPolicy(new ObservablePolicy("PerTryPolicy"), PipelinePosition.PerTry);

        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.AreEqual(3, observations.Count);
        Assert.AreEqual("Request:PerTryPolicy", observations[index++]);

        // TODO: Validate that per call policy comes after retry policy

        Assert.AreEqual("Transport:Transport", observations[index++]);
        Assert.AreEqual("Response:PerTryPolicy", observations[index++]);
    }

    [Test]
    public async Task CanAddBeforeTransportPolicy()
    {
        ClientPipelineOptions options = new()
        {
            Transport = new ObservableTransport("Transport")
        };

        options.AddPolicy(new ObservablePolicy("BeforeTransportPolicy"), PipelinePosition.BeforeTransport);

        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.AreEqual(3, observations.Count);
        Assert.AreEqual("Request:BeforeTransportPolicy", observations[index++]);

        // TODO: Validate that before transport policy comes after retry policy

        Assert.AreEqual("Transport:Transport", observations[index++]);
        Assert.AreEqual("Response:BeforeTransportPolicy", observations[index++]);
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
        Assert.AreEqual(11, observations.Count);
        Assert.AreEqual("Request:BeforeTransportPolicyA", observations[index++]);
        Assert.AreEqual("Request:BeforeTransportPolicyB", observations[index++]);

        // TODO: Validate that before transport policy comes after retry policy

        Assert.AreEqual("Transport:Transport", observations[index++]);
        Assert.AreEqual("Response:BeforeTransportPolicy", observations[index++]);
    }

    #region Helpers

    #endregion
}
