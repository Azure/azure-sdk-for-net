// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.Communication.Calling.Server
{
    /// <summary>
    /// The invited participants result event.
    /// </summary>
    public class InviteParticipantsResultEvent
    {
        /// <summary>
        /// The event type.
        /// </summary>
        public const string EventType = "Microsoft.Communication.InviteParticipantResult";

        /// <summary>
        /// The result details.
        /// </summary>
        public ResultInfo ResultInfo { get; set; }

        /// <summary>
        /// The operation context.
        /// </summary>
        public string OperationContext { get; set; }

        /// <summary>
        /// The status of the operation.
        /// </summary>
        public OperationStatus Status { get; set; }

        /// <summary>
        /// The call leg Id .
        /// </summary>
        public string CallLegId { get; set; }

        /// <summary>
        /// The invited participants.
        /// </summary>
        public IEnumerable<CommunicationIdentifier> Participants { get; set; }
    }
}
