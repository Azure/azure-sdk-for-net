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

public partial class Sample_PersistentAgents_Streaming_with_Auto_Function_Call : SamplesBase<AIAgentsTestEnvironment>
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
        #region Snippet:StreamingWithAutoFunctionCall_CreateClient
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
        #endregion

        #region Snippet:StreamingWithAutoFunctionCallAsync_CreateAgent
        // NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
        PersistentAgent agent = await client.Administration.CreateAgentAsync(
            model: modelDeploymentName,
            name: "SDK Test Agent - Functions",
                instructions: "You are a weather bot. Use the provided functions to help answer questions. "
                    + "Customize your responses to the user's preferences as much as possible and use friendly "
                    + "nicknames for cities whenever possible.",
            tools: [getCityNicknameTool, getCurrentWeatherAtLocationTool, getUserFavoriteCityTool]
        );
        #endregion

        #region Snippet:StreamingWithAutoFunctionCallAsync_CreateThreadMessage
        PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

        PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
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
        CreateRunStreamingOptions runOptions = new()
        {
            AutoFunctionCallOptions = autoFunctionCallOptions
        };
        await foreach (StreamingUpdate streamingUpdate in client.Runs.CreateRunStreamingAsync(thread.Id, agent.Id, options: runOptions))
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
        // NOTE: Comment out these two lines if you plan to reuse the agent later.
        await client.Threads.DeleteThreadAsync(thread.Id);
        await client.Administration.DeleteAgentAsync(agent.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void AutoFunctionCallingWithStreamingExample()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif

        PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());

        #region Snippet:StreamingWithAutoFunctionCall_CreateAgent
        // NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
        PersistentAgent agent = client.Administration.CreateAgent(
            model: modelDeploymentName,
            name: "SDK Test Agent - Functions",
                instructions: "You are a weather bot. Use the provided functions to help answer questions. "
                    + "Customize your responses to the user's preferences as much as possible and use friendly "
                    + "nicknames for cities whenever possible.",
            tools: [getCityNicknameTool, getCurrentWeatherAtLocationTool, getUserFavoriteCityTool]
        );
        #endregion

        #region Snippet:StreamingWithAutoFunctionCall_CreateThreadMessage
        PersistentAgentThread thread = client.Threads.CreateThread();

        PersistentThreadMessage message = client.Messages.CreateMessage(
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
        CreateRunStreamingOptions runOptions = new()
        {
            AutoFunctionCallOptions = autoFunctionCallOptions
        };
        CollectionResult<StreamingUpdate> stream = client.Runs.CreateRunStreaming(thread.Id, agent.Id, options: runOptions);
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
        // NOTE: Comment out these two lines if you plan to reuse the agent later.
        client.Threads.DeleteThread(thread.Id);
        client.Administration.DeleteAgent(agent.Id);
        #endregion
    }
}
