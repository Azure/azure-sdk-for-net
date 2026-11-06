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
        var modelDeploymentName = Environment.GetEnvironmentVariable("FOUNDRY_REALTIME_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_REALTIME_MODEL_NAME;
#endif
        #region Snippet:Sample_VoiceAgent_ReadConversation_Initialize
        string agentName = $"voice-h-{Guid.NewGuid():N}";
        using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(2));

        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion

        try
        {
            #region Snippet:Sample_VoiceAgent_ReadConversation_Create
            VoiceAgentDefinition definition = new()
            {
                ModelType = VoiceModelType.SelfDeployed,
                Model = modelDeploymentName,
                Instructions = "Respond briefly and helpfully.",
            };
            definition.OutputModalities.Add(VoiceOutputModality.Text);
            ClientResult<ProjectsAgentVersion> created = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
                agentName, new ProjectsAgentVersionCreationOptions(definition), cancellationToken: timeout.Token);
            Console.WriteLine($"Created voice agent {created.Value.Name}: HTTP {created.GetRawResponse().Status}");
            #endregion

            #region Snippet:Sample_VoiceAgent_ReadConversation_HoldSession
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
                bool completed = false;
                await foreach (RealtimeServerUpdate update in session.ReceiveUpdatesAsync(timeout.Token))
                {
                    Console.WriteLine($"Received event: {update.Kind}");
                    if (update is RealtimeServerUpdateResponseOutputTextDone text)
                    {
                        responseText = text.Text;
                    }
                    else if (update is RealtimeServerUpdateResponseDone done)
                    {
                        completed = done.Response.Status == RealtimeResponseStatus.Completed;
                        conversationId = done.Response.ConversationId;
                        break;
                    }
                }
                if (!completed || string.IsNullOrWhiteSpace(responseText) || string.IsNullOrWhiteSpace(conversationId))
                {
                    throw new InvalidOperationException("The voice agent did not complete a stored text response.");
                }
                Console.WriteLine($"Voice agent response: {responseText}");
            }
            #endregion
            #region Snippet:Sample_VoiceAgent_ReadConversation_Read
            // Read the saved messages and responses over REST.
            BetaVoiceAgentsConversations conversationsClient = projectClient.AgentAdministrationClient.GetBetaVoiceAgentEndpointConversations();

            ClientResult<VoiceConversation> conversation = await conversationsClient.GetAgentConversationAsync(
                agentName, conversationId, cancellationToken: timeout.Token);
            if (conversation.Value.Id != conversationId)
            {
                throw new InvalidOperationException("The saved conversation ID did not match the Realtime response.");
            }
            Console.WriteLine($"Conversation {conversation.Value.Id} status: {conversation.Value.Status}; HTTP {conversation.GetRawResponse().Status}");

            int itemCount = 0;
            await foreach (RealtimeItem item in conversationsClient.GetAgentConversationItemsAsync(
                agentName, conversationId, cancellationToken: timeout.Token))
            {
                itemCount++;
                Console.WriteLine($"Conversation item: {item.Kind}");
            }

            int completedResponses = 0;
            await foreach (VoiceResult response in conversationsClient.GetAgentConversationResponsesAsync(
                agentName, conversationId, cancellationToken: timeout.Token))
            {
                if (response.Status == RealtimeResponseStatus.Completed)
                {
                    completedResponses++;
                }
                Console.WriteLine($"Response {response.Id} status: {response.Status}");
            }
            #endregion
            Assert.That(itemCount, Is.GreaterThanOrEqualTo(2));
            Assert.That(completedResponses, Is.GreaterThanOrEqualTo(1));
        }
        finally
        {
            #region Snippet:Sample_VoiceAgent_ReadConversation_Cleanup
            using CancellationTokenSource cleanupTimeout = new(TimeSpan.FromSeconds(30));
            try
            {
                ClientResult deleted = await projectClient.AgentAdministrationClient.DeleteAgentAsync(
                    agentName, cancellationToken: cleanupTimeout.Token);
                Console.WriteLine($"Deleted temporary voice agent {agentName}: HTTP {deleted.GetRawResponse().Status}");
            }
            catch (ClientResultException exception) when (exception.Status == 404)
            {
                Console.WriteLine($"Temporary voice agent {agentName} is already absent.");
            }
            #endregion
        }
        using CancellationTokenSource verificationTimeout = new(TimeSpan.FromSeconds(30));
        ClientResultException notFound = Assert.ThrowsAsync<ClientResultException>(async () =>
            await projectClient.AgentAdministrationClient.GetAgentAsync(agentName, verificationTimeout.Token));
        Assert.That(notFound.Status, Is.EqualTo(404));
        Console.WriteLine($"Verified temporary voice agent {agentName} is absent: HTTP 404");
    }
}
