# Azure AI Speech Transcription client library for .NET

The Azure AI Speech Transcription client library provides easy access to Azure's speech-to-text transcription service, enabling you to convert audio to text with high accuracy.

Use the client library to:

* Transcribe audio files to text
* Support multiple languages and locales
* Enable speaker diarization to identify different speakers
* Apply profanity filtering
* Use custom speech models
* Process both local files and remote URLs

[Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/transcription/Azure.AI.Speech.Transcription/src) | [Package (NuGet)](https://www.nuget.org/packages) | [API reference documentation](https://azure.github.io/azure-sdk-for-net) | [Product documentation](https://docs.microsoft.com/azure)

## Getting started

### Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download) or later
- [Azure Subscription](https://azure.microsoft.com/free/)
- An [Azure AI Speech resource](https://learn.microsoft.com/azure/ai-services/speech-service/overview#try-the-speech-service-for-free)

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.AI.Speech.Transcription --prerelease
```

### Authenticate the client

Azure Speech Transcription supports two authentication methods:

#### Option 1: Entra ID OAuth2 Authentication (Recommended for Production)

For production scenarios, it's recommended to use Entra ID authentication with managed identities or service principals. This provides better security and easier credential management.

```csharp
using Azure.Identity;
using Azure.AI.Speech.Transcription;

// Use DefaultAzureCredential which works with managed identities, service principals, Azure CLI, etc.
DefaultAzureCredential credential = new DefaultAzureCredential();

Uri endpoint = new Uri("https://<your-region>.api.cognitive.microsoft.com");
TranscriptionClient client = new TranscriptionClient(endpoint, credential);
```

Note: To use Azure Identity authentication, you need to:

1. Add the `Azure.Identity` package to your project
2. Assign the appropriate role (e.g., "Cognitive Services User") to your managed identity or service principal
3. Ensure your Speech resource has Entra ID authentication enabled

For more information on Entra ID authentication, see:

- [Authenticate with Azure Identity](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme)
- [Azure AI Services authentication](https://learn.microsoft.com/azure/ai-services/authentication)

#### Option 2: API Key Authentication (Subscription Key)

You can find your Speech resource's API key in the [Azure Portal](https://portal.azure.com/) or by using the Azure CLI:

```bash
az cognitiveservices account keys list --name <your-resource-name> --resource-group <your-resource-group>
```

Once you have an API key, you can authenticate using `ApiKeyCredential`:

```csharp
using System;
using System.ClientModel;
using Azure.AI.Speech.Transcription;

Uri endpoint = new Uri("https://<your-region>.api.cognitive.microsoft.com/");
ApiKeyCredential credential = new ApiKeyCredential("<your-api-key>");
TranscriptionClient client = new TranscriptionClient(endpoint, credential);
```

### Service API versions

The client library targets the latest service API version by default. A client instance accepts an optional service API version parameter from its options to specify which API version service to communicate.

#### Select a service API version

You have the flexibility to explicitly select a supported service API version when instantiating a client by configuring its associated options. This ensures that the client can communicate with services using the specified API version.

For example,

```C# Snippet:CreateTranscriptionClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
ApiKeyCredential credential = new("your apikey");
TranscriptionClientOptions options = new TranscriptionClientOptions(TranscriptionClientOptions.ServiceVersion.V20251015);
TranscriptionClient client = new TranscriptionClient(endpoint, credential, options);
```

When selecting an API version, it's important to verify that there are no breaking changes compared to the latest API version. If there are significant differences, API calls may fail due to incompatibility.

Always ensure that the chosen API version is fully supported and operational for your specific use case and that it aligns with the service's versioning policy.

## Key concepts

### TranscriptionClient

The `TranscriptionClient` is the primary interface for interacting with the Speech Transcription service. It provides methods to transcribe audio to text.

### Audio Formats

The service supports various audio formats including WAV, MP3, OGG, and more. Audio must be:

- Shorter than 2 hours in duration
- Smaller than 250 MB in size

### Transcription Options

You can customize transcription with options like:

- **Profanity filtering**: Control how profanity is handled in transcriptions
- **Speaker diarization**: Identify different speakers in multi-speaker audio
- **Phrase lists**: Provide domain-specific phrases to improve accuracy
- **Language detection**: Automatically detect the spoken language
- **Enhanced mode**: Improve transcription quality with custom prompts, translation, and task-specific configurations

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

### Create a TranscriptionClient

Create a `TranscriptionClient` using your Speech service endpoint and API key:

```C# Snippet:CreateTranscriptionClient
// Get the endpoint and API key from your Speech resource in the Azure portal
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
ApiKeyCredential credential = new ApiKeyCredential("your-api-key");

// Create the TranscriptionClient
TranscriptionClient client = new TranscriptionClient(endpoint, credential);
```

### Transcribe a local audio file

Transcribe audio from a local file using the synchronous API:

```C# Snippet:TranscribeLocalFileSync
string filePath = "path/to/audio.wav";
TranscriptionClient client = CreateTranscriptionClient();
using (FileStream fileStream = File.Open(filePath, FileMode.Open))
{
    var options = new TranscriptionOptions(fileStream);
    var response = client.Transcribe(options);

    Console.WriteLine($"File Duration: {response.Value.Duration}");
    foreach (var phrase in response.Value.PhrasesByChannel.First().Phrases)
    {
        Console.WriteLine($"{phrase.Offset}-{phrase.Offset+phrase.Duration}: {phrase.Text}");
    }
}
```

Or use the asynchronous API:

```C# Snippet:TranscribeLocalFileAsync
string filePath = "path/to/audio.wav";
TranscriptionClient client = CreateTranscriptionClient();
using (FileStream fileStream = File.Open(filePath, FileMode.Open))
{
    var options = new TranscriptionOptions(fileStream);
    var response = await client.TranscribeAsync(options);

    Console.WriteLine($"File Duration: {response.Value.Duration}");
    foreach (var phrase in response.Value.PhrasesByChannel.First().Phrases)
    {
        Console.WriteLine($"{phrase.Offset}-{phrase.Offset+phrase.Duration}: {phrase.Text}");
    }
}
```

### Transcribe from URL

Transcribe audio directly from a publicly accessible URL:

```C# Snippet:TranscribeFromUrl
// Specify the URL of the audio file to transcribe
Uri audioUrl = new Uri("https://example.com/audio/sample.wav");

// Configure transcription to use the remote URL
TranscriptionOptions options = new TranscriptionOptions(audioUrl);

// No audio stream needed - the service fetches the file from the URL
ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
TranscriptionResult result = response.Value;

Console.WriteLine($"Transcribed audio from URL: {audioUrl}");
Console.WriteLine($"Duration: {result.Duration}");

var channelPhrases = result.PhrasesByChannel.First();
Console.WriteLine($"\nTranscription:\n{channelPhrases.Text}");
```

### Transcribe with options

Configure transcription options like locale, profanity filtering, and speaker diarization:

```C# Snippet:TranscribeWithMultipleOptions
string audioFilePath = "path/to/meeting.wav";
using FileStream audioStream = File.OpenRead(audioFilePath);

// Create TranscriptionOptions with audio stream
TranscriptionOptions options = new TranscriptionOptions(audioStream);

// Enable speaker diarization to identify different speakers
options.DiarizationOptions = new TranscriptionDiarizationOptions
{
    MaxSpeakers = 5 // Enabled is automatically set to true
};

// Mask profanity in the transcription
options.ProfanityFilterMode = ProfanityFilterMode.Masked;

// Add custom phrases to improve recognition of domain-specific terms
// These phrases help the service correctly recognize words that might be misheard
options.PhraseList = new PhraseListProperties();
options.PhraseList.Phrases.Add("action items");
options.PhraseList.Phrases.Add("Q4");
options.PhraseList.Phrases.Add("KPIs");

ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
TranscriptionResult result = response.Value;

// Display results
Console.WriteLine($"Duration: {result.DurationMilliseconds / 1000.0:F1}s | Speakers: {result.PhrasesByChannel.First().Phrases.Select(p => p.Speaker).Distinct().Count()}");
Console.WriteLine();
Console.WriteLine("Full Transcript:");
Console.WriteLine(result.CombinedPhrases.First().Text);
```

### Enhanced Mode with Translation

Use LLM-powered Enhanced Mode to translate speech during transcription. Enhanced mode is automatically enabled when you create an `EnhancedModeProperties` object:

```C# Snippet:TranslateWithEnhancedMode
string audioFilePath = "path/to/chinese-audio.wav";
using FileStream audioStream = File.OpenRead(audioFilePath);

// Translate Chinese speech to Korean
EnhancedModeProperties enhancedMode = new EnhancedModeProperties
{
    Task = "translate",
    TargetLanguage = "ko"  // Translate to Korean
};

TranscriptionOptions options = new TranscriptionOptions(audioStream)
{
    EnhancedMode = enhancedMode
};

ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
TranscriptionResult result = response.Value;

Console.WriteLine("Translated to Korean:");
var channelPhrases = result.PhrasesByChannel.First();
Console.WriteLine(channelPhrases.Text);
```

For more examples, see the [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/transcription/Azure.AI.Speech.Transcription/samples) directory.

## Troubleshooting

### Enable client logging

You can enable logging to debug issues with the client library. For more information, see the [logging documentation](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md).

### Common issues

#### Authentication errors

- Verify that your API key is correct
- Ensure your endpoint URL matches your Azure resource region

#### Audio format errors

- Verify your audio file is in a supported format
- Ensure the audio file size is under 250 MB and duration is under 2 hours

### Getting help

If you encounter issues:

- Check the [troubleshooting guide](https://learn.microsoft.com/azure/ai-services/speech-service/troubleshooting)
- Search for existing issues or create a new one on [GitHub](https://github.com/Azure/azure-sdk-for-net/issues)
- Ask questions on [Stack Overflow](https://stackoverflow.com/questions/tagged/.net+azure-sdk) with the `.net` and `azure-sdk` tags

## Next steps

- Explore the [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/transcription/Azure.AI.Speech.Transcription/samples) for more examples
- Learn more about [Azure Speech Service](https://learn.microsoft.com/azure/ai-services/speech-service/)
- Review the [API reference documentation](https://azure.github.io/azure-sdk-for-net) for detailed information about classes and methods

## Contributing

For details on contributing to this repository, see the [contributing guide](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md).

1. Fork it
2. Create your feature branch (`git checkout -b my-new-feature`)
3. Commit your changes (`git commit -am 'Add some feature'`)
4. Push to the branch (`git push origin my-new-feature`)
5. Create new Pull Request
