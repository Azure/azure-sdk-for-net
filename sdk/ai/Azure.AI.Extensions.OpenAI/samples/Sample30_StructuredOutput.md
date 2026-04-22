# Sample for generation of structured output by Agent in Azure.AI.Extensions.OpenAI.

In this example we will demonstrate creation of an Agent for generation output in JSON, compliant with the provided schema.

1. First, we need to create project client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateClient_StructuredOutput
string RAW_FOUNDRY_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT")
    ?? throw new InvalidOperationException("Missing environment variable 'FOUNDRY_PROJECT_ENDPOINT'");
string MODEL_DEPLOYMENT = Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME")
    ?? throw new InvalidOperationException("Missing environment variable 'FOUNDRY_MODEL_NAME'");
AIProjectClient projectClient = new(new Uri(RAW_FOUNDRY_PROJECT_ENDPOINT), new DefaultAzureCredential());
```

2. Define the schema of Agents expected output.

```C# Snippet:Sample_Schema_StructuredOutput
private static readonly BinaryData s_calendarSchema = BinaryData.FromObjectAsJson(
    new
    {
        additionalProperties = false,
        properties = new
        {
            name = new
            {
                title = "Name",
                type = "string"
            },
            date = new
            {
                description = "Date in YYYY-MM-DD format",
                title = "Date",
                type = "string"
            },
            participants = new
            {
                items = new { type = "string" },
                title = "Participants",
                type = "array"
            }
        },
        required = new List<string> { "name", "date", "participants" },
        title = "CalendarEvent",
        type = "object",
    }
);
```

3. Use the client to create the versioned agent object; provide schema information through `TextOptions` property of `DeclarativeAgentDefinition`.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_StructuredOutput_Sync
var textOptions = new ResponseTextOptions()
{
    TextFormat = ResponseTextFormat.CreateJsonSchemaFormat(
        jsonSchemaFormatName: "Calendar",
        jsonSchema: s_calendarSchema
    )
};
DeclarativeAgentDefinition agentDefinition = new(model: MODEL_DEPLOYMENT)
{
    Instructions = "You are a helpful assistant that extracts calendar event information from the input user messages," +
                   "and returns it in the desired structured output format.",
    TextOptions = textOptions
};
ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
    agentName: "myAgent",
    options: new(agentDefinition)
);
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_StructuredOutput_Async
var textOptions = new ResponseTextOptions()
{
    TextFormat = ResponseTextFormat.CreateJsonSchemaFormat(
        jsonSchemaFormatName: "Calendar",
        jsonSchema: s_calendarSchema
    )
};
DeclarativeAgentDefinition agentDefinition = new(model: MODEL_DEPLOYMENT)
{
    Instructions = "You are a helpful assistant that extracts calendar event information from the input user messages," +
                   "and returns it in the desired structured output format.",
    TextOptions = textOptions
};
ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition)
);
```

4. Create a conversation with the only item, containing request to Agent. Use conversation ID while creating a response and get output in JSON format.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_StructuredOutput_Sync
ProjectConversationCreationOptions options = new()
{
    Items = { ResponseItem.CreateUserMessageItem("Alice and Bob are going to a science fair this Friday, November 7, 2025.") }
};
ProjectConversation conversation = projectClient.ProjectOpenAIClient.GetProjectConversationsClient().CreateProjectConversation(options);
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(new(name: agentVersion.Name, version: agentVersion.Version), defaultConversationId: conversation.Id);
ResponseResult response = responseClient.CreateResponse(options: new());
Console.WriteLine(response.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_StructuredOutput_Async
ProjectConversationCreationOptions options = new()
{
    Items = { ResponseItem.CreateUserMessageItem("Alice and Bob are going to a science fair this Friday, November 7, 2025.") }
};
ProjectConversation conversation = await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().CreateProjectConversationAsync(options);
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(new(name: agentVersion.Name, version: agentVersion.Version), defaultConversationId: conversation.Id);
ResponseResult response = await responseClient.CreateResponseAsync(options: new());
Console.WriteLine(response.GetOutputText());
```

5. Clean up resources by deleting conversation and Agent.

Synchronous sample:
```C# Snippet:Sample_CleanUp_StructuredOutput_Sync
projectClient.ProjectOpenAIClient.GetProjectConversationsClient().DeleteConversation(conversation.Id);
projectClient.AgentAdministrationClient.DeleteAgent(agentName: "myAgent");
```

Asynchronous sample:
```C# Snippet:Sample_CleanUp_StructuredOutput_Async
await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().DeleteConversationAsync(conversation.Id);
await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentName: "myAgent");
```
