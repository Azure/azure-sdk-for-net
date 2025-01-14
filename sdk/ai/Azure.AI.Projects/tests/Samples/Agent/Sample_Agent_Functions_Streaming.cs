// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public partial class Sample_Agent_Functions_Streaming : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    public async Task FunctionCallingWithStreamingExample()
    {
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        AgentsClient client = new AgentsClient(connectionString, new AzureCliCredential());

        #region FunctionDefinition
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

        #region Snippet:FunctionsHandleFunctionCallsStreaming
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

        #region Snippet:FunctionsCreateAgentWithFunctionToolsStreaming
        // note: parallel function calling is only supported with newer models like gpt-4-1106-preview
        Response<Agent> agentResponse = await client.CreateAgentAsync(
            model: "gpt-4",
            name: "SDK Test Agent - Functions",
                instructions: "You are a weather bot. Use the provided functions to help answer questions. "
                    + "Customize your responses to the user's preferences as much as possible and use friendly "
                    + "nicknames for cities whenever possible.",
            tools: new List<ToolDefinition> { getUserFavoriteCityTool, getCityNicknameTool, getCurrentWeatherAtLocationTool }
            );
        Agent agent = agentResponse.Value;
        #endregion

        Response<AgentThread> threadResponse = await client.CreateThreadAsync();
        AgentThread thread = threadResponse.Value;

        Response<ThreadMessage> messageResponse = await client.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What's the weather like in my favorite city?");
        ThreadMessage message = messageResponse.Value;

        List<ToolOutput> toolOutputs = new();
        ThreadRun streamRun = null;
        await foreach (StreamingUpdate streamingUpdate in client.CreateRunStreamingAsync(thread.Id, agent.Id))
        {
            if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
            {
                Console.WriteLine($"--- Run started! ---");
            }
            else if (streamingUpdate is RequiredActionUpdate submitToolOutputsUpdate)
            {
                toolOutputs.Add(
                    GetResolvedToolOutput(
                        submitToolOutputsUpdate.FunctionName,
                        submitToolOutputsUpdate.ToolCallId,
                        submitToolOutputsUpdate.FunctionArguments
                ));
                streamRun = submitToolOutputsUpdate.Value;
            }
            else if (streamingUpdate is MessageContentUpdate contentUpdate)
            {
                Console.Write(contentUpdate.Text);
            }
        }

        #region Snippet:FunctionsHandlePollingWithRequiredActionStreaming

        if (streamRun.Status == RunStatus.RequiresAction)
        {
            await foreach (StreamingUpdate streamingUpdate in client.SubmitToolOutputsToRunStreamingAsync(thread.Id, agent.Id, toolOutputs))
            {
                if (streamingUpdate is MessageContentUpdate contentUpdate)
                {
                    Console.Write(contentUpdate.Text);
                }
            }
        }
        //do
        //{

            //    if (runResponse.Value.Status == RunStatus.RequiresAction
            //        && runResponse.Value.RequiredAction is SubmitToolOutputsAction submitToolOutputsAction)
            //    {
            //        runResponse = await client.SubmitToolOutputsToRunAsync(runResponse.Value, toolOutputs);
            //    }
            //}
            //while (runResponse.Value.Status == RunStatus.Queued
            //    || runResponse.Value.Status == RunStatus.InProgress);
            #endregion

            //    Response<PageableList<ThreadMessage>> afterRunMessagesResponse
            //        = await client.GetMessagesAsync(thread.Id);
            //    IReadOnlyList<ThreadMessage> messages = afterRunMessagesResponse.Value.Data;

            //    // Note: messages iterate from newest to oldest, with the messages[0] being the most recent
            //    foreach (ThreadMessage threadMessage in messages)
            //    {
            //        Console.Write($"{threadMessage.CreatedAt:yyyy-MM-dd HH:mm:ss} - {threadMessage.Role,10}: ");
            //        foreach (MessageContent contentItem in threadMessage.ContentItems)
            //        {
            //            if (contentItem is MessageTextContent textItem)
            //            {
            //                Console.Write(textItem.Text);
            //            }
            //            else if (contentItem is MessageImageFileContent imageFileItem)
            //            {
            //                Console.Write($"<image from ID: {imageFileItem.FileId}");
            //            }
            //            Console.WriteLine();
            //        }
            //    }
    }
}
