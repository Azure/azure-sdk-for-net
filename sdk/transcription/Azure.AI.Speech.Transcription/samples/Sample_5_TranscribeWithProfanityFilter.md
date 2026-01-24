# Profanity Filter

This sample shows how to use profanity filtering options when transcribing audio with the `Azure.AI.Speech.Transcription` SDK.

## Overview

The profanity filter allows you to control how profane words are handled in the transcription output. This is useful for applications that need to display clean text or handle profanity in specific ways.

## Profanity Filter Modes

The `ProfanityFilterMode` enum supports the following modes:

| Mode | Description | Example Output |
|------|-------------|----------------|
| `None` | No filtering is applied. Profane words appear as spoken. | "What does the word fuck mean?" |
| `Masked` | **Default.** Profane words are replaced with asterisks. | "What does the word **** mean?" |
| `Removed` | Profane words are completely removed from the output. | "What does the word  mean?" |
| `Tags` | Profane words are wrapped in XML tags. | "What does the word \<profanity\>fuck\</profanity\> mean?" |

## Transcribe with Profanity Filter

To transcribe audio with profanity filtering, specify the `ProfanityFilterMode` in the `TranscriptionOptions`:

```C# Snippet:TranscribeWithProfanityFilter
string audioFilePath = "path/to/audio-with-profanity.wav";

// Demonstrate all four profanity filter modes (default is Masked)
ProfanityFilterMode[] filterModes = new[]
{
    ProfanityFilterMode.None,    // No filtering - profanity appears as spoken
    ProfanityFilterMode.Masked,  // Default - profanity is replaced with asterisks (e.g., "f***")
    ProfanityFilterMode.Removed, // Profanity is completely removed from the text
    ProfanityFilterMode.Tags     // Profanity is wrapped in XML tags (e.g., "<profanity>word</profanity>")
};

foreach (ProfanityFilterMode filterMode in filterModes)
{
    using FileStream audioStream = File.OpenRead(audioFilePath);

    TranscriptionOptions options = new TranscriptionOptions(audioStream)
    {
        ProfanityFilterMode = filterMode
    };

    ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
    TranscriptionResult result = response.Value;

    Console.WriteLine($"ProfanityFilterMode.{filterMode}:");
    var channelPhrases = result.PhrasesByChannel.First();
    Console.WriteLine($"  {channelPhrases.Text}");
    Console.WriteLine();
}
```

## When to Use Each Mode

- **None**: Use when you need the exact spoken content, such as for content moderation analysis or research purposes.
- **Masked** (Default): Use for general applications where you want to indicate profanity was present but not display the actual words.
- **Removed**: Use when you want completely clean output without any indication of profanity.
- **Tags**: Use when you need to programmatically identify and handle profanity in post-processing, or when building content filtering systems.
