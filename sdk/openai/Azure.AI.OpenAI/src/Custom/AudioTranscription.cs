// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.OpenAI
{
    /// <summary> Transcription response. </summary>
    public partial class AudioTranscription
    {
        internal AudioTranscriptionTask? Task { get; set; }
    }
}
