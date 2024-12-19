// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    [CodeGenModel("PlayOptions")]
    internal partial class PlayOptionsInternal
    {
        /// <summary> Initializes a new instance of <see cref="PlayOptionsInternal"/>. </summary>
        /// <param name="loop"> The option to play the provided audio source in loop when set to true. </param>
        /// <param name="interruptCallMediaOperation"> If set play can barge into other existing queued-up/currently-processing requests. </param>
        /// <param name="interruptHoldAudio"> If set, hold audio will be interrupted, then this request will be played, and then the hold audio will be resumed. </param>
        internal PlayOptionsInternal(bool loop, bool? interruptCallMediaOperation, bool? interruptHoldAudio)
        {
            Loop = loop;
            InterruptCallMediaOperation = interruptCallMediaOperation;
            InterruptHoldAudio = interruptHoldAudio;
        }
        /// <summary> If set, hold audio will be interrupted, then this request will be played, and then the hold audio will be resumed. </summary>
        public bool? InterruptHoldAudio { get; set; }
    }
}
