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
    public void CanAddMultiValueRequestHeaders()
    {
        ClientPipeline pipeline = ClientPipeline.Create();
        PipelineMessage message = pipeline.CreateMessage();

        RequestOptions options = new RequestOptions();
        options.AddHeader("MockHeader", "MockValue1");
        options.AddHeader("MockHeader", "MockValue2");
        message.Apply(options);

        Assert.IsTrue(message.Request.Headers.TryGetValue("MockHeader", out string? value));
        Assert.AreEqual("MockValue1,MockValue2", value);
    }

    [Test]
    public void CanSetRequestHeaders()
    {
        ClientPipeline pipeline = ClientPipeline.Create();
        PipelineMessage message = pipeline.CreateMessage();

        RequestOptions options = new RequestOptions();
        options.SetHeader("MockHeader", "MockValue");
        message.Apply(options);

        Assert.IsTrue(message.Request.Headers.TryGetValue("MockHeader", out string? value));
        Assert.AreEqual("MockValue", value);
    }

    [Test]
    public void SetReplacesHeaderAddedViaRequestOptions()
    {
        ClientPipeline pipeline = ClientPipeline.Create();
        PipelineMessage message = pipeline.CreateMessage();

        RequestOptions options = new RequestOptions();
        options.AddHeader("MockHeader", "MockValue1");
        options.SetHeader("MockHeader", "MockValue2");
        message.Apply(options);

        Assert.IsTrue(message.Request.Headers.TryGetValue("MockHeader", out string? value));
        Assert.AreEqual("MockValue2", value);
    }

    [Test]
    public void AddHeaderAddsValueToRequestMessageValue()
    {
        ClientPipeline pipeline = ClientPipeline.Create();
        PipelineMessage message = pipeline.CreateMessage();

        message.Request.Headers.Add("MockHeader", "Message.Request Value");

        RequestOptions options = new RequestOptions();
        options.AddHeader("MockHeader", "RequestOptions Value");
        message.Apply(options);

        Assert.IsTrue(message.Request.Headers.TryGetValue("MockHeader", out string? value));
        Assert.AreEqual("Message.Request Value,RequestOptions Value", value);
    }

    [Test]
    public void SetReplacesHeaderAddedViaMessageRequest()
    {
        ClientPipeline pipeline = ClientPipeline.Create();
        PipelineMessage message = pipeline.CreateMessage();

        message.Request.Headers.Add("MockHeader", "Message.Request Value");

        RequestOptions options = new RequestOptions();
        options.SetHeader("MockHeader", "RequestOptions Value");
        message.Apply(options);

        Assert.IsTrue(message.Request.Headers.TryGetValue("MockHeader", out string? value));
        Assert.AreEqual("RequestOptions Value", value);
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
