# Sample for logging of web requests and responses in Azure.AI.Projects.OpenAI.

In this example we will demonstrate how to obtain detailed information on the requests to Microsoft Foundry while creating Agent and getting the Response.

1. Create a `LoggingPolicy` by inheriting the `PipelinePolicy`. This class implements two methods `Process` and `ProcessAsync`. The Azure pipeline calls the chain of policies, where the preceding one calls the next policy, hence by placing calls to `ProcessMessage` method before and after `ProcessNext` we can print request and response. The `ProcessMessage` method contains logic to show the contents of web request and response along with headers and URI paths.

```C# Snippet:Sample_LoggingPolicy_AgentsLogging
public class LoggingPolicy : PipelinePolicy
{
    private static void ProcessMessage(PipelineMessage message)
    {
        if (message.Request is not null && message.Response is null)
        {
            Console.WriteLine($"--- New request ---");
            IEnumerable<string> headerPairs = message?.Request?.Headers?.Select(header => $"\n    {header.Key}={(header.Key.ToLower().Contains("auth") ? "***" : header.Value)}");
            string headers = string.Join("", headerPairs);
            Console.WriteLine($"Request headers:{headers}");
            Console.WriteLine($"{message?.Request?.Method} URI: {message?.Request?.Uri}");
            if (message.Request?.Content != null)
            {
                string contentType = "Unknown Content Type";
                if (message.Request.Headers?.TryGetValue("Content-Type", out contentType) == true
                    && contentType == "application/json")
                {
                    using MemoryStream stream = new();
                    message.Request.Content.WriteTo(stream, default);
                    stream.Position = 0;
                    using StreamReader reader = new(stream);
                    string requestDump = reader.ReadToEnd();
                    stream.Position = 0;
                    requestDump = Regex.Replace(requestDump, @"""data"":[\\w\\r\\n]*""[^""]*""", @"""data"":""...""");
                    // Make sure JSON string is properly formatted.
                    JsonSerializerOptions jsonOptions = new()
                    {
                        WriteIndented = true,
                    };
                    JsonElement jsonElement = JsonSerializer.Deserialize<JsonElement>(requestDump);
                    Console.WriteLine("--- Begin request content ---");
                    Console.WriteLine(JsonSerializer.Serialize(jsonElement, jsonOptions));
                    Console.WriteLine("--- End request content ---");
                }
                else
                {
                    string length = message.Request.Content.TryComputeLength(out long numberLength)
                        ? $"{numberLength} bytes"
                        : "unknown length";
                    Console.WriteLine($"<< Non-JSON content: {contentType} >> {length}");
                }
            }
        }
        if (message.Response != null)
        {
            IEnumerable<string> headerPairs = message?.Response?.Headers?.Select(header => $"\n    {header.Key}={(header.Key.ToLower().Contains("auth") ? "***" : header.Value)}");
            string headers = string.Join("", headerPairs);
            Console.WriteLine($"Response headers:{headers}");
            if (message.BufferResponse)
            {
                message.Response.BufferContent();
                Console.WriteLine("--- Begin response content ---");
                Console.WriteLine(message.Response.Content?.ToString());
                Console.WriteLine("--- End of response content ---");
            }
            else
            {
                Console.WriteLine("--- Response (unbuffered, content not rendered) ---");
            }
        }
    }

    public LoggingPolicy(){}

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        ProcessMessage(message); // for request
        ProcessNext(message, pipeline, currentIndex);
        ProcessMessage(message); // for response
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        ProcessMessage(message); // for request
        await ProcessNextAsync(message, pipeline, currentIndex);
        ProcessMessage(message); // for response
    }
}
```

2. To apply the policy to the pipeline, we create `AIProjectClientOptions` object containing `LoggingPolicy`, inform the pipeline to execute this policy by call and set the option while instantiating `AIProjectClient` that we will consequently use.

```C# Snippet:Sample_CreateClient_AgentsLogging
string RAW_PROJECT_ENDPOINT = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT")
    ?? throw new InvalidOperationException("Missing environment variable 'PROJECT_ENDPOINT'");
string MODEL_DEPLOYMENT = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME")
    ?? throw new InvalidOperationException("Missing environment variable 'MODEL_DEPLOYMENT_NAME'");
AIProjectClientOptions options = new();
options.AddPolicy(new LoggingPolicy(), PipelinePosition.PerCall);
AIProjectClient projectClient = new(new Uri(RAW_PROJECT_ENDPOINT), new AzureCliCredential(), options: options);
```

3. Use the client to create the `AgentVersion` object.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_AgentsLogging_Sync
PromptAgentDefinition agentDefinition = new(model: MODEL_DEPLOYMENT)
{
    Instructions = "You are a physics teacher with a sense of humor.",
};
AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
    agentName: "myAgent",
    options: new(agentDefinition)
);
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_AgentsLogging_Async
PromptAgentDefinition agentDefinition = new(model: MODEL_DEPLOYMENT)
{
    Instructions = "You are a physics teacher with a sense of humor.",
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition)
);
```

4. Ask question for an agent.

Synchronous sample:
```C# Snippet:Sample_CreateResponseBasic_AgentsLogging_Sync
var agentReference = new AgentReference(name: agentVersion.Name);
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentReference);
CreateResponseOptions responseOptions = new([ResponseItem.CreateUserMessageItem("Write the proof of the intermediate value theorem.")]);
ResponseResult response = responseClient.CreateResponse(responseOptions);
Console.WriteLine(response.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponseBasic_AgentsLogging_Async
var agentReference = new AgentReference(name: agentVersion.Name);
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentReference);
CreateResponseOptions responseOptions = new([ResponseItem.CreateUserMessageItem("Write the proof of the intermediate value theorem.")]);
ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
Console.WriteLine(response.GetOutputText());
```

7. Delete the `AgentVersion` object created in this sample.

Synchronous sample:
```C# Snippet:CleanUp_AgentsLogging_Sync
projectClient.Agents.DeleteAgent(agentName: "myAgent");
```

Asynchronous sample:
```C# Snippet:CleanUp_AgentsLogging_Async
await projectClient.Agents.DeleteAgentAsync(agentName: "myAgent");
```
