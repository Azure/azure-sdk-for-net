// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests;

[Category("Smoke")]
public class ProjectOAIResponsesClientOptionsTests
{
    [Test]
    public void Defaults_ApiVersionIsV1()
    {
        ProjectOAIResponsesClientOptions options = new();
        Assert.That(options.ApiVersion, Is.EqualTo("v1"));
        Assert.That(options.AgentName, Is.Null);
    }

    [Test]
    public void Setters_ThrowAfterFreeze()
    {
        ProjectOAIResponsesClientOptions options = new();
        options.Freeze();

        Assert.That(() => options.ApiVersion = "2025-11-15-preview", Throws.InvalidOperationException);
        Assert.That(() => options.AgentName = "agent", Throws.InvalidOperationException);
    }

    [Test]
    public void ImplicitOperator_NullSource_ReturnsNull()
    {
        ProjectOpenAIClientOptions source = null;
        ProjectOAIResponsesClientOptions destination = source;
        Assert.That(destination, Is.Null);
    }

    [Test]
    public void ImplicitOperator_CopiesAllExpectedProperties()
    {
        Uri endpoint = new("https://example.foundry.azure.com/api/projects/p/openai/v1");
        ClientLoggingOptions loggingOptions = new();
        ProjectOpenAIClientOptions source = new()
        {
            Endpoint = endpoint,
            OrganizationId = "org-123",
            ProjectId = "proj-456",
            UserAgentApplicationId = "MyApp",
            RetryPolicy = new ClientRetryPolicy(maxRetries: 3),
            MessageLoggingPolicy = MessageLoggingPolicy.Default,
            Transport = HttpClientPipelineTransport.Shared,
            NetworkTimeout = TimeSpan.FromSeconds(42),
            ClientLoggingOptions = loggingOptions,
            EnableDistributedTracing = true,
            ApiVersion = "2025-11-15-preview",
            AgentName = "MyAgent",
        };

        ProjectOAIResponsesClientOptions destination = source;

        Assert.That(destination, Is.Not.Null);
        Assert.That(destination, Is.Not.SameAs(source));
        Assert.That(destination.Endpoint, Is.EqualTo(endpoint));
        Assert.That(destination.OrganizationId, Is.EqualTo("org-123"));
        Assert.That(destination.ProjectId, Is.EqualTo("proj-456"));
        Assert.That(destination.UserAgentApplicationId, Is.EqualTo("MyApp"));
        Assert.That(destination.RetryPolicy, Is.SameAs(source.RetryPolicy));
        Assert.That(destination.MessageLoggingPolicy, Is.SameAs(MessageLoggingPolicy.Default));
        Assert.That(destination.Transport, Is.SameAs(HttpClientPipelineTransport.Shared));
        Assert.That(destination.NetworkTimeout, Is.EqualTo(TimeSpan.FromSeconds(42)));
        Assert.That(destination.ClientLoggingOptions, Is.SameAs(loggingOptions));
        Assert.That(destination.EnableDistributedTracing, Is.True);
        Assert.That(destination.ApiVersion, Is.EqualTo("2025-11-15-preview"));
        Assert.That(destination.AgentName, Is.EqualTo("MyAgent"));
    }

    [Test]
    public void ImplicitOperator_ProducesUnfrozenDestinationEvenIfSourceIsFrozen()
    {
        ProjectOpenAIClientOptions source = new();
        source.Freeze();
        Assert.That(source.IsReadOnly, Is.True);

        ProjectOAIResponsesClientOptions destination = source;

        Assert.That(destination.IsReadOnly, Is.False);
        Assert.DoesNotThrow(() => destination.ApiVersion = "v2");
        Assert.DoesNotThrow(() => destination.AddPolicy(new TestPolicy(), PipelinePosition.PerCall));
    }

    [Test]
    public void NewOptionsInstance_CanBeUsedToConstructResponsesClient()
    {
        ProjectOAIResponsesClientOptions options = new()
        {
            Endpoint = new Uri("https://example.foundry.azure.com/api/projects/p/openai/v1"),
        };

        // Direct construction against the new options type compiles and binds.
        ResponsesClient client = new(
            credential: new System.ClientModel.ApiKeyCredential("fake-key-for-smoke-test"),
            options: options);
        Assert.That(client, Is.Not.Null);
    }

    private sealed class TestPolicy : PipelinePolicy
    {
        public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
            => ProcessNext(message, pipeline, currentIndex);

        public override System.Threading.Tasks.ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
            => ProcessNextAsync(message, pipeline, currentIndex);
    }
}
