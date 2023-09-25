// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.OpenAI
{
    public partial class AudioTranscription
    {
        // CUSTOM CODE NOTE: included to demote visibility of 'task'

        /// <summary> The label that describes which operation type generated the accompanying response data. </summary>
        internal AudioTaskLabel? InternalAudioTaskLabel { get; }
    }
}
