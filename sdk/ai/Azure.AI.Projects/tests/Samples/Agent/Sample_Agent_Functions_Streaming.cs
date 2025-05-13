// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public partial class Sample_Agent_Functions_Streaming : SamplesBase<AIProjectsTestEnvironment>
{
    #region Snippet:FunctionsWithStreaming_DefineFunctionTools
    // Example of a function that defines no parameters
    private string GetUserFavoriteCity() => "Seattle, WA";
    private FunctionToolDefinition getUserFavoriteCityTool = new("GetUserFavoriteCity", "Gets the user's favorite city.");
    // Example of a function with a single required parameter
    private string GetCityNickname(string location) => location switch
    {
        "Seattle, WA" => "The Emerald City",
        _ => throw new NotImplementedException(),
    };
    private FunctionToolDefinition getCityNicknameTool = new(
        name: "GetCityNickname",
        description: "Gets the nickname of a city, e.g. 'LA' for 'Los Angeles, CA'.",
        parameters: BinaryData.FromObjectAsJson(
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
            new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));
    // Example of a function with one required and one optional, enum parameter
    private string GetWeatherAtLocation(string location, string temperatureUnit = "f") => location switch
    {
        "Seattle, WA" => temperatureUnit == "f" ? "70f" : "21c",
        _ => throw new NotImplementedException()
    };
    private FunctionToolDefinition getCurrentWeatherAtLocationTool = new(
        name: "GetWeatherAtLocation",
        description: "Gets the current weather at a provided location.",
        parameters: BinaryData.FromObjectAsJson(
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
                    Unit = new
                    {
                        Type = "string",
                        Enum = new[] { "c", "f" },
                    },
                },
                Required = new[] { "location" },
            },
            new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));
    #endregion

    [Test]
    [AsyncOnly]
    public async Task FunctionCallingWithStreamingExampleAsync()
    {
        #region Snippet:FunctionsWithStreaming_CreateClient
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AgentsClient client = new(connectionString, new DefaultAzureCredential());
        #endregion

        #region Snippet:FunctionsWithStreamingUpdateHandling
        ToolOutput GetResolvedToolOutput(string functionName, string toolCallId, string functionArguments)
        {
            if (functionName == getUserFavoriteCityTool.Name)
            {
                return new ToolOutput(toolCallId, GetUserFavoriteCity());
            }
            using JsonDocument argumentsJson = JsonDocument.Parse(functionArguments);
            if (functionName == getCityNicknameTool.Name)
            {
                string locationArgument = argumentsJson.RootElement.GetProperty("location").GetString();
                return new ToolOutput(toolCallId, GetCityNickname(locationArgument));
            }
            if (functionName == getCurrentWeatherAtLocationTool.Name)
            {
                string locationArgument = argumentsJson.RootElement.GetProperty("location").GetString();
                if (argumentsJson.RootElement.TryGetProperty("unit", out JsonElement unitElement))
                {
                    string unitArgument = unitElement.GetString();
                    return new ToolOutput(toolCallId, GetWeatherAtLocation(locationArgument, unitArgument));
                }
                return new ToolOutput(toolCallId, GetWeatherAtLocation(locationArgument));
            }
            return null;
        }
        #endregion
        #region Snippet:FunctionsWithStreaming_CreateAgent
        Agent agent = await client.CreateAgentAsync(
            model: modelDeploymentName,
            name: "SDK Test Agent - Functions",
                instructions: "You are a weather bot. Use the provided functions to help answer questions. "
                    + "Customize your responses to the user's preferences as much as possible and use friendly "
                    + "nicknames for cities whenever possible.",
            tools: [ getUserFavoriteCityTool, getCityNicknameTool, getCurrentWeatherAtLocationTool ]
        );
        #endregion
        #region Snippet:FunctionsWithStreaming_CreateThread
        AgentThread thread = await client.CreateThreadAsync();

        ThreadMessage message = await client.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What's the weather like in my favorite city?");
        #endregion
        #region Snippet:FunctionsWithStreamingUpdateCycle
        List<ToolOutput> toolOutputs = [];
        ThreadRun streamRun = null;
        AsyncCollectionResult<StreamingUpdate> stream = client.CreateRunStreamingAsync(thread.Id, agent.Id);
        do
        {
            toolOutputs.Clear();
            await foreach (StreamingUpdate streamingUpdate in stream)
            {
                if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
                {
                    Console.WriteLine("--- Run started! ---");
                }
                else if (streamingUpdate is RequiredActionUpdate submitToolOutputsUpdate)
                {
                    RequiredActionUpdate newActionUpdate = submitToolOutputsUpdate;
                    toolOutputs.Add(
                        GetResolvedToolOutput(
                            newActionUpdate.FunctionName,
                            newActionUpdate.ToolCallId,
                            newActionUpdate.FunctionArguments
                    ));
                    streamRun = submitToolOutputsUpdate.Value;
                }
                else if (streamingUpdate is MessageContentUpdate contentUpdate)
                {
                    Console.Write(contentUpdate.Text);
                }
                else if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCompleted)
                {
                    Console.WriteLine();
                    Console.WriteLine("--- Run completed! ---");
                }
            }
            if (toolOutputs.Count > 0)
            {
                stream = client.SubmitToolOutputsToStreamAsync(streamRun, toolOutputs);
            }
        }
        while (toolOutputs.Count > 0);
        #endregion
        #region Snippet:FunctionsWithStreaming_Cleanup
        await client.DeleteThreadAsync(thread.Id);
        await client.DeleteAgentAsync(agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void FunctionCallingWithStreamingExample()
    {
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AgentsClient client = new(connectionString, new DefaultAzureCredential());

        ToolOutput GetResolvedToolOutput(string functionName, string toolCallId, string functionArguments)
        {
            if (functionName == getUserFavoriteCityTool.Name)
            {
                return new ToolOutput(toolCallId, GetUserFavoriteCity());
            }
            using JsonDocument argumentsJson = JsonDocument.Parse(functionArguments);
            if (functionName == getCityNicknameTool.Name)
            {
                string locationArgument = argumentsJson.RootElement.GetProperty("location").GetString();
                return new ToolOutput(toolCallId, GetCityNickname(locationArgument));
            }
            if (functionName == getCurrentWeatherAtLocationTool.Name)
            {
                string locationArgument = argumentsJson.RootElement.GetProperty("location").GetString();
                if (argumentsJson.RootElement.TryGetProperty("unit", out JsonElement unitElement))
                {
                    string unitArgument = unitElement.GetString();
                    return new ToolOutput(toolCallId, GetWeatherAtLocation(locationArgument, unitArgument));
                }
                return new ToolOutput(toolCallId, GetWeatherAtLocation(locationArgument));
            }
            return null;
        }

        #region Snippet:FunctionsWithStreamingSync_CreateAgent
        Agent agent = client.CreateAgent(
            model: modelDeploymentName,
            name: "SDK Test Agent - Functions",
                instructions: "You are a weather bot. Use the provided functions to help answer questions. "
                    + "Customize your responses to the user's preferences as much as possible and use friendly "
                    + "nicknames for cities whenever possible.",
            tools: [getUserFavoriteCityTool, getCityNicknameTool, getCurrentWeatherAtLocationTool]
        );
        #endregion
        #region Snippet:FunctionsWithStreamingSync_CreateThread
        AgentThread thread = client.CreateThread();

        ThreadMessage message = client.CreateMessage(
            thread.Id,
            MessageRole.User,
            "What's the weather like in my favorite city?");
        #endregion
        #region Snippet:FunctionsWithStreamingSyncUpdateCycle
        List<ToolOutput> toolOutputs = [];
        ThreadRun streamRun = null;
        CollectionResult<StreamingUpdate> stream = client.CreateRunStreaming(thread.Id, agent.Id);
        do
        {
            toolOutputs.Clear();
            foreach (StreamingUpdate streamingUpdate in stream)
            {
                if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
                {
                    Console.WriteLine("--- Run started! ---");
                }
                else if (streamingUpdate is RequiredActionUpdate submitToolOutputsUpdate)
                {
                    RequiredActionUpdate newActionUpdate = submitToolOutputsUpdate;
                    toolOutputs.Add(
                        GetResolvedToolOutput(
                            newActionUpdate.FunctionName,
                            newActionUpdate.ToolCallId,
                            newActionUpdate.FunctionArguments
                    ));
                    streamRun = submitToolOutputsUpdate.Value;
                }
                else if (streamingUpdate is MessageContentUpdate contentUpdate)
                {
                    Console.Write(contentUpdate.Text);
                }
                else if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCompleted)
                {
                    Console.WriteLine();
                    Console.WriteLine("--- Run completed! ---");
                }
            }
            if (toolOutputs.Count > 0)
            {
                stream = client.SubmitToolOutputsToStream(streamRun, toolOutputs);
            }
        }
        while (toolOutputs.Count > 0);
        #endregion
        #region Snippet:FunctionsWithStreamingSync_Cleanup
        client.DeleteThread(thread.Id);
        client.DeleteAgent(agent.Id);
        #endregion
    }
}
