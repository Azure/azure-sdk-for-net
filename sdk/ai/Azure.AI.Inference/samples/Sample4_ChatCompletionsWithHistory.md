# Chat Completions with Chat History

This sample demonstrates how to get a chat completions response from the service using a synchronous call and providing chat history. Two completion calls are made, the second one containing the chat history from the first one.

## Usage

Set these two environment variables before running the sample:

1. AZURE_AI_CHAT_ENDPOINT - Your endpoint URL, in the form `https://your-deployment-name.your-azure-region.inference.ai.azure.com` where `your-deployment-name` is your unique AI Model deployment name, and `your-azure-region` is the Azure region where your model is deployed.

2. AZURE_AI_CHAT_KEY - Your model key. Keep it secret.

```C# Snippet:Azure_AI_Inference_ChatCompletionsWithHistoryScenario
var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));

var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());
var messages = new List<ChatRequestMessage>()
{
    new ChatRequestSystemMessage("You are an AI assistant that helps people find information. Your replies are short, no more than two sentences."),
    new ChatRequestUserMessage("What year was construction of the international space station mostly done?"),
};

var requestOptions = new ChatCompletionsOptions(messages);

Response<ChatCompletions> response = client.Complete(requestOptions);
System.Console.WriteLine(response.Value.Content);

messages.Add(new ChatRequestAssistantMessage(response.Value));
messages.Add(new ChatRequestUserMessage("And what was the estimated cost to build it?"));

requestOptions = new ChatCompletionsOptions(messages);
response = client.Complete(requestOptions);
System.Console.WriteLine(response.Value.Content);
```

An `async` option is also available.

```C# Snippet:Azure_AI_Inference_ChatCompletionsWithHistoryScenarioAsync
var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));

var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());
var messages = new List<ChatRequestMessage>()
{
    new ChatRequestSystemMessage("You are an AI assistant that helps people find information. Your replies are short, no more than two sentences."),
    new ChatRequestUserMessage("What year was construction of the international space station mostly done?"),
};

var requestOptions = new ChatCompletionsOptions(messages);

Response<ChatCompletions> response = await client.CompleteAsync(requestOptions);
System.Console.WriteLine(response.Value.Content);

messages.Add(new ChatRequestAssistantMessage(response.Value));
messages.Add(new ChatRequestUserMessage("And what was the estimated cost to build it?"));

requestOptions = new ChatCompletionsOptions(messages);
response = await client.CompleteAsync(requestOptions);
System.Console.WriteLine(response.Value.Content);
```
