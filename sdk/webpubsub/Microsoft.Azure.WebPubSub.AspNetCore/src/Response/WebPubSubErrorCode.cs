// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Response Error Code.
    /// </summary>
    public enum WebPubSubErrorCode
    {
        /// <summary>
        /// Unauthorized.
        /// </summary>
        Unauthorized,
        /// <summary>
        /// User Error.
        /// </summary>
        UserError,
        /// <summary>
        /// Server Error.
        /// </summary>
        ServerError
    }
}
