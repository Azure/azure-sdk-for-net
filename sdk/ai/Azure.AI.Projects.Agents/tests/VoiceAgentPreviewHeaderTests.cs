// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;

namespace Azure.AI.Projects.Agents.Tests;

public class VoiceAgentPreviewHeaderTests
{
    private static readonly Uri Endpoint = new("https://example.test/api/projects/project");
    private const string Preview = "VoiceAgents=V1Preview";

    private static IEnumerable<TestCaseData> VoiceRequests()
    {
        string prefix = "/agents/agent/endpoint/protocols/voice";
        (string Method, string Path, bool Required)[] cases =
        [
            ("POST", "/agents:generate", false),
            ("GET", prefix + "/conversations", false),
            ("GET", prefix + "/conversations/conv", false),
            ("DELETE", prefix + "/conversations/conv", false),
            ("GET", prefix + "/conversations/conv/responses", false),
            ("GET", prefix + "/conversations/conv/responses/response", false),
            ("GET", prefix + "/conversations/conv/responses/response/items", false),
            ("GET", prefix + "/conversations/conv/items", false),
            ("GET", prefix + "/conversations/conv/items/item", false),
            ("GET", prefix + "/conversations/conv/items/item/audio", false),
            ("GET", prefix + "/conversations/conv/items/item/audio/content", false),
            ("GET", prefix + "/conversations/conv/items/item/audio/generated", false),
            ("GET", prefix + "/conversations/conv/items/item/audio/generated/content", false),
            ("GET", prefix + "/conversations/conv/audio", false),
            ("GET", prefix + "/conversations/conv/audio/content", false),
            ("GET", "/agents/agent/telephony/bindings", false),
            ("POST", "/agents/agent/telephony/bindings", false),
            ("PATCH", "/agents/agent/telephony/bindings/binding", false),
            ("DELETE", "/agents/agent/telephony/bindings/binding", false),
            ("POST", "/agents/agent/telephony/calls/call:transfer", false),
            ("POST", "/agents/agent/telephony/calls/call:end", false),
            ("PUT", "/agents/agent/telephony/transfer_targets", false),
            ("GET", "/agents/agent/telephony_call_jobs", false),
            ("GET", "/agents/agent/telephony_call_jobs/job", false),
            ("POST", "/agents/agent/telephony_call_jobs", false),
            ("POST", "/agents/agent/telephony_call_jobs/job:cancel", false),
            ("DELETE", "/agents/agent/telephony_call_jobs/job", false),
            ("GET", prefix + "/live/conversations", true),
            ("GET", prefix + "/live/conversations/conv", true),
            ("DELETE", prefix + "/live/conversations/conv", true),
            ("GET", prefix + "/live/conversations/conv/items", true),
            ("GET", prefix + "/live/conversations/conv/items/item", true),
            ("GET", prefix + "/live/conversations/conv/items/item/audio", true),
            ("GET", prefix + "/live/conversations/conv/items/item/audio/content", true),
            ("GET", prefix + "/live/conversations/conv/audio", true),
            ("GET", prefix + "/live/conversations/conv/audio/content", true),
            ("PUT", "/agents/agent/telephony_campaigns/campaign", true),
            ("GET", "/agents/agent/telephony_campaigns/campaign", true),
            ("GET", "/agents/agent/telephony_campaigns", true),
            ("POST", "/agents/agent/telephony_campaigns/campaign:cancel", true),
            ("DELETE", "/agents/agent/telephony_campaigns/campaign", true),
            ("GET", "/agents/agent/telephony_campaigns/campaign/validation_errors", true),
            ("GET", "/agents/agent/telephony_campaigns/campaign/operations/operation", true)
        ];
        foreach (bool isAsync in new[] { false, true })
        {
            foreach (var request in cases)
            {
                yield return new TestCaseData(isAsync, request.Method, request.Path, request.Required);
            }
        }
    }

    [TestCaseSource(nameof(VoiceRequests))]
    public async Task VoicePreviewHeaderMatchesOperationScope(bool isAsync, string method, string path, bool required)
    {
        MockPipelineTransport transport = new(_ => new MockPipelineResponse(200)) { ExpectSyncPipeline = !isAsync };
        AgentAdministrationClient client = new(Endpoint, new FakeTokenProvider(),
            new AgentAdministrationClientOptions { Transport = transport });
        await SendRequest(client.Pipeline, isAsync, method, path);

        Assert.That(transport.Requests, Has.Count.EqualTo(1));
        bool present = transport.Requests[0].Headers.TryGetValue("Foundry-Features", out string features);
        Assert.That(present, Is.EqualTo(required));
        if (required)
        {
            Assert.That(features, Is.EqualTo(Preview));
        }
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task SettingsPipelineAlsoSuppliesRequiredPreview(bool isAsync)
    {
        MockPipelineTransport transport = new(_ => new MockPipelineResponse(200)) { ExpectSyncPipeline = !isAsync };
        AgentAdministrationClient client = new((AuthenticationPolicy)null, Endpoint,
            new AgentAdministrationClientOptions { Transport = transport });
        await SendRequest(client.Pipeline, isAsync, "GET", "/agents/agent/endpoint/protocols/voice/live/conversations");

        Assert.That(transport.Requests[0].Headers.TryGetValue("Foundry-Features", out string features), Is.True);
        Assert.That(features, Is.EqualTo(Preview));
    }

    [TestCase(false, "/agents/agent/telephony/bindings", "VoiceAgents=V1Preview")]
    [TestCase(true, "/agents/agent/telephony/bindings", "VoiceAgents=V1Preview")]
    [TestCase(false, "/agents/agent/telephony_call_jobs/job:cancel", "Other=V2Preview,VoiceAgents=V1Preview")]
    [TestCase(true, "/agents/agent/telephony_call_jobs/job:cancel", "Other=V2Preview,VoiceAgents=V1Preview")]
    public async Task ConditionalCallerOptInIsNotOverwritten(bool isAsync, string path, string explicitFeatures)
    {
        MockPipelineTransport transport = new(_ => new MockPipelineResponse(200)) { ExpectSyncPipeline = !isAsync };
        AgentAdministrationClient client = new(Endpoint, new FakeTokenProvider(),
            new AgentAdministrationClientOptions { Transport = transport });
        await SendRequest(client.Pipeline, isAsync, "POST", path, explicitFeatures);

        Assert.That(transport.Requests[0].Headers.TryGetValue("Foundry-Features", out string actual), Is.True);
        Assert.That(actual, Is.EqualTo(explicitFeatures));
    }

    [TestCase(false, "Other=V2Preview", "Other=V2Preview,VoiceAgents=V1Preview")]
    [TestCase(true, "Other=V2Preview", "Other=V2Preview,VoiceAgents=V1Preview")]
    [TestCase(false, "VoiceAgents=V1Preview", "VoiceAgents=V1Preview")]
    [TestCase(true, "VoiceAgents=V1Preview", "VoiceAgents=V1Preview")]
    public async Task RequiredPreviewPreservesOtherOptInsWithoutDuplicates(bool isAsync, string supplied, string expected)
    {
        MockPipelineTransport transport = new(_ => new MockPipelineResponse(200)) { ExpectSyncPipeline = !isAsync };
        AgentAdministrationClient client = new(Endpoint, new FakeTokenProvider(),
            new AgentAdministrationClientOptions { Transport = transport });
        await SendRequest(client.Pipeline, isAsync, "GET",
            "/agents/agent/endpoint/protocols/voice/live/conversations", supplied);

        Assert.That(transport.Requests[0].Headers.TryGetValue("Foundry-Features", out string actual), Is.True);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(false, "VoiceAgents=V2Preview")]
    [TestCase(true, "VoiceAgents=V2Preview")]
    [TestCase(false, "VoiceAgents=V1Preview,VoiceAgents=V2Preview")]
    [TestCase(true, "VoiceAgents=V1Preview,VoiceAgents=V2Preview")]
    public void RequiredPreviewRejectsConflictingVoiceVersions(bool isAsync, string features)
    {
        MockPipelineTransport transport = new(_ => new MockPipelineResponse(200)) { ExpectSyncPipeline = !isAsync };
        AgentAdministrationClient client = new(Endpoint, new FakeTokenProvider(),
            new AgentAdministrationClientOptions { Transport = transport });
        Assert.ThrowsAsync<ArgumentException>(() => SendRequest(client.Pipeline, isAsync, "GET",
            "/agents/agent/endpoint/protocols/voice/live/conversations", features));
        Assert.That(transport.Requests, Is.Empty);
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task UnrelatedFoundryDefaultsArePreservedWithoutVoiceOptIn(bool isAsync)
    {
        MockPipelineTransport transport = new(_ => new MockPipelineResponse(200)) { ExpectSyncPipeline = !isAsync };
        AgentAdministrationClient client = new(Endpoint, new FakeTokenProvider(),
            new AgentAdministrationClientOptions { Transport = transport });
        await SendRequest(client.Pipeline, isAsync, "GET", "/agents");

        Assert.That(transport.Requests[0].Headers.TryGetValue("Foundry-Features", out string features), Is.True);
        Assert.That(features, Does.Contain("Skills=V1Preview").And.Not.Contain("VoiceAgents="));
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task GenerateAgentPublicProtocolSendsNoPreviewHeader(bool isAsync)
    {
        MockPipelineTransport transport = new(_ => new MockPipelineResponse(200).WithContent("{}")) { ExpectSyncPipeline = !isAsync };
        AgentAdministrationClient client = new(Endpoint, new FakeTokenProvider(),
            new AgentAdministrationClientOptions { Transport = transport });
        using BinaryContent content = BinaryContent.Create(BinaryData.FromString("{}"));
        if (isAsync)
        {
            await client.GenerateAgentAsync(content);
        }
        else
        {
            client.GenerateAgent(content);
        }
        Assert.That(transport.Requests[0].Headers.TryGetValue("Foundry-Features", out _), Is.False);
    }

    private static async Task SendRequest(ClientPipeline pipeline, bool isAsync, string method, string path, string features = null)
    {
        using PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = method;
        message.Request.Uri = new Uri(Endpoint.AbsoluteUri + path);
        if (features != null)
        {
            RequestOptions options = new();
            options.SetHeader("Foundry-Features", features);
            message.Apply(options);
        }
        if (isAsync)
        {
            await pipeline.SendAsync(message);
        }
        else
        {
            pipeline.Send(message);
        }
    }

    private sealed class FakeTokenProvider : AuthenticationTokenProvider
    {
        public override GetTokenOptions CreateTokenOptions(IReadOnlyDictionary<string, object> properties) => new(properties);
        public override AuthenticationToken GetToken(GetTokenOptions options, CancellationToken cancellationToken)
            => new("fake-token", "Bearer", DateTimeOffset.UtcNow.AddHours(1), null);
        public override ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions options, CancellationToken cancellationToken)
            => new(GetToken(options, cancellationToken));
    }
}
