// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging
{
    /// <summary>
    /// An abstraction for a read-only message containing additional metadata along with its data.
    /// </summary>
    public abstract class ReadOnlyMessageWithMetadata
    {
        /// <summary>
        /// Gets the message data.
        /// </summary>
        public abstract BinaryData Data { get; }

        /// <summary>
        /// Gets the message content type.
        /// </summary>
        public abstract string ContentType { get; }
    }
}