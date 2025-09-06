// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Represents configuration options for a VoiceLive session.
    /// </summary>
    /// <remarks>
    /// This unified class provides all configuration options that can be used to customize
    /// the behavior of a VoiceLive session, whether for conversation, transcription, or
    /// hybrid scenarios.
    /// </remarks>
    public class SessionOptions
    {
        // ==================== Audio Configuration ====================

        /// <summary>
        /// Gets or sets the input audio format for the session.
        /// </summary>
        /// <value>
        /// The audio format to use for input audio. If not specified, the service will use a default format.
        /// </value>
        public AudioFormat? InputAudioFormat { get; set; }

        /// <summary>
        /// Gets or sets the output audio format for the session.
        /// </summary>
        /// <value>
        /// The audio format to use for output audio. If not specified, the service will use a default format.
        /// </value>
        public AudioFormat? OutputAudioFormat { get; set; }

        /// <summary>
        /// Gets or sets the turn detection configuration for the session.
        /// </summary>
        /// <value>
        /// The turn detection configuration to use. If not specified, the service will use server-side VAD.
        /// </value>
        public TurnDetection TurnDetection { get; set; }

        /// <summary>
        /// Gets or sets the audio noise reduction settings.
        /// </summary>
        /// <value>
        /// Configuration for reducing noise in the input audio to improve accuracy.
        /// If not specified, default noise reduction settings will be used.
        /// </value>
        public AudioNoiseReduction NoiseReduction { get; set; }

        /// <summary>
        /// Gets or sets the echo cancellation settings.
        /// </summary>
        /// <value>
        /// Configuration for cancelling echo in the input audio to improve accuracy.
        /// If not specified, default echo cancellation settings will be used.
        /// </value>
        public AudioEchoCancellation EchoCancellation { get; set; }

        // ==================== Modalities & Core Settings ====================

        /// <summary>
        /// Gets or sets the modalities supported by the session.
        /// </summary>
        /// <value>
        /// A list of modalities that the session should support. Defaults to text and audio.
        /// </value>
        public IList<InputModality> Modalities { get; set; } = new List<InputModality> { InputModality.Text, InputModality.Audio };

        /// <summary>
        /// Gets or sets the model to use for the session.
        /// </summary>
        /// <value>
        /// The model identifier for processing. If not specified, the service will use a default model.
        /// </value>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the temperature parameter for response generation.
        /// </summary>
        /// <value>
        /// A value between 0.0 and 1.0 controlling the randomness of the response. Higher values produce more random responses.
        /// </value>
        public float? Temperature { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of tokens to generate in the response.
        /// </summary>
        /// <value>
        /// The maximum number of tokens to generate. If not specified, the service will use a default limit.
        /// </value>
        public int? MaxResponseOutputTokens { get; set; }

        // ==================== Transcription Features ====================

        /// <summary>
        /// Gets or sets the input audio transcription settings.
        /// </summary>
        /// <value>
        /// Configuration for transcribing input audio. If not specified, transcription is disabled.
        /// </value>
        public AudioInputTranscriptionSettings InputAudioTranscription { get; set; }

        /// <summary>
        /// Gets or sets the language for transcription.
        /// </summary>
        /// <value>
        /// The language code (e.g., "en-US", "fr-FR") to use for transcription.
        /// If not specified, the service will attempt to auto-detect the language.
        /// </value>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to include confidence scores in transcription results.
        /// </summary>
        /// <value>
        /// <c>true</c> to include confidence scores for transcribed text; otherwise, <c>false</c>.
        /// Default is <c>false</c>.
        /// </value>
        public bool IncludeConfidenceScores { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to include timestamps in transcription results.
        /// </summary>
        /// <value>
        /// <c>true</c> to include word-level timestamps in transcribed text; otherwise, <c>false</c>.
        /// Default is <c>false</c>.
        /// </value>
        public bool IncludeTimestamps { get; set; }

        /// <summary>
        /// Gets or sets a list of words or phrases to boost recognition accuracy.
        /// </summary>
        /// <value>
        /// A list of domain-specific words or phrases that should be recognized more accurately.
        /// This can improve transcription quality for specialized vocabulary like brand names,
        /// technical terms, or industry jargon.
        /// </value>
        public IList<string> CustomVocabulary { get; set; } = new List<string>();

        // ==================== Conversation Features ====================

        /// <summary>
        /// Gets or sets the voice configuration for the conversation.
        /// </summary>
        /// <value>
        /// The voice configuration to use for generating spoken responses. If not specified,
        /// the service will use a default voice.
        /// </value>
        public VoiceProvider Voice { get; set; }

        /// <summary>
        /// Gets or sets the instructions for the conversation assistant.
        /// </summary>
        /// <value>
        /// Instructions that guide the assistant's behavior and responses during the conversation.
        /// </value>
        public string Instructions { get; set; }

        /// <summary>
        /// Gets or sets the tools available to the conversation assistant.
        /// </summary>
        /// <value>
        /// A list of tools that the assistant can use during the conversation.
        /// </value>
        public IList<VoiceLiveToolDefinition> Tools { get; set; } = new List<VoiceLiveToolDefinition>();

        /// <summary>
        /// Gets or sets the tool choice strategy for the conversation.
        /// </summary>
        /// <value>
        /// Specifies how the assistant should choose which tools to use. If not specified,
        /// the assistant will automatically decide when to use tools.
        /// </value>
        public string ToolChoice { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to enable parallel tool calling.
        /// </summary>
        /// <value>
        /// <c>true</c> to allow the assistant to call multiple tools in parallel; otherwise, <c>false</c>.
        /// Default is <c>false</c>.
        /// </value>
        public bool ParallelToolCalls { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionOptions"/> class.
        /// </summary>
        public SessionOptions()
        {
        }

        /// <summary>
        /// Converts the session options to a <see cref="RequestSession"/> instance.
        /// </summary>
        /// <returns>A <see cref="RequestSession"/> instance configured with the current options.</returns>
        internal virtual RequestSession ToRequestSession()
        {
            var session = new RequestSession();

            // Audio configuration
            if (InputAudioFormat.HasValue)
            {
                session.InputAudioFormat = InputAudioFormat.Value;
            }

            if (OutputAudioFormat.HasValue)
            {
                session.OutputAudioFormat = OutputAudioFormat.Value;
            }

            if (TurnDetection != null)
            {
                session.TurnDetection = TurnDetection;
            }

            if (NoiseReduction != null)
            {
                session.InputAudioNoiseReduction = NoiseReduction;
            }

            if (EchoCancellation != null)
            {
                session.InputAudioEchoCancellation = EchoCancellation;
            }

            // Modalities
            if (Modalities != null && Modalities.Count > 0)
            {
                session.Modalities.Clear();
                foreach (var modality in Modalities)
                {
                    session.Modalities.Add(modality);
                }
            }

            // Model and generation settings
            if (!string.IsNullOrEmpty(Model))
            {
                session.Model = Model;
            }

            if (Temperature.HasValue)
            {
                session.Temperature = Temperature.Value;
            }

            if (MaxResponseOutputTokens.HasValue)
            {
                session.MaxResponseOutputTokens = MaxResponseOutputTokens.Value;
            }

            // Transcription settings
            if (InputAudioTranscription != null)
            {
                session.InputAudioTranscription = InputAudioTranscription;
            }

            if (!string.IsNullOrEmpty(Language))
            {
                // Store language in additional properties since it might not be a direct property
                session.AdditionalProperties["language"] = BinaryData.FromString($"\"{Language}\"");
            }

            // Note: IncludeConfidenceScores, IncludeTimestamps, and CustomVocabulary
            // may need special handling based on the service API

            // Conversation settings
            if (Voice != null)
            {
                session.Voice = Voice;
            }

            if (!string.IsNullOrEmpty(Instructions))
            {
                session.Instructions = Instructions;
            }

            if (Tools != null && Tools.Count > 0)
            {
                session.Tools.Clear();
                foreach (var tool in Tools)
                {
                    session.Tools.Add(tool);
                }
            }

            if (ToolChoice != null)
            {
                session.ToolChoice = ToolChoice;
            }

            // Note: ParallelToolCalls may need special handling

            return session;
        }
    }
}
