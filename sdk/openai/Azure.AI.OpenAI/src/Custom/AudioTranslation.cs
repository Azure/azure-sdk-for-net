// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.OpenAI
{
    /// <summary> Result information for an operation that translated spoken audio into written text. </summary>
    public partial class AudioTranslation
    {
        /// <summary> The label that describes which operation type generated the accompanying response data. </summary>
        internal AudioTaskLabel? InternalAudioTaskLabel { get; }
    }
}
