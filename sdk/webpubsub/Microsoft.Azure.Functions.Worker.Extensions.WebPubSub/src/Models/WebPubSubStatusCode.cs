// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Microsoft.Azure.Functions.Worker
{
    /// <summary>
    /// The general enum to represent response status.
    /// DO set to Success for backward capability.
    /// Has mapping relationship to <see cref="WebPubSubErrorCode"/>.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    internal enum WebPubSubStatusCode
    {
        /// <summary>
        /// Default success.
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
