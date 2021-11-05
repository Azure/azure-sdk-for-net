// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// ShareInfo
    /// </summary>
    public class ShareInfo
    {
        /// <summary>
        /// The ETag contains a value which represents the version of the share, in quotes.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the share was last modified. Any operation that modifies the share or its properties or metadata updates the last modified time. Operations on files do not affect the last modified time of the share.
        /// </summary>
        public DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of ShareInfo instances.
        /// You can use ShareModelFactory.ShareInfo instead.
        /// </summary>
        internal ShareInfo() { }
    }
}
