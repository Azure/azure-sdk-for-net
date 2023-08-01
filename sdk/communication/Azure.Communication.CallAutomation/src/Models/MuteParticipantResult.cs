// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System;
using System.Threading.Tasks;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// MuteParticipantResult Result.
    /// </summary>
    public class MuteParticipantResult
    {
        /// <summary> Initializes a new instance of MuteParticipantResult. </summary>
        /// <param name="operationContext"> The operation context provided by client. </param>
        internal MuteParticipantResult(string operationContext)
        {
            OperationContext = operationContext;
        }

        /// <summary> Initializes a new instance of MuteParticipantResult. </summary>
        /// <param name="muteParticipantsResultInternal"> The internal mute participants result.</param>
        internal MuteParticipantResult(MuteParticipantsResult muteParticipantsResultInternal)
        {
            OperationContext = muteParticipantsResultInternal.OperationContext;
        }

        /// <summary> The operation context provided by client. </summary>
        public string OperationContext { get; }
    }
}
