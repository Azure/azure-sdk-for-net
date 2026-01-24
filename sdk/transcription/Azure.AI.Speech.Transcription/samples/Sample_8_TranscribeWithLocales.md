# Locales

This sample shows how to specify language locales for transcription with the `Azure.AI.Speech.Transcription` SDK.

## Overview

The `Locales` property controls how the transcription service handles language recognition:

- **Single locale (known language)**: When you know the language of the audio, specify one locale to improve accuracy and minimize latency.
- **Multiple locales (language identification)**: When you're not sure about the language, specify multiple candidate locales and the service will identify the language (one locale per audio file).
- **No locale specified**: The service uses the multi-lingual model to auto-detect and transcribe.

For the full list of supported locales, see [Language support](https://learn.microsoft.com/azure/ai-services/speech-service/language-support?tabs=stt).

## Transcribe with Known Locale

When you know the language of the audio file, specify a single locale for better accuracy and lower latency:

```C# Snippet:TranscribeWithKnownLocale
string audioFilePath = "path/to/english-audio.mp3";
using FileStream audioStream = File.OpenRead(audioFilePath);

// When you know the locale of the audio, specify a single locale
// to improve transcription accuracy and minimize latency
TranscriptionOptions options = new TranscriptionOptions(audioStream);
options.Locales.Add("en-US");

ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
TranscriptionResult result = response.Value;

Console.WriteLine("Transcription with known locale (en-US):");
var channelPhrases = result.PhrasesByChannel.First();
Console.WriteLine(channelPhrases.Text);
```

## Transcribe with Language Identification

When you're not sure about the locale, specify multiple candidate locales. The service will identify the main language of the audio (one locale per audio file):

```C# Snippet:TranscribeWithLanguageIdentification
string audioFilePath = "path/to/english-audio.mp3";
using FileStream audioStream = File.OpenRead(audioFilePath);

// When you're not sure about the locale, specify multiple candidate locales
// The service will identify the language (one locale per audio file)
TranscriptionOptions options = new TranscriptionOptions(audioStream);
options.Locales.Add("en-US");
options.Locales.Add("es-ES");

ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
TranscriptionResult result = response.Value;

Console.WriteLine("Transcription with language identification:");
var channelPhrases = result.PhrasesByChannel.First();

// The detected locale is available in each phrase
foreach (TranscribedPhrase phrase in channelPhrases.Phrases)
{
    Console.WriteLine($"[{phrase.Locale}] {phrase.Text}");
}
```

> **Note:** Language identification is designed to identify one main language locale per audio file. If you need to transcribe multi-lingual content within a single audio file, consider using the multi-lingual transcription feature (preview) by not specifying any locales.


