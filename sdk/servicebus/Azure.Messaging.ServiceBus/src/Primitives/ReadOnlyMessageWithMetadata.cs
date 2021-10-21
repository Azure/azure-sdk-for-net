// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging
{
    /// <summary>
    ///
    /// </summary>
    public abstract class ReadOnlyMessageWithMetadata
    {
        /// <summary>
        ///
        /// </summary>
        public virtual BinaryData Body { get; }

        /// <summary>
        ///
        /// </summary>
        public virtual string ContentType { get; }
    }
}