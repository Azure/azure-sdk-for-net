// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.VoiceLive
{
    /// <summary> The SessionUpdateInputAudioBufferSpeechStarted. </summary>
    public partial class SessionUpdateInputAudioBufferSpeechStarted
    {
        /// <summary>
        /// Time from the start of all audio written to the buffer during the
        /// session when speech was first detected. This will correspond to the
        /// beginning of audio sent to the model, and thus includes the
        /// `prefix_padding_ms` configured in the Session.
        /// </summary>
        public TimeSpan AudioStart { get => TimeSpan.FromMilliseconds(AudioStartMs); }

        internal int AudioStartMs { get; }
    }
}
