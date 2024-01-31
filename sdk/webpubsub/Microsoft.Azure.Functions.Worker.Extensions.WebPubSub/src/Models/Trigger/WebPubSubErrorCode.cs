// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Microsoft.Azure.Functions.Worker
{
    /// <summary>
    /// Response Error Code.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WebPubSubErrorCode
    {
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
