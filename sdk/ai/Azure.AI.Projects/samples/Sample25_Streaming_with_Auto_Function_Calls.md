# Sample using agents streaming with auto function calls in Azure.AI.Projects.

We demonstrated how to write code to call local functions with the agents in streaming scenarios in a previous example. In this example, we will demonstrate how to configure calling local functions automatically.

1. First we need to create agent client and read the environment variables that will be used in the next steps.
```C# Snippet:FunctionsWithStreaming_CreateClient
var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AgentsClient client = new(connectionString, new DefaultAzureCredential());
```

2 Define three toy functions: `GetUserFavoriteCity`that always returns "Seattle, WA" and `GetCityNickname`, which will handle only "Seattle, WA" and will throw exception in response to other city names. The last function `GetWeatherAtLocation` returns weather at Seattle, WA. For each function we need to create `FunctionToolDefinition`, which defines function name, description and parameters.
```C# Snippet:StreamingWithAutoFunctionCall_DefineFunctionTools
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
```

3. Create Agent with the `FunctionToolDefinitions. 

Synchronous sample:
```C# Snippet:StreamingWithAutoFunctionCall_CreateAgent
Agent agent = client.CreateAgent(
    model: modelDeploymentName,
    name: "SDK Test Agent - Functions",
        instructions: "You are a weather bot. Use the provided functions to help answer questions. "
            + "Customize your responses to the user's preferences as much as possible and use friendly "
            + "nicknames for cities whenever possible.",
    tools: [getCityNicknameTool, getCurrentWeatherAtLocationTool, getUserFavoriteCityTool]
);
```

Asynchronous sample:
```C# Snippet:StreamingWithAutoFunctionCallAsync_CreateAgent
Agent agent = await client.CreateAgentAsync(
    model: modelDeploymentName,
    name: "SDK Test Agent - Functions",
        instructions: "You are a weather bot. Use the provided functions to help answer questions. "
            + "Customize your responses to the user's preferences as much as possible and use friendly "
            + "nicknames for cities whenever possible.",
    tools: [getCityNicknameTool, getCurrentWeatherAtLocationTool, getUserFavoriteCityTool]
);
```

4. Create `Thread` with the message.

Synchronous sample:
```C# Snippet:StreamingWithAutoFunctionCall_CreateThreadMessage
AgentThread thread = client.CreateThread();

ThreadMessage message = client.CreateMessage(
    thread.Id,
    MessageRole.User,
    "What's the weather like in my favorite city?");
```

Asynchronous sample:
```C# Snippet:StreamingWithAutoFunctionCallAsync_CreateThreadMessage
AgentThread thread = await client.CreateThreadAsync();

ThreadMessage message = await client.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "What's the weather like in my favorite city?");
```

5. Setup `AutoFunctionCallOptions` with the function delegates above.
```C# Snippet:StreamingWithAutoFunctionCall_EnableAutoFunctionCalls
List<ToolOutput> toolOutputs = new();
Dictionary<string, Delegate> toolDelegates = new();
toolDelegates.Add(nameof(GetWeatherAtLocation), GetWeatherAtLocation);
toolDelegates.Add(nameof(GetCityNickname), GetCityNickname);
toolDelegates.Add(nameof(GetUserFavoriteCity), GetUserFavoriteCity);
AutoFunctionCallOptions autoFunctionCallOptions = new(toolDelegates, 10);
```

6. Create a stream that will allow us to receive updates from the agent.  With `autoFunctionCallOptions` as parameter, the functions will be called automatically when the agent needs to call them. The `StreamingUpdate` object will contain the results of the function calls.
 
Synchronous sample:
```C# Snippet:StreamingWithAutoFunctionCall
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
```

Asynchronous sample:
```C# Snippet:StreamingWithAutoFunctionCallAsync
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
```

7. Finally, we delete all the resources, we have created in this sample.

Synchronous sample:
```C# Snippet:StreamingWithAutoFunctionCall_Cleanup
client.DeleteThread(thread.Id);
client.DeleteAgent(agent.Id);
```

Asynchronous sample:
```C# Snippet:StreamingWithAutoFunctionCallAsync_Cleanup
await client.DeleteThreadAsync(thread.Id);
await client.DeleteAgentAsync(agent.Id);
```
