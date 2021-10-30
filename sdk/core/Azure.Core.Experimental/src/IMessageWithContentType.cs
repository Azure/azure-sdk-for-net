// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging
{
    /// <summary>
    /// An interface for a message containing a content type along with its data.
    /// </summary>
    public interface IMessageWithContentType
    {
        /// <summary>
        /// Gets or sets the message data.
        /// </summary>
        BinaryData Data { get; set; }

        /// <summary>
        /// Gets or sets the message content type.
        /// </summary>
        string ContentType { get; set; }
    }
}