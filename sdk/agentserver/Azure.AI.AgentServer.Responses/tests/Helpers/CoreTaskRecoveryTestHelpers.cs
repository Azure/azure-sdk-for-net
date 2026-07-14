// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Nodes;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using Azure.AI.AgentServer.Responses.Internal.Resilience;

namespace Azure.AI.AgentServer.Responses.Tests.Helpers;

internal static class CoreTaskRecoveryTestHelpers
{
    public static ITaskStore CreateTaskStore(string tasksDir) => new LocalTaskStore(tasksDir);

    public static async Task SeedInterruptedTaskAsync(
        string tasksDir,
        ResponseRecoveryPayload payload,
        string taskName = ResponsesResilientTaskHandler.OneShotTaskName)
    {
        var store = new LocalTaskStore(tasksDir);
        await store.CreateAsync(new TaskCreateRequest
        {
            Id = payload.ResponseId,
            AgentName = TaskEngineConstants.DefaultAgentName,
            SessionId = TaskEngineConstants.DefaultSessionId,
            Title = taskName,
            Status = TaskWireKeys.StatusInProgress,
            Payload = BuildTaskPayload(payload),
            Source = BuildSource(taskName),
            Tags = new Dictionary<string, string>(StringComparer.Ordinal)
            {
                [TaskWireKeys.TagTaskName] = taskName,
            },
        });
    }

    public static int TaskRecordCount(string tasksDir)
        => Directory.Exists(tasksDir)
            ? Directory.GetFiles(tasksDir, "*.json", SearchOption.AllDirectories).Length
            : 0;

    public static async Task<ResponseRecoveryPayload> ReadTaskPayloadAsync(string tasksDir, string responseId)
    {
        var store = new LocalTaskStore(tasksDir);
        var record = await store.GetAsync(responseId)
            ?? throw new InvalidOperationException($"Task '{responseId}' not found.");
        JsonNode input = record.Payload[TaskWireKeys.PayloadInput]
            ?? throw new InvalidOperationException($"Task '{responseId}' has no payload input.");
        return ResponseRecoveryPayload.FromTaskInput(BinaryData.FromString(input.ToJsonString()));
    }

    private static JsonObject BuildTaskPayload(ResponseRecoveryPayload payload)
        => new()
        {
            [TaskWireKeys.PayloadInput] = JsonNode.Parse(payload.ToTaskInput().ToString()),
            [TaskWireKeys.PayloadLastInputId] = payload.ResponseId,
            [TaskWireKeys.PayloadTurnStartedAt] = DateTimeOffset.UtcNow.ToString("O"),
            [TaskWireKeys.PayloadSchemaVersion] = TaskWireKeys.SchemaVersionValue,
        };

    private static JsonObject BuildSource(string taskName)
        => new()
        {
            [TaskWireKeys.SourceType] = TaskWireKeys.SourceTypeValue,
            [TaskWireKeys.SourceName] = taskName,
            [TaskWireKeys.SourceServerVersion] = "Azure.AI.AgentServer.Core.Tests/0.0.0",
            [TaskWireKeys.SourceHostingEnvironment] = string.Empty,
        };
}
