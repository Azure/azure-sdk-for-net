// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Response for errors.
    /// </summary>
    public class ErrorResponse : ServiceResponse
    {
        /// <summary>
        /// Error code.
        /// </summary>
        public WebPubSubErrorCode Code { get; set; }

        /// <summary>
        /// Error messages.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// ctor.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public ErrorResponse(WebPubSubErrorCode code, string message = null)
        {
            Code = code;
            ErrorMessage = message;
        }
    }
}
