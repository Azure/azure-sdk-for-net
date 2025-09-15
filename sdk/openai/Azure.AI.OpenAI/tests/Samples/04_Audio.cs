// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.IO;
using Azure.Identity;
using OpenAI.Audio;

namespace Azure.AI.OpenAI.Samples;

public partial class AzureOpenAISamples
{
    public void AudioTranscription()
    {
        #region Snippet:AudioTranscription
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        AudioClient audioClient = azureClient.GetAudioClient("my-whisper-deployment");

        // Load an audio file from your local system
        string audioFilePath = "path/to/your/audio/file.wav";
        
        // Transcribe the audio to text
        AudioTranscription transcription = audioClient.TranscribeAudio(audioFilePath);
        
        Console.WriteLine($"Transcribed text: {transcription.Text}");
        #endregion
    }

    public void AudioTranscriptionWithOptions()
    {
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        AudioClient audioClient = azureClient.GetAudioClient("my-whisper-deployment");

        #region Snippet:AudioTranscriptionWithOptions
        string audioFilePath = "path/to/your/audio/file.wav";

        // Configure transcription options for enhanced output
        AudioTranscriptionOptions options = new()
        {
            ResponseFormat = AudioTranscriptionFormat.Verbose,
            Temperature = 0.2f,
            Language = "en", // Specify the language if known for better accuracy
            Prompt = "This is a recording about artificial intelligence and machine learning.", // Context hint
        };

        AudioTranscription transcription = audioClient.TranscribeAudio(audioFilePath, options);
        
        Console.WriteLine($"Transcribed text: {transcription.Text}");
        Console.WriteLine($"Language detected: {transcription.Language}");
        Console.WriteLine($"Duration: {transcription.Duration}");
        
        // Access word-level timestamps if using verbose format
        if (transcription.Words != null)
        {
            Console.WriteLine("Word-level timestamps:");
            foreach (var word in transcription.Words)
            {
                Console.WriteLine($"  {word.Word}: timestamps available");
            }
        }
        #endregion
    }

    public void AudioTranslation()
    {
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        AudioClient audioClient = azureClient.GetAudioClient("my-whisper-deployment");

        #region Snippet:AudioTranslation
        // Load an audio file in any supported language
        string audioFilePath = "path/to/your/foreign/audio/file.wav";
        
        // Translate the audio to English text
        AudioTranslation translation = audioClient.TranslateAudio(audioFilePath);
        
        Console.WriteLine($"Translated to English: {translation.Text}");
        #endregion
    }

    public void AudioTranslationWithOptions()
    {
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        AudioClient audioClient = azureClient.GetAudioClient("my-whisper-deployment");

        #region Snippet:AudioTranslationWithOptions
        string audioFilePath = "path/to/your/foreign/audio/file.wav";

        // Configure translation options for enhanced output
        AudioTranslationOptions options = new()
        {
            ResponseFormat = AudioTranslationFormat.Verbose,
            Temperature = 0.1f, // Lower temperature for more deterministic translation
            Prompt = "This is a technical presentation about computer science.", // Context for better translation
        };

        AudioTranslation translation = audioClient.TranslateAudio(audioFilePath, options);
        
        Console.WriteLine($"Translated text: {translation.Text}");
        Console.WriteLine($"Duration: {translation.Duration}");
        #endregion
    }

#if !AZURE_OPENAI_GA
    public void TextToSpeech()
    {
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        AudioClient audioClient = azureClient.GetAudioClient("my-tts-deployment");

        #region Snippet:TextToSpeech
        string textToSpeak = "Hello! Welcome to Azure OpenAI text-to-speech. This technology can convert written text into natural-sounding speech.";
        
        // Generate speech from text
        BinaryData speechData = audioClient.GenerateSpeech(textToSpeak, GeneratedSpeechVoice.Alloy);
        
        // Save the audio to a file
        string outputPath = "generated_speech.mp3";
        File.WriteAllBytes(outputPath, speechData.ToArray());
        
        Console.WriteLine($"Speech generated and saved to: {outputPath}");
        #endregion
    }

    public void TextToSpeechWithOptions()
    {
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        AudioClient audioClient = azureClient.GetAudioClient("my-tts-deployment");

        #region Snippet:TextToSpeechWithOptions
        string textToSpeak = "This is a demonstration of advanced text-to-speech capabilities with customized voice settings.";

        // Generate speech with specific voice
        BinaryData speechData = audioClient.GenerateSpeech(textToSpeak, GeneratedSpeechVoice.Nova);
        
        // Save with descriptive filename
        string outputPath = $"speech_nova_{DateTime.Now:yyyyMMdd_HHmmss}.mp3";
        File.WriteAllBytes(outputPath, speechData.ToArray());
        
        Console.WriteLine($"Speech generated with Nova voice");
        Console.WriteLine($"Saved to: {outputPath}");
        #endregion
    }

    public void AudioWorkflowExample()
    {
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        
        AudioClient whisperClient = azureClient.GetAudioClient("my-whisper-deployment");
        AudioClient ttsClient = azureClient.GetAudioClient("my-tts-deployment");

        #region Snippet:AudioWorkflowExample
        // Complete workflow: audio processing pipeline
        string inputAudioPath = "path/to/meeting/recording.wav";
        
        // Step 1: Transcribe the meeting recording
        Console.WriteLine("Transcribing meeting recording...");
        AudioTranscriptionOptions transcriptionOptions = new()
        {
            ResponseFormat = AudioTranscriptionFormat.Verbose,
            Language = "en",
            Prompt = "This is a business meeting discussing project updates and next steps.",
        };
        
        AudioTranscription transcription = whisperClient.TranscribeAudio(inputAudioPath, transcriptionOptions);
        Console.WriteLine($"Meeting transcribed: {transcription.Text.Length} characters");
        
        // Step 2: Extract key points or summary (this would typically involve chat completion)
        string summary = "Key meeting outcomes: Project milestone achieved, budget approved, next review scheduled for next week.";
        
        // Step 3: Convert summary back to speech for accessibility
        Console.WriteLine("Generating audio summary...");
        
        BinaryData summaryAudio = ttsClient.GenerateSpeech(summary, GeneratedSpeechVoice.Echo);
        
        // Step 4: Save outputs
        File.WriteAllText("meeting_transcript.txt", transcription.Text);
        File.WriteAllText("meeting_summary.txt", summary);
        File.WriteAllBytes("meeting_summary.mp3", summaryAudio.ToArray());
        
        Console.WriteLine("Audio workflow completed:");
        Console.WriteLine("- meeting_transcript.txt: Full transcription");
        Console.WriteLine("- meeting_summary.txt: Key points summary");
        Console.WriteLine("- meeting_summary.mp3: Audio summary");
        #endregion
    }
#endif
}