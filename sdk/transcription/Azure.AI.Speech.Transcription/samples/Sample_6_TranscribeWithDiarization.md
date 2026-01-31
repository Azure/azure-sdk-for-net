# Speaker Diarization

This sample shows how to use speaker diarization (speaker identification) when transcribing audio with the `Azure.AI.Speech.Transcription` SDK.

## Overview

Speaker diarization automatically identifies and labels different speakers in an audio file. This is useful for meeting transcriptions, interview recordings, podcast transcriptions, call center analytics, and any multi-speaker conversation.

## Transcribe with Speaker Diarization

To enable speaker diarization, configure the `DiarizationOptions` in your `TranscriptionOptions`. Set `MaxSpeakers` to the expected number of speakers - this automatically enables diarization.

> **Note**: The total number of identified speakers will never exceed `MaxSpeakers`. If the actual audio contains more speakers than specified, the service will consolidate them. Set a reasonable upper bound if you're unsure of the exact count.

```C# Snippet:TranscribeWithDiarizationSample
string audioFilePath = "path/to/conversation.wav";
using FileStream audioStream = File.OpenRead(audioFilePath);

// Enable speaker diarization
TranscriptionOptions options = new TranscriptionOptions(audioStream)
{
    DiarizationOptions = new TranscriptionDiarizationOptions
    {
        // Enabled is automatically set to true when MaxSpeakers is specified
        MaxSpeakers = 4 // Expect up to 4 speakers in the conversation
    }
};

ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
TranscriptionResult result = response.Value;

Console.WriteLine("Transcription with speaker diarization:");
var channelPhrases = result.PhrasesByChannel.First();
foreach (TranscribedPhrase phrase in channelPhrases.Phrases)
{
    // Speaker information is included in the phrase
    Console.WriteLine($"Speaker {phrase.Speaker}: {phrase.Text}");
}
```

