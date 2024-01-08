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
    public async Task CanEnumeratePipeline()
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

    // TODO: RequestOptions will come in a later PR.
    //[Test]
    //public async Task RequestOptionsCanCustomizePipeline()
    //{
    //    ClientPipelineOptions pipelineOptions = new ClientPipelineOptions();
    //    pipelineOptions.RetryPolicy = new ObservablePolicy("RetryPolicy");
    //    pipelineOptions.Transport = new ObservableTransport("Transport");

    //    ClientPipeline pipeline = ClientPipeline.Create(pipelineOptions);

    //    RequestOptions requestOptions = new RequestOptions();
    //    requestOptions.AddPolicy(new ObservablePolicy("A"), PipelinePosition.PerCall);
    //    requestOptions.AddPolicy(new ObservablePolicy("B"), PipelinePosition.PerTry);

    //    PipelineMessage message = pipeline.CreateMessage();
    //    message.Apply(requestOptions);
    //    await pipeline.SendSyncOrAsync(message, IsAsync);

    //    List<string> observations = ObservablePolicy.GetData(message);

    //    int index = 0;
    //    Assert.AreEqual(7, observations.Count);
    //    Assert.AreEqual("Request:A", observations[index++]);
    //    Assert.AreEqual("Request:RetryPolicy", observations[index++]);
    //    Assert.AreEqual("Request:B", observations[index++]);
    //    Assert.AreEqual("Transport:Transport", observations[index++]);
    //    Assert.AreEqual("Response:B", observations[index++]);
    //    Assert.AreEqual("Response:RetryPolicy", observations[index++]);
    //    Assert.AreEqual("Response:A", observations[index++]);
    //}
}
