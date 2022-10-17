// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement.Models
{
    /// <summary>
    /// Options bag for listing Storage Resources
    /// </summary>
    public class ListStorageResourceOptions
    {
        /// <summary>
        /// Specifies trait options for shaping the storage resources.
        /// </summary>
        public StorageResourceListTraits Traits { get; internal set; }

        /// <summary>
        /// Specifies state options for filtering the storage resources.
        /// </summary>
        public StorageResourceListStates States { get; internal set; }
    }
}
