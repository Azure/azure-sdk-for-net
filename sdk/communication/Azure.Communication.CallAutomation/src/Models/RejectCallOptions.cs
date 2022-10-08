// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The reject call operation options.
    /// </summary>
    public class RejectCallOptions
    {
        /// <summary>
        /// Creates a new RejectCallOptions object.
        /// </summary>
        /// <param name="incomingCallContext"></param>
        /// <param name="callRejectReason"></param>
        public RejectCallOptions(string incomingCallContext, CallRejectReason callRejectReason)
        {
            IncomingCallContext = incomingCallContext;
            CallRejectReason = callRejectReason;
        }

        /// <summary>
        /// The context associated with the call.
        /// </summary>
        public string IncomingCallContext { get; }

        /// <summary>
        /// The reason for rejecting call.
        /// </summary>
        public CallRejectReason CallRejectReason { get; }

        /// <summary>
        /// Repeatability Headers.
        /// </summary>
        public RepeatabilityHeaders RepeatabilityHeaders { get; set; } = new RepeatabilityHeaders(Guid.NewGuid(), DateTimeOffset.UtcNow);
    }
}
