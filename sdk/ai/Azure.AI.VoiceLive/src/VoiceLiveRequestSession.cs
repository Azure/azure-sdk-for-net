// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.VoiceLive
{
    /// <summary> The VoiceLiveRequestSession. </summary>
    public partial class RequestSession
    {
        /// <summary>
        /// Serialized additional properties for the request session
        /// </summary>
        internal IDictionary<string, BinaryData> AdditionalProperties => this._additionalBinaryDataProperties;

        [CodeGenMember("Voice")]
        private BinaryData _serviceVoice;

        /// <summary>
        /// Gets or sets the Voice.
        /// </summary>
        public VoiceProvider Voice
        {
            get
            {
                if (_serviceVoice == null)
                {
                    return null;
                }
                return _serviceVoice.ToObjectFromJson<VoiceProvider>();
            }
            set
            {
                if (value == null)
                {
                    _serviceVoice = null;
                }
                else
                {
                    _serviceVoice = value.ToBinaryData();
                }
            }
        }

        [CodeGenMember("MaxResponseOutputTokens")]
        private BinaryData _maxResponseOutputTokens;

        /// <summary>
        /// Gets or sets the maximum number of tokens to generate in the response.
        /// </summary>
        public int? MaxResponseOutputTokens
        {
            get => _maxResponseOutputTokens.ToObjectFromJson<int?>();
            set => _maxResponseOutputTokens = BinaryData.FromObjectAsJson(value);
        }

        [CodeGenMember("ToolChoice")]
        private BinaryData _toolChoice;

        /// <summary>
        /// Gets or sets the tool choice strategy for response generation.
        /// </summary>
        public string ToolChoice
        {
            get => _toolChoice.ToObjectFromJson<string>();
            set => _toolChoice = BinaryData.FromObjectAsJson(value);
        }
    }
}
