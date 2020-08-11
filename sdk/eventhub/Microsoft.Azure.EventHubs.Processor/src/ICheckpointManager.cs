// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Processor
{
    using System.Threading.Tasks;

    /// <summary>
    /// If you wish to have EventProcessorHost store checkpoints somewhere other than Azure Storage,
    /// you can write your own checkpoint manager using this interface.  
    /// 
    /// <para>The Azure Storage managers use the same storage for both lease and checkpoints, so both
    /// interfaces are implemented by the same class. You are free to do the same thing if you have
    /// a unified store for both types of data.</para>
    /// 
    /// <para>This interface does not specify initialization methods because we have no way of knowing what
    /// information your implementation will require.</para>
    /// </summary>
    public interface ICheckpointManager
    {
        /// <summary>
        /// Does the checkpoint store exist?
        /// </summary>
        /// <returns>true if it exists, false if not</returns>
        Task<bool> CheckpointStoreExistsAsync();

        /// <summary>
        /// Create the checkpoint store if it doesn't exist. Do nothing if it does exist.
        /// </summary>
        /// <returns>true if the checkpoint store already exists or was created OK, false if there was a failure</returns>
        Task<bool> CreateCheckpointStoreIfNotExistsAsync();

        /// <summary>
        /// Get the checkpoint data associated with the given partition. Could return null if no checkpoint has
        /// been created for that partition.
        /// </summary>
        /// <param name="partitionId">Id of partition to get checkpoint info for.</param>
        /// <returns>Checkpoint info for the given partition, or null if none has been previously stored.</returns>
        Task<Checkpoint> GetCheckpointAsync(string partitionId);

        /// <summary>
        /// Create the checkpoint for the given partition if it doesn't exist. Do nothing if it does exist.
        /// The offset/sequenceNumber for a freshly-created checkpoint should be set to StartOfStream/0.
        /// </summary>
        /// <param name="partitionId">Id of partition to create the checkpoint for.</param>
        /// <returns>The checkpoint for the given partition, whether newly created or already existing.</returns>
        Task<Checkpoint> CreateCheckpointIfNotExistsAsync(string partitionId);

        /// <summary>
        /// Update the checkpoint in the store with the offset/sequenceNumber in the provided checkpoint.
        /// </summary>
        /// <param name="lease">Partition information against which to perform a checkpoint.</param>
        /// <param name="checkpoint">offset/sequeceNumber to update the store with.</param>
        Task UpdateCheckpointAsync(Lease lease, Checkpoint checkpoint);

        /// <summary>
        /// Delete the stored checkpoint for the given partition. If there is no stored checkpoint for the
        /// given partition, that is treated as success.
        /// </summary>
        /// <param name="partitionId">id of partition to delete checkpoint from store</param>
        /// <returns></returns>
        Task DeleteCheckpointAsync(string partitionId);
    }
}