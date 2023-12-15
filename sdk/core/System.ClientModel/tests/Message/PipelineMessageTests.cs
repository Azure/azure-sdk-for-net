// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests.Mocks;
using NUnit.Framework;
using System.ClientModel.Primitives;

namespace System.ClientModel.Tests.Message;

public class PipelineMessageTests
{
    // TODO: Add test to validate CancelllationToken is set by Apply

    [Test]
    public void ApplySetsRequestHeaders()
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
    public void ApplySetsMessageClassifier()
    {
        ClientPipeline pipeline = ClientPipeline.Create();
        PipelineMessage message = pipeline.CreateMessage();

        RequestOptions options = new RequestOptions();
        message.Apply(options, new MockMessageClassifier("MockClassifier"));

        MockMessageClassifier? classifier = message.MessageClassifier as MockMessageClassifier;

        Assert.IsNotNull(classifier);
        Assert.AreEqual("MockClassifier", classifier!.Id);
    }

    [Test]
    public void CanSetAndGetProperties()
    {
        ClientPipeline pipeline = ClientPipeline.Create();
        PipelineMessage message = pipeline.CreateMessage();

        message.SetProperty(GetType(), "MockProperty");

        Assert.IsTrue(message.TryGetProperty(GetType(), out object? property));
        Assert.AreEqual("MockProperty", property);
    }
}
