# Sample for generation of structured output by Agent in Azure.AI.Projects.OpenAI.

In this example we will demonstrate creation of an Agent for generation output in JSON, compliant with the provided schema.

1. First, we need to create project client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateClient_StructuredOutput
string RAW_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT")
    ?? throw new InvalidOperationException("Missing environment variable 'PROJECT_ENDPOINT'");
string MODEL_DEPLOYMENT = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT")
    ?? throw new InvalidOperationException("Missing environment variable 'MODEL_DEPLOYMENT_NAME'");
AIProjectClient projectClient = new(new Uri(RAW_PROJECT_ENDPOINT), new DefaultAzureCredential());
```

2. Define the schema of Agents expected output.

```C# Snippet:Sample_Schema_StructuredOutput
private static readonly BinaryData s_calendatSchema = BinaryData.FromObjectAsJson(
    new {
        additionalProperties = false,
        properties = new {
            name = new {
                title = "Name",
                type = "string"
            },
            date = new {
                description = "Date in YYYY-MM-DD format",
                title = "Date",
                type = "string"
            },
            participants = new {
                items = new { type = "string" },
                title = "Participants",
                type = "array"
            }
        },
        required = new List<string> { "name", "date", "participants" },
        title ="CalendarEvent",
        type = "object",
    }
);
```

3. Use the client to create the versioned agent object; provide schema information through `TextOptions` property of `PromptAgentDefinition`.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_StructuredOutput_Sync
var textOptions = new ResponseTextOptions()
{
    TextFormat = ResponseTextFormat.CreateJsonSchemaFormat(
        jsonSchemaFormatName: "Calendar",
        jsonSchema: s_calendatSchema
    )
};
PromptAgentDefinition agentDefinition = new(model: MODEL_DEPLOYMENT)
{
    Instructions = "You are a helpful assistant that extracts calendar event information from the input user messages," +
                   "and returns it in the desired structured output format.",
    TextOptions = textOptions
};
AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
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
        jsonSchema: s_calendatSchema
    )
};
PromptAgentDefinition agentDefinition = new(model: MODEL_DEPLOYMENT)
{
    Instructions = "You are a helpful assistant that extracts calendar event information from the input user messages," +
                   "and returns it in the desired structured output format.",
    TextOptions = textOptions
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
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
ProjectConversation conversation = projectClient.OpenAI.Conversations.CreateProjectConversation(options);
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion, defaultConversationId: conversation.Id);
ResponseResult response = responseClient.CreateResponse(options: new());
Console.WriteLine(response.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_StructuredOutput_Async
ProjectConversationCreationOptions options = new()
{
    Items = { ResponseItem.CreateUserMessageItem("Alice and Bob are going to a science fair this Friday, November 7, 2025.") }
};
ProjectConversation conversation = await projectClient.OpenAI.Conversations.CreateProjectConversationAsync(options);
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion, defaultConversationId: conversation.Id);
ResponseResult response = await responseClient.CreateResponseAsync(options: new());
Console.WriteLine(response.GetOutputText());
```

5. Clean up resources by deleting conversation and Agent.

Synchronous sample:
```C# Snippet:Sample_CleanUp_StructuredOutput_Sync
projectClient.OpenAI.Conversations.DeleteConversation(conversation.Id);
projectClient.Agents.DeleteAgent(agentName: "myAgent");
```

Asynchronous sample:
```C# Snippet:Sample_CleanUp_StructuredOutput_Async
await projectClient.OpenAI.Conversations.DeleteConversationAsync(conversation.Id);
await projectClient.Agents.DeleteAgentAsync(agentName: "myAgent");
```
