// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.Sms.Models
{
    /// <summary> Model factory for custom models. </summary>
    public static partial class CommunicationSmsModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.OptOutCheckResponseItem"/>. </summary>
        /// <param name="to"> The recipient phone number (in E.164 format). </param>
        /// <param name="httpStatusCode"></param>
        /// <param name="isOptedOut"> Optional flag specifying if number was Opted Out from receiving messages. </param>
        /// <param name="errorMessage"> Optional error message in case of 4xx/5xx errors. </param>
        /// <returns> A new <see cref="Models.OptOutCheckResponseItem"/> instance for mocking. </returns>
        public static OptOutCheckResponseItem OptOutCheckResponseItem(string to = null, int httpStatusCode = default, bool? isOptedOut = null, string errorMessage = null)
        {
            return new OptOutCheckResponseItem(to, httpStatusCode, isOptedOut, errorMessage);
        }

        /// <summary> Initializes a new instance of <see cref="Models.OptOutOperationResponseItem"/>. </summary>
        /// <param name="to"> The recipient phone number (in E.164 format). </param>
        /// <param name="httpStatusCode"></param>
        /// <param name="errorMessage"> Optional error message in case of 4xx/5xx errors. </param>
        /// <returns> A new <see cref="Models.OptOutOperationResponseItem"/> instance for mocking. </returns>
        public static OptOutOperationResponseItem OptOutOperationResponseItem(string to = null, int httpStatusCode = default, string errorMessage = null)
        {
            return new OptOutOperationResponseItem(to, httpStatusCode, errorMessage);
        }
    }
}
