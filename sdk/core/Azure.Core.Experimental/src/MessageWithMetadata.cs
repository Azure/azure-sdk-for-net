// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging
{
    /// <summary>
    /// An abstraction for a message containing additional metadata along with its data.
    /// </summary>
    public abstract class MessageWithMetadata
    {
        /// <summary>
        /// Gets or sets the message data.
        /// </summary>
        public abstract BinaryData Data { get; set; }

        /// <summary>
        /// Gets or sets the message content type.
        /// </summary>
        public abstract string ContentType { get; set; }
    }
}