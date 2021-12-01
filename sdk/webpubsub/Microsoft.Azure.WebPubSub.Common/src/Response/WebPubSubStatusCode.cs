// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebPubSub.Common
{
    /// <summary>
    /// A general status code for <see cref="WebPubSubEventResponse"/>.
    /// </summary>
    public enum WebPubSubStatusCode
    {
        /// <summary>
        /// Response is success.
        /// </summary>
        Success,
        /// <summary>
        /// Unauthorized error.
        /// </summary>
        Unauthorized,
        /// <summary>
        /// User error.
        /// </summary>
        UserError,
        /// <summary>
        /// Server error.
        /// </summary>
        ServerError
    }
}
