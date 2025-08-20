// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.Communication.CallAutomation
{
    internal class MarkAudioInternal
    {
        /// <summary>
        /// The sequence of the mark audio.
        /// </summary>
        [JsonPropertyName("sequence")]
        public string Sequence { get; set; }
    }
}
