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
        /// <param name="to"> The recipient&apos;s phone number in E.164 format. </param>
        /// <param name="messageId"> The identifier of the outgoing Sms message. Only present if message processed. </param>
        /// <param name="httpStatusCode"> HTTP Status code. </param>
        /// <param name="successful"> Indicates if the message is processed successfully or not. </param>
        /// <param name="errorMessage"> Optional error message in case of 4xx/5xx/repeatable errors. </param>
        public static SmsSendResult SmsSendResult(string to, string messageId, int httpStatusCode, bool successful, string errorMessage)
            => new(to, messageId, httpStatusCode, SmsSendResponseItemRepeatabilityResult.Accepted, successful, errorMessage);
    }
}
