# Chat Completions with Audio Input

This sample demonstrates how to get a chat completions response from the service using a synchronous call. It shows different ways to include audio in the input chat messages.

This sample will only work on AI models that support audio input.

## Usage

Set these two environment variables before running the sample:

1. AZURE_AI_CHAT_ENDPOINT - Your endpoint URL, in the form `https://your-deployment-name.your-azure-region.inference.ai.azure.com` where `your-deployment-name` is your unique AI Model deployment name, and `your-azure-region` is the Azure region where your model is deployed.

2. AZURE_AI_CHAT_KEY - Your model key. Keep it secret.

An audio input can be provided using a URI pointer to an audio file:

```C# Snippet:Azure_AI_Inference_AudioUrlInput
var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));

ChatMessageAudioContentItem audioContentItem = new ChatMessageAudioContentItem(new Uri("https://example.com/audio.mp3"));

var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());

var requestOptions = new ChatCompletionsOptions()
{
    Messages =
    {
        new ChatRequestSystemMessage("You are a helpful assistant that helps provide translations."),
        new ChatRequestUserMessage(
            new ChatMessageTextContentItem("Translate this audio for me"),
            audioContentItem),
    },
};

Response<ChatCompletions> response = client.Complete(requestOptions);
System.Console.WriteLine(response.Value.Content);
```

Alternatively, you can provide a pointer to a file on disk:

```C# Snippet:Azure_AI_Inference_AudioDataFileInput
var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));

ChatMessageAudioContentItem audioContentItem = new ChatMessageAudioContentItem("sample_audio.mp3", AudioContentFormat.Mp3);

var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());

var requestOptions = new ChatCompletionsOptions()
{
    Messages =
    {
        new ChatRequestSystemMessage("You are a helpful assistant that helps provide translations."),
        new ChatRequestUserMessage(
            new ChatMessageTextContentItem("Translate this audio for me"),
            audioContentItem),
    },
};

Response<ChatCompletions> response = client.Complete(requestOptions);
System.Console.WriteLine(response.Value.Content);
```

Either method supports an `async` option, with the only difference being how the client is invoked:

```C# Snippet:Azure_AI_Inference_AudioInputAsync
Response<ChatCompletions> response = await client.CompleteAsync(requestOptions);
System.Console.WriteLine(response.Value.Content);
```
