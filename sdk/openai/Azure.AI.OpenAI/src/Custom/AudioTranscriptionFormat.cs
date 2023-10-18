// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.OpenAI
{
    public readonly partial struct AudioTranscriptionFormat : IEquatable<AudioTranscriptionFormat>
    {
        /// <summary>
        /// Specifies that a transcription response should provide plain, unannotated text with no additional metadata.
        /// </summary>
        [CodeGenMember("Json")]
        public static AudioTranscriptionFormat Simple { get; } = new AudioTranscriptionFormat(SimpleValue);

        /// <summary>
        /// Specifies that a transcription response should provide plain, unannotated text with additional metadata
        /// including timings, probability scores, and other processing details.
        /// </summary>
        [CodeGenMember("VerboseJson")]
        public static AudioTranscriptionFormat Verbose { get; } = new AudioTranscriptionFormat(VerboseValue);
        /// <summary> Use a response body that is plain text containing the raw, unannotated transcription. </summary>

        // (Note: text is hidden as its behavior is redundant with 'json' when using a shared, strongly-typed response
        // value container)
        [CodeGenMember("Text")]
        internal static AudioTranscriptionFormat InternalPlainText { get; } = new AudioTranscriptionFormat(InternalPlainTextValue);
    }
}
