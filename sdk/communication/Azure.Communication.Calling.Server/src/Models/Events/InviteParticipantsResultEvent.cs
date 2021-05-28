// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.Communication.Calling.Server
{
    /// <summary>
    /// The invited participants result event.
    /// </summary>
    public partial class InviteParticipantsResultEvent : CallEventBase
    {
        /// <summary>
        /// The event type.
        /// </summary>
        public const string EventType = "Microsoft.Communication.InviteParticipantResult";

        /// <summary>
        /// The result info.
        /// </summary>
        public ResultInfoInternal ResultInfo { get; set; }

        /// <summary>
        /// The operation context.
        /// </summary>
        public string OperationContext { get; set; }

        /// <summary>
        /// The status of the operation.
        /// </summary>
        public OperationStatusModel Status { get; set; }

        /// <summary>
        /// The call leg Id .
        /// </summary>
        public string CallLegId { get; set; }

        /// <summary> Initializes a new instance of <see cref="InviteParticipantsResultEvent"/>. </summary>
        /// <param name="resultInfo"> The result info. </param>
        /// <param name="operationContext"> The operation context. </param>
        /// <param name="status"> The status. </param>
        /// <param name="callLegId"> The call leg id. </param>
        public InviteParticipantsResultEvent(ResultInfoInternal resultInfo, string operationContext, OperationStatusModel status, string callLegId)
        {
            ResultInfo = resultInfo;
            OperationContext = operationContext;
            Status = status;
            CallLegId = callLegId;
        }
    }
}
