// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.OpenAI;

public partial class AudioTranslation
{
    // CUSTOM CODE NOTE: this is here purely to demote the visibility of task labels to internal.

    /// <summary> The label that describes which operation type generated the accompanying response data. </summary>
    internal AudioTaskLabel? InternalAudioTaskLabel { get; }
}
