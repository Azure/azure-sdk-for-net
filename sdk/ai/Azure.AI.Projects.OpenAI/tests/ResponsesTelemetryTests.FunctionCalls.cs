// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.AI.Projects.OpenAI.Tests.Utilities;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI.Tests;

public partial class ResponsesTelemetryTests
{
    private static readonly FunctionTool s_getUserFavoriteCityTool = ResponseTool.CreateFunctionTool(
        functionName: "getUserFavoriteCity",
        functionDescription: "Gets the user's favorite city.",
        functionParameters: BinaryData.FromString("{}"),
        strictModeEnabled: false);

    private static readonly FunctionTool s_getCityNicknameTool = ResponseTool.CreateFunctionTool(
        functionName: "getCityNickname",
        functionDescription: "Gets the nickname of a city, e.g. 'LA' for 'Los Angeles, CA'.",
        functionParameters: BinaryData.FromObjectAsJson(
            new
            {
                Type = "object",
                Properties = new
                {
                    Location = new
                    {
                        Type = "string",
                        Description = "The city and state, e.g. San Francisco, CA",
                    },
                },
                Required = new[] { "location" },
            },
            new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }),
        strictModeEnabled: false);

    private static FunctionCallOutputResponseItem ResolveFunctionCall(FunctionCallResponseItem item)
    {
        if (item.FunctionName == "getUserFavoriteCity")
        {
            return ResponseItem.CreateFunctionCallOutputItem(item.CallId, "Seattle, WA");
        }
        if (item.FunctionName == "getCityNickname")
        {
            using JsonDocument args = JsonDocument.Parse(item.FunctionArguments);
            string location = args.RootElement.GetProperty("location").GetString();
            string nickname = location == "Seattle, WA" ? "The Emerald City" : location;
            return ResponseItem.CreateFunctionCallOutputItem(item.CallId, nickname);
        }
        return null;
    }

    [RecordedTest]
    public async Task TestFunctionCallWithContentRecordingEnabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeResponseScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        ProjectResponsesClient client = projectClient.OpenAI.GetProjectResponsesClientForModel(modelDeploymentName);

        // First call: user message with tools → model should issue function_call(s)
        CreateResponseOptions options = new()
        {
            Tools = { s_getUserFavoriteCityTool, s_getCityNicknameTool },
            InputItems = { ResponseItem.CreateUserMessageItem("What's the nickname of my favorite city?") },
        };

        ResponseResult response = await client.CreateResponseAsync(options);

        _exporter.ForceFlush();

        var span1 = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == $"chat {modelDeploymentName}");
        Assert.That(span1, Is.Not.Null, $"Expected span 'chat {modelDeploymentName}'");

        // Output should contain tool_call with function name
        string outputMessages1 = span1.GetTagItem("gen_ai.output.messages") as string;
        Assert.That(outputMessages1, Does.Contain("\"type\":\"tool_call\""));
        Assert.That(outputMessages1, Does.Contain("\"name\":\"getUserFavoriteCity\"").Or.Contains("\"name\":\"getCityNickname\""));

        // Resolve tool calls in a loop until the model returns a final text response
        bool functionCalled;
        do
        {
            List<ResponseItem> nextInputItems = new();
            functionCalled = false;
            foreach (ResponseItem outputItem in response.OutputItems)
            {
                nextInputItems.Add(outputItem);
                if (outputItem is FunctionCallResponseItem functionCall)
                {
                    nextInputItems.Add(ResolveFunctionCall(functionCall));
                    functionCalled = true;
                }
            }

            if (!functionCalled)
            {
                break;
            }

            _exporter.Clear();

            CreateResponseOptions followUpOptions = new()
            {
                Tools = { s_getUserFavoriteCityTool, s_getCityNicknameTool },
            };
            foreach (ResponseItem item in nextInputItems)
            {
                followUpOptions.InputItems.Add(item);
            }

            response = await client.CreateResponseAsync(followUpOptions);
        } while (functionCalled);

        _exporter.ForceFlush();

        var span2 = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == $"chat {modelDeploymentName}");
        Assert.That(span2, Is.Not.Null, $"Expected final span 'chat {modelDeploymentName}'");

        // Input should contain tool_call_response with result content
        string inputMessages2 = span2.GetTagItem("gen_ai.input.messages") as string;
        Assert.That(inputMessages2, Does.Contain("\"type\":\"tool_call_response\""));
        Assert.That(inputMessages2, Does.Contain("\"role\":\"tool\""));
        Assert.That(inputMessages2, Does.Contain("Seattle").Or.Contains("Emerald"));

        // Output should contain assistant text
        string outputMessages2 = span2.GetTagItem("gen_ai.output.messages") as string;
        Assert.That(outputMessages2, Does.Contain("\"role\":\"assistant\""));
        Assert.That(outputMessages2, Does.Contain("\"content\":"));
    }

    [RecordedTest]
    public async Task TestFunctionCallWithContentRecordingDisabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "false", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeResponseScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        ProjectResponsesClient client = projectClient.OpenAI.GetProjectResponsesClientForModel(modelDeploymentName);

        CreateResponseOptions options = new()
        {
            Tools = { s_getUserFavoriteCityTool, s_getCityNicknameTool },
            InputItems = { ResponseItem.CreateUserMessageItem("What's the nickname of my favorite city?") },
        };

        ResponseResult response = await client.CreateResponseAsync(options);

        _exporter.ForceFlush();

        var span1 = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == $"chat {modelDeploymentName}");
        Assert.That(span1, Is.Not.Null);

        // Output should contain tool_call but NOT function name or arguments
        string outputMessages1 = span1.GetTagItem("gen_ai.output.messages") as string;
        Assert.That(outputMessages1, Does.Contain("\"type\":\"tool_call\""));
        Assert.That(outputMessages1, Does.Not.Contain("\"name\":"));
        Assert.That(outputMessages1, Does.Not.Contain("\"arguments\":"));

        // Resolve tool calls in a loop until the model returns a final text response
        bool functionCalled;
        do
        {
            List<ResponseItem> nextInputItems = new();
            functionCalled = false;
            foreach (ResponseItem outputItem in response.OutputItems)
            {
                nextInputItems.Add(outputItem);
                if (outputItem is FunctionCallResponseItem functionCall)
                {
                    nextInputItems.Add(ResolveFunctionCall(functionCall));
                    functionCalled = true;
                }
            }

            if (!functionCalled)
            {
                break;
            }

            _exporter.Clear();

            CreateResponseOptions followUpOptions = new()
            {
                Tools = { s_getUserFavoriteCityTool, s_getCityNicknameTool },
            };
            foreach (ResponseItem item in nextInputItems)
            {
                followUpOptions.InputItems.Add(item);
            }

            response = await client.CreateResponseAsync(followUpOptions);
        } while (functionCalled);

        _exporter.ForceFlush();

        var span2 = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == $"chat {modelDeploymentName}");
        Assert.That(span2, Is.Not.Null);

        // Input should contain tool_call_response but NOT the result content
        string inputMessages2 = span2.GetTagItem("gen_ai.input.messages") as string;
        Assert.That(inputMessages2, Does.Contain("\"type\":\"tool_call_response\""));
        Assert.That(inputMessages2, Does.Contain("\"role\":\"tool\""));
        Assert.That(inputMessages2, Does.Not.Contain("Seattle"));
        Assert.That(inputMessages2, Does.Not.Contain("Emerald"));
        Assert.That(inputMessages2, Does.Not.Contain("\"result\":"));

        // Output should not contain content
        string outputMessages2 = span2.GetTagItem("gen_ai.output.messages") as string;
        Assert.That(outputMessages2, Does.Contain("\"role\":\"assistant\""));
        Assert.That(outputMessages2, Does.Not.Contain("\"content\":"));
    }

    [RecordedTest]
    public async Task TestFunctionCallStreamingWithContentRecordingEnabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeResponseScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        ProjectResponsesClient client = projectClient.OpenAI.GetProjectResponsesClientForModel(modelDeploymentName);

        CreateResponseOptions options = new()
        {
            Tools = { s_getUserFavoriteCityTool, s_getCityNicknameTool },
            InputItems = { ResponseItem.CreateUserMessageItem("What's the nickname of my favorite city?") },
            StreamingEnabled = true,
        };

        ResponseResult completedResponse = null;
        await foreach (StreamingResponseUpdate update in client.CreateResponseStreamingAsync(options))
        {
            if (update is StreamingResponseCompletedUpdate completed)
            {
                completedResponse = completed.Response;
            }
        }

        Assert.That(completedResponse, Is.Not.Null);

        _exporter.ForceFlush();

        var span1 = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == $"chat {modelDeploymentName}");
        Assert.That(span1, Is.Not.Null);

        string outputMessages1 = span1.GetTagItem("gen_ai.output.messages") as string;
        Assert.That(outputMessages1, Does.Contain("\"type\":\"tool_call\""));
        Assert.That(outputMessages1, Does.Contain("\"name\":\"getUserFavoriteCity\"").Or.Contains("\"name\":\"getCityNickname\""));

        // Resolve tool calls in a loop until the model returns a final text response
        bool functionCalled;
        do
        {
            List<ResponseItem> nextInputItems = new();
            functionCalled = false;
            foreach (ResponseItem outputItem in completedResponse.OutputItems)
            {
                nextInputItems.Add(outputItem);
                if (outputItem is FunctionCallResponseItem functionCall)
                {
                    nextInputItems.Add(ResolveFunctionCall(functionCall));
                    functionCalled = true;
                }
            }

            if (!functionCalled)
            {
                break;
            }

            _exporter.Clear();

            CreateResponseOptions followUpOptions = new()
            {
                Tools = { s_getUserFavoriteCityTool, s_getCityNicknameTool },
                StreamingEnabled = true,
            };
            foreach (ResponseItem item in nextInputItems)
            {
                followUpOptions.InputItems.Add(item);
            }

            completedResponse = null;
            await foreach (StreamingResponseUpdate update in client.CreateResponseStreamingAsync(followUpOptions))
            {
                if (update is StreamingResponseCompletedUpdate completed)
                {
                    completedResponse = completed.Response;
                }
            }

            Assert.That(completedResponse, Is.Not.Null);
        } while (functionCalled);

        _exporter.ForceFlush();

        var span2 = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == $"chat {modelDeploymentName}");
        Assert.That(span2, Is.Not.Null);

        string inputMessages2 = span2.GetTagItem("gen_ai.input.messages") as string;
        Assert.That(inputMessages2, Does.Contain("\"type\":\"tool_call_response\""));
        Assert.That(inputMessages2, Does.Contain("\"role\":\"tool\""));
        Assert.That(inputMessages2, Does.Contain("Seattle").Or.Contains("Emerald"));

        string outputMessages2 = span2.GetTagItem("gen_ai.output.messages") as string;
        Assert.That(outputMessages2, Does.Contain("\"role\":\"assistant\""));
        Assert.That(outputMessages2, Does.Contain("\"content\":"));
    }

    [RecordedTest]
    public async Task TestFunctionCallStreamingWithContentRecordingDisabled()
    {
        Environment.SetEnvironmentVariable(TraceContentsEnvironmentVariable, "false", EnvironmentVariableTarget.Process);
        Environment.SetEnvironmentVariable(EnableOpenTelemetryEnvironmentVariable, "true", EnvironmentVariableTarget.Process);
        ReinitializeResponseScopeConfiguration();

        AIProjectClient projectClient = GetTestProjectClient();
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        ProjectResponsesClient client = projectClient.OpenAI.GetProjectResponsesClientForModel(modelDeploymentName);

        CreateResponseOptions options = new()
        {
            Tools = { s_getUserFavoriteCityTool, s_getCityNicknameTool },
            InputItems = { ResponseItem.CreateUserMessageItem("What's the nickname of my favorite city?") },
            StreamingEnabled = true,
        };

        ResponseResult completedResponse = null;
        await foreach (StreamingResponseUpdate update in client.CreateResponseStreamingAsync(options))
        {
            if (update is StreamingResponseCompletedUpdate completed)
            {
                completedResponse = completed.Response;
            }
        }

        Assert.That(completedResponse, Is.Not.Null);

        _exporter.ForceFlush();

        var span1 = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == $"chat {modelDeploymentName}");
        Assert.That(span1, Is.Not.Null);

        string outputMessages1 = span1.GetTagItem("gen_ai.output.messages") as string;
        Assert.That(outputMessages1, Does.Contain("\"type\":\"tool_call\""));
        Assert.That(outputMessages1, Does.Not.Contain("\"name\":"));
        Assert.That(outputMessages1, Does.Not.Contain("\"arguments\":"));

        // Resolve tool calls in a loop until the model returns a final text response
        bool functionCalled;
        do
        {
            List<ResponseItem> nextInputItems = new();
            functionCalled = false;
            foreach (ResponseItem outputItem in completedResponse.OutputItems)
            {
                nextInputItems.Add(outputItem);
                if (outputItem is FunctionCallResponseItem functionCall)
                {
                    nextInputItems.Add(ResolveFunctionCall(functionCall));
                    functionCalled = true;
                }
            }

            if (!functionCalled)
            {
                break;
            }

            _exporter.Clear();

            CreateResponseOptions followUpOptions = new()
            {
                Tools = { s_getUserFavoriteCityTool, s_getCityNicknameTool },
                StreamingEnabled = true,
            };
            foreach (ResponseItem item in nextInputItems)
            {
                followUpOptions.InputItems.Add(item);
            }

            completedResponse = null;
            await foreach (StreamingResponseUpdate update in client.CreateResponseStreamingAsync(followUpOptions))
            {
                if (update is StreamingResponseCompletedUpdate completed)
                {
                    completedResponse = completed.Response;
                }
            }

            Assert.That(completedResponse, Is.Not.Null);
        } while (functionCalled);

        _exporter.ForceFlush();

        var span2 = _exporter.GetExportedActivities().FirstOrDefault(s => s.DisplayName == $"chat {modelDeploymentName}");
        Assert.That(span2, Is.Not.Null);

        string inputMessages2 = span2.GetTagItem("gen_ai.input.messages") as string;
        Assert.That(inputMessages2, Does.Contain("\"type\":\"tool_call_response\""));
        Assert.That(inputMessages2, Does.Contain("\"role\":\"tool\""));
        Assert.That(inputMessages2, Does.Not.Contain("Seattle"));
        Assert.That(inputMessages2, Does.Not.Contain("Emerald"));
        Assert.That(inputMessages2, Does.Not.Contain("\"result\":"));

        string outputMessages2 = span2.GetTagItem("gen_ai.output.messages") as string;
        Assert.That(outputMessages2, Does.Contain("\"role\":\"assistant\""));
        Assert.That(outputMessages2, Does.Not.Contain("\"content\":"));
}
}
