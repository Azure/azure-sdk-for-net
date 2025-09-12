// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using System;
using System.IO;

namespace Azure.AI.VoiceLive.Tests.Infrastructure
{
    /// <summary>
    /// Test environment configuration for Voice Live Service tests.
    /// Manages credentials, endpoints, and test settings.
    /// </summary>
    public class VoiceLiveTestEnvironment : TestEnvironment
    {
        // ===== Core Service Configuration =====

        /// <summary>
        /// Voice Live Service endpoint URL.
        /// Example: https://my-resource.cognitiveservices.azure.com
        /// </summary>
        public string Endpoint => GetRecordedVariable("VOICELIVE_ENDPOINT");

        /// <summary>
        /// API key for authentication (alternative to Azure AD).
        /// Keep secret and never record.
        /// </summary>
        public string ApiKey => GetRecordedVariable("VOICELIVE_API_KEY",
            options => options.IsSecret());

        /// <summary>
        /// Azure region for the service.
        /// </summary>
        public string Region => GetRecordedVariable("VOICELIVE_REGION",
            defaultValue: "eastus");

        // ===== Model Configuration =====

        /// <summary>
        /// Realtime model for native audio processing.
        /// Examples: gpt-4o-realtime-preview, gpt-4o-mini-realtime-preview
        /// </summary>
        public string RealtimeModel => GetRecordedVariable("VOICELIVE_REALTIME_MODEL",
            defaultValue: "gpt-4o-realtime-preview");

        /// <summary>
        /// Cascaded model using Azure Speech Services.
        /// Examples: gpt-4o, gpt-4.1, phi4-mini
        /// </summary>
        public string CascadedModel => GetRecordedVariable("VOICELIVE_CASCADED_MODEL",
            defaultValue: "gpt-4o");

        /// <summary>
        /// Lightweight model for testing.
        /// </summary>
        public string LiteModel => GetRecordedVariable("VOICELIVE_LITE_MODEL",
            defaultValue: "phi4-mini");

        // ===== Voice Configuration =====

        /// <summary>
        /// Custom voice endpoint ID (GUID).
        /// Only set if custom voice is deployed.
        /// </summary>
        public string CustomVoiceEndpointId => GetVariable("VOICELIVE_CUSTOM_VOICE_ENDPOINT",
            defaultValue: null);

        /// <summary>
        /// Custom voice name.
        /// </summary>
        public string CustomVoiceName => GetVariable("VOICELIVE_CUSTOM_VOICE_NAME",
            defaultValue: "en-US-CustomNeural");

        /// <summary>
        /// Personal voice name for testing AzurePersonalVoice.
        /// </summary>
        public string PersonalVoiceName => GetVariable("VOICELIVE_PERSONAL_VOICE_NAME",
            defaultValue: null);

        /// <summary>
        /// Personal voice model (DragonLatestNeural, PhoenixLatestNeural, PhoenixV2Neural).
        /// </summary>
        public string PersonalVoiceModel => GetVariable("VOICELIVE_PERSONAL_VOICE_MODEL",
            defaultValue: "DragonLatestNeural");

        // ===== Animation and Avatar Configuration =====

        /// <summary>
        /// Avatar character name.
        /// </summary>
        public string AvatarCharacter => GetVariable("VOICELIVE_AVATAR_CHARACTER",
            defaultValue: "lisa");

        /// <summary>
        /// Avatar style.
        /// </summary>
        public string AvatarStyle => GetVariable("VOICELIVE_AVATAR_STYLE",
            defaultValue: "casual-sitting");

        /// <summary>
        /// Animation model name.
        /// </summary>
        public string AnimationModel => GetVariable("VOICELIVE_ANIMATION_MODEL",
            defaultValue: "default");

        /// <summary>
        /// ICE server URLs for WebRTC (comma-separated).
        /// </summary>
        public string IceServerUrls => GetVariable("VOICELIVE_ICE_SERVERS",
            defaultValue: "stun:stun.l.google.com:19302");

        // ===== AI Agent Configuration =====

        /// <summary>
        /// AI Agent ID for agent integration tests.
        /// </summary>
        public string AgentId => GetVariable("VOICELIVE_AGENT_ID",
            defaultValue: null);

        /// <summary>
        /// AI Agent connection string.
        /// </summary>
        public string AgentConnectionString => GetVariable("VOICELIVE_AGENT_CONNECTION",
            options => options.IsSecret(),
            defaultValue: null);

        /// <summary>
        /// AI Agent thread ID for conversation continuity.
        /// </summary>
        public string AgentThreadId => GetVariable("VOICELIVE_AGENT_THREAD_ID",
            defaultValue: null);

        // ===== Audio Processing Configuration =====

        /// <summary>
        /// Enable echo cancellation in tests.
        /// </summary>
        public bool EnableEchoCancellation => GetVariable("VOICELIVE_ECHO_CANCELLATION",
            defaultValue: "false") == "true";

        /// <summary>
        /// Enable noise reduction in tests.
        /// </summary>
        public bool EnableNoiseReduction => GetVariable("VOICELIVE_NOISE_REDUCTION",
            defaultValue: "false") == "true";

        /// <summary>
        /// Default audio input transcription model.
        /// Options: whisper-1, azure-speech, azure-fast-transcription, s2s-ingraph
        /// </summary>
        public string TranscriptionModel => GetVariable("VOICELIVE_TRANSCRIPTION_MODEL",
            defaultValue: "whisper-1");

        // ===== Test Configuration =====

        /// <summary>
        /// Path to test audio files.
        /// </summary>
        public string TestAudioPath => GetVariable("VOICELIVE_TEST_AUDIO_PATH",
            defaultValue: Path.Combine(TestContext.CurrentContext.TestDirectory, "Audio"));

        /// <summary>
        /// Enable extended logging for debugging.
        /// </summary>
        public bool EnableVerboseLogging => GetVariable("VOICELIVE_VERBOSE_LOGGING",
            defaultValue: "false") == "true";

        /// <summary>
        /// Default timeout for operations.
        /// </summary>
        public TimeSpan DefaultTimeout => TimeSpan.FromSeconds(
            int.Parse(GetVariable("VOICELIVE_DEFAULT_TIMEOUT", defaultValue: "30")));

        /// <summary>
        /// Extended timeout for long-running operations.
        /// </summary>
        public TimeSpan ExtendedTimeout => TimeSpan.FromSeconds(
            int.Parse(GetVariable("VOICELIVE_EXTENDED_TIMEOUT", defaultValue: "120")));

        // ===== Feature Flags =====

        public bool HasCustomVoice => !string.IsNullOrEmpty(CustomVoiceEndpointId);
        public bool HasPersonalVoice => !string.IsNullOrEmpty(PersonalVoiceName);
        public bool HasAgent => !string.IsNullOrEmpty(AgentId);
        public bool HasAvatarSupport => GetVariable("VOICELIVE_AVATAR_ENABLED",
            defaultValue: "false") == "true";
        public bool HasAnimationSupport => GetVariable("VOICELIVE_ANIMATION_ENABLED",
            defaultValue: "false") == "true";
    }
}
