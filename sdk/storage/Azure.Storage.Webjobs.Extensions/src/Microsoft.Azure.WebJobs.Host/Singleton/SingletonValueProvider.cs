// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.Host
{
    /// <summary>
    /// <see cref="IValueProvider"/> implementation for "virtual" singleton parameters.
    /// When <see cref="SingletonAttribute"/> is applied to a function, 
    /// </summary>
    internal class SingletonValueProvider : IWatchable, IValueProvider
    {
        public const string SingletonParameterName = "(singleton)";
        private readonly SingletonLock _singletonLock;
        private readonly SingletonWatcher _watcher;
        private readonly string _scopeId;

        public SingletonValueProvider(FunctionDescriptor method, string scopeId, string functionInstanceId, SingletonAttribute attribute, SingletonManager singletonManager)
        {
            _scopeId = string.IsNullOrEmpty(scopeId) ? "(null)" : scopeId;
            string lockId = singletonManager.FormatLockId(method, attribute.Scope, scopeId);
            _singletonLock = new SingletonLock(lockId, functionInstanceId, attribute, singletonManager);
            _watcher = new SingletonWatcher(_singletonLock);
        }

        public Type Type
        {
            get
            {
                return typeof(SingletonLock);
            }
        }

        public IWatcher Watcher
        {
            get
            {
                return _watcher;
            }
        }

        public Task<object> GetValueAsync()
        {
            return Task.FromResult<object>(_singletonLock);
        }

        public string ToInvokeString()
        {
            return string.Format(CultureInfo.InvariantCulture, "ScopeId: {0}", _scopeId);
        }

        /// <summary>
        /// This watcher provides detailed information about the current status of the
        /// lock for a function instance.
        /// </summary>
        internal class SingletonWatcher : IWatcher
        {
            private readonly SingletonLock _singletonLock;
            private readonly SingletonParameterLog _log;
            private TimeSpan _ownerUpdateInterval = TimeSpan.FromSeconds(3);
            private TimeSpan _minimumWaitForFirstOwnerCheck = TimeSpan.FromSeconds(10);
            private DateTime _lastOwnerCheck;

            public SingletonWatcher(SingletonLock singletonLock)
            {
                _singletonLock = singletonLock;
                _log = new SingletonParameterLog();
            }

            public ParameterLog GetStatus()
            {
                if (_singletonLock.AcquireEndTime != null)
                {
                    // we've acquired the lock. compute the final wait time
                    _log.TimeToAcquireLock = _singletonLock.AcquireEndTime.Value - _singletonLock.AcquireStartTime.Value;
                    _log.LockAcquired = true;

                    // clear lock owner, now that we have it
                    _log.LockOwner = null;

                    if (_singletonLock.ReleaseTime != null)
                    {
                        // we've released the lock, so compute the final lock duration
                        _log.LockDuration = _singletonLock.ReleaseTime - _singletonLock.AcquireEndTime.Value;
                    }
                    else
                    {
                        // we haven't released the lock yet
                        _log.LockDuration = DateTime.UtcNow - _singletonLock.AcquireEndTime.Value;
                    }
                }
                else if (_singletonLock.AcquireStartTime != null)
                {
                    // we're waiting for the lock
                    TimeSpan timeWaiting = DateTime.UtcNow - _singletonLock.AcquireStartTime.Value;
                    _log.TimeToAcquireLock = timeWaiting;

                    TimeSpan timeSinceLastOwnerCheck = DateTime.UtcNow - _lastOwnerCheck;
                    if (timeWaiting > _minimumWaitForFirstOwnerCheck &&
                        timeSinceLastOwnerCheck > _ownerUpdateInterval)
                    {
                        // periodically determine and log the current owner
                        Task<string> task = _singletonLock.GetOwnerAsync(CancellationToken.None);
                        _log.LockOwner = task.Result;

                        _lastOwnerCheck = DateTime.UtcNow;
                    }
                }

                return _log;
            }
        }
    }
}
