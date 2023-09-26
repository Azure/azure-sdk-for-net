// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Abstract class for checkpoint data related to a specific resource type.
    /// </summary>
    public abstract class StorageResourceCheckpointData
    {
        /// <summary>
        /// The length of the checkpoint data in bytes.
        /// </summary>
        public abstract int Length { get; }

        /// <summary>
        /// Serializes the checkpoint data into the given stream.
        /// </summary>
        /// <param name="stream">The stream to serialize the data into.</param>
        protected internal abstract void Serialize(Stream stream);
    }
}
