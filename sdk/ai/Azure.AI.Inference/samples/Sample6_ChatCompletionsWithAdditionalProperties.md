# Chat Completions with Additional Model Properties

This sample demonstrates how to get a chat completions response from the service using a synchronous call, while supplying additional model-specific parameters as part of the request. See setting of the optional `AdditionalProperties` in the `ChatCompletionsOptions` object.

## Usage

Set these two environment variables before running the sample:

1. AZURE_AI_CHAT_ENDPOINT - Your endpoint URL, in the form `https://your-deployment-name.your-azure-region.inference.ai.azure.com` where `your-deployment-name` is your unique AI Model deployment name, and `your-azure-region` is the Azure region where your model is deployed.

2. AZURE_AI_CHAT_KEY - Your model key. Keep it secret.

```C# Snippet:Azure_AI_Inference_ChatCompletionsWithAdditionalPropertiesScenario
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
    AdditionalProperties = { { "foo", BinaryData.FromString("\"bar\"") } }, // Optional, add additional properties to the request to pass to the model
};
Response<ChatCompletions> response = client.Complete(requestOptions);
System.Console.WriteLine(response.Value.Choices[0].Message.Content);
```

An `async` option is also available.

```C# Snippet:Azure_AI_Inference_ChatCompletionsWithAdditionalPropertiesScenarioAsync
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
    AdditionalProperties = { { "foo", BinaryData.FromString("\"bar\"") } }, // Optional, add additional properties to the request to pass to the model
};
Response<ChatCompletions> response = await client.CompleteAsync(requestOptions);
System.Console.WriteLine(response.Value.Choices[0].Message.Content);
```
