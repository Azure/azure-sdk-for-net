// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Response for message events.
    /// </summary>
    public class MessageResponse : ServiceResponse
    {
        /// <summary>
        /// Message.
        /// </summary>
        public BinaryData Message { get; }

        /// <summary>
        /// Message data type.
        /// </summary>
        public MessageDataType DataType { get; }

        /// <summary>
        /// Initialize an instance of MessageResponse.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="dataType"></param>
        public MessageResponse(BinaryData message, MessageDataType dataType = MessageDataType.Text)
        {
            Message = message;
            DataType = dataType;
        }

        /// <summary>
        /// Initialize an instance of MessageResponse.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="dataType"></param>
        public MessageResponse(string message, MessageDataType dataType = MessageDataType.Text)
            : this(BinaryData.FromString(message), dataType)
        { }
    }
}
