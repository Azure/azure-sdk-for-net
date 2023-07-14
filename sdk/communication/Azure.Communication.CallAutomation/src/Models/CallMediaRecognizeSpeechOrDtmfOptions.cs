// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Recognize configurations specific for IVR Continuouse Speech Recognition.
    /// </summary>
    public class CallMediaRecognizeSpeechOrDtmfOptions : CallMediaRecognizeOptions
    {
        private static readonly TimeSpan _defaultInterToneTimeout = TimeSpan.FromSeconds(2);

        /// <summary> Initializes a new instance of CallMediaRecognizeSpeechOrDtmfOptions. </summary>
        public CallMediaRecognizeSpeechOrDtmfOptions(CommunicationIdentifier targetParticipant, int maxTonesToCollect) : base(RecognizeInputType.SpeechOrDtmf, targetParticipant)
        {
            EndSilenceTimeout = _defaultInterToneTimeout;
            MaxTonesToCollect = maxTonesToCollect;
            StopTones = Array.Empty<DtmfTone>();
        }

        /// <summary> The length of end silence when user stops speaking and cogservice send response. </summary>
        public TimeSpan EndSilenceTimeout { get; set; }

        /// <summary>
        /// Time to wait between DTMF inputs to stop recognizing.
        /// If not provided, a default of 2 seconds is set.
        /// </summary>
        public TimeSpan InterToneTimeout { get; set; } = _defaultInterToneTimeout;

        /// <summary>
        /// Maximum number of DTMF tones to be collected.
        /// </summary>
        public int MaxTonesToCollect { get; }

        /// <summary>
        /// List of tones that will stop recognizing.
        /// </summary>
        public IList<DtmfTone> StopTones { get; set; }
    }
}
