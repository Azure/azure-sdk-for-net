// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Realtime;

#pragma warning disable AAIP001
#pragma warning disable AAIP002
#pragma warning disable OPENAI002

namespace Azure.AI.Projects.Tests.Samples;

[NonParallelizable]
[LiveOnly]
public class Sample_VoiceAgent_ReadConversation : SamplesBase
{
    public Sample_VoiceAgent_ReadConversation(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    [AsyncOnly]
    public async Task VoiceAgentReadConversationAsync()
    {
#if SNIPPET
        var projectEndpoint = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_REALTIME_MODEL_NAME;
#endif
        string agentName = $"voice-agent-read-conversation-sample-{Guid.NewGuid():N}".Substring(0, 40);

        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #region Snippet:Sample_VoiceAgent_ReadConversation_Create
        VoiceAgentDefinition definition = new()
        {
            ModelType = VoiceModelType.SelfDeployed,
            Model = modelDeploymentName,
            Instructions = "Respond briefly and helpfully.",
        };
        definition.OutputModalities.Add(VoiceOutputModality.Text);
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName,
            new ProjectsAgentVersionCreationOptions(definition));
        #endregion

        try
        {
            #region Snippet:Sample_VoiceAgent_ReadConversation_HoldSession
            // store: true persists this session's conversation so it can be read back afterward
            // through BetaVoiceAgentsConversations; the response.done event reports the resulting
            // conversation ID.
            string conversationId;
            using (ProjectsRealtimeSessionClient session = await projectClient.GetProjectsRealtimeSessionClientAsync(
                agentName,
                store: true))
            {
                await session.AddItemAsync(RealtimeItem.CreateUserMessageItem("Say hello in one short sentence."));
                await session.StartResponseAsync();

                conversationId = null;
                await foreach (RealtimeServerUpdate update in session.ReceiveUpdatesAsync())
                {
                    Console.WriteLine($"Received event: {update.Kind}");
                    if (update is RealtimeServerUpdateResponseDone doneUpdate)
                    {
                        conversationId = doneUpdate.Response.ConversationId;
                        break;
                    }
                }
            }
            #endregion

            #region Snippet:Sample_VoiceAgent_ReadConversation_Read
            // Once the session above closes, the conversation it produced becomes readable through
            // the REST-only BetaVoiceAgentsConversations surface -- no realtime connection needed.
            BetaVoiceAgentsConversations conversationsClient = projectClient.AgentAdministrationClient.GetBetaVoiceAgentEndpointConversations();

            VoiceConversation conversation = await conversationsClient.GetAgentConversationAsync(agentName, conversationId);
            Console.WriteLine($"Conversation {conversation.Id} status: {conversation.Status}");

            await foreach (RealtimeItem item in conversationsClient.GetAgentConversationItemsAsync(agentName, conversationId))
            {
                Console.WriteLine($"Conversation item: {item.Kind}");
            }

            await foreach (VoiceResponse response in conversationsClient.GetAgentConversationResponsesAsync(agentName, conversationId))
            {
                Console.WriteLine($"Response {response.Id} status: {response.Status}");
            }
            #endregion
        }
        finally
        {
            #region Snippet:Sample_VoiceAgent_ReadConversation_Cleanup
            await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentName, agentVersion: agentVersion.Version);
            #endregion
        }
    }
}
