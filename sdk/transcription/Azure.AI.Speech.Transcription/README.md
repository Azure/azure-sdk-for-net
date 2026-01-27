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

- [Create a TranscriptionClient](#create-a-transcriptionclient)
- [Transcribe a local audio file](#transcribe-a-local-audio-file)
- [Transcribe audio from a URL](#transcribe-audio-from-a-url)
- [Access individual transcribed words](#access-individual-transcribed-words)
- [Identify speakers with diarization](#identify-speakers-with-diarization)
- [Filter profanity](#filter-profanity)
- [Improve accuracy with custom phrases](#improve-accuracy-with-custom-phrases)
- [Transcribe with a known language](#transcribe-with-a-known-language)
- [Use Enhanced Mode for highest accuracy](#use-enhanced-mode-for-highest-accuracy)
- [Combine multiple options](#combine-multiple-options)

### Create a TranscriptionClient

Create a `TranscriptionClient` using your Speech service endpoint and API key:

```csharp
using System;
using System.ClientModel;
using Azure.AI.Speech.Transcription;

Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
ApiKeyCredential credential = new ApiKeyCredential("your-api-key");
TranscriptionClient client = new TranscriptionClient(endpoint, credential);
```

### Transcribe a local audio file

The most basic operation is to transcribe an audio file from your local filesystem:

```csharp Snippet:TranscribeLocalFile
string audioFilePath = "path/to/audio.wav";
using FileStream audioStream = File.OpenRead(audioFilePath);

TranscriptionOptions options = new TranscriptionOptions(audioStream);
ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);

// Get the transcribed text
var channelPhrases = response.Value.PhrasesByChannel.First();
Console.WriteLine(channelPhrases.Text);
```

For synchronous transcription, use the `Transcribe` method instead of `TranscribeAsync`.

### Transcribe audio from a URL

You can transcribe audio directly from a publicly accessible URL without downloading the file first:

```csharp Snippet:TranscribeFromUrl
Uri audioUrl = new Uri("https://example.com/audio/sample.wav");
TranscriptionOptions options = new TranscriptionOptions(audioUrl);

ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
TranscriptionResult result = response.Value;

Console.WriteLine($"Transcribed audio from URL: {audioUrl}");
var channelPhrases = result.PhrasesByChannel.First();
Console.WriteLine($"\nTranscription:\n{channelPhrases.Text}");
```

### Access individual transcribed words

To access word-level details including timestamps, confidence scores, and individual words:

```csharp Snippet:AccessTranscribedWords
string audioFilePath = "path/to/audio.wav";
using FileStream audioStream = File.OpenRead(audioFilePath);

TranscriptionOptions options = new TranscriptionOptions(audioStream);
ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);

// Access the first channel's phrases
var channelPhrases = response.Value.PhrasesByChannel.First();

// Iterate through each phrase (typically sentences or segments)
foreach (TranscribedPhrase phrase in channelPhrases.Phrases)
{
    Console.WriteLine($"\nPhrase: {phrase.Text}");
    Console.WriteLine($"  Offset: {phrase.Offset} | Duration: {phrase.Duration}");
    Console.WriteLine($"  Confidence: {phrase.Confidence:F2}");
    
    // Access individual words in the phrase
    foreach (TranscribedWord word in phrase.Words)
    {
        Console.WriteLine($"    Word: '{word.Text}' | Confidence: {word.Confidence:F2} | Offset: {word.Offset}");
    }
}
```

### Identify speakers with diarization

Speaker diarization identifies who spoke when in multi-speaker conversations:

```csharp Snippet:TranscribeWithDiarizationSample
string audioFilePath = "path/to/conversation.wav";
using FileStream audioStream = File.OpenRead(audioFilePath);

TranscriptionOptions options = new TranscriptionOptions(audioStream)
{
    DiarizationOptions = new TranscriptionDiarizationOptions
    {
        MaxSpeakers = 4 // Expect up to 4 speakers in the conversation
    }
};

ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
TranscriptionResult result = response.Value;

Console.WriteLine("Transcription with speaker diarization:");
var channelPhrases = result.PhrasesByChannel.First();
foreach (TranscribedPhrase phrase in channelPhrases.Phrases)
{
    Console.WriteLine($"Speaker {phrase.Speaker}: {phrase.Text}");
}
```

### Filter profanity

Control how profanity appears in your transcriptions using different filter modes:

```csharp Snippet:TranscribeWithProfanityFilter
string audioFilePath = "path/to/audio-with-profanity.wav";
using FileStream audioStream = File.OpenRead(audioFilePath);

TranscriptionOptions options = new TranscriptionOptions(audioStream)
{
    ProfanityFilterMode = ProfanityFilterMode.Masked // Default - profanity replaced with asterisks
};

ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
TranscriptionResult result = response.Value;

var channelPhrases = result.PhrasesByChannel.First();
Console.WriteLine(channelPhrases.Text); // Profanity will appear as "f***"
```

Available modes:
- `None`: No filtering - profanity appears as spoken
- `Masked`: Profanity replaced with asterisks (e.g., "f***")
- `Removed`: Profanity completely removed from text
- `Tags`: Profanity wrapped in XML tags (e.g., "<profanity>word</profanity>")

### Improve accuracy with custom phrases

Add custom phrases to help the service correctly recognize domain-specific terms, names, and acronyms:

```csharp Snippet:TranscribeWithPhraseListSample
string audioFilePath = "path/to/audio.wav";
using FileStream audioStream = File.OpenRead(audioFilePath);

TranscriptionOptions options = new TranscriptionOptions(audioStream)
{
    PhraseList = new PhraseListProperties()
};

// Add names, locations, and terms that might be misrecognized
options.PhraseList.Phrases.Add("Contoso");
options.PhraseList.Phrases.Add("Jessie");
options.PhraseList.Phrases.Add("Rehaan");

ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
TranscriptionResult result = response.Value;

var channelPhrases = result.PhrasesByChannel.First();
Console.WriteLine(channelPhrases.Text);
```

### Transcribe with a known language

When you know the language of the audio, specifying a single locale improves accuracy and reduces latency:

```csharp Snippet:TranscribeWithKnownLocale
string audioFilePath = "path/to/english-audio.mp3";
using FileStream audioStream = File.OpenRead(audioFilePath);

TranscriptionOptions options = new TranscriptionOptions(audioStream);
options.Locales.Add("en-US");

ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
TranscriptionResult result = response.Value;

var channelPhrases = result.PhrasesByChannel.First();
Console.WriteLine(channelPhrases.Text);
```

For language identification when you're unsure of the language, specify multiple candidate locales and the service will automatically detect the language. See [Sample08_TranscribeWithLocales.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/transcription/Azure.AI.Speech.Transcription/tests/Samples/Sample08_TranscribeWithLocales.cs) for details.

### Use Enhanced Mode for highest accuracy

Enhanced Mode uses LLM-powered processing for the highest accuracy transcription and translation:

```csharp Snippet:TranscribeWithEnhancedMode
string audioFilePath = "path/to/audio.wav";
using FileStream audioStream = File.OpenRead(audioFilePath);

EnhancedModeProperties enhancedMode = new EnhancedModeProperties
{
    Task = "transcribe"
};

TranscriptionOptions options = new TranscriptionOptions(audioStream)
{
    EnhancedMode = enhancedMode
};

ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
TranscriptionResult result = response.Value;

var channelPhrases = result.PhrasesByChannel.First();
Console.WriteLine(channelPhrases.Text);
```

Enhanced Mode also supports translation. See [Sample04_EnhancedMode.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/transcription/Azure.AI.Speech.Transcription/tests/Samples/Sample04_EnhancedMode.cs) for translation examples.

### Combine multiple options

You can combine multiple transcription features for complex scenarios:

```csharp Snippet:TranscribeWithMultipleOptions
string audioFilePath = "path/to/meeting.wav";
using FileStream audioStream = File.OpenRead(audioFilePath);

TranscriptionOptions options = new TranscriptionOptions(audioStream);

// Enable speaker diarization to identify different speakers
options.DiarizationOptions = new TranscriptionDiarizationOptions
{
    MaxSpeakers = 5
};

// Mask profanity in the transcription
options.ProfanityFilterMode = ProfanityFilterMode.Masked;

// Add custom phrases to improve recognition of domain-specific terms
options.PhraseList = new PhraseListProperties();
options.PhraseList.Phrases.Add("action items");
options.PhraseList.Phrases.Add("Q4");
options.PhraseList.Phrases.Add("KPIs");

ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
TranscriptionResult result = response.Value;

// Display results
var channelPhrases = result.PhrasesByChannel.First();
Console.WriteLine("Full Transcript:");
Console.WriteLine(result.CombinedPhrases.First().Text);
```

## Troubleshooting

### Common issues

- **Authentication failures**: Verify your API key or Entra ID credentials are correct and that your Speech resource is active.
- **Unsupported audio format**: Ensure your audio is in a supported format (WAV, MP3, OGG, FLAC, etc.). The service automatically handles format detection.
- **Slow transcription**: For large files, consider using asynchronous transcription or ensure your network connection is stable.
- **Poor accuracy**: Try specifying the correct locale, adding custom phrases for domain-specific terms, or using Enhanced Mode.

### Exceptions

The library throws exceptions for various error conditions:
- `RequestFailedException`: The service returned an error response (check `Status` and `ErrorCode` for details)
- `ArgumentException`: Invalid parameters were provided to a method
- `InvalidOperationException`: The operation cannot be performed in the current state

### Enable client logging

You can enable logging to debug issues with the client library. For more information, see the [diagnostics documentation](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md).

## Next steps

Explore additional samples to learn more about advanced features:

- [Sample01_BasicTranscription.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/transcription/Azure.AI.Speech.Transcription/tests/Samples/Sample01_BasicTranscription.cs) - Create clients and basic transcription
- [Sample02_TranscriptionOptions.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/transcription/Azure.AI.Speech.Transcription/tests/Samples/Sample02_TranscriptionOptions.cs) - Combine multiple transcription features
- [Sample03_TranscribeFromUrl.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/transcription/Azure.AI.Speech.Transcription/tests/Samples/Sample03_TranscribeFromUrl.cs) - Transcribe from remote URLs
- [Sample04_EnhancedMode.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/transcription/Azure.AI.Speech.Transcription/tests/Samples/Sample04_EnhancedMode.cs) - LLM-powered transcription and translation
- [Sample05_TranscribeWithProfanityFilter.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/transcription/Azure.AI.Speech.Transcription/tests/Samples/Sample05_TranscribeWithProfanityFilter.cs) - All profanity filtering modes
- [Sample06_TranscribeWithDiarization.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/transcription/Azure.AI.Speech.Transcription/tests/Samples/Sample06_TranscribeWithDiarization.cs) - Speaker identification
- [Sample07_TranscribeWithPhraseList.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/transcription/Azure.AI.Speech.Transcription/tests/Samples/Sample07_TranscribeWithPhraseList.cs) - Custom vocabulary
- [Sample08_TranscribeWithLocales.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/transcription/Azure.AI.Speech.Transcription/tests/Samples/Sample08_TranscribeWithLocales.cs) - Language specification and detection
- [Sample09_MultilingualTranscription.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/transcription/Azure.AI.Speech.Transcription/tests/Samples/Sample09_MultilingualTranscription.cs) - Multilingual content

## Contributing

For details on contributing to this repository, see the [contributing guide](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md).

1. Fork it
2. Create your feature branch (`git checkout -b my-new-feature`)
3. Commit your changes (`git commit -am 'Add some feature'`)
4. Push to the branch (`git push origin my-new-feature`)
5. Create new Pull Request
