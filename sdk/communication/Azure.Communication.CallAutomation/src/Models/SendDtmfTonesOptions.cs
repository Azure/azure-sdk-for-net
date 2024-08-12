// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The SendDtmfTonesOptions operation options.
    /// </summary>
    public class SendDtmfTonesOptions
    {
        /// <summary>
        /// Creates a new SendDtmfTonesOptions object.
        /// </summary>
        /// <param name="tones"> A list of Tones to be sent. </param>
        /// <param name="targetParticipant"> The target communication identifier. </param>
        public SendDtmfTonesOptions(IEnumerable<DtmfTone> tones, CommunicationIdentifier targetParticipant)
        {
            Tones = tones.ToList().AsReadOnly();
            TargetParticipant = targetParticipant;
        }

        /// <summary>
        /// A list of Tones to be sent.
        /// </summary>
        public IList<DtmfTone> Tones { get; }

        /// <summary> The target communication identifier. </summary>
        public CommunicationIdentifier TargetParticipant { get; }

        /// <summary>
        /// The operationContext for this add participants call.
        /// </summary>
        public string OperationContext { get; set; }

        /// <summary>
        /// The callback URI to override the main callback URI.
        /// </summary>
        public Uri OperationCallbackUri { get; set; }
    }
}
