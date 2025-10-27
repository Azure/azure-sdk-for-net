# Transcribe with Options

This sample shows how to transcribe files using the options of the `Azure.AI.Speech.Transcription` SDK.

## Create a Transcription Client

To create a Transcription Client, you will need the service endpoint and credentials of your AI Foundry resource or Speech Service resource. You can specify the service version by providing a TranscriptionClientOptions instance.

```C# Snippet:CreateTranscriptionClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.api.cognitive.microsoft.com/");
AzureKeyCredential credential = new("your apikey");
TranscriptionClientOptions options = new TranscriptionClientOptions(TranscriptionClientOptions.ServiceVersion.V2025_10_15);
TranscriptionClient client = new TranscriptionClient(endpoint, credential, options);
```

## Transcribe with Locale Options

To transcribe a file using manually specified locales, create a stream from the file, add the locale in the `TranscriptionOptions` and call `TranscribeAsync` on the `TranscriptionClient` clientlet. This method returns the transcribed phrases and total duration of the file.

If not specified, the locale of the speech in the audio is detected automatically from all supported locales.

```C# Snippet:TranscribeWithLocales
string filePath = "path/to/audio.wav";
TranscriptionClient client = new TranscriptionClient(new Uri("https://myaccount.api.cognitive.microsoft.com/"), new AzureKeyCredential("your apikey"));
using (FileStream fileStream = File.Open(filePath, FileMode.Open))
{
    var options = new TranscriptionOptions();
    options.Locales.Add("en-US");

    var request = new TranscribeRequestContent
    {
        Audio = fileStream,
        Options = options
    };

    var response = await client.TranscribeAsync(request);

    Console.WriteLine($"File Duration: {response.Value.Duration}");
    foreach (var phrase in response.Value.PhrasesByChannel.First().Phrases)
    {
        Console.WriteLine($"{phrase.Offset}-{phrase.Offset+phrase.Duration}: {phrase.Text}");
    }
}
```

## Transcribe with Model Options

To transcribe a file using specific models for specific locales, create a stream from the file, add the model mapping in the `TranscriptionOptions` and call `TranscribeAsync` on the `TranscriptionClient` clientlet. This method returns the transcribed phrases and total duration of the file.

If no mapping is given, the default model for the locale is used.

```C# Snippet:TranscribeWithModels
string filePath = "path/to/audio.wav";
TranscriptionClient client = new TranscriptionClient(new Uri("https://myaccount.api.cognitive.microsoft.com/"), new AzureKeyCredential("your apikey"));
using (FileStream fileStream = File.Open(filePath, FileMode.Open))
{
    var options = new TranscriptionOptions();
    options.Models.Add("en-US", new Uri("https://myaccount.api.cognitive.microsoft.com/speechtotext/models/your-model-uuid"));

    var request = new TranscribeRequestContent
    {
        Audio = fileStream,
        Options = options
    };

    var response = await client.TranscribeAsync(request);

    Console.WriteLine($"File Duration: {response.Value.Duration}");
    foreach (var phrase in response.Value.PhrasesByChannel.First().Phrases)
    {
        Console.WriteLine($"{phrase.Offset}-{phrase.Offset+phrase.Duration}: {phrase.Text}");
    }
}
```

## Transcribe with Profanity Filter Options

To transcribe a file using profanity filters, create a stream from the file, specify the filter mode in the `TranscriptionOptions` and call `TranscribeAsync` on the `TranscriptionClient` clientlet. This method returns the transcribed phrases and total duration of the file.

```C# Snippet:TranscribeWithProfinityFilter
string filePath = "path/to/audio.wav";
TranscriptionClient client = new TranscriptionClient(new Uri("https://myaccount.api.cognitive.microsoft.com/"), new AzureKeyCredential("your apikey"));
using (FileStream fileStream = File.Open(filePath, FileMode.Open))
{
    var options = new TranscriptionOptions();
    options.ProfanityFilterMode = ProfanityFilterMode.Masked;

    var request = new TranscribeRequestContent
    {
        Audio = fileStream,
        Options = options
    };

    var response = await client.TranscribeAsync(request);

    Console.WriteLine($"File Duration: {response.Value.Duration}");
    foreach (var phrase in response.Value.PhrasesByChannel.First().Phrases)
    {
        Console.WriteLine($"{phrase.Offset}-{phrase.Offset+phrase.Duration}: {phrase.Text}");
    }
}
```

## Transcribe with Active Channels Options

To transcribe a file using only a subset of the channels, create a stream from the file, specify the 0-based indices of the active channels in the `TranscriptionOptions` and call `TranscribeAsync` on the `TranscriptionClient` clientlet. This method returns the transcribed phrases and total duration of the file.

If not specified, multiple channels are merged and transcribed jointly. Only up to two channels are supported.

```C# Snippet:TranscribeWithActiveChannels
string filePath = "path/to/audio.wav";
TranscriptionClient client = new TranscriptionClient(new Uri("https://myaccount.api.cognitive.microsoft.com/"), new AzureKeyCredential("your apikey"));
using (FileStream fileStream = File.Open(filePath, FileMode.Open))
{
    var options = new TranscriptionOptions();
    options.ActiveChannels.Add(0);

    var request = new TranscribeRequestContent
    {
        Audio = fileStream,
        Options = options
    };

    var response = await client.TranscribeAsync(request);

    Console.WriteLine($"File Duration: {response.Value.Duration}");
    foreach (var phrase in response.Value.PhrasesByChannel.First().Phrases)
    {
        Console.WriteLine($"{phrase.Offset}-{phrase.Offset+phrase.Duration}: {phrase.Text}");
    }
}
```

## Transcribe with Diarization Options

To transcribe a file with speaker identification, create a stream from the file, specify the diarization options in the `TranscriptionOptions` and call `TranscribeAsync` on the `TranscriptionClient` clientlet. This method returns the transcribed phrases and total duration of the file.

If not specified, no speaker information is included in the transcribed phrases.

```C# Snippet:TranscribeWithDiarization
string filePath = "path/to/audio.wav";
TranscriptionClient client = new TranscriptionClient(new Uri("https://myaccount.api.cognitive.microsoft.com/"), new AzureKeyCredential("your apikey"));
using (FileStream fileStream = File.Open(filePath, FileMode.Open))
{
    var options = new TranscriptionOptions()
    {
        DiarizationOptions = new()
        {
            // Enabled is automatically set to true when MaxSpeakers is specified
            MaxSpeakers = 2
        }
    };

    var request = new TranscribeRequestContent
    {
        Audio = fileStream,
        Options = options
    };

    var response = await client.TranscribeAsync(request);

    Console.WriteLine($"File Duration: {response.Value.Duration}");
    foreach (var phrase in response.Value.PhrasesByChannel.First().Phrases)
    {
        Console.WriteLine($"{phrase.Offset}-{phrase.Offset+phrase.Duration} [{phrase.Speaker}]: {phrase.Text}");
    }
}
```
