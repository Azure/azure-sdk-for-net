// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.VoiceLive
{
    /// <summary> The VoiceLiveRequestSession. </summary>
    public partial class VoiceLiveSessionOptions
    {
        /// <summary>
        /// Serialized additional properties for the request session
        /// </summary>
        internal IDictionary<string, BinaryData> AdditionalProperties => this._additionalBinaryDataProperties;

        private BinaryData VoiceInternal;

        /// <summary>
        /// Gets or sets the Voice.
        /// </summary>
        public VoiceProvider Voice
        {
            get
            {
                if (VoiceInternal == null)
                {
                    return null;
                }

                var s = VoiceInternal.ToString();

                return null;
            }
            set
            {
                if (value == null)
                {
                    VoiceInternal = null;
                }
                else
                {
                    VoiceInternal = value.ToBinaryData();
                }
            }
        }

        [CodeGenMember("MaxResponseOutputTokens")]
        private BinaryData _maxResponseOutputTokens;

        /// <summary>
        /// Gets or sets the maximum number of tokens to generate in the response.
        /// </summary>
        public MaxResponseOutputTokensOption MaxResponseOutputTokens
        {
            get => MaxResponseOutputTokensOption.FromBinaryData(_maxResponseOutputTokens);
            set
            {
                var persistable = value as IPersistableModel<MaxResponseOutputTokensOption>;
                _maxResponseOutputTokens = persistable?.Write(new ModelReaderWriterOptions("J")) ?? null;
            }
        }

        [CodeGenMember("ToolChoice")]
        private BinaryData _toolChoice;

        /// <summary>
        /// Gets or sets the tool choice strategy for response generation.
        /// </summary>
        public ToolChoiceOption ToolChoice
        {
            get => ToolChoiceOption.FromBinaryData(_toolChoice);
            set
            {
                var persistable = value as IPersistableModel<ToolChoiceOption>;
                _toolChoice = persistable?.Write(new ModelReaderWriterOptions("J")) ?? null;
            }
        }

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
            set
            {
                if (value.Type == new TurnDetectionType("None"))
                {
                    _turnDetection = BinaryData.FromString(" null");
                }
                else
                {
                    var persist = value as IPersistableModel<TurnDetection>;
                    _turnDetection = persist.Write(new ModelReaderWriterOptions("J"));
                }
            }
        }
    }
}
