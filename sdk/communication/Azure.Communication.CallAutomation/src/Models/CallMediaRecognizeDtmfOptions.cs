// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Recognize configurations specific for Dtmf.
    /// </summary>
    public class CallMediaRecognizeDtmfOptions : CallMediaRecognizeOptions
    {
        private static readonly TimeSpan _defaultInterToneTimeout = TimeSpan.FromSeconds(2);

        private IList<DtmfTone> _stopTones;

        /// <summary> Initializes a new instance of CallMediaRecognizeDtmfOptions. </summary>
        public CallMediaRecognizeDtmfOptions(CommunicationIdentifier targetParticipant, int maxTonesToCollect) : base(RecognizeInputType.Dtmf, targetParticipant)
        {
            MaxTonesToCollect = maxTonesToCollect;
        }

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
        public IList<DtmfTone> StopTones
        {
            get
            {
                _stopTones ??= new List<DtmfTone>();
                return _stopTones;
            }
            set
            {
                _stopTones = value;
            }
        }
    }
}
