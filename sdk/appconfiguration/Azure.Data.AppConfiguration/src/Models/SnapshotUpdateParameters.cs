// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Data.AppConfiguration
{
    /// <summary> Parameters used to update a snapshot. </summary>
    internal partial class SnapshotUpdateParameters
    {
        /// <summary> Initializes a new instance of SnapshotUpdateParameters. </summary>
        public SnapshotUpdateParameters()
        {
        }

        /// <summary> The desired status of the snapshot. </summary>
        public ConfigurationSnapshotStatus? Status { get; set; }
    }
}
