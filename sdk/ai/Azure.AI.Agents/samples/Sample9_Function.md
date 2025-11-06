# Sample using Agents with functions in Azure.AI.Agents.

In this example we are demonstrating how to use the local functions with the Agents. The functions can be used to provide the Agent with specific information in response to a user question.

1. First, we need to create agent client and read in the environment variables that will be used in the next steps.
```C# Snippet:Sample_CreateAgentClient_Function
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AgentsClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
OpenAIClient openAIClient = client.GetOpenAIClient();
```

2 Define three toy functions: `GetUserFavoriteCity` that always returns "Seattle, WA" and `GetCityNickname`, which will handle only "Seattle, WA" and will throw exception in response to other city names. The last function `GetWeatherAtLocation` returns weather in Seattle, WA.
```C# Snippet:Sample_Functions_Function
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
```

3. For each function we need to create `FunctionTool`, which defines function name, description and parameters.
```C# Snippet:Sample_FunctionTools_Function
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
```

4. We will create the method `GetResolvedToolOutput`. It runs the abovementioned functions and wraps their outputs in `ResponseItem` object.
```C# Snippet:Sample_Resolver_Function
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
```

4. Create agent with the `FunctionTool` we have created in step 3.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_Function_Sync
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a weather bot. Use the provided functions to help answer questions. "
            + "Customize your responses to the user's preferences as much as possible and use friendly "
            + "nicknames for cities whenever possible.",
    Tools = { getUserFavoriteCityTool, getCityNicknameTool, getCurrentWeatherAtLocationTool }
};
AgentVersion agentVersion = client.CreateAgentVersion(
    agentName: "myAgent",
    definition: agentDefinition, options: null);
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_Function_Async
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a weather bot. Use the provided functions to help answer questions. "
            + "Customize your responses to the user's preferences as much as possible and use friendly "
            + "nicknames for cities whenever possible.",
    Tools = { getUserFavoriteCityTool, getCityNicknameTool, getCurrentWeatherAtLocationTool }
};
AgentVersion agentVersion = await client.CreateAgentVersionAsync(
    agentName: "myAgent",
    definition: agentDefinition, options: null);
```

5. To supply functions outputs, we will need to wait for response multiple times. We will define methods `CreateAndWaitForResponse` and `CreateAndWaitForResponseAsync` for brevity.

Synchronous sample:
```C# Snippet:Sample_WaitForResponse_Function_Sync
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
```

Asynchronous sample:
```C# Snippet:Sample_WaitForResponse_Function_Async
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
```

6. Wait for the response; if the local function call is required, the response item will be of `FunctionCallResponseItem` type and will contain the function name needed by the Agent. In this case we will use our helper method `GetResolvedToolOutput` to get the `FunctionCallOutputResponseItem` with function call result. To provide the right answer, we need to supply all the response items to `CreateResponse` or `CreateResponseAsync` call. At the end we will print out the function response.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_Function_Sync
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
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_Function_Async
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
```

7. Finally, we delete all the resources we have created in this sample.

Synchronous sample:
```C# Snippet:Sample_Cleanup_Function_Sync
client.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_Function_Async
await client.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```
