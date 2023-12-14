// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using TestHelpers.Internal;

namespace System.ClientModel.Tests;

public class ClientPipelineTests
{
    [Test]
    public void CanEnumeratePipeline()
    {
        PipelineOptions options = new();
        options.Transport = new ObservableTransport("Transport");
        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        pipeline.Send(message);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.AreEqual(1, observations.Count);
        Assert.AreEqual("Transport:Transport", observations[index++]);
    }

    [Test]
    public void RequestOptionsCanCustomizePipeline()
    {
        PipelineOptions pipelineOptions = new PipelineOptions();
        pipelineOptions.RetryPolicy = new ObservablePolicy("RetryPolicy");
        pipelineOptions.Transport = new ObservableTransport("Transport");

        ClientPipeline pipeline = ClientPipeline.Create(pipelineOptions);

        RequestOptions requestOptions = new RequestOptions();
        requestOptions.AddPolicy(new ObservablePolicy("A"), PipelinePosition.PerCall);
        requestOptions.AddPolicy(new ObservablePolicy("B"), PipelinePosition.PerTry);

        PipelineMessage message = pipeline.CreateMessage();
        message.Apply(requestOptions);
        pipeline.Send(message);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;
        Assert.AreEqual(7, observations.Count);
        Assert.AreEqual("Request:A", observations[index++]);
        Assert.AreEqual("Request:RetryPolicy", observations[index++]);
        Assert.AreEqual("Request:B", observations[index++]);
        Assert.AreEqual("Transport:Transport", observations[index++]);
        Assert.AreEqual("Response:B", observations[index++]);
        Assert.AreEqual("Response:RetryPolicy", observations[index++]);
        Assert.AreEqual("Response:A", observations[index++]);
    }
}
