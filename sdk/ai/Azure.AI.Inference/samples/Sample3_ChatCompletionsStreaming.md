# Chat Completions with Streaming Response

This sample demonstrates how to get a chat completion streaming response from the service using a synchronous call.

## Usage

Set these two environment variables before running the sample:

1. AZURE_AI_CHAT_ENDPOINT - Your endpoint URL, in the form `https://your-deployment-name.your-azure-region.inference.ai.azure.com` where `your-deployment-name` is your unique AI Model deployment name, and `your-azure-region` is the Azure region where your model is deployed.

2. AZURE_AI_CHAT_KEY - Your model key. Keep it secret.

```C# Snippet:Azure_AI_Inference_HelloWorldStreamingScenarioAsync
var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));

var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());

var requestOptions = new ChatCompletionsOptions()
{
    Messages =
    {
        new ChatRequestSystemMessage("You are a helpful assistant."),
        new ChatRequestUserMessage("How many feet are in a mile?"),
    },
};

StreamingResponse<StreamingChatCompletionsUpdate> response = await client.CompleteStreamingAsync(requestOptions);
```

Calling `CompleteAsync` returns a `StreamingResponse` object which can be iterated over to retrieve the streamed results

```C# Snippet:Azure_AI_Inference_HelloWorldStreamingScenarioAsync_ProcessResponse
StringBuilder contentBuilder = new();
await foreach (StreamingChatCompletionsUpdate chatUpdate in response)
{
    if (!string.IsNullOrEmpty(chatUpdate.ContentUpdate))
    {
        contentBuilder.Append(chatUpdate.ContentUpdate);
    }
}
System.Console.WriteLine(contentBuilder.ToString());
```

An `async` option is also available for the initial streaming call.

```C# Snippet:Azure_AI_Inference_HelloWorldStreamingScenarioAsync
var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));

var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());

var requestOptions = new ChatCompletionsOptions()
{
    Messages =
    {
        new ChatRequestSystemMessage("You are a helpful assistant."),
        new ChatRequestUserMessage("How many feet are in a mile?"),
    },
};

StreamingResponse<StreamingChatCompletionsUpdate> response = await client.CompleteStreamingAsync(requestOptions);
```
