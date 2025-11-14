// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.VoiceLive.Tests.Infrastructure
{
    /// <summary>
    /// Constants used across the VoiceLive unit tests.
    /// </summary>
    public static class TestConstants
    {
        // ===== Basic Constants =====
        public const string ModelName = "gpt-4o-mini-realtime-preview";
        public const string VoiceName = "en-US-AvaNeural";
        public const string DefaultLocale = "en-US";

        // ===== Azure Voice Types =====
        public const string DefaultAzureVoice = "en-US-AriaNeural";
        public const string AlternateAzureVoice = "en-US-JennyNeural";
        public const string HDVoice = "en-US-Ava:DragonHDLatestNeural";

        // ===== OpenAI Voices (realtime models only) =====
        public const string OpenAIVoiceAlloy = "alloy";
        public const string OpenAIVoiceEcho = "echo";
        public const string OpenAIVoiceShimmer = "shimmer";
        public const string OpenAIVoiceCoral = "coral";
        public const string OpenAIVoiceSage = "sage";
        public const string OpenAIVoiceAsh = "ash";
        public const string OpenAIVoiceBallad = "ballad";
        public const string OpenAIVoiceVerse = "verse";

        // ===== Audio Formats =====
        public const string FormatPCM16 = "pcm16";
        public const string FormatG711ULaw = "g711_ulaw";
        public const string FormatG711ALaw = "g711_alaw";

        // ===== Input Modalities =====
        public const string ModalityText = "text";
        public const string ModalityAudio = "audio";
        public const string ModalityAnimation = "animation";
        public const string ModalityAvatar = "avatar";

        // ===== Transcription Models =====
        public const string TranscriptionWhisper1 = "whisper-1";
        public const string TranscriptionAzureSpeech = "azure-speech";
        public const string TranscriptionAzureFast = "azure-fast-transcription";
        public const string TranscriptionS2SIngraph = "s2s-ingraph";

        // ===== Animation Output Types =====
        public const string AnimationBlendshapes = "blendshapes";
        public const string AnimationVisemeId = "viseme_id";
        public const string AnimationEmotion = "emotion";

        // ===== Common Test Phrases =====
        public const string TestPhraseHello = "Hello, how are you?";
        public const string TestPhraseWeather = "What's the weather in Seattle?";
        public const string TestPhraseLongStory = "Tell me a long story about space exploration";
        public const string TestPhraseCalculation = "What is 25 times 37?";
        public const string TestPhraseMultilingual = "Bonjour, comment allez-vous?";

        // ===== Tool Call Test Functions =====
        public const string TestToolGetWeather = "get_weather";
        public const string TestToolCalculate = "calculate";
        public const string TestToolSearch = "web_search";

        // ===== Timeouts =====
        public static readonly System.TimeSpan QuickTimeout = System.TimeSpan.FromSeconds(5);
        public static readonly System.TimeSpan StandardTimeout = System.TimeSpan.FromSeconds(30);
        public static readonly System.TimeSpan ExtendedTimeout = System.TimeSpan.FromMinutes(2);
        public static readonly System.TimeSpan AnimationTimeout = System.TimeSpan.FromSeconds(10);

        // ===== Audio Sample Rates =====
        public const int SampleRate16kHz = 16000;
        public const int SampleRate24kHz = 24000;
        public const int SampleRate48kHz = 48000;

        // ===== Test File Names =====
        public const string AudioFileHello = "Basic/hello.wav";
        public const string AudioFileWeather = "Questions/whats_weather_in_seattle.wav";
        public const string AudioFileLongSpeech = "LongForm/conversation_120s.wav";
        public const string AudioFileWithNoise = "WithIssues/hello_with_background_noise.wav";
        public const string AudioFileMultiSpeaker = "WithIssues/multiple_speakers.wav";

        // ===== Response Status Values =====
        public const string StatusInProgress = "in_progress";
        public const string StatusCompleted = "completed";
        public const string StatusIncomplete = "incomplete";
        public const string StatusFailed = "failed";
        public const string StatusCancelled = "cancelled";
    }
}
