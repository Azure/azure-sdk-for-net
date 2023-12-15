﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.ClientModel.Tests.Pipeline;

public class RequestRetryPolicyTests : SyncAsyncTestBase
{
    public RequestRetryPolicyTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task CanRetryErrorResponse()
    {
        PipelineOptions options = new();
        options.Transport = new RetriableTransport("Transport", new int[] { 429, 200 });
        ClientPipeline pipeline = ClientPipeline.Create(options);

        PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);

        List<string> observations = ObservablePolicy.GetData(message);

        int index = 0;

        // We visited the transport twice due to retries
        Assert.AreEqual(2, observations.Count);
        Assert.AreEqual("Transport:Transport", observations[index++]);
        Assert.AreEqual("Transport:Transport", observations[index++]);
    }
}
