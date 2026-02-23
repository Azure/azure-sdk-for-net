using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.Projects.OpenAI;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Projects.Tests;

public partial class ResponsesTelemetryTests
{
    [RecordedTest]
    public async Task TestResponseStreamingWithTelemetry()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeResponseScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        ProjectResponsesClient client = projectClient.OpenAI.GetProjectResponsesClientForModel(modelDeploymentName);

        CreateResponseOptions options = new()
        {
            InputItems = { ResponseItem.CreateUserMessageItem("Count from 1 to 5") },
            StreamingEnabled = true
        };

        var deltaTexts = new List<string>();
        await foreach (StreamingResponseUpdate update in client.CreateResponseStreamingAsync(options))
        {
            if (update is StreamingResponseOutputTextDeltaUpdate textDelta)
            {
                deltaTexts.Add(textDelta.Delta);
            }
        }

        Assert.That(deltaTexts.Count, Is.GreaterThan(0), "Should have received text deltas");

        _exporter.ForceFlush();

        var span = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == $"chat {modelDeploymentName}");
        Assert.That(span, Is.Not.Null, $"Expected span 'chat {modelDeploymentName}'");

        var expectedAttributes = new Dictionary<string, object>
        {
            { "gen_ai.provider.name", "microsoft.foundry" },
            { "gen_ai.operation.name", "chat" },
            { "server.address", "*" },
            { "az.namespace", "Microsoft.CognitiveServices" },
            { "gen_ai.request.model", modelDeploymentName },
            { "gen_ai.response.model", "*" },
            { "gen_ai.response.id", "*" },
            { "gen_ai.usage.input_tokens", "+" },
            { "gen_ai.usage.output_tokens", "+" },
            { "gen_ai.input.messages", "*" },
            { "gen_ai.output.messages", "*" },
        };
        GenAiTraceVerifier.ValidateSpanAttributes(span, expectedAttributes, allowUnexpected: false);

        string outputMessages = span.GetTagItem("gen_ai.output.messages") as string;
        Assert.That(outputMessages, Does.Contain("\"role\":\"assistant\""));
        Assert.That(outputMessages, Does.Contain("\"content\":"));
        Assert.That(outputMessages, Does.Contain("\"finish_reason\":\"completed\""));
    }
}
