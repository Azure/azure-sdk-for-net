// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Messaging
{
    /// <summary>
    /// An interface for a message containing metadata along with its data.
    /// </summary>
    public interface IMessageWithMetadata
    {
        /// <summary>
        /// Gets or sets the message data.
        /// </summary>
        BinaryData Data { get; set; }

        /// <summary>
        /// Gets the message metadata.
        /// </summary>
        IDictionary<string, object> Metadata { get; }
    }
}