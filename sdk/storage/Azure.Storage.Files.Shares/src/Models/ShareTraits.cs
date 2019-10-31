// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Traits to be included when listing shares with the
    /// <see cref="ShareServiceClient.GetSharesAsync"/> operations.
    /// </summary>
    [Flags]
    public enum ShareTraits
    {
        /// <summary>
        /// Default value specifying that no flags are set in <see cref="ShareTraits"/>.
        /// </summary>
        None = 0,

        /// <summary>
        /// Flag specifying that the share's metadata should be included.
        /// </summary>
        Metadata = 1,

        /// <summary>
        /// Flag specifying that all traits should be included.
        /// </summary>
        All = ~None
    }
}
