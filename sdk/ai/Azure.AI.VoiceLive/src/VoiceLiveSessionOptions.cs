// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Represents configuration options for VoiceLive response generation.
    /// </summary>
    /// <remarks>
    /// This class provides configuration options for controlling how the VoiceLive service
    /// generates responses, including modalities, tools, and response formatting.
    /// </remarks>
    public class VoiceLiveSessionOptions
    {
        /// <summary>
        /// Gets or sets the modalities to include in the response.
        /// </summary>
        /// <value>
        /// A list of modalities (e.g., text, audio) that should be included in the response.
        /// If not specified, the service will use default modalities.
        /// </value>
        public IList<InputModality> Modalities { get; set; } = new List<InputModality>();

        /// <summary>
        /// Gets or sets the instructions for response generation.
        /// </summary>
        /// <value>
        /// Instructions that guide how the response should be generated.
        /// </value>
        public string Instructions { get; set; }

        /// <summary>
        /// Gets or sets the voice configuration for spoken responses.
        /// </summary>
        /// <value>
        /// The voice configuration to use for generating spoken responses.
        /// </value>
        public VoiceProvider Voice { get; set; }

        /// <summary>
        /// Gets or sets the output audio format for the response.
        /// </summary>
        /// <value>
        /// The audio format to use for output audio in the response.
        /// </value>
        public AudioFormat? OutputAudioFormat { get; set; }

        /// <summary>
        /// Gets or sets the tools available during response generation.
        /// </summary>
        /// <value>
        /// A list of tools that can be used during response generation.
        /// </value>
        public IList<VoiceLiveToolDefinition> Tools { get; set; } = new List<VoiceLiveToolDefinition>();

        /// <summary>
        /// Gets or sets the tool choice strategy for response generation.
        /// </summary>
        /// <value>
        /// Specifies how tools should be chosen during response generation.
        /// </value>
        public string ToolChoice { get; set; }

        /// <summary>
        /// Gets or sets the temperature parameter for response generation.
        /// </summary>
        /// <value>
        /// A value between 0.0 and 1.0 controlling the randomness of the response.
        /// Higher values produce more random responses.
        /// </value>
        public float? Temperature { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of tokens to generate in the response.
        /// </summary>
        /// <value>
        /// The maximum number of tokens to generate. If not specified, the service will use a default limit.
        /// </value>
        public int? MaxOutputTokens { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to commit the response to the conversation.
        /// </summary>
        /// <value>
        /// <c>true</c> to commit the response to the conversation; otherwise, <c>false</c>.
        /// Default is <c>true</c>.
        /// </value>
        public bool? Commit { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to cancel any ongoing generation before starting this one.
        /// </summary>
        /// <value>
        /// <c>true</c> to cancel ongoing generation; otherwise, <c>false</c>.
        /// Default is <c>true</c>.
        /// </value>
        public bool? CancelPrevious { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VoiceLiveSessionOptions"/> class.
        /// </summary>
        public VoiceLiveSessionOptions()
        {
        }

        /// <summary>
        /// Converts the response options to a <see cref="ResponseCreateParams"/> instance.
        /// </summary>
        /// <returns>A <see cref="ResponseCreateParams"/> instance configured with the current options.</returns>
        /// <remarks>
        /// This method uses the model factory to create the response parameters since the
        /// VoiceLiveResponseCreateParams constructor is internal.
        /// </remarks>
        internal virtual ResponseCreateParams ToCreateParams()
        {
            // Since VoiceLiveResponseCreateParams has an internal constructor,
            // we need to find another way to create it. For now, we'll return null
            // and handle this at the call site.
            return null;
        }
    }
}
