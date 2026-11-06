// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
public class Sample_VoiceAgent : SamplesBase
{
    public Sample_VoiceAgent(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    [AsyncOnly]
    public async Task VoiceAgentAsync()
    {
#if SNIPPET
        var projectEndpoint = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_REALTIME_MODEL_NAME;
#endif
        string agentName = $"voice-agent-sample-{Guid.NewGuid():N}".Substring(0, 40);

        #region Snippet:Sample_VoiceAgent_Create
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

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
            #region Snippet:Sample_VoiceAgent_Realtime
            // ProjectsRealtimeSessionClient extends OpenAI's RealtimeSessionClient, so it reuses
            // OpenAI's realtime command/event model (SendInputAudioAsync, AddItemAsync,
            // StartResponseAsync, ReceiveUpdatesAsync, ...). Getting one works the same way as with
            // OpenAI's own RealtimeClient: call StartSessionAsync on a ProjectsRealtimeClient; only
            // the WebSocket handshake targets the Foundry voice-agent endpoint instead of OpenAI's
            // own /realtime endpoint.
            using ProjectsRealtimeSessionClient session = (ProjectsRealtimeSessionClient)
                await projectClient.ProjectsRealtimeClient.StartSessionAsync(agentName, intent: null);

            await session.AddItemAsync(RealtimeItem.CreateUserMessageItem("Say hello in one short sentence."));
            await session.StartResponseAsync();

            string responseText = string.Empty;
            await foreach (RealtimeServerUpdate update in session.ReceiveUpdatesAsync())
            {
                Console.WriteLine($"Received event: {update.Kind}");
                if (update is RealtimeServerUpdateResponseOutputTextDone textDoneUpdate)
                {
                    responseText = textDoneUpdate.Text;
                }
                else if (update is RealtimeServerUpdateResponseDone)
                {
                    break;
                }
            }
            Console.WriteLine($"Voice agent response: {responseText}");
            #endregion
        }
        finally
        {
            #region Snippet:Sample_VoiceAgent_Cleanup
            await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentName, agentVersion: agentVersion.Version);
            #endregion
        }
    }
}
