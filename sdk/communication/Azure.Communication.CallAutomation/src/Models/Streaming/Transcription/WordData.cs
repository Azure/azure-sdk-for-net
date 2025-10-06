// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Serialization;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The result for each word of the phrase
    /// </summary>
    public class WordData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WordData"/> class.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="offset"></param>
        /// <param name="duration"></param>
        internal WordData(string text, long offset, long duration)
        {
            Text = text;
            Offset = TimeSpan.FromTicks(offset);
            Duration = TimeSpan.FromTicks(duration);
        }

        /// <summary>
        /// Text in the phrase.
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; }
        /// <summary>
        /// The word's position within the phrase.
        /// </summary>
        [JsonPropertyName("offset")]
        public TimeSpan Offset { get; }

        /// <summary>
        /// Duration in ticks. 1 tick = 100 nanoseconds.
        /// </summary>
        [JsonPropertyName("duration")]
        public TimeSpan Duration { get; }
    }
}
