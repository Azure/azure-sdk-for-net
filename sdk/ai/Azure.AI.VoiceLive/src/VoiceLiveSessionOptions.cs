// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Represents configuration options for a VoiceLive session.
    /// </summary>
    /// <remarks>
    /// This class provides a base set of configuration options that can be used to customize
    /// the behavior of a VoiceLive session.
    /// </remarks>
    public class VoiceLiveSessionOptions
    {
        /// <summary>
        /// Gets or sets the input audio format for the session.
        /// </summary>
        /// <value>
        /// The audio format to use for input audio. If not specified, the service will use a default format.
        /// </value>
        public VoiceLiveAudioFormat? InputAudioFormat { get; set; }

        /// <summary>
        /// Gets or sets the output audio format for the session.
        /// </summary>
        /// <value>
        /// The audio format to use for output audio. If not specified, the service will use a default format.
        /// </value>
        public VoiceLiveAudioFormat? OutputAudioFormat { get; set; }

        /// <summary>
        /// Gets or sets the turn detection configuration for the session.
        /// </summary>
        /// <value>
        /// The turn detection configuration to use. If not specified, the service will use server-side VAD.
        /// </value>
        public VoiceLiveTurnDetection TurnDetection { get; set; }

        /// <summary>
        /// Gets or sets the modalities supported by the session.
        /// </summary>
        /// <value>
        /// A list of modalities that the session should support. Defaults to text and audio.
        /// </value>
        public IList<VoiceLiveModality> Modalities { get; set; } = new List<VoiceLiveModality> { VoiceLiveModality.Text, VoiceLiveModality.Audio };

        /// <summary>
        /// Gets or sets the input audio transcription settings.
        /// </summary>
        /// <value>
        /// Configuration for transcribing input audio. If not specified, transcription is disabled.
        /// </value>
        public VoiceLiveAudioInputTranscriptionSettings InputAudioTranscription { get; set; }

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

        /// <summary>
        /// Initializes a new instance of the <see cref="VoiceLiveSessionOptions"/> class.
        /// </summary>
        public VoiceLiveSessionOptions()
        {
        }

        /// <summary>
        /// Converts the session options to a <see cref="VoiceLiveRequestSession"/> instance.
        /// </summary>
        /// <returns>A <see cref="VoiceLiveRequestSession"/> instance configured with the current options.</returns>
        internal virtual VoiceLiveRequestSession ToRequestSession()
        {
            var session = new VoiceLiveRequestSession();

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

            if (Modalities != null && Modalities.Count > 0)
            {
                session.Modalities.Clear();
                foreach (var modality in Modalities)
                {
                    session.Modalities.Add(modality);
                }
            }

            if (InputAudioTranscription != null)
            {
                session.InputAudioTranscription = InputAudioTranscription;
            }

            if (Temperature.HasValue)
            {
                session.Temperature = Temperature.Value;
            }

            if (MaxResponseOutputTokens.HasValue)
            {
                session.MaxResponseOutputTokens = BinaryData.FromObjectAsJson(MaxResponseOutputTokens.Value);
            }

            return session;
        }
    }
}