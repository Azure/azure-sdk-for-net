// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging
{
    /// <summary>
    /// A message containing a content type along with its data.
    /// </summary>
    public class MessageWithMetadata
    {
        /// <summary>
        /// Gets or sets the message data.
        /// </summary>
        public virtual BinaryData? Data { get; set; }

        /// <summary>
        /// Gets or sets the message content type.
        /// </summary>
        public virtual string? ContentType { get; set; }

        /// <summary>
        /// Gets whether the message is read only or not. This
        /// can be overriden by inheriting classes to specify whether or
        /// not the message can be modified.
        /// </summary>
        public virtual bool IsReadOnly { get; }
    }
}