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
        public RejectCallOptions(string incomingCallContext)
        {
            IncomingCallContext = incomingCallContext;
            RepeatabilityHeaders = new RepeatabilityHeaders();
        }

        /// <summary>
        /// The context associated with the call.
        /// </summary>
        public string IncomingCallContext { get; }

        /// <summary>
        /// The reason for rejecting call.
        /// </summary>
        public CallRejectReason CallRejectReason { get; set; } = CallRejectReason.None;

        /// <summary>
        /// Repeatability Headers.
        /// </summary>
        public RepeatabilityHeaders RepeatabilityHeaders { get; set; }
    }
}
