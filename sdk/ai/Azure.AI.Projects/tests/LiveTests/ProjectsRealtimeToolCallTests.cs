// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// LIVE function tool-calling tests for Voice Agent realtime streaming -- mirrors the pattern used
// by sdk/voicelive/Azure.AI.VoiceLive/tests/LiveTests/ToolCallTests.cs, adapted to
// ProjectsRealtimeSessionClient's realtime protocol surface. Covers the full round trip of a
// client-side function tool: the agent requests a call, the client supplies a result, and the
// agent completes a follow-up response using that result.

using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Realtime;

#pragma warning disable AAIP001
#pragma warning disable AAIP002
#pragma warning disable OPENAI002

namespace Azure.AI.Projects.Tests.LiveTests;

public class ProjectsRealtimeToolCallTests : ProjectsRealtimeLiveTestBase
{
    public ProjectsRealtimeToolCallTests(bool isAsync) : base(isAsync)
    {
    }

    private async Task EnsureToolCallAgentAsync(Azure.AI.Projects.Agents.AgentAdministrationClient agentsClient, CancellationToken cancellationToken)
    {
        try
        {
            await agentsClient.GetAgentAsync(TOOLCALL_AGENT_NAME, cancellationToken);
        }
        catch
        {
            Azure.AI.Projects.Agents.VoiceAgentDefinition definition = new()
            {
                ModelType = Azure.AI.Projects.Agents.VoiceModelType.SelfDeployed,
                Model = TestEnvironment.FOUNDRY_REALTIME_MODEL_NAME,
                Instructions = "You are a helpful assistant. Always call the get_current_time function " +
                    "to answer any question about the current time, then briefly summarize the result.",
            };
            definition.OutputModalities.Add(Azure.AI.Projects.Agents.VoiceOutputModality.Text);
            definition.Tools.Add(new Azure.AI.Projects.Agents.VoiceAgentFunctionTool("get_current_time")
            {
                Description = "Returns the current time for a given location.",
                Parameters = ModelReaderWriter.Read<global::OpenAI.RealtimeFunctionToolParameters>(BinaryData.FromObjectAsJson(new
                {
                    type = "object",
                    properties = new
                    {
                        location = new
                        {
                            type = "string",
                            description = "The city or location to get the current time for."
                        }
                    },
                    required = Array.Empty<string>()
                })),
            });
            await agentsClient.CreateAgentVersionAsync(
                TOOLCALL_AGENT_NAME,
                new Azure.AI.Projects.Agents.ProjectsAgentVersionCreationOptions(definition),
                cancellationToken: cancellationToken);
        }
    }

    // -----------------------------------------------------------------------
    // Verifies: a function tool call is requested by the agent, the client
    // supplies a function_call_output item, and the agent completes a
    // follow-up response using that result.
    // -----------------------------------------------------------------------
    [Test]
    [AsyncOnly]
    public async Task FunctionToolCallRoundTripCompletesResponse()
    {
        AIProjectClient client = GetLiveClient();
        using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(2));
        await EnsureToolCallAgentAsync(client.AgentAdministrationClient, timeout.Token);

        using ProjectsRealtimeSessionClient session = await client.GetProjectsRealtimeSessionClientAsync(
            TOOLCALL_AGENT_NAME,
            cancellationToken: timeout.Token);

        await session.AddItemAsync(RealtimeItem.CreateUserMessageItem("What time is it right now in Seattle?"), timeout.Token);
        await session.StartResponseAsync(timeout.Token);

        string callId = null;
        string responseText = string.Empty;
        int responseDoneCount = 0;
        await foreach (RealtimeServerUpdate update in session.ReceiveUpdatesAsync(timeout.Token))
        {
            Console.WriteLine($"[event] {update.Kind}");
            if (update is RealtimeServerUpdateResponseFunctionCallArgumentsDone functionCallUpdate)
            {
                callId = functionCallUpdate.CallId;
                Console.WriteLine($"  tool call requested: {functionCallUpdate.FunctionName}({functionCallUpdate.FunctionArguments})");
            }
            else if (update is RealtimeServerUpdateResponseOutputTextDone textDoneUpdate)
            {
                responseText = textDoneUpdate.Text;
            }
            else if (update is RealtimeServerUpdateResponseDone)
            {
                responseDoneCount++;
                if (responseDoneCount == 1)
                {
                    Assert.That(callId, Is.Not.Null.And.Not.Empty, "Expected the agent to request a get_current_time function call.");

                    await session.AddItemAsync(RealtimeItem.CreateFunctionCallOutputItem(callId, "3:24 PM PDT"), timeout.Token);
                    await session.StartResponseAsync(timeout.Token);
                    continue;
                }

                break;
            }
        }

        Console.WriteLine($"Follow-up response after tool call: {responseText}");
        Assert.That(responseDoneCount, Is.EqualTo(2), "Expected a tool-call response followed by a follow-up response.");
        Assert.That(responseText, Is.Not.Null.And.Not.Empty, "Expected a non-empty follow-up response after the tool call completed.");
    }
}
