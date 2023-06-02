// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;

namespace Microsoft.Azure.Functions.Worker
{
    /// <summary>
    /// Message data type.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WebPubSubDataType
    {
        /// <summary>
        /// binary of content type application/octet-stream.
        /// </summary>
        Binary,
        /// <summary>
        /// json of content type application/json.
        /// </summary>
        Json,
        /// <summary>
        /// text of content type text/plain.
        /// </summary>
        Text
    }
}
