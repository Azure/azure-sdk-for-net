# Transcribe a Local File

This sample shows how to transcribe a local file using the `Azure.AI.Speech.Transcription` SDK.

## Create a Transcription Client

To create a Transcription Client, you will need the service endpoint and credentials of your AI Foundry resource or Speech Service resource.

```C# Snippet:CreateTranscriptionClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
ApiKeyCredential credential = new("your apikey");
TranscriptionClientOptions options = new TranscriptionClientOptions(TranscriptionClientOptions.ServiceVersion.V20251015);
TranscriptionClient client = new TranscriptionClient(endpoint, credential, options);
```

## Transcribe Local File

To transcribe a local file, create a stream from the file and call `Transcribe` or `TranscribeAsync` on the `TranscriptionClient`, which returns the transcribed phrases and total duration of the file.

```C# Snippet:TranscribeLocalFile
// Path to your local audio file
string audioFilePath = "path/to/audio.wav";

// Open the audio file as a stream
using FileStream audioStream = File.OpenRead(audioFilePath);

// Create the transcription request
TranscriptionOptions options = new TranscriptionOptions(audioStream);

// Perform synchronous transcription
ClientResult<TranscriptionResult> response = client.Transcribe(options);
TranscriptionResult result = response.Value;

// Display the transcription results
Console.WriteLine($"Total audio duration: {result.Duration}");
Console.WriteLine("\nTranscription:");

// Get the first channel's phrases (most audio files have a single channel)
var channelPhrases = result.PhrasesByChannel.First();
foreach (TranscribedPhrase phrase in channelPhrases.Phrases)
{
    Console.WriteLine($"[{phrase.Offset} - {phrase.Offset + phrase.Duration}] {phrase.Text}");
    Console.WriteLine($"  Confidence: {phrase.Confidence:F2}");
}
```


