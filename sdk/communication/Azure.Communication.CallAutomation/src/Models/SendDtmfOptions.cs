// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Send Dtmf configurations.
    /// </summary>
    public class SendDtmfOptions
    {
        /// <summary> Initializes a new instance of SendDtmfOptions. </summary>
        public SendDtmfOptions(CommunicationIdentifier targetParticipant, IReadOnlyList<DtmfTone> tones)
        {
            Tones = tones;
            TargetParticipant = targetParticipant;
        }

        /// <summary>
        /// Target participant of Send Dtmf.
        /// </summary>
        public CommunicationIdentifier TargetParticipant { get; }

        /// <summary>
        /// List of Dtmf tones to be sent
        /// </summary>
        public IReadOnlyList<DtmfTone> Tones { get; set; }
    }
}
