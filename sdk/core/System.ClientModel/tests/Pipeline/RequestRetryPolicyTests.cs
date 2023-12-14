// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.TestHelpers.Mocks;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Collections.Generic;

namespace System.ClientModel.Tests;

public class RequestRetryPolicyTests
{
    [Test]
    public void CanRetryErrorResponse()
    {
        PipelineOptions options = new();
        options.Transport = new RetriableTransport("Transport", new int[] { 429, 200 });
        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        pipeline.Send(message);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;

        // We visited the transport twice due to retries
        Assert.AreEqual(2, observations.Count);
        Assert.AreEqual("Transport:Transport", observations[index++]);
        Assert.AreEqual("Transport:Transport", observations[index++]);
    }
}
