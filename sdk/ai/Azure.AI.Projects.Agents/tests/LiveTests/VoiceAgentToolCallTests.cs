// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// LIVE function tool-calling tests for Voice Agent WebSocket streaming — mirrors the pattern
// used by sdk/voicelive/Azure.AI.VoiceLive/tests/LiveTests/ToolCallTests.cs, adapted to
// VoiceAgentSession's realtime protocol surface. Covers the full round trip of a client-side
// function tool: the agent requests a call, the client supplies a result, and the agent
// completes a follow-up response using that result.

using System;
using System.ClientModel.Primitives;
using System.Net.WebSockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI;

#pragma warning disable AAIP001

namespace Azure.AI.Projects.Agents.Tests.LiveTests;

public class VoiceAgentToolCallTests : VoiceAgentLiveTestBase
{
    public VoiceAgentToolCallTests(bool isAsync) : base(isAsync)
    {
    }

    private async Task EnsureToolCallAgentAsync(AgentAdministrationClient agentsClient, CancellationToken cancellationToken)
    {
        try
        {
            await agentsClient.GetAgentAsync(TOOLCALL_AGENT_NAME, cancellationToken);
        }
        catch
        {
            VoiceAgentDefinition definition = new()
            {
                ModelType = VoiceModelType.SelfDeployed,
                Model = TestEnvironment.FOUNDRY_REALTIME_MODEL_NAME,
                Instructions = "You are a helpful assistant. Always call the get_current_time function " +
                    "to answer any question about the current time, then briefly summarize the result.",
            };
            definition.OutputModalities.Add(VoiceOutputModality.Text);
            definition.Tools.Add(new VoiceAgentFunctionTool("get_current_time")
            {
                Description = "Returns the current time for a given location.",
                Parameters = ModelReaderWriter.Read<RealtimeFunctionToolParameters>(BinaryData.FromObjectAsJson(new
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
                new ProjectsAgentVersionCreationOptions(definition),
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
        AgentAdministrationClient agentsClient = GetTestClient();
        using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(2));
        await EnsureToolCallAgentAsync(agentsClient, timeout.Token);

        VoiceAgentWebSocket realtimeClient = agentsClient.GetVoiceAgentWebSocket();
        await using VoiceAgentSession session = await realtimeClient.StartSessionAsync(
            TOOLCALL_AGENT_NAME,
            cancellationToken: timeout.Token);

        await session.AddItemAsync(
            BinaryData.FromObjectAsJson(new
            {
                type = "message",
                role = "user",
                content = new[] { new { type = "input_text", text = "What time is it right now in Seattle?" } }
            }),
            cancellationToken: timeout.Token);
        await session.StartResponseAsync(cancellationToken: timeout.Token);

        string callId = null;
        string responseText = string.Empty;
        int responseDoneCount = 0;
        await foreach (VoiceAgentSessionMessage update in session.ReceiveUpdatesAsync(timeout.Token))
        {
            if (update.MessageType != WebSocketMessageType.Text)
            {
                continue;
            }

            if (update.EventType == RealtimeServerEventType.ResponseFunctionCallArgumentsDone)
            {
                using JsonDocument document = JsonDocument.Parse(update.Data);
                callId = document.RootElement.GetProperty("call_id").GetString();
            }
            else if (update.EventType == RealtimeServerEventType.ResponseOutputTextDone)
            {
                using JsonDocument document = JsonDocument.Parse(update.Data);
                responseText = document.RootElement.GetProperty("text").GetString();
            }
            else if (update.EventType == RealtimeServerEventType.ResponseDone)
            {
                responseDoneCount++;
                if (responseDoneCount == 1)
                {
                    Assert.That(callId, Is.Not.Null.And.Not.Empty, "Expected the agent to request a get_current_time function call.");

                    await session.AddItemAsync(
                        BinaryData.FromObjectAsJson(new
                        {
                            type = "function_call_output",
                            call_id = callId,
                            output = "3:24 PM PDT"
                        }),
                        cancellationToken: timeout.Token);
                    await session.StartResponseAsync(cancellationToken: timeout.Token);
                    continue;
                }

                break;
            }
        }

        Assert.That(responseDoneCount, Is.EqualTo(2), "Expected a tool-call response followed by a follow-up response.");
        Assert.That(responseText, Is.Not.Null.And.Not.Empty, "Expected a non-empty follow-up response after the tool call completed.");
    }
}
