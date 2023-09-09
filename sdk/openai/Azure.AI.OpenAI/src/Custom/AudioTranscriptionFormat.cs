// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.OpenAI
{
    public readonly partial struct AudioTranscriptionFormat : IEquatable<AudioTranscriptionFormat>
    {
        /// <summary> Use a response body that is a JSON object containing a single 'text' field for the transcription. </summary>
        [CodeGenMember("Json")]
        public static AudioTranscriptionFormat SimpleJson { get; } = new AudioTranscriptionFormat(SimpleJsonValue);

        /// <summary>
        /// Use a response body that is a JSON object containing transcription text along with timing, segments, and other
        /// metadata.
        /// </summary>
        [CodeGenMember("VerboseJson")]
        public static AudioTranscriptionFormat VerboseJson { get; } = new AudioTranscriptionFormat(VerboseJsonValue);
        /// <summary> Use a response body that is plain text containing the raw, unannotated transcription. </summary>

        /// <summary>
        /// Use a response body that is plain text containing the raw, unannotated transcription.
        /// </summary>
        [CodeGenMember("Text")]
        public static AudioTranscriptionFormat PlainText{ get; } = new AudioTranscriptionFormat(PlainTextValue);

        [CodeGenMember("Srt")]
        public static AudioTranscriptionFormat SubRipText { get; } = new AudioTranscriptionFormat(SubRipTextValue);
        /// <summary> Use a response body is plain text in Web Video Text Tracks (VTT) format that also includes timing information. </summary>

        [CodeGenMember("Vtt")]
        public static AudioTranscriptionFormat WebVideoTextTracksText { get; } = new AudioTranscriptionFormat(WebVideoTextTracksTextValue);
    }
}
