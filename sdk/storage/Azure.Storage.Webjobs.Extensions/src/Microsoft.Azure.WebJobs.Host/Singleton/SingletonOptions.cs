// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using Microsoft.Azure.WebJobs.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Host
{
    /// <summary>
    /// Configuration options governing the lock functionality of <see cref="SingletonAttribute"/>.
    /// The configuration needs to cooperate with the SDK's registered <see cref="IDistributedLockManager"/>. 
    /// For example, this configuration determines the refresh frequently for calls on <see cref="IDistributedLockManager.RenewAsync(IDistributedLock, CancellationToken)"/>. 
    /// </summary>
    public sealed class SingletonOptions : IOptionsFormatter
    {
        // These are the min/max values supported by Azure Storage
        private static readonly TimeSpan MinimumLeasePeriod = TimeSpan.FromSeconds(15);
        private static readonly TimeSpan MaximumLeasePeriod = TimeSpan.FromSeconds(60);

        private TimeSpan _lockPeriod;
        private TimeSpan _listenerLockPeriod;
        private TimeSpan _lockAcquisitionTimeout;
        private TimeSpan _lockAcquisitionPollingInterval;
        private TimeSpan _listenerLockRecoveryPollingInterval;

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SingletonOptions()
        {
            _lockPeriod = MinimumLeasePeriod;
            _listenerLockPeriod = MaximumLeasePeriod;
            _lockAcquisitionTimeout = TimeSpan.MaxValue;
            _lockAcquisitionPollingInterval = TimeSpan.FromSeconds(5);
            _listenerLockRecoveryPollingInterval = TimeSpan.FromMinutes(1);
        }

        /// <summary>
        /// Gets or sets the default duration of <see cref="SingletonMode.Function"/> locks.
        /// As this period nears expiry, the lock will be automatically renewed.
        /// </summary>
        public TimeSpan LockPeriod
        {
            get
            {
                return _lockPeriod;
            }
            set
            {
                ValidateLockPeriod(value);
                _lockPeriod = value;
            }
        }

        /// <summary>
        /// Gets or sets the default duration of <see cref="SingletonMode.Listener"/> locks.
        /// As this period nears expiry, the lock will be automatically renewed.
        /// </summary>
        public TimeSpan ListenerLockPeriod
        {
            get
            {
                return _listenerLockPeriod;
            }
            set
            {
                ValidateLockPeriod(value);
                _listenerLockPeriod = value;
            }
        }

        /// <summary>
        /// Gets or sets the timeout value for lock acquisition.
        /// </summary>
        public TimeSpan LockAcquisitionTimeout
        {
            get
            {
                return _lockAcquisitionTimeout;
            }
            set
            {
                if (value <= TimeSpan.Zero)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                _lockAcquisitionTimeout = value;
            }
        }

        /// <summary>
        /// Gets or sets the polling interval governing how often retries are made
        /// when waiting to acquire a lock. The system will retry on this interval
        /// until the <see cref="LockAcquisitionTimeout"/> is exceeded.
        /// </summary>
        public TimeSpan LockAcquisitionPollingInterval
        {
            get
            {
                return _lockAcquisitionPollingInterval;
            }
            set
            {
                if (value < TimeSpan.FromMilliseconds(500))
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                _lockAcquisitionPollingInterval = value;
            }
        }

        /// <summary>
        /// Gets or sets the polling interval used by <see cref="SingletonMode.Listener"/> locks
        /// to acquire their lock if they failed to acquire it on startup.
        /// </summary>
        /// <remarks>
        /// On startup, singleton listeners for triggered functions make a single attempt to acquire
        /// their locks. If unable to acquire the lock (e.g. if another instance has it) the listener
        /// won't start (and the triggered function won't be running). However, the listener will
        /// periodically reattempt to acquire the lock based on this value. To disable this behavior
        /// set the value to <see cref="TimeSpan.MaxValue"/>.
        /// </remarks>
        public TimeSpan ListenerLockRecoveryPollingInterval
        {
            get
            {
                return _listenerLockRecoveryPollingInterval;
            }
            set
            {
                if (value != TimeSpan.MaxValue &&
                    value < MinimumLeasePeriod)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                _listenerLockRecoveryPollingInterval = value;
            }
        }

        private static void ValidateLockPeriod(TimeSpan value)
        {
            if (value < MinimumLeasePeriod ||
                value > MaximumLeasePeriod)
            {
                throw new ArgumentOutOfRangeException("value");
            }
        }

        public string Format()
        {
            JObject options = new JObject
            {
                { nameof(LockPeriod), LockPeriod },
                { nameof(ListenerLockPeriod), ListenerLockPeriod },
                { nameof(LockAcquisitionTimeout), LockAcquisitionTimeout },
                { nameof(LockAcquisitionPollingInterval), LockAcquisitionPollingInterval },
                { nameof(ListenerLockRecoveryPollingInterval), ListenerLockRecoveryPollingInterval }
            };

            return options.ToString(Formatting.Indented);
        }
    }
}
