# Enhanced Mode for Transcription

This sample demonstrates how to use LLM-powered Enhanced Mode for speech transcription and translation.

## What is Enhanced Mode?

Enhanced Mode uses a large language model to provide:

- **Advanced transcription**: Improved quality with deep contextual understanding
- **Translation**: Translate speech to another language in one step
- **Prompt tuning**: Guide output style and improve recognition of specific terms

Enhanced mode is **automatically enabled** when you create an `EnhancedModeProperties` object.

## Transcribe with Enhanced Mode

Use Enhanced Mode for improved transcription quality:

```C# Snippet:TranscribeWithEnhancedMode
string audioFilePath = "path/to/audio.wav";
using FileStream audioStream = File.OpenRead(audioFilePath);

// Enhanced mode is automatically enabled
EnhancedModeProperties enhancedMode = new EnhancedModeProperties
{
    Task = "transcribe"
};

TranscriptionOptions options = new TranscriptionOptions(audioStream)
{
    EnhancedMode = enhancedMode
};

ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
TranscriptionResult result = response.Value;

var channelPhrases = result.PhrasesByChannel.First();
Console.WriteLine(channelPhrases.Text);
```

## Translate Speech to Another Language

Translate speech during transcription:

```C# Snippet:TranscribeWithTranslation
string audioFilePath = "path/to/spanish-audio.wav";
using FileStream audioStream = File.OpenRead(audioFilePath);

// Translate Spanish speech to English
EnhancedModeProperties enhancedMode = new EnhancedModeProperties
{
    Task = "translate",
    TargetLanguage = "en"  // Translate to English
};

TranscriptionOptions options = new TranscriptionOptions(audioStream)
{
    EnhancedMode = enhancedMode
};

ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
TranscriptionResult result = response.Value;

Console.WriteLine("Translated to English:");
var channelPhrases = result.PhrasesByChannel.First();
Console.WriteLine(channelPhrases.Text);
```

## Use Prompts to Guide Output

Provide prompts to improve recognition or control output format:

```C# Snippet:TranscribeWithEnhancedPrompts
string audioFilePath = "path/to/audio.wav";
using FileStream audioStream = File.OpenRead(audioFilePath);

EnhancedModeProperties enhancedMode = new EnhancedModeProperties
{
    Task = "transcribe"
};

// Guide output formatting
enhancedMode.Prompt.Add("Output must be in lexical format.");
// Or improve recognition of specific terms
enhancedMode.Prompt.Add("Pay attention to Azure, OpenAI, Kubernetes.");

TranscriptionOptions options = new TranscriptionOptions(audioStream)
{
    EnhancedMode = enhancedMode
};

ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
TranscriptionResult result = response.Value;

var channelPhrases = result.PhrasesByChannel.First();
Console.WriteLine(channelPhrases.Text);
```

## Combine with Other Options

Enhanced mode works with diarization and profanity filtering:

```C# Snippet:TranscribeWithEnhancedAndDiarization
string audioFilePath = "path/to/meeting.wav";
using FileStream audioStream = File.OpenRead(audioFilePath);

EnhancedModeProperties enhancedMode = new EnhancedModeProperties
{
    Task = "transcribe"
};
enhancedMode.Prompt.Add("Output must be in lexical format.");

TranscriptionOptions options = new TranscriptionOptions(audioStream)
{
    EnhancedMode = enhancedMode,
    ProfanityFilterMode = ProfanityFilterMode.Masked,
    DiarizationOptions = new TranscriptionDiarizationOptions
    {
        MaxSpeakers = 2
    }
};

ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
TranscriptionResult result = response.Value;

var channelPhrases = result.PhrasesByChannel.First();
foreach (TranscribedPhrase phrase in channelPhrases.Phrases)
{
    Console.WriteLine($"[Speaker {phrase.Speaker}] {phrase.Text}");
}
```

## Supported Languages

Enhanced Mode supports: English, Chinese, German, French, Italian, Japanese, Spanish, Portuguese, and Korean.

## Prompt Best Practices

- Maximum length: 4,096 characters
- Write prompts in English for best results
- Use `"Output must be in lexical format."` to control formatting
- Use `"Pay attention to phrase1, phrase2."` to improve recognition
- Limit the number of phrases per prompt

## See Also

- [LLM Speech Documentation](https://learn.microsoft.com/azure/ai-services/speech-service/llm-speech)
- [Sample 3: Transcribe with Options](Sample_3_TranscribeWithOptions.md)
