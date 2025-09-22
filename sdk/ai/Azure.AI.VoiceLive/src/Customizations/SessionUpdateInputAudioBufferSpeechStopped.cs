// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.VoiceLive
{
    /// <summary> The SessionUpdateInputAudioBufferSpeechStopped. </summary>
    public partial class SessionUpdateInputAudioBufferSpeechStopped
    {
        /// <summary>
        /// Time from the start of all audio written to the buffer during the
        /// session when speech was first detected. This will correspond to the
        /// beginning of audio sent to the model, and thus includes the
        /// `prefix_padding_ms` configured in the Session.
        /// </summary>
        public TimeSpan AudioEnd { get => TimeSpan.FromMilliseconds(AudioEndMs); }

        internal int AudioEndMs { get; }
    }
}
