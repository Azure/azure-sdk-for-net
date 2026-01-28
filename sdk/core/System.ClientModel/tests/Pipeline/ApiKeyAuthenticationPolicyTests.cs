// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Threading.Tasks;
using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace System.ClientModel.Tests.Pipeline;

public class ApiKeyAuthenticationPolicyTests : SyncAsyncTestBase
{
    public ApiKeyAuthenticationPolicyTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task HeaderPolicySetsKey()
    {
        string keyValue = "test_key";
        string header = "api_key";

        ApiKeyCredential credential = new(keyValue);
        ApiKeyAuthenticationPolicy keyPolicy = ApiKeyAuthenticationPolicy.CreateHeaderApiKeyPolicy(credential, header);

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", new int[] { 200 })
        };

        ClientPipeline pipeline = ClientPipeline.Create(options,
            perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            perTryPolicies: new PipelinePolicy[] { keyPolicy },
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);

        using PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);

        Assert.That(message.Request.Headers.TryGetValue(header, out var requestHeaderValue), Is.True);
        Assert.That(requestHeaderValue, Is.EqualTo(keyValue));
    }

    [Test]
    public async Task HeaderPolicySetsKeyWithPrefix()
    {
        string keyValue = "test_key";
        string header = "api_key";
        string prefix = "prefix";

        ApiKeyCredential credential = new(keyValue);
        ApiKeyAuthenticationPolicy keyPolicy = ApiKeyAuthenticationPolicy.CreateHeaderApiKeyPolicy(credential, header, prefix);

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", new int[] { 200 })
        };

        ClientPipeline pipeline = ClientPipeline.Create(options,
            perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            perTryPolicies: new PipelinePolicy[] { keyPolicy },
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);

        using PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);

        Assert.That(message.Request.Headers.TryGetValue(header, out var requestHeaderValue), Is.True);
        Assert.That(requestHeaderValue, Is.EqualTo($"{prefix} {keyValue}"));
    }

    [Test]
    public async Task HeaderPolicyAddsSingleKeyWhenRetried()
    {
        string keyValue = "test_key";
        string header = "api_key";

        ApiKeyCredential credential = new(keyValue);
        ApiKeyAuthenticationPolicy keyPolicy = ApiKeyAuthenticationPolicy.CreateHeaderApiKeyPolicy(credential, header);

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", new int[] { 200, 200 })
        };

        ClientPipeline pipeline = ClientPipeline.Create(options,
            perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            perTryPolicies: new PipelinePolicy[] { keyPolicy },
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);

        using PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);
        await pipeline.SendSyncOrAsync(message, IsAsync);

        Assert.That(message.Request.Headers.TryGetValue(header, out var requestHeaderValue), Is.True);
        Assert.That(requestHeaderValue, Is.EqualTo(keyValue));
    }

    [Test]
    public async Task HeaderPolicyWithPrefixAddsSingleKeyWhenRetried()
    {
        string keyValue = "test_key";
        string header = "api_key";
        string prefix = "prefix";

        ApiKeyCredential credential = new(keyValue);
        ApiKeyAuthenticationPolicy keyPolicy = ApiKeyAuthenticationPolicy.CreateHeaderApiKeyPolicy(credential, header, prefix);

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", new int[] { 200, 200 })
        };

        ClientPipeline pipeline = ClientPipeline.Create(options,
            perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            perTryPolicies: new PipelinePolicy[] { keyPolicy },
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);

        using PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);
        await pipeline.SendSyncOrAsync(message, IsAsync);

        Assert.That(message.Request.Headers.TryGetValue(header, out var requestHeaderValue), Is.True);
        Assert.That(requestHeaderValue, Is.EqualTo($"{prefix} {keyValue}"));
    }

    [Test]
    public async Task BasicPolicySetsKey()
    {
        string keyValue = "test_key";

        ApiKeyCredential credential = new(keyValue);
        ApiKeyAuthenticationPolicy keyPolicy = ApiKeyAuthenticationPolicy.CreateBasicAuthorizationPolicy(credential);

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", new int[] { 200 })
        };

        ClientPipeline pipeline = ClientPipeline.Create(options,
            perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            perTryPolicies: new PipelinePolicy[] { keyPolicy },
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);

        using PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);

        Assert.That(message.Request.Headers.TryGetValue("Authorization", out var requestHeaderValue), Is.True);
        Assert.That(requestHeaderValue, Is.EqualTo($"Basic {keyValue}"));
    }

    [Test]
    public async Task BearerPolicySetsKey()
    {
        string keyValue = "test_key";

        ApiKeyCredential credential = new(keyValue);
        ApiKeyAuthenticationPolicy keyPolicy = ApiKeyAuthenticationPolicy.CreateBearerAuthorizationPolicy(credential);

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", new int[] { 200 })
        };

        ClientPipeline pipeline = ClientPipeline.Create(options,
            perCallPolicies: ReadOnlySpan<PipelinePolicy>.Empty,
            perTryPolicies: new PipelinePolicy[] { keyPolicy },
            beforeTransportPolicies: ReadOnlySpan<PipelinePolicy>.Empty);

        using PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);

        Assert.That(message.Request.Headers.TryGetValue("Authorization", out var requestHeaderValue), Is.True);
        Assert.That(requestHeaderValue, Is.EqualTo($"Bearer {keyValue}"));
    }
}
