// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests.Mocks;
using NUnit.Framework;
using System.ClientModel.Primitives;

namespace System.ClientModel.Tests.Options;

public class RequestOptionsTests
{
    [Test]
    public void CanAddRequestHeaders()
    {
        ClientPipeline pipeline = ClientPipeline.Create();
        PipelineMessage message = pipeline.CreateMessage();

        RequestOptions options = new RequestOptions();
        options.AddHeader("MockHeader", "MockValue");
        message.Apply(options);

        Assert.IsTrue(message.Request.Headers.TryGetValue("MockHeader", out string? value));
        Assert.AreEqual("MockValue", value);
    }

    [Test]
    public void CannotModifyOptionsAfterFrozen()
    {
        ClientPipeline pipeline = ClientPipeline.Create();
        PipelineMessage message = pipeline.CreateMessage();

        RequestOptions options = new RequestOptions();
        message.Apply(options);

        Assert.Throws<InvalidOperationException>(() => options.AddHeader("A", "B"));
        Assert.Throws<InvalidOperationException>(() => options.AddPolicy(
            new ObservablePolicy("A"), PipelinePosition.PerCall));
    }
}
