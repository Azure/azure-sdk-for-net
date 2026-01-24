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

## Transcribe from URL (Synchronous)

Transcribe an audio file directly from a public URL without downloading it first:

```C# Snippet:TranscribeFromUrlSync
TranscriptionClient client = new TranscriptionClient(new Uri("https://myaccount.api.cognitive.microsoft.com/"), new ApiKeyCredential("your apikey"));
Uri audioUrl = new Uri("https://your-domain.com/your-file.wav");
// Transcribe directly from URL - the service fetches the audio
var options = new TranscriptionOptions(audioUrl);
var response = client.Transcribe(options);

Console.WriteLine($"File Duration: {response.Value.Duration}");
foreach (var phrase in response.Value.PhrasesByChannel.First().Phrases)
{
    Console.WriteLine($"{phrase.Offset}-{phrase.Offset+phrase.Duration}: {phrase.Text}");
}
```

## Transcribe from URL (Asynchronous)

```C# Snippet:TranscribeFromUrlAsync
TranscriptionClient client = new TranscriptionClient(new Uri("https://myaccount.api.cognitive.microsoft.com/"), new ApiKeyCredential("your apikey"));
Uri audioUrl = new Uri("https://your-domain.com/your-file.wav");
// Transcribe directly from URL - the service fetches the audio
var options = new TranscriptionOptions(audioUrl);
var response = await client.TranscribeAsync(options);

Console.WriteLine($"File Duration: {response.Value.Duration}");
foreach (var phrase in response.Value.PhrasesByChannel.First().Phrases)
{
    Console.WriteLine($"{phrase.Offset}-{phrase.Offset+phrase.Duration}: {phrase.Text}");
}
```
}
```

