# Transcription Options

This sample shows how to transcribe files using the options of the `Azure.AI.Speech.Transcription` SDK.

## Create a Transcription Client

To create a Transcription Client, you will need the service endpoint and credentials of your AI Foundry resource or Speech Service resource.

```C# Snippet:CreateTranscriptionClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
ApiKeyCredential credential = new("your apikey");
TranscriptionClientOptions options = new TranscriptionClientOptions(TranscriptionClientOptions.ServiceVersion.V20251015);
TranscriptionClient client = new TranscriptionClient(endpoint, credential, options);
```

## Transcribe with Multiple Options

Combine multiple options for complex transcription scenarios such as meetings:

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
Console.WriteLine($"Duration: {result.Duration.TotalSeconds:F1}s | Speakers: {result.PhrasesByChannel.First().Phrases.Select(p => p.Speaker).Distinct().Count()}");
Console.WriteLine();
Console.WriteLine("Full Transcript:");
Console.WriteLine(result.CombinedPhrases.First().Text);
```


