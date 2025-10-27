# Advanced Remote File Transcription

This sample demonstrates advanced scenarios for transcribing audio files from remote locations using the `Azure.AI.Speech.Transcription` SDK.

## Transcribe from URL

Transcribe an audio file directly from a public URL without downloading it first.

```C# Snippet:TranscribeFromUrl
// Specify the URL of the audio file to transcribe
Uri audioUrl = new Uri("https://example.com/audio/sample.wav");

// Configure transcription to use the remote URL
TranscriptionOptions options = new TranscriptionOptions(audioUrl);

// No audio stream needed - the service fetches the file from the URL
Response<TranscriptionResult> response = await client.TranscribeAsync(options);
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
// Azure Blob Storage URL with SAS token for access
Uri blobSasUrl = new Uri(
    "https://mystorageaccount.blob.core.windows.net/audio-files/recording.wav?sv=2021-06-08&st=...");

TranscriptionOptions options = new TranscriptionOptions(blobSasUrl);

Response<TranscriptionResult> response = await client.TranscribeAsync(options);
TranscriptionResult result = response.Value;

Console.WriteLine($"Transcribed audio from Azure Blob Storage");
Console.WriteLine($"Duration: {result.Duration}");

var channelPhrases = result.PhrasesByChannel.First();
Console.WriteLine($"\nFull Transcription:\n{channelPhrases.Text}");
```

## Transcribe Remote File with Options

Combine remote file transcription with transcription options like locale and diarization.

```C# Snippet:TranscribeRemoteFileWithOptions
Uri audioUrl = new Uri("https://example.com/audio/spanish-interview.mp3");

// Configure transcription options for remote audio
TranscriptionOptions options = new TranscriptionOptions(audioUrl)
{
    ProfanityFilterMode = ProfanityFilterMode.Masked,
    DiarizationOptions = new TranscriptionDiarizationOptions
    {
        Enabled = true,
        MaxSpeakers = 2
    }
};

// Add Spanish locale
options.Locales.Add("es-ES");

Response<TranscriptionResult> response = await client.TranscribeAsync(options);
TranscriptionResult result = response.Value;

Console.WriteLine("Remote transcription with options:");
Console.WriteLine($"Duration: {result.Duration}");

var channelPhrases = result.PhrasesByChannel.First();
foreach (TranscribedPhrase phrase in channelPhrases.Phrases)
{
    Console.WriteLine($"Speaker {phrase.Speaker}: {phrase.Text}");
}
```

## Process Multiple Remote Files

Process multiple audio files from different sources in parallel.

```C# Snippet:TranscribeMultipleRemoteFiles
// List of audio files to transcribe
Uri[] audioUrls = new[]
{
    new Uri("https://example.com/audio/file1.wav"),
    new Uri("https://example.com/audio/file2.wav"),
    new Uri("https://example.com/audio/file3.wav")
};

// Create tasks for parallel transcription
Task<Response<TranscriptionResult>>[] transcriptionTasks = audioUrls
    .Select(url =>
    {
        TranscriptionOptions options = new TranscriptionOptions(url);

        return client.TranscribeAsync(options);
    })
    .ToArray();

// Wait for all transcriptions to complete
Response<TranscriptionResult>[] responses = await Task.WhenAll(transcriptionTasks);

// Process results
for (int i = 0; i < responses.Length; i++)
{
    TranscriptionResult result = responses[i].Value;
    Console.WriteLine($"\nFile {i + 1} ({audioUrls[i]}):");
    Console.WriteLine($"Duration: {result.Duration}");

    var channelPhrases = result.PhrasesByChannel.First();
    Console.WriteLine($"Text: {channelPhrases.Text}");
}
```
