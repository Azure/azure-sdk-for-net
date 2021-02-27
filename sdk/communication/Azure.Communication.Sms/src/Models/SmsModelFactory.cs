// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.Sms.Models
{
    /// <summary>
    /// Model factory that enables mocking for the Sms library.
    /// </summary>
    public static class SmsModelFactory
    {
        /// <summary> Initializes a new instance of SmsSendResult. </summary>
        /// <param name="to"> The recipient&apos;s phone number in E.164 format. </param>
        /// <param name="httpStatusCode"> HTTP Status code. </param>
        /// <param name="successful"> Indicates if the message is processed successfully or not. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="to"/> is null. </exception>
        public static SmsSendResult SmsSendResult(string to, int httpStatusCode, bool successful)
            => new SmsSendResult(to, httpStatusCode, successful);
    }
}
