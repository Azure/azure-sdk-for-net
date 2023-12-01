// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.OpenAI;

public partial class AudioTranscription
{
    // CUSTOM CODE NOTE: included to demote visibility of 'task' to internal.

    internal AudioTaskLabel? InternalAudioTaskLabel { get; }
}
