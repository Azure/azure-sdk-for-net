// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Azure.Communication.CallAutomation.Models.Transcription
{
    internal class Word
    {
        /// <summary>
        /// Text in the phrase.
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }
        /// <summary>
        /// The word's position within the phrase.
        /// </summary>
        [JsonPropertyName("offset")]
        public ulong Offset { get; set; }
    }
}
