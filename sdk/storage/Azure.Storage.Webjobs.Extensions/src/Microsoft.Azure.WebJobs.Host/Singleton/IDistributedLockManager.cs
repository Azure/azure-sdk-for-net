// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host
{
    /// <summary>
    /// Manage distributed lock. A lock is specified by (account, lockId).  Interface implementations should cooperate with <see cref="SingletonOptions"/>
    /// </summary>
    /// <remarks>
    /// 1. Account can be null or it may be a storage account name intended for <see cref="IStorageAccountProvider"/>. 
    /// 2. lockId has the same naming restrictions as blobs.     
    /// </remarks>    
    [Obsolete("Not ready for public consumption.")]
    public interface IDistributedLockManager
    {        
        /// <summary>
        /// Try to acquire a lock specified by (account, lockId).
        /// </summary>
        /// <param name="account">optional. A string specifying the "account" to use. LockIds are scoped to an account. This value may come from <see cref="SingletonAttribute.Account"/> </param>
        /// <param name="lockId">The name of the lock. </param>
        /// <param name="lockOwnerId">A string hint specifying who owns this lock. Only used for diagnostics. </param>
        /// <param name="proposedLeaseId">Optional. This can allow the caller to immediately assume the lease.
        /// If this call acquires the lock, then this becomes the leaseId. 
        /// If the lock is already held with this same leaseId, then this call will acquire the lock. 
        /// The caller is responsible for enforcing that any simultaneous callers have different lease ids. 
        /// </param>
        /// <param name="lockPeriod">The length of the lease to acquire. The caller is responsible for Renewing the lease well before this time is up. 
        /// The exact value here is restricted based on the underlying implementation.  </param>
        /// <param name="cancellationToken"></param>
        /// <returns>Null if can't acquire the lock. This is common if somebody else holds it.</returns>
        Task<IDistributedLock> TryLockAsync(
            string account,
            string lockId, 
            string lockOwnerId,
            string proposedLeaseId,
            TimeSpan lockPeriod,  
            CancellationToken cancellationToken);

        /// <summary>
        /// Called by the client to renew the lease. The timing internals here are determined by <see cref="SingletonOptions"/>
        /// </summary>
        /// <param name="lockHandle"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>A hint used for determining the next time delay in calling Renew. 
        /// True means the next execution should occur at a normal delay. False means the next execution should occur quickly; use this in network error cases.   </returns>
        /// <remarks>
        /// If this throws an exception, the lease is cancelled. 
        /// </remarks>
        Task<bool> RenewAsync(IDistributedLock lockHandle, CancellationToken cancellationToken);

        /// <summary>
        /// Get the owner for a given lock or null if not held. 
        /// This is used for diagnostics only. 
        /// The lock owner can change immediately after this function returns, so callers can't be guaranteed the owner still the same. 
        /// </summary>
        /// <param name="account">optional. A string specifying the account to use. LockIds are scoped to an account </param>
        /// <param name="lockId">the name of the lock. </param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> GetLockOwnerAsync(
            string account, 
            string lockId, 
            CancellationToken cancellationToken);

        /// <summary>
        /// Release a lock that was previously acquired via TryLockAsync.
        /// </summary>
        /// <param name="lockHandle">previously acquired handle to be released</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task ReleaseLockAsync(
            IDistributedLock lockHandle, 
            CancellationToken cancellationToken);
    }
}
