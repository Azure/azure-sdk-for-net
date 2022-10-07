// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Defines what type of listing can occur when calling the
    /// <see cref="StorageResourceContainer"/>
    /// </summary>
    public enum ListStorageResourcesType
    {
        /// <summary>
        /// When attempting to list all the child resources in the
        /// container resource, the list call is pageable and will
        /// return in batches (using a continuation token to keep
        /// track of what batch is next to list).
        ///
        /// This is normally used for blob container list calls where
        /// a continuation token is needed for containers that have
        /// large amounts of files.
        /// </summary>
        PageableListCall = 2,

        /// <summary>
        /// When attempting to list all the child resources in the
        /// container resource, the list call will be called in one go.
        ///
        /// This is normally used for local filesytem list calls where
        /// the listing returns all the child resources in one go.
        /// </summary>
        SingleListCall = 1,

        /// <summary>
        /// Unable to list
        /// </summary>
        ListingUnavailable = ~0,
    }
}
