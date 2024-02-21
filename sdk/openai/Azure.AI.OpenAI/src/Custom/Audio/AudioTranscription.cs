// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.OpenAI;

public partial class AudioTranscription
{
    // CUSTOM CODE NOTE:
    // Mark the `task` property as internal. Its purpose is to identify the type of task that
    // yielded this result, i.e. transcription or translation. In C#, this is redundant because we
    // have strongly-typed classes for both.

    /// <summary> The label that describes which operation type generated the accompanying response data. </summary>
    internal AudioTaskLabel? InternalAudioTaskLabel { get; }
}
