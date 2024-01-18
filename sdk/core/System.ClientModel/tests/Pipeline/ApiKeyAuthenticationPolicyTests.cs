// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.ClientModel.Primitives;

namespace System.ClientModel.Tests.Pipeline;

public class ApiKeyAuthenticationPolicyTests : SyncAsyncTestBase
{
    public ApiKeyAuthenticationPolicyTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task SetsKey()
    {
        string keyValue = "test_key";
        string header = "api_key";

        ApiKeyCredential credential = new(keyValue);
        ApiKeyAuthenticationPolicy keyPolicy = ApiKeyAuthenticationPolicy.CreateHeaderApiKeyPolicy(credential, header);

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", new int[] { 200 })
        };

        ClientPipeline pipeline = ClientPipeline.Create(options, keyPolicy);

        using PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);

        Assert.True(message.Request.Headers.TryGetValue(header, out var requestHeaderValue));
        Assert.AreEqual(keyValue, requestHeaderValue);
    }

    [Test]
    public async Task SetsKeyWithPrefix()
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

        ClientPipeline pipeline = ClientPipeline.Create(options, keyPolicy);

        using PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);

        Assert.True(message.Request.Headers.TryGetValue(header, out var requestHeaderValue));
        Assert.AreEqual($"{prefix} {keyValue}", requestHeaderValue);
    }

    [Test]
    public async Task VerifyRetry()
    {
        string keyValue = "test_key";
        string header = "api_key";

        ApiKeyCredential credential = new(keyValue);
        ApiKeyAuthenticationPolicy keyPolicy = ApiKeyAuthenticationPolicy.CreateHeaderApiKeyPolicy(credential, header);

        ClientPipelineOptions options = new()
        {
            Transport = new MockPipelineTransport("Transport", new int[] { 200, 200 })
        };

        ClientPipeline pipeline = ClientPipeline.Create(options, keyPolicy);

        using PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);
        await pipeline.SendSyncOrAsync(message, IsAsync);

        Assert.True(message.Request.Headers.TryGetValue(header, out var requestHeaderValue));
        Assert.AreEqual(keyValue, requestHeaderValue);
    }

    [Test]
    public async Task VerifyRetrySetsPrefix()
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

        ClientPipeline pipeline = ClientPipeline.Create(options, keyPolicy);

        using PipelineMessage message = pipeline.CreateMessage();
        await pipeline.SendSyncOrAsync(message, IsAsync);
        await pipeline.SendSyncOrAsync(message, IsAsync);

        Assert.True(message.Request.Headers.TryGetValue(header, out var requestHeaderValue));
        Assert.AreEqual($"{prefix} {keyValue}", requestHeaderValue);
    }
}
