// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Assistants.Samples;

public partial class Samples_Functions
{
    [Test]
    [Ignore("Sample included only for compilation validation.")]
    public async Task FunctionCallingExample()
    {
        // Patterned from https://platform.openai.com/docs/assistants/tools/function-calling

        bool isAzureOpenAI = false;
        string azureResourceUrl = "https://my-resource.openai.azure.com";
        string nonAzureApiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
        string azureApiKey = Environment.GetEnvironmentVariable("AOAI_API_KEY");

        AssistantsClient client = isAzureOpenAI
            ? new AssistantsClient(new Uri(azureResourceUrl), new AzureKeyCredential(azureApiKey))
            : new AssistantsClient(nonAzureApiKey);

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

        #region Snippet:FunctionsCreateAssistantWithFunctionTools
        Response<Assistant> assistantResponse = await client.CreateAssistantAsync(
            // note: parallel function calling is only supported with newer models like gpt-4-1106-preview
            new AssistantCreationOptions("gpt-4-1106-preview")
            {
                Name = "SDK Test Assistant - Functions",
                Instructions = "You are a weather bot. Use the provided functions to help answer questions. "
                    + "Customize your responses to the user's preferences as much as possible and use friendly "
                    + "nicknames for cities whenever possible.",
                Tools =
                {
                    getUserFavoriteCityTool,
                    getCityNicknameTool,
                    getCurrentWeatherAtLocationTool,
                },
            });
        Assistant assistant = assistantResponse.Value;
        #endregion

        Response<AssistantThread> threadResponse = await client.CreateThreadAsync();
        AssistantThread thread = threadResponse.Value;

        Response<ThreadMessage> messageResponse = await client.CreateMessageAsync(
            thread.Id,
            MessageRole.User,
            "What's the weather like in my favorite city?");
        ThreadMessage message = messageResponse.Value;

        Response<ThreadRun> runResponse = await client.CreateRunAsync(thread, assistant);

        #region Snippet:FunctionsHandlePollingWithRequiredAction
        do
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            runResponse = await client.GetRunAsync(thread.Id, runResponse.Value.Id);

            if (runResponse.Value.Status == RunStatus.RequiresAction
                && runResponse.Value.RequiredAction is SubmitToolOutputsAction submitToolOutputsAction)
            {
                List<ToolOutput> toolOutputs = new();
                foreach (RequiredToolCall toolCall in submitToolOutputsAction.ToolCalls)
                {
                    toolOutputs.Add(GetResolvedToolOutput(toolCall));
                }
                runResponse = await client.SubmitToolOutputsToRunAsync(runResponse.Value, toolOutputs);
            }
        }
        while (runResponse.Value.Status == RunStatus.Queued
            || runResponse.Value.Status == RunStatus.InProgress);
        #endregion

        Response<PageableList<ThreadMessage>> afterRunMessagesResponse
            = await client.GetMessagesAsync(thread.Id);
        IReadOnlyList<ThreadMessage> messages = afterRunMessagesResponse.Value.Data;

        // Note: messages iterate from newest to oldest, with the messages[0] being the most recent
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
    }
}
