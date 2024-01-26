// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Threading;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

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
    public void CanInterleaveAddAndSetCalls()
    {
        ClientPipeline pipeline = ClientPipeline.Create();
        PipelineMessage message = pipeline.CreateMessage();

        message.Request.Headers.Add("MockHeader1", "Message.Request Value");
        message.Request.Headers.Add("MockHeader2", "Message.Request Value");
        message.Request.Headers.Add("MockHeader3", "Message.Request Value");

        RequestOptions options = new RequestOptions();

        options.SetHeader("MockHeader1", "RequestOptions SetHeader Value 1");
        options.AddHeader("MockHeader1", "RequestOptions AddHeader Value 1");
        options.SetHeader("MockHeader1", "RequestOptions SetHeader Value 2");

        options.AddHeader("MockHeader2", "RequestOptions AddHeader Value 1");
        options.SetHeader("MockHeader2", "RequestOptions SetHeader Value 1");
        options.AddHeader("MockHeader2", "RequestOptions AddHeader Value 2");

        message.Apply(options);

        Assert.IsTrue(message.Request.Headers.TryGetValue("MockHeader1", out string? value1));
        Assert.AreEqual("RequestOptions SetHeader Value 2", value1);

        Assert.IsTrue(message.Request.Headers.TryGetValue("MockHeader2", out string? value2));
        Assert.AreEqual("RequestOptions SetHeader Value 1,RequestOptions AddHeader Value 2", value2);

        Assert.IsTrue(message.Request.Headers.TryGetValue("MockHeader3", out string? value3));
        Assert.AreEqual("Message.Request Value", value3);
    }

    [Test]
    public void CannotModifyOptionsAfterFrozen()
    {
        ClientPipeline pipeline = ClientPipeline.Create();
        PipelineMessage message = pipeline.CreateMessage();

        RequestOptions options = new RequestOptions();
        message.Apply(options);

        Assert.Throws<InvalidOperationException>(() => options.CancellationToken = CancellationToken.None);
        Assert.Throws<InvalidOperationException>(() => options.ErrorOptions = ClientErrorBehaviors.NoThrow);
        Assert.Throws<InvalidOperationException>(() => options.AddHeader("A", "B"));
        Assert.Throws<InvalidOperationException>(()
            => options.AddPolicy(new ObservablePolicy("A"), PipelinePosition.PerCall));
    }

    [Test]
    public void CannotModifyOptionsAfterExplicitlyFrozen()
    {
        RequestOptions options = new RequestOptions();
        options.Freeze();

        Assert.Throws<InvalidOperationException>(() => options.CancellationToken = CancellationToken.None);
        Assert.Throws<InvalidOperationException>(() => options.ErrorOptions = ClientErrorBehaviors.NoThrow);
        Assert.Throws<InvalidOperationException>(() => options.AddHeader("A", "B"));
        Assert.Throws<InvalidOperationException>(() => options.AddPolicy(
            new ObservablePolicy("A"), PipelinePosition.PerCall));
    }
}
