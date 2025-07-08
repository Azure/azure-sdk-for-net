# Sample using agents with functions and streaming in Azure.AI.Agents.Persistent.

In this example we are demonstrating how to use the local functions with the agents in streaming scenarios. The functions can be used to provide agent specific information in response to user question.

1. First we need to create agent client and read the environment variables that will be used in the next steps.
```C# Snippet:AgentsFunctionsWithStreaming_CreateClient
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
PersistentAgentsClient client = new(projectEndpoint, new DefaultAzureCredential());
```

2 Define three toy functions: `GetUserFavoriteCity`that always returns "Seattle, WA" and `GetCityNickname`, which will handle only "Seattle, WA" and will throw exception in response to other city names. The last function `GetWeatherAtLocation` returns weather at Seattle, WA. For each function we need to create `FunctionToolDefinition`, which defines function name, description and parameters.
```C# Snippet:AgentsFunctionsWithStreaming_DefineFunctionTools
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
```

3. We will create the function `GetResolvedToolOutput`. It runs the abovementioned functions and wraps their outouts in `ToolOutput` object.
```C# Snippet:AgentsFunctionsWithStreamingUpdateHandling
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
```

4. Create agent with the `FunctionToolDefinitions` we have created in step 2.

Synchronous sample:
```C# Snippet:AgentsFunctionsWithStreamingSync_CreateAgent
// NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
PersistentAgent agent = client.Administration.CreateAgent(
    model: modelDeploymentName,
    name: "SDK Test Agent - Functions",
        instructions: "You are a weather bot. Use the provided functions to help answer questions. "
            + "Customize your responses to the user's preferences as much as possible and use friendly "
            + "nicknames for cities whenever possible.",
    tools: [getUserFavoriteCityTool, getCityNicknameTool, getCurrentWeatherAtLocationTool]
);
```

Asynchronous sample:
```C# Snippet:AgentsFunctionsWithStreaming_CreateAgent
// NOTE: To reuse existing agent, fetch it with client.Administration.GetAgent(agentId)
PersistentAgent agent = await client.Administration.CreateAgentAsync(
    model: modelDeploymentName,
    name: "SDK Test Agent - Functions",
        instructions: "You are a weather bot. Use the provided functions to help answer questions. "
            + "Customize your responses to the user's preferences as much as possible and use friendly "
            + "nicknames for cities whenever possible.",
    tools: [ getUserFavoriteCityTool, getCityNicknameTool, getCurrentWeatherAtLocationTool ]
);
```

5. Create thread with the message.

Synchronous sample:
```C# Snippet:AgentsFunctionsWithStreamingSync_CreateThread
PersistentAgentThread thread = client.Threads.CreateThread();

PersistentThreadMessage message = client.Messages.CreateMessage(
    thread.Id,
    MessageRole.User,
    "What's the weather like in my favorite city?");
```

Asynchronous sample:
```C# Snippet:AgentsFunctionsWithStreaming_CreateThread
PersistentAgentThread thread = await client.Threads.CreateThreadAsync();

PersistentThreadMessage message = await client.Messages.CreateMessageAsync(
    thread.Id,
    MessageRole.User,
    "What's the weather like in my favorite city?");
```

6. Create a stream and wait for the stream update of the `RequiredActionUpdate` type. This update will mark the point, when we need to submit tool outputs to the stream. We will store function outputs in `toolOutputs` and submit them to run, creating another stream. Please note that `RequiredActionUpdate` keeps only one required action, while our run may require multiple function calls. After all required actions were submitted we clean up the array of required actions (`toolOutputs`).

Synchronous sample:
```C# Snippet:AgentsFunctionsWithStreamingSyncUpdateCycle
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
```

Asynchronous sample:
```C# Snippet:AgentsFunctionsWithStreamingUpdateCycle
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
```

7. Finally, we delete all the resources, we have created in this sample.

Synchronous sample:
```C# Snippet:AgentsFunctionsWithStreamingSync_Cleanup
// NOTE: Comment out these two lines if you plan to reuse the agent later.
client.Threads.DeleteThread(thread.Id);
client.Administration.DeleteAgent(agent.Id);
```

Asynchronous sample:
```C# Snippet:AgentsFunctionsWithStreaming_Cleanup
// NOTE: Comment out these two lines if you plan to reuse the agent later.
await client.Threads.DeleteThreadAsync(thread.Id);
await client.Administration.DeleteAgentAsync(agent.Id);
```
