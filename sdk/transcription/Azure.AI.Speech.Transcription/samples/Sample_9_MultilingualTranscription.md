# Multilingual Transcription (Preview)

This sample shows how to transcribe audio with multilingual content using the `Azure.AI.Speech.Transcription` SDK.

## Overview

When your audio contains multilingual content that switches between different languages, use the multilingual transcription model by **not specifying any locales**. The service will automatically detect and transcribe each language segment.

**Supported locales:**
de-DE, en-AU, en-CA, en-GB, en-IN, en-US, es-ES, es-MX, fr-CA, fr-FR, it-IT, ja-JP, ko-KR, zh-CN

## Transcribe Multilingual Audio

```C# Snippet:TranscribeWithMultilingualModel
string audioFilePath = "path/to/multilingual-audio.wav";
using FileStream audioStream = File.OpenRead(audioFilePath);

// For multilingual content, do not specify any locales
TranscriptionOptions options = new TranscriptionOptions(audioStream);

ClientResult<TranscriptionResult> response = await client.TranscribeAsync(options);
TranscriptionResult result = response.Value;
```

> **Note:** This feature is currently in preview. The multilingual model outputs the "major locale" for each language (e.g., always "en-US" for English regardless of accent). For more information, see [Fast transcription - Multilingual transcription](https://learn.microsoft.com/azure/ai-services/speech-service/fast-transcription-create?tabs=multilingual-transcription-on).

