// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Represents configuration options for a VoiceLive transcription session.
    /// </summary>
    /// <remarks>
    /// This class provides configuration options specifically tailored for audio transcription
    /// scenarios with the VoiceLive service, focusing on audio processing and transcription accuracy.
    /// </remarks>
    public class TranscriptionSessionOptions : VoiceLiveSessionOptions
    {
        /// <summary>
        /// Gets or sets the language for transcription.
        /// </summary>
        /// <value>
        /// The language code (e.g., "en-US", "fr-FR") to use for transcription.
        /// If not specified, the service will attempt to auto-detect the language.
        /// </value>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the transcription model to use.
        /// </summary>
        /// <value>
        /// The model identifier for transcription processing. If not specified,
        /// the service will use a default transcription model.
        /// </value>
        public string Model { get; set; }

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
        /// Gets or sets the audio noise reduction settings.
        /// </summary>
        /// <value>
        /// Configuration for reducing noise in the input audio to improve transcription accuracy.
        /// If not specified, default noise reduction settings will be used.
        /// </value>
        public VoiceLiveAudioNoiseReduction NoiseReduction { get; set; }

        /// <summary>
        /// Gets or sets the echo cancellation settings.
        /// </summary>
        /// <value>
        /// Configuration for cancelling echo in the input audio to improve transcription accuracy.
        /// If not specified, default echo cancellation settings will be used.
        /// </value>
        public VoiceLiveAudioEchoCancellation EchoCancellation { get; set; }

        /// <summary>
        /// Gets or sets a list of words or phrases to boost recognition accuracy.
        /// </summary>
        /// <value>
        /// A list of domain-specific words or phrases that should be recognized more accurately.
        /// This can improve transcription quality for specialized vocabulary.
        /// </value>
        public IList<string> CustomVocabulary { get; set; } = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TranscriptionSessionOptions"/> class.
        /// </summary>
        public TranscriptionSessionOptions() : base()
        {
            // Default modalities for transcription sessions - typically just audio
            Modalities = new List<VoiceLiveModality> { VoiceLiveModality.Audio };
        }

        /// <summary>
        /// Converts the transcription session options to a <see cref="VoiceLiveRequestSession"/> instance.
        /// </summary>
        /// <returns>A <see cref="VoiceLiveRequestSession"/> instance configured with the current options.</returns>
        internal override VoiceLiveRequestSession ToRequestSession()
        {
            var session = base.ToRequestSession();

            if (!string.IsNullOrEmpty(Language))
            {
                // Store language in additional properties since it might not be a direct property
                session.AdditionalProperties["language"] = BinaryData.FromString($"\"{Language}\"");
            }

            if (!string.IsNullOrEmpty(Model))
            {
                session.Model = Model;
            }

            // Note: The following properties may need to be stored differently
            // as they might not be direct properties on VoiceLiveRequestSession

            if (NoiseReduction != null)
            {
                session.InputAudioNoiseReduction = NoiseReduction;
            }

            if (EchoCancellation != null)
            {
                session.InputAudioEchoCancellation = EchoCancellation;
            }

            // Custom vocabulary and other properties may need special handling
            // as they may not be directly supported by VoiceLiveRequestSession

            return session;
        }
    }
}
