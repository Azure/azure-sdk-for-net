# Chat Completions with Tools

This sample demonstrates how to do chat completions using a synchronous client, with the assistance of tools. In this sample, we use a mock function tool to retrieve temperature information of a location, in order to provide suggestions for what clothes to wear on vacation.

## Usage

Set these two environment variables before running the sample:

1. AZURE_AI_CHAT_ENDPOINT - Your endpoint URL, in the form `https://your-deployment-name.your-azure-region.inference.ai.azure.com` where `your-deployment-name` is your unique AI Model deployment name, and `your-azure-region` is the Azure region where your model is deployed.

2. AZURE_AI_CHAT_KEY - Your model key. Keep it secret.

```C# Snippet:Azure_AI_Inference_ChatCompletionsWithToolsScenario
var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));

var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());

FunctionDefinition futureTemperatureFunction = new FunctionDefinition("get_future_temperature")
{
    Description = "requests the anticipated future temperature at a provided location to help inform "
    + "advice about topics like choice of attire",
    Parameters = BinaryData.FromObjectAsJson(new
    {
        Type = "object",
        Properties = new
        {
            LocationName = new
            {
                Type = "string",
                Description = "the name or brief description of a location for weather information"
            },
            DaysInAdvance = new
            {
                Type = "integer",
                Description = "the number of days in the future for which to retrieve weather information"
            }
        }
    },
    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })
};
ChatCompletionsToolDefinition functionToolDef = new ChatCompletionsToolDefinition(futureTemperatureFunction);

var requestOptions = new ChatCompletionsOptions()
{
    Messages =
    {
        new ChatRequestSystemMessage("You are a helpful assistant."),
        new ChatRequestUserMessage("What should I wear in Honolulu in 3 days?"),
    },
    Tools = { functionToolDef },
};

Response<ChatCompletions> response = client.Complete(requestOptions);
System.Console.WriteLine(response.Value.Content);

ChatCompletionsToolCall functionToolCall = response.Value.ToolCalls[0];

ChatCompletionsOptions followupOptions = new()
{
    Tools = { functionToolDef },
};

// Include all original messages
foreach (ChatRequestMessage originalMessage in requestOptions.Messages)
{
    followupOptions.Messages.Add(originalMessage);
}

// Add the tool call message just received back from the assistant
followupOptions.Messages.Add(new ChatRequestAssistantMessage(response.Value));

// And also the tool message that resolves the tool call
followupOptions.Messages.Add(new ChatRequestToolMessage(
    toolCallId: functionToolCall.Id,
    content: "31 celsius"));

Response<ChatCompletions> followupResponse = client.Complete(followupOptions);
System.Console.WriteLine(followupResponse.Value.Content);
```

An `async` option is also available.

```C# Snippet:Azure_AI_Inference_ChatCompletionsWithToolsScenarioAsync
var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));

var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());

FunctionDefinition futureTemperatureFunction = new FunctionDefinition("get_future_temperature")
{
    Description = "requests the anticipated future temperature at a provided location to help inform "
    + "advice about topics like choice of attire",
    Parameters = BinaryData.FromObjectAsJson(new
    {
        Type = "object",
        Properties = new
        {
            LocationName = new
            {
                Type = "string",
                Description = "the name or brief description of a location for weather information"
            },
            DaysInAdvance = new
            {
                Type = "integer",
                Description = "the number of days in the future for which to retrieve weather information"
            }
        }
    },
    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })
};
ChatCompletionsToolDefinition functionToolDef = new ChatCompletionsToolDefinition(futureTemperatureFunction);

var requestOptions = new ChatCompletionsOptions()
{
    Messages =
    {
        new ChatRequestSystemMessage("You are a helpful assistant."),
        new ChatRequestUserMessage("What should I wear in Honolulu in 3 days?"),
    },
    Tools = { functionToolDef },
};

Response<ChatCompletions> response = await client.CompleteAsync(requestOptions);
System.Console.WriteLine(response.Value.Content);

ChatCompletionsToolCall functionToolCall = response.Value.ToolCalls[0];

ChatCompletionsOptions followupOptions = new()
{
    Tools = { functionToolDef },
};

// Include all original messages
foreach (ChatRequestMessage originalMessage in requestOptions.Messages)
{
    followupOptions.Messages.Add(originalMessage);
}

// Add the tool call message just received back from the assistant
followupOptions.Messages.Add(new ChatRequestAssistantMessage(response.Value));

// And also the tool message that resolves the tool call
followupOptions.Messages.Add(new ChatRequestToolMessage(
    toolCallId: functionToolCall.Id,
    content: "31 celsius"));

Response<ChatCompletions> followupResponse = await client.CompleteAsync(followupOptions);
System.Console.WriteLine(followupResponse.Value.Content);
```
