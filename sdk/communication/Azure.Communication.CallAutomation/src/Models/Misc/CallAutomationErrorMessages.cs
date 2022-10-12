// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Error messages for Call Automation.
    /// </summary>
    public static class CallAutomationErrorMessages
    {
        /// <summary>
        /// Invalid RepeatabilityHeaders message.
        /// </summary>
        public const string InvalidRepeatabilityHeadersMessage = "Invalid RepeatabilityHeaders. RepeatabilityHeaders is only valid when RepeatabilityRequestId and RepeatabilityFirstSent are set to non-default value.";
    }
}
