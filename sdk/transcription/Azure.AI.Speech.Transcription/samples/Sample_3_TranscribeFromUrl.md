# Transcribe from URL

This sample shows how to transcribe audio files from remote URLs using the `Azure.AI.Speech.Transcription` SDK.

## Create a Transcription Client

To create a Transcription Client, you will need the service endpoint and credentials of your AI Foundry resource or Speech Service resource.

```C# Snippet:CreateTranscriptionClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
ApiKeyCredential credential = new("your apikey");
TranscriptionClientOptions options = new TranscriptionClientOptions(TranscriptionClientOptions.ServiceVersion.V20251015);
TranscriptionClient client = new TranscriptionClient(endpoint, credential, options);
```

## Transcribe from URL

Transcribe an audio file directly from a publicly accessible URL:

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

