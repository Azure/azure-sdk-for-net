// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.Sms.Models
{
    /// <summary> The OptOutCheckResponseItem represents the response for Check opt-out operations. </summary>
    public partial class OptOutCheckResponseItem
    {
        /// <summary> Initializes a new instance of <see cref="OptOutCheckResponseItem"/>. </summary>
        /// <param name="to"> The recipient phone number (in E.164 format). </param>
        /// <param name="httpStatusCode"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="to"/> is null. </exception>
        internal OptOutCheckResponseItem(string to, int httpStatusCode)
        {
            Argument.AssertNotNull(to, nameof(to));

            To = to;
            HttpStatusCode = httpStatusCode;
        }

        /// <summary> Initializes a new instance of <see cref="OptOutCheckResponseItem"/>. </summary>
        /// <param name="to"> The recipient phone number (in E.164 format). </param>
        /// <param name="httpStatusCode"></param>
        /// <param name="isOptedOut"> Optional flag specifying if number was Opted Out from receiving messages. </param>
        /// <param name="errorMessage"> Optional error message in case of 4xx/5xx errors. </param>
        internal OptOutCheckResponseItem(string to, int httpStatusCode, bool? isOptedOut, string errorMessage)
        {
            To = to;
            HttpStatusCode = httpStatusCode;
            IsOptedOut = isOptedOut;
            ErrorMessage = errorMessage;
        }

        /// <summary> The recipient phone number (in E.164 format). </summary>
        public string To { get; }
        /// <summary> Gets the http status code. </summary>
        public int HttpStatusCode { get; }
        /// <summary> Optional flag specifying if number was Opted Out from receiving messages. </summary>
        public bool? IsOptedOut { get; }
        /// <summary> Optional error message in case of 4xx/5xx errors. </summary>
        public string ErrorMessage { get; }
    }
}
