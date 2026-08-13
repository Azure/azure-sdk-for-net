// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.WebSockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

#pragma warning disable AAIP001

namespace Azure.AI.Projects.Agents.Tests.Samples;

public class Sample_VoiceAgent : SamplesBase
{
    [Test]
    [AsyncOnly]
    public async Task VoiceAgentAsync()
    {
#if SNIPPET
        var projectEndpoint = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AgentAdministrationClient agentsClient = new(
            endpoint: new Uri(projectEndpoint),
            tokenProvider: new DefaultAzureCredential());
        string agentName = $"voice-agent-sample-{Guid.NewGuid():N}".Substring(0, 40);
        ProjectsAgentVersion agentVersion = null;

        try
        {
            #region Snippet:Sample_VoiceAgent_Create
            VoiceAgentDefinition definition = new(
                modelType: VoiceModelType.SelfDeployed,
                model: modelDeploymentName)
            {
                Instructions = "Respond briefly and helpfully.",
                Store = true
            };
            agentVersion = await agentsClient.CreateAgentVersionAsync(
                agentName,
                new ProjectsAgentVersionCreationOptions(definition));
            #endregion

            #region Snippet:Sample_VoiceAgent_Realtime
            VoiceAgentWebSocket realtimeClient = agentsClient.GetVoiceAgentWebSocket();
            using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(1));
            await using VoiceAgentSession session = await realtimeClient.StartSessionAsync(
                agentName,
                new VoiceAgentConnectionOptions { AgentVersion = agentVersion.Version, Store = true },
                timeout.Token);

            await session.SendCommandAsync(BinaryData.FromObjectAsJson(new
            {
                type = "conversation.item.create",
                item = new
                {
                    type = "message",
                    role = "user",
                    content = new[] { new { type = "input_text", text = "Say hello in one sentence." } }
                }
            }), timeout.Token);
            await session.SendCommandAsync(
                BinaryData.FromObjectAsJson(new { type = "response.create" }),
                timeout.Token);

            await foreach (VoiceAgentSessionMessage update in session.ReceiveUpdatesAsync(timeout.Token))
            {
                if (update.MessageType != WebSocketMessageType.Text)
                {
                    continue;
                }

                using JsonDocument document = JsonDocument.Parse(update.Data);
                string eventType = document.RootElement.GetProperty("type").GetString();
                Console.WriteLine(eventType);
                if (eventType == "response.done")
                {
                    break;
                }
            }
            await session.CloseAsync();
            #endregion

            #region Snippet:Sample_VoiceAgent_Conversations
            AgentEndpointConversations conversationsClient = agentsClient.GetAgentEndpointConversations();
            await foreach (VoiceConversation conversation in conversationsClient.GetAgentConversationsAsync(agentName))
            {
                Console.WriteLine($"Conversation {conversation.Id}: {conversation.Status}");
            }
            #endregion
        }
        finally
        {
            if (agentVersion is not null)
            {
                await agentsClient.DeleteAgentVersionAsync(agentName, agentVersion.Version);
            }
        }
    }

    public Sample_VoiceAgent(bool isAsync) : base(isAsync)
    {
    }
}