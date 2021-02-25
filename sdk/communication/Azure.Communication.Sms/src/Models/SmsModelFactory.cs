// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.Sms.Models
{
    /// <summary>
    /// Model factory that enables mocking for the Sms library.
    /// </summary>
    public static class SmsModelFactory
    {
        /// <summary> Initializes a new instance of SmsSendResult. </summary>
        /// <param name="to"> The recipients&apos;s phone number in E.164 format. </param>
        /// <param name="messageId"> The identifier of the outgoing SMS message. Only present if message processed. </param>
        /// <param name="httpStatusCode"> HTTP Status code. </param>
        /// <param name="repeatabilityResult">The result of a repeatable request with one of the case-insensitive values accepted or rejected. </param>
        /// <param name="succeeded"> Flag to check if message processing succeeded or not. </param>
        /// <param name="errorMessage"> Optional error message in case of 4xx or 5xx errors. </param>
        public static SmsSendResult SmsSendResult(string to, string messageId, int httpStatusCode, SmsSendResponseItemRepeatabilityResult? repeatabilityResult, bool succeeded, string errorMessage)
            => new SmsSendResult(to, messageId, httpStatusCode, repeatabilityResult, succeeded, errorMessage);
    }
}
