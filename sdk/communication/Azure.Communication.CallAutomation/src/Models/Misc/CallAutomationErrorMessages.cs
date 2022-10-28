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

        /// <summary>
        /// Error message for null CallerId in CreateCallOptions.
        /// </summary>
        public const string CreateCallOptionsNullCallerId = "CallSource.CallerId should be specified in CreateCallOptions when calling PSTN number.";

        /// <summary>
        /// Error message for null SourceCallerId in AddParticipantsOptions.
        /// </summary>
        public const string AddParticipantsOptionsNullSourceCallerId = "SourceCallerId should be specified in AddParticipantsOptions when adding PSTN participants.";

        /// <summary>
        /// Error message for null SourceCallerId in TransferToParticipantOptions.
        /// </summary>
        public const string TransferToParticipantOptionsNullSourceCallerId = "SourceCallerId should be specified in TransferToParticipantOptions when transferring the call to a PSTN target";

        /// <summary>
        /// Invalid Https Uri message.
        /// </summary>
        public const string InvalidHttpsUriMessage = "Callback Uri has to be in well-formed, valid https format.";

        /// <summary>
        /// Invalid InvitationTimeoutInSeconds message.
        /// </summary>
        public const string InvalidInvitationTimeoutInSeconds = "InvitationTimeoutInSeconds has to be between 1 and 180 seconds.";
    }
}
