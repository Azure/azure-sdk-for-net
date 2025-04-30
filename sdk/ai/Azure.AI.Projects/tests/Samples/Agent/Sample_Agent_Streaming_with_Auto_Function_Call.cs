// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public partial class Sample_Agent_Streaming_with_Auto_Function_Call : SamplesBase<AIProjectsTestEnvironment>
{
    #region Snippet:StreamingWithAutoFunctionCall_DefineFunctionTools
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
    public async Task AutoFunctionCallingWithStreamingExampleAsync()
    {
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif

        AgentsClient client = new(connectionString, new DefaultAzureCredential());

        #region Snippet:StreamingWithAutoFunctionCallAsync_CreateAgent
        Agent agent = await client.CreateAgentAsync(
            model: modelDeploymentName,
            name: "SDK Test Agent - Functions",
                instructions: "You are a weather bot. Use the provided functions to help answer questions. "
                    + "Customize your responses to the user's preferences as much as possible and use friendly "
                    + "nicknames for cities whenever possible.",
            tools: [getCityNicknameTool, getCurrentWeatherAtLocationTool, getUserFavoriteCityTool]
        );
        #endregion

        #region Snippet:StreamingWithAutoFunctionCallAsync_CreateThreadMessage
        AgentThread thread = await client.CreateThreadAsync();

        ThreadMessage message = await client.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What's the weather like in my favorite city?");
        #endregion

        #region Snippet:StreamingWithAutoFunctionCall_EnableAutoFunctionCalls
        List<ToolOutput> toolOutputs = new();
        Dictionary<string, Delegate> toolDelegates = new();
        toolDelegates.Add(nameof(GetWeatherAtLocation), GetWeatherAtLocation);
        toolDelegates.Add(nameof(GetCityNickname), GetCityNickname);
        toolDelegates.Add(nameof(GetUserFavoriteCity), GetUserFavoriteCity);
        AutoFunctionCallOptions autoFunctionCallOptions = new(toolDelegates, 10);
        #endregion

        #region Snippet:StreamingWithAutoFunctionCallAsync
        await foreach (StreamingUpdate streamingUpdate in client.CreateRunStreamingAsync(thread.Id, agent.Id, autoFunctionCallOptions: autoFunctionCallOptions))
        {
            if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
            {
                Console.WriteLine("--- Run started! ---");
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
        #endregion

        #region Snippet:StreamingWithAutoFunctionCallAsync_Cleanup
        await client.DeleteThreadAsync(thread.Id);
        await client.DeleteAgentAsync(agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void AutoFunctionCallingWithStreamingExample()
    {
#if SNIPPET
        var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif

        AgentsClient client = new(connectionString, new DefaultAzureCredential());

        #region Snippet:StreamingWithAutoFunctionCall_CreateAgent
        Agent agent = client.CreateAgent(
            model: modelDeploymentName,
            name: "SDK Test Agent - Functions",
                instructions: "You are a weather bot. Use the provided functions to help answer questions. "
                    + "Customize your responses to the user's preferences as much as possible and use friendly "
                    + "nicknames for cities whenever possible.",
            tools: [getCityNicknameTool, getCurrentWeatherAtLocationTool, getUserFavoriteCityTool]
        );
        #endregion

        #region Snippet:StreamingWithAutoFunctionCall_CreateThreadMessage
        AgentThread thread = client.CreateThread();

        ThreadMessage message = client.CreateMessage(
            thread.Id,
            MessageRole.User,
            "What's the weather like in my favorite city?");
        #endregion

        List<ToolOutput> toolOutputs = new();
        Dictionary<string, Delegate> toolDelegates = new();
        toolDelegates.Add(nameof(GetWeatherAtLocation), GetWeatherAtLocation);
        toolDelegates.Add(nameof(GetCityNickname), GetCityNickname);
        toolDelegates.Add(nameof(GetUserFavoriteCity), GetUserFavoriteCity);
        AutoFunctionCallOptions autoFunctionCallOptions = new(toolDelegates, 10);

        #region Snippet:StreamingWithAutoFunctionCall
        CollectionResult<StreamingUpdate> stream = client.CreateRunStreaming(thread.Id, agent.Id, autoFunctionCallOptions: autoFunctionCallOptions);
        foreach (StreamingUpdate streamingUpdate in stream)
        {
            if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
            {
                Console.WriteLine("--- Run started! ---");
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
        #endregion

        #region Snippet:StreamingWithAutoFunctionCall_Cleanup
        client.DeleteThread(thread.Id);
        client.DeleteAgent(agent.Id);
        #endregion
    }
}
