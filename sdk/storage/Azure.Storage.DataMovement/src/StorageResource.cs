// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Threading;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// The base class for all storage resources.
    /// </summary>
    public abstract class StorageResource
    {
        /// <summary>
        /// The protected constructor for the abstract StorageResource class (to allow for mocking).
        /// </summary>
        protected StorageResource()
        {
        }

        /// <summary>
        /// Defines whether the storage resource is a container.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal abstract bool IsContainer { get; }

        /// <summary>
        /// Gets the Uri of the Storage Resource.
        /// </summary>
        public abstract Uri Uri { get; }

        /// <summary>
        /// A string ID for the resource provider that should be used for rehydration.
        /// NOTE: Must be no more than 5 characters long.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract string ProviderId { get; }

        /// <summary>
        /// Gets the source checkpoint data for this resource that will be written to the checkpointer.
        /// </summary>
        /// <returns>A <see cref="StorageResourceCheckpointDetails"/> containing the checkpoint information for this resource.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal abstract StorageResourceCheckpointDetails GetSourceCheckpointDetails();

        /// <summary>
        /// Gets the destination checkpoint data for this resource that will be written to the checkpointer.
        /// </summary>
        /// <returns>A <see cref="StorageResourceCheckpointDetails"/> containing the checkpoint information for this resource.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal abstract StorageResourceCheckpointDetails GetDestinationCheckpointDetails();

        /// <summary>
        /// Ensures the transfer is valid. Intended to be called on destination resource with the source resource passed-in.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal virtual Task ValidateTransferAsync(string transferId, StorageResource sourceResource, CancellationToken cancellationToken = default)
            => Task.CompletedTask;
    }
}
