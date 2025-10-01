# Advanced Remote File Transcription

This sample demonstrates advanced scenarios for transcribing audio files from remote locations using the `Azure.AI.Speech.Transcription` SDK.

## Transcribe from URL

Transcribe an audio file directly from a public URL without downloading it first.

```C# Snippet:TranscribeFromUrl
// Specify the URL of the audio file to transcribe
Uri audioUrl = new Uri("https://example.com/audio/sample.wav");

// Configure transcription to use the remote URL
TranscriptionOptions options = new TranscriptionOptions
{
    AudioUrl = audioUrl
};

// No audio stream needed - the service fetches the file from the URL
TranscribeRequestContent request = new TranscribeRequestContent
{
    Options = options
};

Response<TranscriptionResult> response = await client.TranscribeAsync(request);
TranscriptionResult result = response.Value;

Console.WriteLine($"Transcribed audio from URL: {audioUrl}");
Console.WriteLine($"Duration: {result.Duration}");

var channelPhrases = result.PhrasesByChannel.First();
Console.WriteLine($"\nTranscription:\n{channelPhrases.Text}");
```

## Download and Transcribe from HTTP

Download an audio file from a remote location and transcribe it.

```C# Snippet:TranscribeFromHttpStream
// Download the audio file from a remote location
string audioUrl = "https://example.com/audio/sample.wav";

using HttpClient httpClient = new HttpClient();
using HttpResponseMessage httpResponse = await httpClient.GetAsync(audioUrl);
httpResponse.EnsureSuccessStatusCode();

// Get the audio stream from the HTTP response
using Stream audioStream = await httpResponse.Content.ReadAsStreamAsync();

// Create transcription request with the downloaded stream
TranscribeRequestContent request = new TranscribeRequestContent
{
    Audio = audioStream
};

Response<TranscriptionResult> response = await client.TranscribeAsync(request);
TranscriptionResult result = response.Value;

Console.WriteLine($"Downloaded and transcribed audio from: {audioUrl}");
Console.WriteLine($"Duration: {result.Duration}");

var channelPhrases = result.PhrasesByChannel.First();
foreach (TranscribedPhrase phrase in channelPhrases.Phrases)
{
    Console.WriteLine($"[{phrase.Offset}] {phrase.Text}");
}
```

## Transcribe from Azure Blob Storage

Transcribe audio files stored in Azure Blob Storage using SAS URLs.

```C# Snippet:TranscribeFromBlobStorage
// Generate a SAS URL for your blob in Azure Storage
string blobSasUrl = "https://yourstorageaccount.blob.core.windows.net/audiofiles/sample.wav?sv=2021-06-08&ss=b&srt=o&sp=r&se=2024-12-31T23:59:59Z&st=2024-01-01T00:00:00Z&spr=https&sig=YOUR_SAS_TOKEN";

Uri blobUri = new Uri(blobSasUrl);

TranscriptionOptions options = new TranscriptionOptions
{
    AudioUrl = blobUri
};

TranscribeRequestContent request = new TranscribeRequestContent
{
    Options = options
};

Response<TranscriptionResult> response = await client.TranscribeAsync(request);
TranscriptionResult result = response.Value;

Console.WriteLine($"Transcribed audio from Azure Blob Storage");
Console.WriteLine($"Duration: {result.Duration}");

var channelPhrases = result.PhrasesByChannel.First();
Console.WriteLine($"Transcription:\n{channelPhrases.Text}");
```

## Transcribe Remote File with Options

Combine remote file transcription with transcription options like locale and diarization.

```C# Snippet:TranscribeRemoteFileWithOptions
Uri audioUrl = new Uri("https://example.com/audio/meeting.wav");

TranscriptionOptions options = new TranscriptionOptions
{
    AudioUrl = audioUrl,
    Locales = { "en-US" },
    Diarization = new TranscriptionDiarizationOptions
    {
        Enabled = true,
        MaxSpeakers = 5
    }
};

TranscribeRequestContent request = new TranscribeRequestContent
{
    Options = options
};

Response<TranscriptionResult> response = await client.TranscribeAsync(request);
TranscriptionResult result = response.Value;

Console.WriteLine($"Transcribed meeting from URL with speaker diarization");
foreach (var channelPhrases in result.PhrasesByChannel)
{
    foreach (var phrase in channelPhrases.Phrases)
    {
        Console.WriteLine($"[Speaker {phrase.Speaker}] {phrase.Text}");
    }
}
```

## Process Multiple Remote Files

Process multiple audio files from different sources in parallel.

```C# Snippet:TranscribeMultipleRemoteFiles
string[] audioUrls = new[]
{
    "https://example.com/audio/file1.wav",
    "https://example.com/audio/file2.wav",
    "https://example.com/audio/file3.wav"
};

var transcriptionTasks = audioUrls.Select(async url =>
{
    var options = new TranscriptionOptions
    {
        AudioUrl = new Uri(url)
    };

    var request = new TranscribeRequestContent { Options = options };
    var response = await client.TranscribeAsync(request);

    return new
    {
        Url = url,
        Result = response.Value
    };
});

var results = await Task.WhenAll(transcriptionTasks);

foreach (var result in results)
{
    Console.WriteLine($"\nFile: {result.Url}");
    Console.WriteLine($"Transcription: {result.Result.PhrasesByChannel.First().Text}");
}
```
