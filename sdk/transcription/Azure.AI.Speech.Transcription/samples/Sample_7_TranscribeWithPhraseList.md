# Phrase List

This sample shows how to use custom phrase lists to improve transcription accuracy with the `Azure.AI.Speech.Transcription` SDK.

## Overview

A phrase list allows you to provide domain-specific terms, product names, technical jargon, or other words that may not be well-recognized by the default speech model. This improves accuracy for specialized content.

## Transcribe with Phrase List

To use a custom phrase list, configure the `PhraseList` property in your `TranscriptionOptions` and add phrases that may not be well-recognized by the default model.

For example, without a phrase list:
- "Jessie" might be recognized as "Jesse"
- "Rehaan" might be recognized as "everyone"
- "Contoso" might be recognized as "can't do so"

```C# Snippet:TranscribeWithPhraseListSample
string audioFilePath = "path/to/audio.wav";
using FileStream audioStream = File.OpenRead(audioFilePath);

// Add custom phrases to improve recognition of names and domain-specific terms
TranscriptionOptions options = new TranscriptionOptions(audioStream)
{
    PhraseList = new PhraseListProperties()
};

// Add names, locations, and terms that might be misrecognized
// For example, "Jessie" might be recognized as "Jesse", or "Contoso" as "can't do so"
options.PhraseList.Phrases.Add("Contoso");
options.PhraseList.Phrases.Add("Jessie");
options.PhraseList.Phrases.Add("Rehaan");

ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
TranscriptionResult result = response.Value;

Console.WriteLine("Transcription with custom phrase list:");
var channelPhrases = result.PhrasesByChannel.First();
Console.WriteLine(channelPhrases.Text);
```

