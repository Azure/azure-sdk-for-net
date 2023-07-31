// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Rehydrates a <see cref="StorageResource"/> for resume.
    /// </summary>
    public abstract class StorageResourceRehydrator
    {
        /// <summary>
        /// Type ID. For DataMovement to query.
        /// </summary>
        protected internal abstract string TypeId { get; }

        /// <summary>
        /// Gets a source resource from the given transfer properties.
        /// </summary>
        protected internal abstract StorageResource GetSourceResource(DataTransferProperties props);

        /// <summary>
        /// Gets a source resource from the given transfer properties.
        /// </summary>
        protected internal abstract StorageResource GetDestinationResource(DataTransferProperties props);
    }
}
