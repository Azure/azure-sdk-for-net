// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Hosting;

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
        public string Endpoint => GetOptionalVariable("VOICELIVE_ENDPOINT") ?? "https://changfu-azure-ai-service.services.ai.azure.com";

        /// <summary>
        /// API key for authentication (alternative to Azure AD).
        /// Keep secret and never record.
        /// </summary>
        public string ApiKey => GetOptionalVariable("VOICELIVE_API_KEY");

        /// <summary>
        /// Azure region for the service.
        /// </summary>
        public string Region => GetOptionalVariable("VOICELIVE_REGION") ?? "eastus";

        // ===== Model Configuration =====

        /// <summary>
        /// Realtime model for native audio processing.
        /// Examples: gpt-4o-realtime-preview, gpt-4o-mini-realtime-preview
        /// </summary>
        public string RealtimeModel => GetOptionalVariable("VOICELIVE_REALTIME_MODEL") ?? "gpt-4o-realtime-preview";

        /// <summary>
        /// Cascaded model using Azure Speech Services.
        /// Examples: gpt-4o, gpt-4.1, phi4-mini
        /// </summary>
        public string CascadedModel => GetOptionalVariable("VOICELIVE_CASCADED_MODEL") ?? "gpt-4o";

        /// <summary>
        /// Lightweight model for testing.
        /// </summary>
        public string LiteModel => GetOptionalVariable("VOICELIVE_LITE_MODEL") ?? "phi4-mini";

        // ===== Voice Configuration =====

        /// <summary>
        /// Custom voice endpoint ID (GUID).
        /// Only set if custom voice is deployed.
        /// </summary>
        public string CustomVoiceEndpointId => GetOptionalVariable("VOICELIVE_CUSTOM_VOICE_ENDPOINT") ?? string.Empty;

        /// <summary>
        /// Custom voice name.
        /// </summary>
        public string CustomVoiceName => GetOptionalVariable("VOICELIVE_CUSTOM_VOICE_NAME") ?? "en-US-CustomNeural";

        /// <summary>
        /// Personal voice name for testing AzurePersonalVoice.
        /// </summary>
        public string PersonalVoiceName => GetOptionalVariable("VOICELIVE_PERSONAL_VOICE_NAME") ?? string.Empty;

        /// <summary>
        /// Personal voice model (DragonLatestNeural, PhoenixLatestNeural, PhoenixV2Neural).
        /// </summary>
        public string PersonalVoiceModel => GetOptionalVariable("VOICELIVE_PERSONAL_VOICE_MODEL") ?? "DragonLatestNeural";

        // ===== Animation and Avatar Configuration =====

        /// <summary>
        /// Avatar character name.
        /// </summary>
        public string AvatarCharacter => GetOptionalVariable("VOICELIVE_AVATAR_CHARACTER") ?? "lisa";

        /// <summary>
        /// Avatar style.
        /// </summary>
        public string AvatarStyle => GetOptionalVariable("VOICELIVE_AVATAR_STYLE") ?? "casual-sitting";

        /// <summary>
        /// Animation model name.
        /// </summary>
        public string AnimationModel => GetOptionalVariable("VOICELIVE_ANIMATION_MODEL") ?? "default";

        /// <summary>
        /// ICE server URLs for WebRTC (comma-separated).
        /// </summary>
        public string IceServerUrls => GetOptionalVariable("VOICELIVE_ICE_SERVERS") ?? "stun:stun.l.google.com:19302";

        // ===== AI Agent Configuration =====

        /// <summary>
        /// AI Agent ID for agent integration tests.
        /// </summary>
        public string AgentId => GetOptionalVariable("VOICELIVE_AGENT_ID") ?? string.Empty;

        /// <summary>
        /// AI Agent connection string.
        /// </summary>
        public string AgentConnectionString => GetOptionalVariable("VOICELIVE_AGENT_CONNECTION") ?? string.Empty;

        /// <summary>
        /// AI Agent thread ID for conversation continuity.
        /// </summary>
        public string AgentThreadId => GetOptionalVariable("VOICELIVE_AGENT_THREAD_ID") ?? string.Empty;

        // ===== Audio Processing Configuration =====

        /// <summary>
        /// Enable echo cancellation in tests.
        /// </summary>
        public bool EnableEchoCancellation => bool.Parse(GetOptionalVariable("VOICELIVE_ECHO_CANCELLATION") ?? "false");

        /// <summary>
        /// Enable noise reduction in tests.
        /// </summary>
        public bool EnableNoiseReduction => bool.Parse(GetOptionalVariable("VOICELIVE_NOISE_REDUCTION") ?? "false");

        /// <summary>
        /// Default audio input transcription model.
        /// Options: whisper-1, azure-speech, azure-fast-transcription, s2s-ingraph
        /// </summary>
        public string TranscriptionModel => GetOptionalVariable("VOICELIVE_TRANSCRIPTION_MODEL") ?? "whisper-1";

        // ===== Test Configuration =====

        /// <summary>
        /// Path to test audio files.
        /// </summary>
        public string TestAudioPath => GetOptionalVariable("VOICELIVE_TEST_AUDIO_PATH") ?? Path.Combine(@"d:\scratch", "Audio");

        /// <summary>
        /// Enable extended logging for debugging.
        /// </summary>
        public bool EnableVerboseLogging => bool.Parse(GetOptionalVariable("VOICELIVE_VERBOSE_LOGGING") ?? "false");

        /// <summary>
        /// Default timeout for operations.
        /// </summary>
        public TimeSpan DefaultTimeout => TimeSpan.FromSeconds(
            int.Parse(GetOptionalVariable("VOICELIVE_DEFAULT_TIMEOUT") ?? "30"));

        /// <summary>
        /// Extended timeout for long-running operations.
        /// </summary>
        public TimeSpan ExtendedTimeout => TimeSpan.FromSeconds(
            int.Parse(GetOptionalVariable("VOICELIVE_EXTENDED_TIMEOUT") ?? "120"));

        // ===== Feature Flags =====

        public bool HasCustomVoice => !string.IsNullOrEmpty(CustomVoiceEndpointId);
        public bool HasPersonalVoice => !string.IsNullOrEmpty(PersonalVoiceName);
        public bool HasAgent => !string.IsNullOrEmpty(AgentId);
        public bool HasAvatarSupport => bool.Parse(GetOptionalVariable("VOICELIVE_AVATAR_ENABLED") ?? "false");

        public bool HasAnimationSupport => bool.Parse(GetOptionalVariable("VOICELIVE_ANIMATION_ENABLED") ?? "false");
    }
}
