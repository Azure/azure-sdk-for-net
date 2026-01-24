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

## Transcribe Local File (Synchronous)

To transcribe a local file synchronously, create a stream from the file and call `Transcribe` on the `TranscriptionClient`, which returns the transcribed phrases and total duration of the file.

```C# Snippet:TranscribeLocalFileSync
string filePath = "path/to/audio.wav";
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

## Transcribe Local File (Asynchronous)

To transcribe a local file asynchronously, create a stream from the file and call `TranscribeAsync` on the `TranscriptionClient`, which returns the transcribed phrases and total duration of the file.

```C# Snippet:TranscribeLocalFileAsync
string filePath = "path/to/audio.wav";
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


