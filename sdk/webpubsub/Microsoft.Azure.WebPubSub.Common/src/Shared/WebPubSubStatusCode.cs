// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebPubSub.Common
{
    /// <summary>
    /// The general enum to represent response status.
    /// DO set to Success for backward capability.
    /// Has mapping relationship to <see cref="WebPubSubErrorCode"/>.
    /// </summary>
    internal enum WebPubSubStatusCode
    {
        /// <summary>
        /// Start from -1 to make values map <see cref="WebPubSubErrorCode"/>.
        /// </summary>
        Success = -1,
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
