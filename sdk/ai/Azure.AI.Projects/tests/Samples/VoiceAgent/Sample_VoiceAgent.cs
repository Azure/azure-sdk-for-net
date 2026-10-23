// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Realtime;

#pragma warning disable AAIP001, AAIP002, OPENAI002

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
        string projectEndpoint = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        string modelDeploymentName = Environment.GetEnvironmentVariable("FOUNDRY_REALTIME_MODEL_NAME");
#else
        string projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        string modelDeploymentName = TestEnvironment.FOUNDRY_REALTIME_MODEL_NAME;
#endif
        string agentName = $"voice-agent-sample-{Guid.NewGuid():N}".Substring(0, 40);
        using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(2));

        #region Snippet:Sample_VoiceAgent_Create
        AIProjectClient projectClient = new(new Uri(projectEndpoint), new DefaultAzureCredential());
        VoiceAgentDefinition definition = new()
        {
            ModelType = VoiceModelType.SelfDeployed,
            Model = modelDeploymentName,
            Instructions = "Respond briefly and helpfully."
        };
        definition.OutputModalities.Add(VoiceOutputModality.Text);
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName, new ProjectsAgentVersionCreationOptions(definition), cancellationToken: timeout.Token);
        #endregion

        try
        {
            #region Snippet:Sample_VoiceAgent_Realtime
            using RealtimeSessionClient session = await projectClient.ProjectsRealtimeClient.StartSessionAsync(
                agentName, intent: null, cancellationToken: timeout.Token);
            await session.AddItemAsync(RealtimeItem.CreateUserMessageItem("Say hello in one short sentence."), timeout.Token);
            await session.StartResponseAsync(timeout.Token);

            string responseText = "";
            await foreach (RealtimeServerUpdate update in session.ReceiveUpdatesAsync(timeout.Token))
            {
                Console.WriteLine($"Received event: {update.Kind}");
                if (update is RealtimeServerUpdateResponseOutputTextDone text)
                {
                    responseText = text.Text;
                }
                else if (update is RealtimeServerUpdateResponseDone done)
                {
                    if (done.Response.Status != RealtimeResponseStatus.Completed)
                    {
                        throw new InvalidOperationException("The Realtime response did not complete.");
                    }
                    break;
                }
            }
            Console.WriteLine($"Voice agent response: {responseText}");
            #endregion
            Assert.That(responseText, Is.Not.Empty);
        }
        finally
        {
            #region Snippet:Sample_VoiceAgent_Cleanup
            await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(
                agentName, agentVersion.Version, CancellationToken.None);
            #endregion
        }
    }

    [Test]
    [AsyncOnly]
    public async Task VoiceAgentFunctionToolAsync()
    {
#if SNIPPET
        string projectEndpoint = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        string modelDeploymentName = Environment.GetEnvironmentVariable("FOUNDRY_REALTIME_MODEL_NAME");
#else
        string projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        string modelDeploymentName = TestEnvironment.FOUNDRY_REALTIME_MODEL_NAME;
#endif
        string agentName = $"voice-function-sample-{Guid.NewGuid():N}".Substring(0, 40);
        AIProjectClient project = new(new Uri(projectEndpoint), new DefaultAzureCredential());
        using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(2));

        #region Snippet:Sample_VoiceAgent_Realtime_FunctionTool
        VoiceAgentDefinition definition = new()
        {
            ModelType = VoiceModelType.SelfDeployed,
            Model = modelDeploymentName,
            Instructions = "Call get_test_value, then report the returned value."
        };
        definition.OutputModalities.Add(VoiceOutputModality.Text);
        definition.Tools.Add(new VoiceAgentFunctionTool("get_test_value")
        {
            Description = "Returns a demonstration value. Takes no arguments.",
            Parameters = ModelReaderWriter.Read<RealtimeFunctionToolParameters>(
                BinaryData.FromString("""{"type":"object","properties":{},"additionalProperties":false}"""))
        });
        await project.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName, new ProjectsAgentVersionCreationOptions(definition), cancellationToken: timeout.Token);
        try
        {
            using RealtimeSessionClient session = await project.ProjectsRealtimeClient.StartSessionAsync(
                agentName, intent: null, cancellationToken: timeout.Token);
            await session.AddItemAsync(RealtimeItem.CreateUserMessageItem("Use the function and tell me its value."), timeout.Token);
            await session.StartResponseAsync(
                new RealtimeResponseOptions { ToolChoice = RealtimeDefaultToolChoice.Required }, timeout.Token);

            RealtimeServerUpdateResponseFunctionCallArgumentsDone call = null;
            bool resultSent = false;
            string answer = "";
            await foreach (RealtimeServerUpdate update in session.ReceiveUpdatesAsync(timeout.Token))
            {
                if (update is RealtimeServerUpdateResponseFunctionCallArgumentsDone function)
                {
                    using JsonDocument arguments = JsonDocument.Parse(function.FunctionArguments);
                    if (function.FunctionName != "get_test_value" ||
                        arguments.RootElement.ValueKind != JsonValueKind.Object || arguments.RootElement.EnumerateObject().MoveNext())
                    {
                        throw new InvalidOperationException("Unexpected function or arguments.");
                    }
                    call = function;
                }
                else if (update is RealtimeServerUpdateResponseOutputTextDone text)
                {
                    answer += text.Text;
                    Console.WriteLine(text.Text);
                }
                else if (update is RealtimeServerUpdateResponseDone done)
                {
                    if (done.Response.Status != RealtimeResponseStatus.Completed)
                    {
                        throw new InvalidOperationException("The Realtime response did not complete.");
                    }
                    if (call == null || resultSent)
                    {
                        break;
                    }
                    await session.AddItemAsync(
                        RealtimeItem.CreateFunctionCallOutputItem(call.CallId, """{"value":7}"""), timeout.Token);
                    resultSent = true;
                    await session.StartResponseAsync(
                        new RealtimeResponseOptions { ToolChoice = RealtimeDefaultToolChoice.None }, timeout.Token);
                }
            }
#if !SNIPPET
            Assert.That(resultSent, Is.True);
            Assert.That(answer, Does.Contain("7"));
#endif
        }
        finally
        {
            await project.AgentAdministrationClient.DeleteAgentAsync(agentName, cancellationToken: CancellationToken.None);
        }
        #endregion
    }
}
