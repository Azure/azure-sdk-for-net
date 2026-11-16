// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using Microsoft.ClientModel.TestFramework.Mocks;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

#pragma warning disable SCME0002

namespace Azure.AI.Projects.Tests;

public class VoiceAgentPreviewHeaderTests
{
    private static readonly Uri Endpoint = new("https://example.test/api/projects/project");

    [TestCase(false, false)]
    [TestCase(false, true)]
    [TestCase(true, false)]
    [TestCase(true, true)]
    public async Task CachedAgentsGenerateSendsNoPreviewHeader(bool settingsPath, bool isAsync)
    {
        MockPipelineTransport transport = new(_ => new MockPipelineResponse(200).WithContent("{}"))
        {
            ExpectSyncPipeline = !isAsync
        };
        AIProjectClient project = CreateProject(settingsPath, transport);
        using BinaryContent content = BinaryContent.Create(BinaryData.FromString("{}"));
        if (isAsync)
        {
            await project.AgentAdministrationClient.GenerateAgentAsync(content);
        }
        else
        {
            project.AgentAdministrationClient.GenerateAgent(content);
        }
        Assert.That(transport.Requests, Has.Count.EqualTo(1));
        Assert.That(transport.Requests[0].Headers.TryGetValue("Foundry-Features", out _), Is.False);
    }

    [TestCase(false, false, "/agents/agent/endpoint/protocols/voice/conversations", null, null)]
    [TestCase(false, true, "/agents/agent/endpoint/protocols/voice/conversations", null, null)]
    [TestCase(true, false, "/agents/agent/endpoint/protocols/voice/conversations", null, null)]
    [TestCase(true, true, "/agents/agent/endpoint/protocols/voice/conversations", null, null)]
    [TestCase(false, false, "/agents/agent/endpoint/protocols/voice/live/conversations", null, "VoiceAgents=V1Preview")]
    [TestCase(false, true, "/agents/agent/endpoint/protocols/voice/live/conversations", null, "VoiceAgents=V1Preview")]
    [TestCase(true, false, "/agents/agent/endpoint/protocols/voice/live/conversations", null, "VoiceAgents=V1Preview")]
    [TestCase(true, true, "/agents/agent/endpoint/protocols/voice/live/conversations", null, "VoiceAgents=V1Preview")]
    [TestCase(false, false, "/agents/agent/telephony_campaigns", null, "VoiceAgents=V1Preview")]
    [TestCase(false, true, "/agents/agent/telephony_campaigns", null, "VoiceAgents=V1Preview")]
    [TestCase(true, false, "/agents/agent/telephony_campaigns", null, "VoiceAgents=V1Preview")]
    [TestCase(true, true, "/agents/agent/telephony_campaigns", null, "VoiceAgents=V1Preview")]
    [TestCase(false, false, "/agents/agent/telephony/bindings", "VoiceAgents=V1Preview", "VoiceAgents=V1Preview")]
    [TestCase(false, true, "/agents/agent/telephony/bindings", "VoiceAgents=V1Preview", "VoiceAgents=V1Preview")]
    [TestCase(true, false, "/agents/agent/telephony/bindings", "VoiceAgents=V1Preview", "VoiceAgents=V1Preview")]
    [TestCase(true, true, "/agents/agent/telephony/bindings", "VoiceAgents=V1Preview", "VoiceAgents=V1Preview")]
    public async Task InheritedPipelineHonorsVoiceScope(bool settingsPath, bool isAsync, string path, string supplied, string expected)
    {
        MockPipelineTransport transport = new(_ => new MockPipelineResponse(200)) { ExpectSyncPipeline = !isAsync };
        AIProjectClient project = CreateProject(settingsPath, transport);
        ClientPipeline pipeline = project.AgentAdministrationClient.Pipeline;
        using PipelineMessage message = pipeline.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = new Uri(Endpoint.AbsoluteUri + path);
        if (supplied != null)
        {
            RequestOptions options = new();
            options.SetHeader("Foundry-Features", supplied);
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
        bool present = transport.Requests[0].Headers.TryGetValue("Foundry-Features", out string actual);
        Assert.That(present, Is.EqualTo(expected != null));
        if (expected != null)
        {
            Assert.That(actual, Is.EqualTo(expected));
        }
    }

    private static AIProjectClient CreateProject(bool settingsPath, MockPipelineTransport transport)
    {
        AIProjectClientOptions options = new() { Transport = transport };
        FakeTokenProvider provider = new();
        if (!settingsPath)
        {
            return new AIProjectClient(Endpoint, provider, options);
        }
        IConfiguration configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string>
        {
            ["Credential:Scope"] = "https://ai.azure.com/.default"
        }).Build();
        return new AIProjectClient(new AIProjectClientSettings
        {
            Endpoint = Endpoint,
            Options = options,
            Credential = new CredentialSettings(configuration.GetSection("Credential"))
            {
                CredentialSource = "TokenCredential"
            },
            CredentialProvider = provider
        });
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
