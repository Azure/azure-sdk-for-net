// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.WebPubSub.Clients
{
    /// <summary>
    /// The message representing an invoke response from the service.
    /// </summary>
    public class InvokeResponseMessage : WebPubSubMessage
    {
        /// <summary>
        /// The invocation ID that this response is for.
        /// </summary>
        public string InvocationId { get; }

        /// <summary>
        /// Indicates whether the invocation was successful.
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// Type of the data
        /// </summary>
        public WebPubSubDataType? DataType { get; }

        /// <summary>
        /// The data content
        /// </summary>
        public BinaryData Data { get; }

        /// <summary>
        /// Error details if the invocation failed.
        /// </summary>
        public InvokeResponseError Error { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvokeResponseMessage"/> class.
        /// </summary>
        /// <param name="invocationId">The invocation id</param>
        /// <param name="success">Whether the invocation succeeded</param>
        /// <param name="dataType">Type of the data</param>
        /// <param name="data">The data content</param>
        /// <param name="error">Error details if the invocation failed</param>
        public InvokeResponseMessage(string invocationId, bool success, WebPubSubDataType? dataType, BinaryData data, InvokeResponseError error)
        {
            InvocationId = invocationId;
            Success = success;
            DataType = dataType;
            Data = data;
            Error = error;
        }
    }
}
