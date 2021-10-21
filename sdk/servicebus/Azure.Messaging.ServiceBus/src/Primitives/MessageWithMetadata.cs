// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging
{
    /// <summary>
    ///
    /// </summary>
    public abstract class MessageWithMetadata
    {
        /// <summary>
        ///
        /// </summary>
        public virtual BinaryData Body { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string ContentType { get; set; }
    }
}