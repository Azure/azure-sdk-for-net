// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Embeddings;

namespace Azure.AI.Extensions.OpenAI.Tests;

[Category("Smoke")]
public class ProjectOpenAIClientEmbeddingTests
{
    [Test]
    public void GetEmbeddingClient_ProjectEndpoint_SendsRequestsToResourceEndpoint()
    {
        (Uri requestUri, string authorization) = SendEmbeddingRequest(new Uri("https://my-resource.services.ai.azure.com/api/projects/my-project/openai/v1"));

        Assert.That(requestUri, Is.EqualTo(new Uri("https://my-resource.services.ai.azure.com/openai/v1/embeddings")));
        Assert.That(authorization, Is.EqualTo("Bearer test-token"));
    }

    [Test]
    public void GetEmbeddingClient_ProjectEndpointConstructor_SendsRequestsToResourceEndpointAsync()
    {
        Uri requestUri = null;
        ProjectOpenAIClientOptions options = new() { RetryPolicy = new ClientRetryPolicy(maxRetries: 0) };
        options.AddPolicy(
            new TestPipelinePolicy(message =>
            {
                requestUri = message.Request.Uri;
                throw new NotImplementedException("This exception is expected as this policy is meant to short-circuit the pipeline after reading the request.");
            }),
            PipelinePosition.BeforeTransport);
        ProjectOpenAIClient client = new(new Uri("https://my-resource.services.ai.azure.com/api/projects/my-project"), new MockCredential(), options);

        EmbeddingClient embeddingClient = client.GetEmbeddingClient("text-embedding-3-small");

        Assert.ThrowsAsync<NotImplementedException>(async () => await embeddingClient.GenerateEmbeddingAsync("Hello"));
        Assert.That(requestUri, Is.EqualTo(new Uri("https://my-resource.services.ai.azure.com/openai/v1/embeddings")));
    }

    [Test]
    public void GetEmbeddingClient_OtherEndpoint_KeepsEndpoint()
    {
        (Uri requestUri, string authorization) = SendEmbeddingRequest(new Uri("https://my-resource.openai.azure.com/openai/v1"));

        Assert.That(requestUri, Is.EqualTo(new Uri("https://my-resource.openai.azure.com/openai/v1/embeddings")));
        Assert.That(authorization, Is.EqualTo("Bearer test-token"));
    }

    [Test]
    public void GetResourceOpenAIEndpoint_ReturnsResourceEndpointForProjectEndpointsOnly()
    {
        Assert.That(
            ProjectOpenAIClient.GetResourceOpenAIEndpoint(new Uri("https://my-resource.services.ai.azure.com/api/projects/my-project/openai/v1")),
            Is.EqualTo(new Uri("https://my-resource.services.ai.azure.com/openai/v1")));
        Assert.That(ProjectOpenAIClient.GetResourceOpenAIEndpoint(new Uri("https://my-resource.openai.azure.com/openai/v1")), Is.Null);
        Assert.That(ProjectOpenAIClient.GetResourceOpenAIEndpoint(null), Is.Null);
    }

    private static (Uri RequestUri, string Authorization) SendEmbeddingRequest(Uri endpoint)
    {
        Uri requestUri = null;
        string authorization = null;
        ProjectOpenAIClientOptions options = new()
        {
            Endpoint = endpoint,
            RetryPolicy = new ClientRetryPolicy(maxRetries: 0),
        };
        options.AddPolicy(
            new TestPipelinePolicy(message =>
            {
                requestUri = message.Request.Uri;
                message.Request.Headers.TryGetValue("Authorization", out authorization);
                throw new NotImplementedException("This exception is expected as this policy is meant to short-circuit the pipeline after reading the request.");
            }),
            PipelinePosition.BeforeTransport);
        ProjectOpenAIClient client = new(new TestAuthenticationPolicy(), options);

        EmbeddingClient embeddingClient = client.GetEmbeddingClient("text-embedding-3-small");

        Assert.Throws<NotImplementedException>(() => embeddingClient.GenerateEmbedding("Hello"));
        return (requestUri, authorization);
    }

    private sealed class TestAuthenticationPolicy : AuthenticationPolicy
    {
        public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            message.Request.Headers.Set("Authorization", "Bearer test-token");
            ProcessNext(message, pipeline, currentIndex);
        }

        public override ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            message.Request.Headers.Set("Authorization", "Bearer test-token");
            return ProcessNextAsync(message, pipeline, currentIndex);
        }
    }
}
