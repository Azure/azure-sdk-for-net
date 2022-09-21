// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation.Models
{
    /// <summary>
    /// Failure Reasons for the upcoming webhook Events.
    /// </summary>
    public enum FailureReason
    {
        /// <summary>
        /// Action failed, initial silence timeout reached.
        /// </summary>
        InitialSilenceTimeout = 8510,

        /// <summary>
        /// Action failed, inter-digit silence timeout reached.
        /// </summary>
        InterDigitTimeout = 8532,

        /// <summary>
        /// Action failed, encountered failure while trying to play the prompt.
        /// </summary>
        PlayPromptFailed = 8511,

        /// <summary>
        /// Unknown internal server error.
        /// </summary>
        UspecifiedError = 9999
    }
}
