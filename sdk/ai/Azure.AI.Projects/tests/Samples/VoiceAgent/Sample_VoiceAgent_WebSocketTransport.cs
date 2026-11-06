// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Threading;
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
public class Sample_VoiceAgent_WebSocketTransport : SamplesBase
{
    public Sample_VoiceAgent_WebSocketTransport(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    [AsyncOnly]
    public async Task VoiceAgentWebSocketTransportAsync()
    {
        #region Snippet:Sample_VoiceAgent_WebSocketTransport_Create
#if SNIPPET
        string projectEndpoint = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        string modelDeploymentName = Environment.GetEnvironmentVariable("FOUNDRY_REALTIME_MODEL_NAME");
#else
        string projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        string modelDeploymentName = TestEnvironment.FOUNDRY_REALTIME_MODEL_NAME;
#endif
        string agentName = $"voice-transport-sample-{Guid.NewGuid():N}".Substring(0, 40);
        AIProjectClient projectClient = new(new Uri(projectEndpoint), new DefaultAzureCredential());

        VoiceAgentDefinition definition = new()
        {
            ModelType = VoiceModelType.SelfDeployed,
            Model = modelDeploymentName,
            Instructions = "Respond briefly and helpfully.",
        };
        definition.OutputModalities.Add(VoiceOutputModality.Text);
        ClientResult<ProjectsAgentVersion> createResult = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName, new ProjectsAgentVersionCreationOptions(definition));
        ProjectsAgentVersion agentVersion = createResult;
        Console.WriteLine($"Created voice agent {agentName} version {agentVersion.Version}: HTTP {createResult.GetRawResponse().Status}");
        #endregion

        try
        {
            #region Snippet:Sample_VoiceAgent_WebSocketTransport_Connect
            using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(2));
            ProjectsRealtimeSessionClientOptions options = new()
            {
                Transport = VoiceAgentTransport.Websocket,
                QueryString = "store=true"
            };
            string conversationId = null;
            using (ProjectsRealtimeSessionClient session = (ProjectsRealtimeSessionClient)
                await projectClient.ProjectsRealtimeClient.StartSessionAsync(
                    agentName, intent: null, options: options, cancellationToken: timeout.Token))
            {
                await session.AddItemAsync(RealtimeItem.CreateUserMessageItem("Say hello in one short sentence."), timeout.Token);
                await session.StartResponseAsync(timeout.Token);

                string responseText = string.Empty;
                bool sawCompletedResponse = false;
                await foreach (RealtimeServerUpdate update in session.ReceiveUpdatesAsync(timeout.Token))
                {
                    Console.WriteLine($"Received event: {update.Kind}");
                    if (update is RealtimeServerUpdateResponseOutputTextDone textDoneUpdate)
                    {
                        responseText = textDoneUpdate.Text;
                    }
                    else if (update is RealtimeServerUpdateResponseDone doneUpdate)
                    {
                        Console.WriteLine($"Response status: {doneUpdate.Response.Status}");
                        sawCompletedResponse = doneUpdate.Response.Status == RealtimeResponseStatus.Completed;
                        conversationId = doneUpdate.Response.ConversationId;
                        break;
                    }
                }
                if (!sawCompletedResponse || string.IsNullOrWhiteSpace(responseText) || string.IsNullOrWhiteSpace(conversationId))
                {
                    throw new InvalidOperationException("The voice agent did not complete a stored text response.");
                }
                Console.WriteLine($"Voice agent response: {responseText}");
            }
            #endregion

            #region Snippet:Sample_VoiceAgent_WebSocketTransport_Read
            ClientResult<VoiceConversation> conversation = await projectClient.AgentAdministrationClient
                .GetBetaVoiceAgentEndpointConversations().GetAgentConversationAsync(agentName, conversationId);
            if (conversation.Value.Id != conversationId)
            {
                throw new InvalidOperationException("The stored conversation ID did not match the realtime session.");
            }
            Console.WriteLine($"Retrieved conversation {conversationId}: HTTP {conversation.GetRawResponse().Status}");
            #endregion
        }
        finally
        {
            #region Snippet:Sample_VoiceAgent_WebSocketTransport_Cleanup
            ClientResult deleteResult = await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(
                agentName: agentName, agentVersion: agentVersion.Version);
            Console.WriteLine($"Deleted voice agent {agentName} version {agentVersion.Version}: HTTP {deleteResult.GetRawResponse().Status}");
            #endregion
        }
    }
}
