// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The ContinuousDtmfRecognitionOptions operation options.
    /// </summary>
    public class ContinuousDtmfRecognitionOptions
    {
        /// <summary>
        /// Creates a new SendDtmfOptions object.
        /// </summary>
        /// <param name="targetParticipant"> The target communication identifier. </param>
        public ContinuousDtmfRecognitionOptions(CommunicationIdentifier targetParticipant)
        {
            TargetParticipant = targetParticipant;
        }

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
