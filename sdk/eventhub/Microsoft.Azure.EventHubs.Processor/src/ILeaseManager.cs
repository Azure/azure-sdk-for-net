// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Processor
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// If you wish to have EventProcessorHost store leases somewhere other than Azure Storage,
    /// you can write your own lease manager using this interface.  
    /// 
    /// <para>The Azure Storage managers use the same storage for both lease and checkpoints, so both
    /// interfaces are implemented by the same class. You are free to do the same thing if you have
    /// a unified store for both types of data.</para>
    /// 
    /// <para>This interface does not specify initialization methods because we have no way of knowing what
    /// information your implementation will require.</para>
    /// </summary>
    public interface ILeaseManager
    {
        /// <summary>
        /// Allows a lease manager implementation to specify to PartitionManager how often it should
        /// scan leases and renew them. In order to redistribute leases in a timely fashion after a host
        /// ceases operating, we recommend a relatively short interval, such as ten seconds. Obviously it
        /// should be less than half of the lease length, to prevent accidental expiration.
        /// </summary>
        /// <value>The sleep interval between scans</value>
        TimeSpan LeaseRenewInterval { get; }

        /// <summary>
        /// Mostly useful for testing.
        /// </summary>
        /// <value>Duration of a lease before it expires unless renewed.</value>
        TimeSpan LeaseDuration { get; }

        /// <summary>
        /// Does the lease store exist?
        /// </summary>
        Task<bool> LeaseStoreExistsAsync();
  
        /// <summary>
        /// Create the lease store if it does not exist, do nothing if it does exist.
        /// </summary>
        /// <returns>true if the lease store already exists or was created successfully, false if not</returns>
        Task<bool> CreateLeaseStoreIfNotExistsAsync();

        /// <summary>
        /// Not used by EventProcessorHost, but a convenient function to have for testing.
        /// </summary>
        /// <returns>true if the lease store was deleted successfully, false if not</returns>
        Task<bool> DeleteLeaseStoreAsync();

        /// <summary>
        /// Return the lease info for the specified partition. Can return null if no lease has been
        /// created in the store for the specified partition.
        /// </summary>
        /// <param name="partitionId">id of partition to get lease for</param>
        /// <returns>lease info for the partition, or null</returns>
        Task<Lease> GetLeaseAsync(string partitionId);

        /// <summary>
        /// Return the lease info for all partitions.
        /// A typical implementation could just call GetLeaseAsync() on all partitions.
        /// </summary>
        /// <returns>list of lease info.</returns>
        Task<IEnumerable<Lease>> GetAllLeasesAsync();

        /// <summary>
        /// Create in the store the lease info for the given partition, if it does not exist. Do nothing if it does exist
        /// in the store already. 
        /// </summary>
        /// <param name="partitionId">id of partition to create lease info for</param>
        /// <returns>the existing or newly-created lease info for the partition</returns>
        Task<Lease> CreateLeaseIfNotExistsAsync(string partitionId);

        /// <summary>
        /// Delete the lease info for the given partition from the store. If there is no stored lease for the given partition,
        /// that is treated as success.
        /// </summary>
        /// <param name="lease">Lease info for the desired partition as previously obtained from GetLeaseAsync()</param>
        /// <returns></returns>
        Task DeleteLeaseAsync(Lease lease);

        /// <summary>
        /// Acquire the lease on the desired partition for this EventProcessorHost.
        /// 
        /// <para>Note that it is legal to acquire a lease that is already owned by another host. Lease-stealing is how
        /// partitions are redistributed when additional hosts are started.</para>
        /// </summary>
        /// <param name="lease">Lease info for the desired partition as previously obtained from GetLeaseAsync()</param>
        /// <returns>true if the lease was acquired successfully, false if not</returns>
        Task<bool> AcquireLeaseAsync(Lease lease);

        /// <summary>
        /// Renew a lease currently held by this host.
        /// 
        /// <para>If the lease has been stolen, or expired, or released, it is not possible to renew it. You will have to call getLease()
        /// and then acquireLease() again.</para>
        /// </summary>
        /// <param name="lease">Lease to be renewed</param>
        /// <returns>true if the lease was renewed successfully, false if not</returns>
        Task<bool> RenewLeaseAsync(Lease lease);      

        /// <summary>
        /// Give up a lease currently held by this host.
        /// <para>If the lease has been stolen, or expired, releasing it is unnecessary, and will fail if attempted.</para>
        /// </summary>
        /// <param name="lease">Lease to be given up</param>
        /// <returns>true if the lease was released successfully, false if not</returns>
        Task<bool> ReleaseLeaseAsync(Lease lease);

        /// <summary>
        /// Update the store with the information in the provided lease.
        /// 
        /// <para>It is necessary to currently hold a lease in order to update it. If the lease has been stolen, or expired, or
        /// released, it cannot be updated. Updating should renew the lease before performing the update to avoid lease
        /// expiration during the process.</para>
        /// </summary>
        /// <param name="lease">New lease info to be stored</param>
        /// <returns>true if the updated was performed successfully, false if not</returns>
        Task<bool> UpdateLeaseAsync(Lease lease);
    }
}