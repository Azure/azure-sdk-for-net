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

namespace Azure.AI.Agents.Persistent.Tests;

public partial class Sample_PersistentAgents_Functions_Streaming : SamplesBase<AIAgentsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task FunctionCallingWithStreamingExampleAsync()
    {
        #region Snippet:AgentsFunctionsWithStreaming_CreateClient
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
        #endregion

        #region Snippet:AgentsFunctionsWithStreaming_DefineFunctionTools
        // Example of a function that defines no parameters
        string GetUserFavoriteCity() => "Seattle, WA";
        FunctionToolDefinition getUserFavoriteCityTool = new("getUserFavoriteCity", "Gets the user's favorite city.");
        // Example of a function with a single required parameter
        string GetCityNickname(string location) => location switch
        {
            "Seattle, WA" => "The Emerald City",
            _ => throw new NotImplementedException(),
        };
        FunctionToolDefinition getCityNicknameTool = new(
            name: "getCityNickname",
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
        string GetWeatherAtLocation(string location, string temperatureUnit = "f") => location switch
        {
            "Seattle, WA" => temperatureUnit == "f" ? "70f" : "21c",
            _ => throw new NotImplementedException()
        };
        FunctionToolDefinition getCurrentWeatherAtLocationTool = new(
            name: "getCurrentWeatherAtLocation",
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
        #region Snippet:AgentsFunctionsWithStreamingUpdateHandling
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
        #region Snippet:AgentsFunctionsWithStreaming_CreateAgent
        // NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
        PersistentAgent agent = await client.Administration.CreateAgentAsync(
            model: modelDeploymentName,
            name: "SDK Test Agent - Functions",
                instructions: "You are a weather bot. Use the provided functions to help answer questions. "
                    + "Customize your responses to the user's preferences as much as possible and use friendly "
                    + "nicknames for cities whenever possible.",
            tools: [ getUserFavoriteCityTool, getCityNicknameTool, getCurrentWeatherAtLocationTool ]
        );
        #endregion
        #region Snippet:AgentsFunctionsWithStreaming_CreateThread
        PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

        PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What's the weather like in my favorite city?");
        #endregion
        #region Snippet:AgentsFunctionsWithStreamingUpdateCycle
        List<ToolOutput> toolOutputs = [];
        ThreadRun streamRun = null;
        AsyncCollectionResult<StreamingUpdate> stream = client.Runs.CreateRunStreamingAsync(thread.Id, agent.Id);
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
                else if (streamingUpdate.UpdateKind == StreamingUpdateReason.Error && streamingUpdate is RunUpdate errorStep)
                {
                    Console.WriteLine($"Error: {errorStep.Value.LastError}");
                }
            }
            if (toolOutputs.Count > 0)
            {
                stream = client.Runs.SubmitToolOutputsToStreamAsync(streamRun, toolOutputs);
            }
        }
        while (toolOutputs.Count > 0);
        #endregion
        #region Snippet:AgentsFunctionsWithStreaming_Cleanup
        // NOTE: Comment out these two lines if you plan to reuse the agent later.
        await client.Threads.DeleteThreadAsync(thread.Id);
        await client.Administration.DeleteAgentAsync(agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void FunctionCallingWithStreamingExample()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());

        // Example of a function that defines no parameters
        string GetUserFavoriteCity() => "Seattle, WA";
        FunctionToolDefinition getUserFavoriteCityTool = new("getUserFavoriteCity", "Gets the user's favorite city.");
        // Example of a function with a single required parameter
        string GetCityNickname(string location) => location switch
        {
            "Seattle, WA" => "The Emerald City",
            _ => throw new NotImplementedException(),
        };
        FunctionToolDefinition getCityNicknameTool = new(
            name: "getCityNickname",
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
        string GetWeatherAtLocation(string location, string temperatureUnit = "f") => location switch
        {
            "Seattle, WA" => temperatureUnit == "f" ? "70f" : "21c",
            _ => throw new NotImplementedException()
        };
        FunctionToolDefinition getCurrentWeatherAtLocationTool = new(
            name: "getCurrentWeatherAtLocation",
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
        #region Snippet:AgentsFunctionsWithStreamingSync_CreateAgent
        // NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
        PersistentAgent agent = client.Administration.CreateAgent(
            model: modelDeploymentName,
            name: "SDK Test Agent - Functions",
                instructions: "You are a weather bot. Use the provided functions to help answer questions. "
                    + "Customize your responses to the user's preferences as much as possible and use friendly "
                    + "nicknames for cities whenever possible.",
            tools: [getUserFavoriteCityTool, getCityNicknameTool, getCurrentWeatherAtLocationTool]
        );
        #endregion
        #region Snippet:AgentsFunctionsWithStreamingSync_CreateThread
        PersistentAgentThread thread = client.Threads.CreateThread();

        PersistentThreadMessage message = client.Messages.CreateMessage(
            thread.Id,
            MessageRole.User,
            "What's the weather like in my favorite city?");
        #endregion
        #region Snippet:AgentsFunctionsWithStreamingSyncUpdateCycle
        List<ToolOutput> toolOutputs = [];
        ThreadRun streamRun = null;
        CollectionResult<StreamingUpdate> stream = client.Runs.CreateRunStreaming(thread.Id, agent.Id);
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
                else if (streamingUpdate.UpdateKind == StreamingUpdateReason.Error && streamingUpdate is RunUpdate errorStep)
                {
                    Console.WriteLine($"Error: {errorStep.Value.LastError}");
                }
            }
            if (toolOutputs.Count > 0)
            {
                stream = client.Runs.SubmitToolOutputsToStream(streamRun, toolOutputs);
            }
        }
        while (toolOutputs.Count > 0);
        #endregion
        #region Snippet:AgentsFunctionsWithStreamingSync_Cleanup
        // NOTE: Comment out these two lines if you plan to reuse the agent later.
        client.Threads.DeleteThread(thread.Id);
        client.Administration.DeleteAgent(agent.Id);
        #endregion
    }
}
