// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.Sms.Models
{
    /// <summary>
    /// Model factory that enables mocking for the Sms library.
    /// </summary>
    public static class SmsModelFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendSmsResponse"/> class.
        /// </summary>
        /// <param name="messageId"> The identifier of the outgoing SMS message. </param>
        public static SendSmsResponse SendSmsResponse(string messageId)
            => new SendSmsResponse(messageId);
    }
}
