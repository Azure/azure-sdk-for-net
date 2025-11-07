// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Agents.Tests.Samples;

public class Sample_Function : AgentsTestBase
{
    #region Snippet:Sample_Functions_Function
    /// Example of a function that defines no parameters
    /// returns user favorite city.
    private static string GetUserFavoriteCity() => "Seattle, WA";

    /// <summary>
    /// Example of a function with a single required parameter
    /// </summary>
    /// <param name="location">The location to get nickname for.</param>
    /// <returns>The city nickname.</returns>
    /// <exception cref="NotImplementedException"></exception>
    private static string GetCityNickname(string location) => location switch
    {
        "Seattle, WA" => "The Emerald City",
        _ => throw new NotImplementedException(),
    };

    /// <summary>
    /// Example of a function with one required and one optional, enum parameter
    /// </summary>
    /// <param name="location">Get weather for location.</param>
    /// <param name="temperatureUnit">"c" or "f"</param>
    /// <returns>The weather in selected location.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public static string GetWeatherAtLocation(string location, string temperatureUnit = "f") => location switch
    {
        "Seattle, WA" => temperatureUnit == "f" ? "70f" : "21c",
        _ => throw new NotImplementedException()
    };
    #endregion
    #region Snippet:Sample_FunctionTools_Function
    public static readonly FunctionTool getUserFavoriteCityTool = ResponseTool.CreateFunctionTool(
        functionName: "getUserFavoriteCity",
        functionDescription: "Gets the user's favorite city.",
        functionParameters: BinaryData.FromString("{}"),
        strictModeEnabled: false
    );

    public static readonly FunctionTool getCityNicknameTool = ResponseTool.CreateFunctionTool(
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
            new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }
        ),
        strictModeEnabled: false
    );

    private static readonly FunctionTool getCurrentWeatherAtLocationTool = ResponseTool.CreateFunctionTool(
        functionName: "getCurrentWeatherAtLocation",
        functionDescription: "Gets the current weather at a provided location.",
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
                     Unit = new
                     {
                         Type = "string",
                         Enum = new[] { "c", "f" },
                     },
                 },
                 Required = new[] { "location" },
             },
            new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }
        ),
        strictModeEnabled: false
    );
    #endregion

    # region Snippet:Sample_Resolver_Function
    private static FunctionCallOutputResponseItem GetResolvedToolOutput(FunctionCallResponseItem item)
    {
        if (item.FunctionName == getUserFavoriteCityTool.FunctionName)
        {
            return ResponseItem.CreateFunctionCallOutputItem(item.CallId, GetUserFavoriteCity());
        }
        using JsonDocument argumentsJson = JsonDocument.Parse(item.FunctionArguments);
        if (item.FunctionName == getCityNicknameTool.FunctionName)
        {
            string locationArgument = argumentsJson.RootElement.GetProperty("location").GetString();
            return ResponseItem.CreateFunctionCallOutputItem(item.CallId, GetCityNickname(locationArgument));
        }
        if (item.FunctionName == getCurrentWeatherAtLocationTool.FunctionName)
        {
            string locationArgument = argumentsJson.RootElement.GetProperty("location").GetString();
            if (argumentsJson.RootElement.TryGetProperty("unit", out JsonElement unitElement))
            {
                string unitArgument = unitElement.GetString();
                return ResponseItem.CreateFunctionCallOutputItem(item.CallId, GetWeatherAtLocation(locationArgument, unitArgument));
            }
            return ResponseItem.CreateFunctionCallOutputItem(item.CallId, GetWeatherAtLocation(locationArgument));
        }
        return null;
    }
    #endregion
    [Test]
    [AsyncOnly]
    public async Task FunctionAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_Function
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AgentClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        OpenAIClient openAIClient = client.GetOpenAIClient();
        #endregion
        #region Snippet:Sample_CreateAgent_Function_Async
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a weather bot. Use the provided functions to help answer questions. "
                    + "Customize your responses to the user's preferences as much as possible and use friendly "
                    + "nicknames for cities whenever possible.",
            Tools = { getUserFavoriteCityTool, getCityNicknameTool, getCurrentWeatherAtLocationTool }
        };
        AgentVersion agentVersion = await client.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_Function_Async
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);
        ResponseCreationOptions responseOptions = new();
        responseOptions.SetAgentReference(new AgentReference(name: agentVersion.Name));

        ResponseItem request = ResponseItem.CreateUserMessageItem("What's the weather like in my favorite city?");
        List<ResponseItem> inputItems = [request];
        bool funcionCalled = false;
        OpenAIResponse response;
        do
        {
            response = await CreateAndWaitForResponseAsync(
                responseClient,
                inputItems,
                responseOptions);
            funcionCalled = false;
            foreach (ResponseItem responseItem in response.OutputItems)
            {
                inputItems.Add(responseItem);
                if (responseItem is FunctionCallResponseItem functionToolCall)
                {
                    Console.WriteLine($"Calling {functionToolCall.FunctionName}...");
                    inputItems.Add(GetResolvedToolOutput(functionToolCall));
                    funcionCalled = true;
                }
            }
        } while (funcionCalled);
        Console.WriteLine(response.GetOutputText());
        #endregion

        #region Snippet:Sample_Cleanup_Function_Async
        await client.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    #region Snippet:Sample_WaitForResponse_Function_Async
    public static async Task<OpenAIResponse> CreateAndWaitForResponseAsync(OpenAIResponseClient responseClient, IEnumerable<ResponseItem> items, ResponseCreationOptions options)
    {
        OpenAIResponse response = await responseClient.CreateResponseAsync(
            inputItems: items,
            options: options);
        while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            response = await responseClient.GetResponseAsync(responseId: response.Id);
        }
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        return response;
    }
    #endregion

    #region Snippet:Sample_WaitForResponse_Function_Sync
    public static OpenAIResponse CreateAndWaitForResponse(OpenAIResponseClient responseClient, IEnumerable<ResponseItem> items, ResponseCreationOptions options)
    {
        OpenAIResponse response = responseClient.CreateResponse(
            inputItems: items,
            options: options);
        while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            response = responseClient.GetResponse(responseId: response.Id);
        }
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        return response;
    }
    #endregion

    [Test]
    [SyncOnly]
    public void FunctionSync()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AgentClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        OpenAIClient openAIClient = client.GetOpenAIClient();
        #region Snippet:Sample_CreateAgent_Function_Sync
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a weather bot. Use the provided functions to help answer questions. "
                    + "Customize your responses to the user's preferences as much as possible and use friendly "
                    + "nicknames for cities whenever possible.",
            Tools = { getUserFavoriteCityTool, getCityNicknameTool, getCurrentWeatherAtLocationTool }
        };
        AgentVersion agentVersion = client.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_Function_Sync
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);
        ResponseCreationOptions responseOptions = new();
        responseOptions.SetAgentReference(new AgentReference(name: agentVersion.Name));

        ResponseItem request = ResponseItem.CreateUserMessageItem("What's the weather like in my favorite city?");
        List<ResponseItem> inputItems = [request];
        bool funcionCalled = false;
        OpenAIResponse response;
        do
        {
            response = CreateAndWaitForResponse(
                responseClient,
                inputItems,
                responseOptions);
            funcionCalled = false;
            foreach (ResponseItem responseItem in response.OutputItems)
            {
                inputItems.Add(responseItem);
                if (responseItem is FunctionCallResponseItem functionToolCall)
                {
                    Console.WriteLine($"Calling {functionToolCall.FunctionName}...");
                    inputItems.Add(GetResolvedToolOutput(functionToolCall));
                    funcionCalled = true;
                }
            }
        } while (funcionCalled);
        Console.WriteLine(response.GetOutputText());
        #endregion

        #region Snippet:Sample_Cleanup_Function_Sync
        client.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    public Sample_Function(bool isAsync) : base(isAsync)
    { }
}
