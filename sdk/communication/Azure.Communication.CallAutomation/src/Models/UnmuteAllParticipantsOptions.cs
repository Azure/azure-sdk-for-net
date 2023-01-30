// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for the Unmute All Participants Request.
    /// </summary>
    public class UnmuteAllParticipantsOptions
    {
        /// <summary>
        /// Creates a new UnmuteAllParticipantsOptions object.
        /// </summary>
        public UnmuteAllParticipantsOptions()
        {
            RepeatabilityHeaders = new RepeatabilityHeaders();
        }

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
