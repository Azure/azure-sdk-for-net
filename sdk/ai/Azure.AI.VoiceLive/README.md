# Azure VoiceLive client library for .NET

Azure VoiceLive is a managed service that enables low-latency, high-quality speech-to-speech interactions for voice agents. The API consolidates speech recognition, generative AI, and text-to-speech functionalities into a single, unified interface, providing an end-to-end solution for creating seamless voice-driven experiences.

Use the client library to:

* Create real-time voice assistants and conversational agents
* Build speech-to-speech applications with minimal latency
* Integrate advanced conversational features like noise suppression and echo cancellation
* Leverage multiple AI models (GPT-4o, GPT-4o-mini, Phi) for different use cases
* Implement function calling and tool integration for dynamic responses
* Create avatar-enabled voice interactions with visual components

[Source code][source_root] | [Package (NuGet)][package] | [API reference documentation][reference_docs] | [Product documentation][voicelive_docs] | [Samples][source_samples]

## Getting started

This section includes everything a developer needs to install the package and create their first VoiceLive client connection.

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.AI.VoiceLive --prerelease
```

### Prerequisites

You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and an [Azure AI Foundry resource](https://docs.microsoft.com/azure/ai-services/openai/how-to/create-resource) to use this service. 

The client library targets .NET Standard 2.0 and .NET 8.0, providing compatibility with a wide range of .NET implementations. To use the async streaming features demonstrated in the examples, you'll need .NET 6.0 or later.

### Authenticate the client

The Azure.AI.VoiceLive client supports two authentication methods:

1. **Microsoft Entra ID (recommended)**: Use token-based authentication
2. **API Key**: Use your resource's API key

#### Authentication with Microsoft Entra ID

```C# Snippet:CreateVoiceLiveClientWithTokenCredential
Uri endpoint = new Uri("https://your-resource.cognitiveservices.azure.com");
DefaultAzureCredential credential = new DefaultAzureCredential();
VoiceLiveClient client = new VoiceLiveClient(endpoint, credential);
```

#### Authentication with API Key

```C# Snippet:CreateVoiceLiveClientWithApiKey
Uri endpoint = new Uri("https://your-resource.cognitiveservices.azure.com");
AzureKeyCredential credential = new AzureKeyCredential("your-api-key");
VoiceLiveClient client = new VoiceLiveClient(endpoint, credential);
```

For the recommended keyless authentication with Microsoft Entra ID, you need to:

1. Assign the `Cognitive Services User` role to your user account or managed identity in the Azure portal under Access control (IAM) > Add role assignment
2. Use a `TokenCredential` implementation - the SDK automatically handles token acquisition and refresh with the appropriate scope

### Service API versions

The client library targets the latest service API version by default. You can optionally specify the API version when creating a client instance.

#### Select a service API version

You have the flexibility to explicitly select a supported service API version when instantiating a client by configuring its associated options:

```C# Snippet:CreateVoiceLiveClientForSpecificApiVersion
Uri endpoint = new Uri("https://your-resource.cognitiveservices.azure.com");
DefaultAzureCredential credential = new DefaultAzureCredential();
VoiceLiveClientOptions options = new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2025_05_01_Preview);
VoiceLiveClient client = new VoiceLiveClient(endpoint, credential, options);
```

## Key concepts

The Azure.AI.VoiceLive client library provides several key classes for real-time voice interactions:

### VoiceLiveClient

The primary entry point for the Azure.AI.VoiceLive service. Use this client to establish sessions and configure authentication.

### VoiceLiveSession

Represents an active WebSocket connection to the VoiceLive service. This class handles bidirectional communication, allowing you to send audio input and receive audio output, text transcriptions, and other events in real-time.

### Session Configuration

The service uses session configuration to control various aspects of the voice interaction:

- **Turn Detection**: Configure how the service detects when users start and stop speaking
- **Audio Processing**: Enable noise suppression and echo cancellation
- **Voice Selection**: Choose from standard Azure voices, high-definition voices, or custom voices
- **Model Selection**: Select the AI model (GPT-4o, GPT-4o-mini, Phi variants) that best fits your needs

### Models and Capabilities

The VoiceLive API supports multiple AI models with different capabilities:

| Model | Description | Use Case |
|-------|-------------|----------|
| `gpt-4o-realtime-preview` | GPT-4o with real-time audio processing | High-quality conversational AI |
| `gpt-4o-mini-realtime-preview` | Lightweight GPT-4o variant | Fast, efficient interactions |
| `phi4-mm-realtime` | Phi model with multimodal support | Cost-effective voice applications |

### Conversational Enhancements

The VoiceLive API provides Azure-specific enhancements:

- **Azure Semantic VAD**: Advanced voice activity detection that removes filler words
- **Noise Suppression**: Reduces environmental background noise
- **Echo Cancellation**: Removes echo from the model's own voice
- **End-of-Turn Detection**: Allows natural pauses without premature interruption

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/ai/Azure.AI.VoiceLive/samples).

### Basic voice assistant

```C# Snippet:BasicVoiceAssistantExample
// Create the VoiceLive client
Uri endpoint = new Uri("https://your-resource.cognitiveservices.azure.com");
DefaultAzureCredential credential = new DefaultAzureCredential();
VoiceLiveClient client = new VoiceLiveClient(endpoint, credential);

var model = "gpt-4o-mini-realtime-preview"; // Specify the model to use
// Start a new session
VoiceLiveSession session = await client.StartSessionAsync(model).ConfigureAwait(false);

// Configure session for voice conversation
VoiceLiveSessionOptions sessionOptions = new()
{
    Model = model,
    Instructions = "You are a helpful AI assistant. Respond naturally and conversationally.",
    Voice = new AzureStandardVoice("en-US-AvaNeural"),
    TurnDetection = new AzureSemanticVadTurnDetection()
    {
        Threshold = 0.5f,
        PrefixPadding = TimeSpan.FromMilliseconds(300),
        SilenceDuration = TimeSpan.FromMilliseconds(500)
    },
    InputAudioFormat = InputAudioFormat.Pcm16,
    OutputAudioFormat = OutputAudioFormat.Pcm16
};

// Ensure modalities include audio
sessionOptions.Modalities.Clear();
sessionOptions.Modalities.Add(InteractionModality.Text);
sessionOptions.Modalities.Add(InteractionModality.Audio);

await session.ConfigureSessionAsync(sessionOptions).ConfigureAwait(false);

// Process events from the session
await foreach (SessionUpdate serverEvent in session.GetUpdatesAsync().ConfigureAwait(false))
{
    if (serverEvent is SessionUpdateResponseAudioDelta audioDelta)
    {
        // Play audio response
        byte[] audioData = audioDelta.Delta.ToArray();
        // ... audio playback logic
    }
    else if (serverEvent is SessionUpdateResponseTextDelta textDelta)
    {
        // Display text response
        Console.Write(textDelta.Delta);
    }
}
```

### Configuring custom voice and advanced features

```C# Snippet:AdvancedVoiceConfiguration
VoiceLiveSessionOptions sessionOptions = new()
{
    Model = model,
    Instructions = "You are a customer service representative. Be helpful and professional.",
    Voice = new AzureCustomVoice("your-custom-voice-name", "your-custom-voice-endpoint-id")
    {
        Temperature = 0.8f
    },
    TurnDetection = new AzureSemanticVadTurnDetection()
    {
        RemoveFillerWords = true
    },
    InputAudioFormat = InputAudioFormat.Pcm16,
    OutputAudioFormat = OutputAudioFormat.Pcm16
};

// Ensure modalities include audio
sessionOptions.Modalities.Clear();
sessionOptions.Modalities.Add(InteractionModality.Text);
sessionOptions.Modalities.Add(InteractionModality.Audio);

await session.ConfigureSessionAsync(sessionOptions).ConfigureAwait(false);
```

### Function calling example

```C# Snippet:FunctionCallingExample
// Define a function for the assistant to call
var getCurrentWeatherFunction = new VoiceLiveFunctionDefinition("get_current_weather")
{
    Description = "Get the current weather for a given location",
    Parameters = BinaryData.FromString("""
        {
            "type": "object",
            "properties": {
                "location": {
                    "type": "string",
                    "description": "The city and state or country"
                }
            },
            "required": ["location"]
        }
        """)
};

VoiceLiveSessionOptions sessionOptions = new()
{
    Model = model,
    Instructions = "You are a weather assistant. Use the get_current_weather function to help users with weather information.",
    Voice = new AzureStandardVoice("en-US-AvaNeural"),
    InputAudioFormat = InputAudioFormat.Pcm16,
    OutputAudioFormat = OutputAudioFormat.Pcm16
};

// Add the function tool
sessionOptions.Tools.Add(getCurrentWeatherFunction);

// Ensure modalities include audio
sessionOptions.Modalities.Clear();
sessionOptions.Modalities.Add(InteractionModality.Text);
sessionOptions.Modalities.Add(InteractionModality.Audio);

await session.ConfigureSessionAsync(sessionOptions).ConfigureAwait(false);
```

## Troubleshooting

### Common errors and exceptions

**Authentication Errors**: If you receive authentication errors, verify that:
- Your Azure AI Foundry resource is correctly configured
- Your API key or credential has the necessary permissions
- The endpoint URL is correct and accessible

**WebSocket Connection Issues**: VoiceLive uses WebSocket connections. Ensure that:
- Your network allows WebSocket connections
- Firewall rules permit connections to `*.cognitiveservices.azure.com`
- The service is available in your selected region

**Audio Processing Errors**: For audio-related issues:
- Verify audio input format is supported (16kHz or 24kHz PCM)
- Check that audio devices are accessible and functioning
- Ensure proper audio codec configuration

### Logging and diagnostics

Enable logging to help diagnose issues:

```csharp
using Azure.Core.Diagnostics;

// Enable logging for Azure SDK
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

### Rate limiting and throttling

The VoiceLive service implements rate limiting based on:
- Concurrent connections per resource
- Token consumption rates
- Model-specific limits

Implement appropriate retry logic and connection management to handle throttling gracefully.

## Next steps

* Explore the comprehensive [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/ai/Azure.AI.VoiceLive/samples) including basic voice assistants and customer service bots
* Learn about [voice customization](https://learn.microsoft.com/azure/ai-services/speech-service/custom-neural-voice) to create unique brand voices
* Understand [avatar integration](https://learn.microsoft.com/azure/ai-services/speech-service/text-to-speech-avatar/what-is-text-to-speech-avatar) for visual voice experiences
* Review the [VoiceLive API documentation](https://docs.microsoft.com/azure/ai-services/) for advanced configuration options

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.opensource.microsoft.com.

When you submit a pull request, a CLA bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., status check, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

<!-- LINKS -->
[source_root]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/ai/Azure.AI.VoiceLive/src
[source_samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/ai/Azure.AI.VoiceLive/samples
[package]: https://www.nuget.org/
[reference_docs]: https://azure.github.io/azure-sdk-for-net/
[voicelive_docs]: https://docs.microsoft.com/azure/ai-services/
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide
