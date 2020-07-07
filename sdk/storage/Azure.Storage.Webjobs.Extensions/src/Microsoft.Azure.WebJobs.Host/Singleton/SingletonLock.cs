// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host
{
    /// <summary>
    /// This class implements a singleton lock for a particular function instance.
    /// </summary>
    internal class SingletonLock
    {
        private readonly string _lockId;
        private readonly string _functionInstanceId;
        private readonly SingletonAttribute _attribute;
        private readonly SingletonManager _singletonManager;
        private RenewableLockHandle _lockHandle;

        public SingletonLock(string id, string functionInstanceId, SingletonAttribute attribute, SingletonManager manager)
        {
            _lockId = id;
            _functionInstanceId = functionInstanceId;
            _attribute = attribute;
            _singletonManager = manager;
        }

        /// <summary>
        /// The singleton lock ID
        /// </summary>
        public string Id
        {
            get
            {
                return _lockId;
            }
        }

        /// <summary>
        /// The function instance ID that this lock is for
        /// </summary>
        public string FunctionId
        {
            get
            {
                return _functionInstanceId;
            }
        }

        /// <summary>
        /// Gets the time when the lock acquisition began.
        /// </summary>
        public DateTime? AcquireStartTime { get; internal set; }

        /// <summary>
        /// Gets the time when the lock acquisition completed.
        /// </summary>
        public DateTime? AcquireEndTime { get; internal set; }

        /// <summary>
        /// Gets the time when the lock was released.
        /// </summary>
        public DateTime? ReleaseTime { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the lock has been acquired and
        /// is currently held.
        /// </summary>
        public bool IsHeld { get; private set; }

        /// <summary>
        /// Acquire the singleton lock. If the lock cannot be acquired within the configured timeout,
        /// an exception will be thrown.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task AcquireAsync(CancellationToken cancellationToken)
        {
            AcquireStartTime = DateTime.UtcNow;

            _lockHandle = await _singletonManager.LockAsync(_lockId, _functionInstanceId, _attribute, cancellationToken);

            AcquireEndTime = DateTime.UtcNow;
            IsHeld = true;
        }

        /// <summary>
        /// Release the lock.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task ReleaseAsync(CancellationToken cancellationToken)
        {
            if (_lockHandle == null)
            {
                throw new InvalidOperationException("Lock has not been acquired.");
            }

            await _singletonManager.ReleaseLockAsync(_lockHandle, cancellationToken);

            ReleaseTime = DateTime.UtcNow;
            IsHeld = false;
        }

        /// <summary>
        /// Gets the current owner of the singleton lock.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string> GetOwnerAsync(CancellationToken cancellationToken)
        {
            return await _singletonManager.GetLockOwnerAsync(_attribute, _lockId, cancellationToken);
        }
    }
}
