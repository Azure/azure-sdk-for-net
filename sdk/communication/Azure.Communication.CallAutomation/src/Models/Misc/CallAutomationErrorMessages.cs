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
        /// Invalid Callback Https Uri message.
        /// </summary>
        public const string InvalidHttpsUriMessage = "Callback Uri has to be in well-formed, valid https format.";

        /// <summary>
        /// Invalid Custom Cognitive service Https Uri message.
        /// </summary>
        public const string InvalidCognitiveServiceHttpsUriMessage = "Cognitive Service Uri has to be in well-formed, valid https format.";

        /// <summary>
        /// Invalid InvitationTimeoutInSeconds message.
        /// </summary>
        public const string InvalidInvitationTimeoutInSeconds = "InvitationTimeoutInSeconds has to be between 1 and 180 seconds.";

        /// <summary>
        /// UserToUserInformation exceeds max length message.
        /// </summary>
        public const string UserToUserInformationExceedsMaxLength = "UserToUserInformation exceeds maximum string length of 5000.";

        /// <summary>
        /// OperationContext exceeds max length message.
        /// </summary>
        public const string OperationContextExceedsMaxLength = "OperationContext exceeds maximum string length of 5000.";
    }
}
