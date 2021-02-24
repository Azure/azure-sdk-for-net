// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging
{
    /// <summary>
    /// Specifies the format that the data of a <see cref="CloudEvent"/> should be sent in
    /// when using the JSON envelope format for a <see cref="CloudEvent"/>.
    /// <see href="https://github.com/cloudevents/spec/blob/v1.0/json-format.md#31-handling-of-data"/>.
    /// </summary>
    public enum CloudEventDataFormat
    {
        /// <summary>
        /// Indicates the <see cref="CloudEvent.Data"/> should be serialized as binary data.
        /// This data will be included as a Base64 encoded string in the "data_base64"
        /// field of the JSON payload.
        /// </summary>
        Binary = 0,

        /// <summary>
        /// Indicates the <see cref="CloudEvent.Data"/> should be serialized as JSON.
        /// The data will be included in the "data" field of the JSON payload.
        /// </summary>
        Json = 1,
    }
}
