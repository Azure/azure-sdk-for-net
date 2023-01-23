// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for the Mute All Participants Request.
    /// </summary>
    public class MuteAllParticipantsOptions
    {
        /// <summary>
        /// Creates a new MuteAllParticipantsOptions object.
        /// </summary>
        public MuteAllParticipantsOptions()
        {
            RepeatabilityHeaders = new RepeatabilityHeaders();
        }

        /// <summary>
        /// The identity of participant that started the request.
        /// This participant won't be muted from the call.
        /// </summary>
        public CommunicationIdentifier RequestInitiator { get; set; }

        /// <summary>
        /// The operation context.
        /// </summary>
        public string OperationContext { get; set; }

        /// <summary>
        /// Repeatability Headers.
        /// </summary>
        public RepeatabilityHeaders RepeatabilityHeaders { get; set; }
    }
}
