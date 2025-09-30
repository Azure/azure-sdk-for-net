// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.VoiceLive
{
    /// <summary> Base for session configuration in the response. </summary>
    public partial class VoiceLiveSessionResponse
    {
        /// <summary> The agent configuration for the session, if applicable. </summary>
        internal RespondingAgentOptions Agent { get; }

        /// <summary>
        /// Gets or sets the Voice.
        /// </summary>
        public VoiceProvider Voice { get; }

        /// <summary>
        /// Gets or sets the maximum number of tokens to generate in the response.
        /// </summary>
        public MaxResponseOutputTokensOption MaxResponseOutputTokens { get;}

        /// <summary>
        /// Gets or sets the tool choice strategy for response generation.
        /// </summary>
        public ToolChoiceOption ToolChoice { get; }

        [CodeGenMember("TurnDetection")]
        private BinaryData _turnDetection;

        /// <summary>
        /// Gets or sets the TurnDetection.
        /// </summary>
        public TurnDetection TurnDetection
        {
            get
            {
                var tdAsString = _turnDetection?.ToString();
                if (string.IsNullOrEmpty(tdAsString))
                {
                    return null;
                }
                else if ("null" == tdAsString.ToLower(System.Globalization.CultureInfo.InvariantCulture))
                {
                    return new NoTurnDetection();
                }
                else
                {
                    using (JsonDocument document = JsonDocument.Parse(_turnDetection))
                    {
                        return TurnDetection.DeserializeTurnDetection(document.RootElement, new ModelReaderWriterOptions("J"));
                    }
                }
            }
        }
    }
}
