// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// User message event request.
    /// </summary>
    public sealed class MessageEventRequest : ServiceRequest
    {
        /// <summary>
        /// Message content.
        /// </summary>
        public BinaryData Message { get; }

        /// <summary>
        /// Message data type.
        /// </summary>
        public MessageDataType DataType { get; }

        /// <summary>
        /// Name of the request.
        /// </summary>
        public override string Name => nameof(MessageEventRequest);

        internal MessageEventRequest(ConnectionContext connectionContext, BinaryData message, MessageDataType dataType)
            : base(connectionContext)
        {
            Message = message;
            DataType = dataType;
        }
    }
}
