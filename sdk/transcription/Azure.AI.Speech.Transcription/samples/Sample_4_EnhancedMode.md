# Enhanced Mode for Transcription

Enhanced Mode uses LLM-powered speech recognition to provide improved transcription accuracy, real-time translation, prompt-based customization, and multilingual support with GPU acceleration.

### Supported Tasks

| Task | Description |
|------|-------------|
| `transcribe` | Transcribe audio in the input language (auto-detected or specified) |
| `translate` | Translate audio to a specified target language |


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

## Translate an Audio File with Enhanced Mode

Translate speech to a target language during transcription. Specify the target language using the language code (e.g., `en` for English, `ko` for Korean, `es` for Spanish).

```C# Snippet:TranslateWithEnhancedMode
string audioFilePath = "path/to/chinese-audio.wav";
using FileStream audioStream = File.OpenRead(audioFilePath);

// Translate Chinese speech to Korean
EnhancedModeProperties enhancedMode = new EnhancedModeProperties
{
    Task = "translate",
    TargetLanguage = "ko"  // Translate to Korean
};

TranscriptionOptions options = new TranscriptionOptions(audioStream)
{
    EnhancedMode = enhancedMode
};

ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
TranscriptionResult result = response.Value;

Console.WriteLine("Translated to Korean:");
var channelPhrases = result.PhrasesByChannel.First();
Console.WriteLine(channelPhrases.Text);
```

## Enhanced Mode with Prompt Tuning

Provide prompts to improve recognition or control output format. Prompts are optional text that guides the output style for `transcribe` or `translate` tasks.


```C# Snippet:EnhancedModeWithPrompts
string audioFilePath = "path/to/audio.wav";
using FileStream audioStream = File.OpenRead(audioFilePath);

// Guide output formatting using prompts
EnhancedModeProperties enhancedMode = new EnhancedModeProperties
{
    Task = "transcribe",
    Prompt = { "Output must be in lexical format." }
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

## Combine Enhanced Mode with Other Options

Enhanced Mode can be combined with other transcription options like `diarization`, `profanityFilterMode`, and `channels` for comprehensive transcription scenarios such as meeting transcription.

> **Note:** Diarization is only supported for the `transcribe` task, not for `translate`.

```C# Snippet:EnhancedModeWithDiarization
string audioFilePath = "path/to/meeting.wav";
using FileStream audioStream = File.OpenRead(audioFilePath);

EnhancedModeProperties enhancedMode = new EnhancedModeProperties
{
    Task = "transcribe",
    Prompt = { "Output must be in lexical format." }
};

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

## Limitations

- `confidence` is not available and always returns `0`
- Word-level timing (`offsetMilliseconds`, `durationMilliseconds`) is not supported for the `translate` task
- Diarization is not supported for the `translate` task (only `speaker1` label is returned)
- `locales` and `phraseLists` options are not required or applicable with Enhanced Mode

## Related Resources

- [LLM speech for speech transcription and translation (preview)](https://learn.microsoft.com/azure/ai-services/speech-service/llm-speech)
- [Fast transcription](https://learn.microsoft.com/azure/ai-services/speech-service/fast-transcription-create)
```

