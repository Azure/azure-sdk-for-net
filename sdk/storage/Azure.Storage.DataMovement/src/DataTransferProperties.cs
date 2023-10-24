// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Storage Resource Item properties returned by <see cref="TransferManager.GetTransfersAsync(DataTransferStatus[])"/>
    /// </summary>
    public class DataTransferProperties
    {
        /// <summary>
        /// Contains the checkpointer information to rehydrate the StorageResource from.
        /// </summary>
        public virtual TransferCheckpointStoreOptions Checkpointer { get; internal set; }

        /// <summary>
        /// Contains the transfer ID which to rehydrate the StorageResource from.
        /// </summary>
        public virtual string TransferId { get; internal set; }

        /// <summary>
        /// Contains the type id for the source resource to use during rehydration.
        /// Will be null if <see cref="IsContainer"/> is true.
        /// </summary>
        public virtual string SourceTypeId { get; internal set; }

        /// <summary>
        /// Contains the Source uri of the Storage Resource.
        /// </summary>
        public virtual Uri SourceUri { get; internal set; }

        /// <summary>
        /// A string ID for the source resource provider that should be used for rehydration.
        /// </summary>
        public virtual string SourceProviderId { get; internal set; }

        /// <summary>
        /// The additional checkpoint data specific to the source resource.
        /// </summary>
        public virtual byte[] SourceCheckpointData { get; internal set; }

        /// <summary>
        /// Contains the type id for the destination resource to use during rehydration.
        /// Will be null if <see cref="IsContainer"/> is true.
        /// </summary>
        public virtual string DestinationTypeId { get; internal set; }

        /// <summary>
        /// Contains the Destination uri of the Storage Resource.
        /// </summary>
        public virtual Uri DestinationUri { get; internal set; }

        /// <summary>
        /// A string ID for the destination resource provider that should be used for rehydration.
        /// </summary>
        public virtual string DestinationProviderId { get; internal set; }

        /// <summary>
        /// The additional checkpoint data specific to the destination resource.
        /// </summary>
        public virtual byte[] DestinationCheckpointData { get; internal set; }

        /// <summary>
        /// Defines whether or not this was a container transfer, in order to rehydrate the StorageResource.
        /// </summary>
        public virtual bool IsContainer { get; internal set; }

        /// <summary>
        /// For mocking.
        /// </summary>
        protected internal DataTransferProperties() { }
    }
}
