// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallingServer.Models
{
    /// <summary> Options for playing audio. </summary>
    public class PlayAudioOptions
    {
        /// <summary> The flag indicating whether audio file needs to be played in loop or not. </summary>
        public bool Loop { get; set; }

        /// <summary> The value to identify context of the operation. </summary>
        public string OperationContext { get; set; }

        /// <summary> An id for the media in the AudioFileUri, using which we cache the media resource. </summary>
        public string AudioFileId { get; set; }

        /// <summary> The callback Uri to receive PlayAudio status notifications. This is used only for out-call operations. </summary>
        public Uri CallbackUri { get; set; }
    }
}
