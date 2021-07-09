// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallingServer
{
    /// <summary> Options for playing audio. </summary>
    public class PlayAudioOptions
    {
        /// <summary>
        /// The media resource uri of the play audio request.
        /// Currently only Wave file (.wav) format audio prompts are supported.
        /// More specifically, the audio content in the wave file must be mono (single-channel),
        /// 16-bit samples with a 16,000 (16KHz) sampling rate.
        /// </summary>
        public Uri AudioFileUri { get; set; }

        /// <summary> The flag indicating whether audio file needs to be played in loop or not. </summary>
        public bool? Loop { get; set; }

        /// <summary> The value to identify context of the operation. </summary>
        public string OperationContext { get; set; }

        /// <summary> An id for the media in the AudioFileUri, using which we cache the media resource. </summary>
        public string AudioFileId { get; set; }

        /// <summary> The callback Uri to receive PlayAudio status notifications. </summary>
        public Uri CallbackUri { get; set; }
    }
}
