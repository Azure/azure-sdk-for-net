// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public partial class Sample_Agent_Functions : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    [AsyncOnly]
    public async Task FunctionCallingExample()
    {
        #region Snippet:Functions_CreateClient
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AgentsClient client = new(connectionString, new DefaultAzureCredential());
        #endregion

        #region Snippet:FunctionsDefineFunctionTools
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

        #region Snippet:FunctionsHandleFunctionCalls
        ToolOutput GetResolvedToolOutput(RequiredToolCall toolCall)
        {
            if (toolCall is RequiredFunctionToolCall functionToolCall)
            {
                if (functionToolCall.Name == getUserFavoriteCityTool.Name)
                {
                    return new ToolOutput(toolCall, GetUserFavoriteCity());
                }
                using JsonDocument argumentsJson = JsonDocument.Parse(functionToolCall.Arguments);
                if (functionToolCall.Name == getCityNicknameTool.Name)
                {
                    string locationArgument = argumentsJson.RootElement.GetProperty("location").GetString();
                    return new ToolOutput(toolCall, GetCityNickname(locationArgument));
                }
                if (functionToolCall.Name == getCurrentWeatherAtLocationTool.Name)
                {
                    string locationArgument = argumentsJson.RootElement.GetProperty("location").GetString();
                    if (argumentsJson.RootElement.TryGetProperty("unit", out JsonElement unitElement))
                    {
                        string unitArgument = unitElement.GetString();
                        return new ToolOutput(toolCall, GetWeatherAtLocation(locationArgument, unitArgument));
                    }
                    return new ToolOutput(toolCall, GetWeatherAtLocation(locationArgument));
                }
            }
            return null;
        }
        #endregion

        #region Snippet:FunctionsCreateAgentWithFunctionTools
        // note: parallel function calling is only supported with newer models like gpt-4-1106-preview
        Agent agent = await client.CreateAgentAsync(
            model: modelDeploymentName,
            name: "SDK Test Agent - Functions",
                instructions: "You are a weather bot. Use the provided functions to help answer questions. "
                    + "Customize your responses to the user's preferences as much as possible and use friendly "
                    + "nicknames for cities whenever possible.",
            tools: [ getUserFavoriteCityTool, getCityNicknameTool, getCurrentWeatherAtLocationTool ]
            );
        #endregion
        #region Snippet:Functions_CreateRun
        AgentThread thread = await client.CreateThreadAsync();

        await client.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What's the weather like in my favorite city?");

        ThreadRun run = await client.CreateRunAsync(thread, agent);
        #endregion
        #region Snippet:FunctionsHandlePollingWithRequiredAction
        do
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            run = await client.GetRunAsync(thread.Id, run.Id);

            if (run.Status == RunStatus.RequiresAction
                && run.RequiredAction is SubmitToolOutputsAction submitToolOutputsAction)
            {
                List<ToolOutput> toolOutputs = [];
                foreach (RequiredToolCall toolCall in submitToolOutputsAction.ToolCalls)
                {
                    toolOutputs.Add(GetResolvedToolOutput(toolCall));
                }
                run = await client.SubmitToolOutputsToRunAsync(run, toolOutputs);
            }
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress);
        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        #endregion

        #region Snippet:Functions_ListMessages
        PageableList<ThreadMessage> messages = await client.GetMessagesAsync(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );

        foreach (ThreadMessage threadMessage in messages)
        {
            Console.Write($"{threadMessage.CreatedAt:yyyy-MM-dd HH:mm:ss} - {threadMessage.Role,10}: ");
            foreach (MessageContent contentItem in threadMessage.ContentItems)
            {
                if (contentItem is MessageTextContent textItem)
                {
                    Console.Write(textItem.Text);
                }
                else if (contentItem is MessageImageFileContent imageFileItem)
                {
                    Console.Write($"<image from ID: {imageFileItem.FileId}");
                }
                Console.WriteLine();
            }
        }
        #endregion
        #region Snippet:Functions_Cleanup
        await client.DeleteThreadAsync(thread.Id);
        await client.DeleteAgentAsync(agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void FunctionCallingExampleSync()
    {
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AgentsClient client = new AgentsClient(connectionString, new DefaultAzureCredential());

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

        ToolOutput GetResolvedToolOutput(RequiredToolCall toolCall)
        {
            if (toolCall is RequiredFunctionToolCall functionToolCall)
            {
                if (functionToolCall.Name == getUserFavoriteCityTool.Name)
                {
                    return new ToolOutput(toolCall, GetUserFavoriteCity());
                }
                using JsonDocument argumentsJson = JsonDocument.Parse(functionToolCall.Arguments);
                if (functionToolCall.Name == getCityNicknameTool.Name)
                {
                    string locationArgument = argumentsJson.RootElement.GetProperty("location").GetString();
                    return new ToolOutput(toolCall, GetCityNickname(locationArgument));
                }
                if (functionToolCall.Name == getCurrentWeatherAtLocationTool.Name)
                {
                    string locationArgument = argumentsJson.RootElement.GetProperty("location").GetString();
                    if (argumentsJson.RootElement.TryGetProperty("unit", out JsonElement unitElement))
                    {
                        string unitArgument = unitElement.GetString();
                        return new ToolOutput(toolCall, GetWeatherAtLocation(locationArgument, unitArgument));
                    }
                    return new ToolOutput(toolCall, GetWeatherAtLocation(locationArgument));
                }
            }
            return null;
        }

        #region Snippet:FunctionsSyncCreateAgentWithFunctionTools
        // note: parallel function calling is only supported with newer models like gpt-4-1106-preview
        Agent agent = client.CreateAgent(
            model: modelDeploymentName,
            name: "SDK Test Agent - Functions",
                instructions: "You are a weather bot. Use the provided functions to help answer questions. "
                    + "Customize your responses to the user's preferences as much as possible and use friendly "
                    + "nicknames for cities whenever possible.",
            tools: [getUserFavoriteCityTool, getCityNicknameTool, getCurrentWeatherAtLocationTool]
            );
        #endregion
        #region Snippet:FunctionsSync_CreateRun
        AgentThread thread = client.CreateThread();

        client.CreateMessage(
            thread.Id,
            MessageRole.User,
            "What's the weather like in my favorite city?");

        ThreadRun run = client.CreateRun(thread, agent);
        #endregion
        #region Snippet:FunctionsSyncHandlePollingWithRequiredAction
        do
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            run = client.GetRun(thread.Id, run.Id);

            if (run.Status == RunStatus.RequiresAction
                && run.RequiredAction is SubmitToolOutputsAction submitToolOutputsAction)
            {
                List<ToolOutput> toolOutputs = [];
                foreach (RequiredToolCall toolCall in submitToolOutputsAction.ToolCalls)
                {
                    toolOutputs.Add(GetResolvedToolOutput(toolCall));
                }
                run = client.SubmitToolOutputsToRun(run, toolOutputs);
            }
        }
        while (run.Status == RunStatus.Queued
            || run.Status == RunStatus.InProgress);
        Assert.AreEqual(
            RunStatus.Completed,
            run.Status,
            run.LastError?.Message);
        #endregion

        #region Snippet:FunctionsSync_ListMessages
        PageableList<ThreadMessage> messages = client.GetMessages(
            threadId: thread.Id,
            order: ListSortOrder.Ascending
        );

        foreach (ThreadMessage threadMessage in messages)
        {
            Console.Write($"{threadMessage.CreatedAt:yyyy-MM-dd HH:mm:ss} - {threadMessage.Role,10}: ");
            foreach (MessageContent contentItem in threadMessage.ContentItems)
            {
                if (contentItem is MessageTextContent textItem)
                {
                    Console.Write(textItem.Text);
                }
                else if (contentItem is MessageImageFileContent imageFileItem)
                {
                    Console.Write($"<image from ID: {imageFileItem.FileId}");
                }
                Console.WriteLine();
            }
        }
        #endregion
        #region Snippet:FunctionsSync_Cleanup
        client.DeleteThread(thread.Id);
        client.DeleteAgent(agent.Id);
        #endregion
    }
}
