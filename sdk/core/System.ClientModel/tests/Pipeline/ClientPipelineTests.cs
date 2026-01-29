// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using NUnit.Framework;

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
        Assert.That(observations.Count, Is.EqualTo(1));
        Assert.That(observations[index++], Is.EqualTo("Transport:Transport"));
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
        Assert.That(observations.Count, Is.EqualTo(7));
        Assert.That(observations[index++], Is.EqualTo("Request:PerCallPolicyA"));
        Assert.That(observations[index++], Is.EqualTo("Request:PerCallPolicyB"));
        Assert.That(observations[index++], Is.EqualTo("Request:RetryPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Transport:Transport"));
        Assert.That(observations[index++], Is.EqualTo("Response:RetryPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:PerCallPolicyB"));
        Assert.That(observations[index++], Is.EqualTo("Response:PerCallPolicyA"));
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
        Assert.That(observations.Count, Is.EqualTo(7));
        Assert.That(observations[index++], Is.EqualTo("Request:RetryPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Request:PerTryPolicyA"));
        Assert.That(observations[index++], Is.EqualTo("Request:PerTryPolicyB"));
        Assert.That(observations[index++], Is.EqualTo("Transport:Transport"));
        Assert.That(observations[index++], Is.EqualTo("Response:PerTryPolicyB"));
        Assert.That(observations[index++], Is.EqualTo("Response:PerTryPolicyA"));
        Assert.That(observations[index++], Is.EqualTo("Response:RetryPolicy"));
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
        Assert.That(observations.Count, Is.EqualTo(7));
        Assert.That(observations[index++], Is.EqualTo("Request:RetryPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Request:BeforeTransportPolicyA"));
        Assert.That(observations[index++], Is.EqualTo("Request:BeforeTransportPolicyB"));
        Assert.That(observations[index++], Is.EqualTo("Transport:Transport"));
        Assert.That(observations[index++], Is.EqualTo("Response:BeforeTransportPolicyB"));
        Assert.That(observations[index++], Is.EqualTo("Response:BeforeTransportPolicyA"));
        Assert.That(observations[index++], Is.EqualTo("Response:RetryPolicy"));
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
        Assert.That(observations.Count, Is.EqualTo(13));

        Assert.That(observations[index++], Is.EqualTo("Request:PerCallPolicyA"));
        Assert.That(observations[index++], Is.EqualTo("Request:PerCallPolicyB"));

        Assert.That(observations[index++], Is.EqualTo("Request:PerTryPolicyA"));
        Assert.That(observations[index++], Is.EqualTo("Request:PerTryPolicyB"));

        Assert.That(observations[index++], Is.EqualTo("Request:BeforeTransportPolicyA"));
        Assert.That(observations[index++], Is.EqualTo("Request:BeforeTransportPolicyB"));

        Assert.That(observations[index++], Is.EqualTo("Transport:Transport"));

        Assert.That(observations[index++], Is.EqualTo("Response:BeforeTransportPolicyB"));
        Assert.That(observations[index++], Is.EqualTo("Response:BeforeTransportPolicyA"));

        Assert.That(observations[index++], Is.EqualTo("Response:PerTryPolicyB"));
        Assert.That(observations[index++], Is.EqualTo("Response:PerTryPolicyA"));

        Assert.That(observations[index++], Is.EqualTo("Response:PerCallPolicyB"));
        Assert.That(observations[index++], Is.EqualTo("Response:PerCallPolicyA"));
    }

    [Test]
    public async Task CanCreateWithClientAuthorAndClientUserPolicies()
    {
        ClientPipelineOptions options = new()
        {
            RetryPolicy = new ObservablePolicy("RetryPolicy"),
            MessageLoggingPolicy = new ObservablePolicy("LoggingPolicy"),
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
        Assert.That(observations.Count, Is.EqualTo(29));

        Assert.That(observations[index++], Is.EqualTo("Request:ClientPerCallPolicyA"));
        Assert.That(observations[index++], Is.EqualTo("Request:ClientPerCallPolicyB"));

        Assert.That(observations[index++], Is.EqualTo("Request:UserPerCallPolicyA"));
        Assert.That(observations[index++], Is.EqualTo("Request:UserPerCallPolicyB"));

        Assert.That(observations[index++], Is.EqualTo("Request:RetryPolicy"));

        Assert.That(observations[index++], Is.EqualTo("Request:ClientPerTryPolicyA"));
        Assert.That(observations[index++], Is.EqualTo("Request:ClientPerTryPolicyB"));

        Assert.That(observations[index++], Is.EqualTo("Request:UserPerTryPolicyA"));
        Assert.That(observations[index++], Is.EqualTo("Request:UserPerTryPolicyB"));

        Assert.That(observations[index++], Is.EqualTo("Request:LoggingPolicy"));

        Assert.That(observations[index++], Is.EqualTo("Request:ClientBeforeTransportPolicyA"));
        Assert.That(observations[index++], Is.EqualTo("Request:ClientBeforeTransportPolicyB"));

        Assert.That(observations[index++], Is.EqualTo("Request:UserBeforeTransportPolicyA"));
        Assert.That(observations[index++], Is.EqualTo("Request:UserBeforeTransportPolicyB"));

        Assert.That(observations[index++], Is.EqualTo("Transport:Transport"));

        Assert.That(observations[index++], Is.EqualTo("Response:UserBeforeTransportPolicyB"));
        Assert.That(observations[index++], Is.EqualTo("Response:UserBeforeTransportPolicyA"));

        Assert.That(observations[index++], Is.EqualTo("Response:ClientBeforeTransportPolicyB"));
        Assert.That(observations[index++], Is.EqualTo("Response:ClientBeforeTransportPolicyA"));

        Assert.That(observations[index++], Is.EqualTo("Response:LoggingPolicy"));

        Assert.That(observations[index++], Is.EqualTo("Response:UserPerTryPolicyB"));
        Assert.That(observations[index++], Is.EqualTo("Response:UserPerTryPolicyA"));

        Assert.That(observations[index++], Is.EqualTo("Response:ClientPerTryPolicyB"));
        Assert.That(observations[index++], Is.EqualTo("Response:ClientPerTryPolicyA"));

        Assert.That(observations[index++], Is.EqualTo("Response:RetryPolicy"));

        Assert.That(observations[index++], Is.EqualTo("Response:UserPerCallPolicyB"));
        Assert.That(observations[index++], Is.EqualTo("Response:UserPerCallPolicyA"));

        Assert.That(observations[index++], Is.EqualTo("Response:ClientPerCallPolicyB"));
        Assert.That(observations[index++], Is.EqualTo("Response:ClientPerCallPolicyA"));
    }

    [Test]
    public async Task RequestOptionsCanCustomizePipeline()
    {
        ClientPipelineOptions pipelineOptions = new ClientPipelineOptions();
        pipelineOptions.RetryPolicy = new ObservablePolicy("RetryPolicy");
        pipelineOptions.MessageLoggingPolicy = new ObservablePolicy("LoggingPolicy");
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
        Assert.That(observations.Count, Is.EqualTo(11));
        Assert.That(observations[index++], Is.EqualTo("Request:A"));
        Assert.That(observations[index++], Is.EqualTo("Request:RetryPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Request:B"));
        Assert.That(observations[index++], Is.EqualTo("Request:LoggingPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Request:C"));
        Assert.That(observations[index++], Is.EqualTo("Transport:Transport"));
        Assert.That(observations[index++], Is.EqualTo("Response:C"));
        Assert.That(observations[index++], Is.EqualTo("Response:LoggingPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:B"));
        Assert.That(observations[index++], Is.EqualTo("Response:RetryPolicy"));
        Assert.That(observations[index++], Is.EqualTo("Response:A"));
    }

    [Test]
    public void CreateMessageWithUriMethodAndClassifierSetsProperties()
    {
        ClientPipeline pipeline = ClientPipeline.Create();
        Uri testUri = new Uri("https://example.com/test");
        string testMethod = "POST";
        PipelineMessageClassifier testClassifier = PipelineMessageClassifier.Create(ReadOnlySpan<ushort>.Empty);

        PipelineMessage message = pipeline.CreateMessage(testUri, testMethod, testClassifier);

        Assert.That(message, Is.Not.Null);
        Assert.That(message.Request.Uri, Is.EqualTo(testUri));
        Assert.That(message.Request.Method, Is.EqualTo(testMethod));
        Assert.That(message.ResponseClassifier, Is.EqualTo(testClassifier));
        Assert.That(message.NetworkTimeout, Is.Not.Null);
    }

    [Test]
    public void CreateMessageThrowsOnNullUriOrMethod()
    {
        ClientPipeline pipeline = ClientPipeline.Create();
        Uri testUri = new Uri("https://example.com/test");
        string testMethod = "GET";
        PipelineMessageClassifier testClassifier = PipelineMessageClassifier.Default;

        Assert.Throws<ArgumentNullException>(() =>
            pipeline.CreateMessage(null!, testMethod, testClassifier));

        Assert.Throws<ArgumentNullException>(() =>
            pipeline.CreateMessage(testUri, null!, testClassifier));
    }

    [Test]
    public void CreateMessageWithUriAndMethodUsesDefaultClassifier()
    {
        ClientPipeline pipeline = ClientPipeline.Create();
        Uri testUri = new Uri("https://example.com/test");
        string testMethod = "DELETE";

        PipelineMessage message = pipeline.CreateMessage(testUri, testMethod);

        Assert.That(message, Is.Not.Null);
        Assert.That(message.Request.Uri, Is.EqualTo(testUri));
        Assert.That(message.Request.Method, Is.EqualTo(testMethod));
        Assert.That(message.ResponseClassifier, Is.EqualTo(PipelineMessageClassifier.Default));
    }
}
