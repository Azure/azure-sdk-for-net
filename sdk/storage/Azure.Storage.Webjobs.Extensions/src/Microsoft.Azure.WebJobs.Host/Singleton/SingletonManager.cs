// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings.Path;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.Host
{

    // $$$
    // Wraps SingletonManager and  exposes to extensions 
    public interface IHostSingletonManager
    {
        IListener CreateHostSingletonListener(IListener innerListener, string scopeId);
    }

    /// <summary>
    /// Encapsulates and manages blob leases for Singleton locks.
    /// </summary>
    internal class SingletonManager : IHostSingletonManager
    {
        private readonly INameResolver _nameResolver;
        private readonly SingletonOptions _options;
        private readonly ILogger _logger;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IDistributedLockManager _lockManager;
        private readonly IWebJobsExceptionHandler _exceptionHandler;

        private IHostIdProvider _hostIdProvider;
        private string _hostId;

        private TimeSpan _minimumLeaseRenewalInterval = TimeSpan.FromSeconds(1);

        // For mock testing only
        internal SingletonManager()
        {
        }

        public SingletonManager(IDistributedLockManager lockManager, IOptions<SingletonOptions> options, IWebJobsExceptionHandler exceptionHandler,
            ILoggerFactory loggerFactory, IHostIdProvider hostIdProvider, INameResolver nameResolver = null)
        {
            _lockManager = lockManager;
            _nameResolver = nameResolver;
            _options = options.Value;
            _loggerFactory = loggerFactory;
            _exceptionHandler = exceptionHandler;
            _logger = _loggerFactory?.CreateLogger(LogCategories.Singleton);
            _hostIdProvider = hostIdProvider;
        }

        // for testing
        internal TimeSpan MinimumLeaseRenewalInterval
        {
            get
            {
                return _minimumLeaseRenewalInterval;
            }
            set
            {
                _minimumLeaseRenewalInterval = value;
            }
        }

        internal virtual SingletonOptions Options
        {
            get
            {
                return _options;
            }
        }

        internal string HostId
        {
            get
            {
                if (_hostId == null)
                {
                    _hostId = _hostIdProvider.GetHostIdAsync(CancellationToken.None).Result;
                }
                return _hostId;
            }
        }

        public async virtual Task<RenewableLockHandle> LockAsync(string lockId, string functionInstanceId, SingletonAttribute attribute, CancellationToken cancellationToken)
        {
            var lockHandle = await TryLockAsync(lockId, functionInstanceId, attribute, cancellationToken);

            if (lockHandle == null)
            {
                TimeSpan acquisitionTimeout = GetLockAcquisitionTimeout(attribute, _options);
                throw new TimeoutException(string.Format("Unable to acquire singleton lock blob lease for blob '{0}' (timeout of {1} exceeded).", lockId, acquisitionTimeout.ToString("g")));
            }

            return lockHandle;
        }

        public async virtual Task<RenewableLockHandle> TryLockAsync(string lockId, string functionInstanceId, SingletonAttribute attribute, CancellationToken cancellationToken, bool retry = true)
        {
            TimeSpan lockPeriod = GetLockPeriod(attribute, _options);
            IDistributedLock handle = await _lockManager.TryLockAsync(attribute.Account, lockId, functionInstanceId, null, lockPeriod, cancellationToken);

            if ((handle == null) && retry)
            {
                // Someone else has the lease. Continue trying to periodically get the lease for
                // a period of time
                TimeSpan acquisitionTimeout = GetLockAcquisitionTimeout(attribute, _options);
                TimeSpan timeWaited = TimeSpan.Zero;
                while ((handle == null) && (timeWaited < acquisitionTimeout))
                {
                    await Task.Delay(_options.LockAcquisitionPollingInterval);
                    timeWaited += _options.LockAcquisitionPollingInterval;
                    handle = await _lockManager.TryLockAsync(attribute.Account, lockId, functionInstanceId, null, lockPeriod, cancellationToken);
                }
            }

            if (handle == null)
            {
                return null;
            }

            var renewal = CreateLeaseRenewalTimer(lockPeriod, handle);

            // start the renewal timer, which ensures that we maintain our lease until
            // the lock is released
            renewal.Start();

            string msg = string.Format(CultureInfo.InvariantCulture, "Singleton lock acquired ({0})", lockId);
            _logger?.LogDebug(msg);

            return new RenewableLockHandle(handle, renewal);
        }

        private ITaskSeriesTimer CreateLeaseRenewalTimer(TimeSpan leasePeriod, IDistributedLock lockHandle)
        {
            // renew the lease when it is halfway to expiring   
            TimeSpan normalUpdateInterval = new TimeSpan(leasePeriod.Ticks / 2);

            IDelayStrategy speedupStrategy = new LinearSpeedupStrategy(normalUpdateInterval, MinimumLeaseRenewalInterval);
            ITaskSeriesCommand command = new RenewLeaseCommand(_lockManager, lockHandle, speedupStrategy);
            return new TaskSeriesTimer(command, this._exceptionHandler, Task.Delay(normalUpdateInterval));
        }

        internal static TimeSpan GetLockPeriod(SingletonAttribute attribute, SingletonOptions config)
        {
            return attribute.Mode == SingletonMode.Listener ?
                    config.ListenerLockPeriod : config.LockPeriod;
        }

        public async virtual Task ReleaseLockAsync(RenewableLockHandle handle, CancellationToken cancellationToken)
        {
            if (handle.LeaseRenewalTimer != null)
            {
                await handle.LeaseRenewalTimer.StopAsync(cancellationToken);
            }

            await _lockManager.ReleaseLockAsync(handle.InnerLock, cancellationToken);

            string msg = string.Format(CultureInfo.InvariantCulture, "Singleton lock released ({0})", handle.InnerLock.LockId);
            _logger?.LogDebug(msg);
        }

        public string FormatLockId(FunctionDescriptor method, SingletonScope scope, string scopeId)
        {
            return FormatLockId(method, scope, HostId, scopeId);
        }

        public static string FormatLockId(FunctionDescriptor descr, SingletonScope scope, string hostId, string scopeId)
        {
            if (string.IsNullOrEmpty(hostId))
            {
                throw new ArgumentNullException("hostId");
            }

            string lockId = string.Empty;
            if (scope == SingletonScope.Function)
            {
                lockId += descr.FullName;
            }

            if (!string.IsNullOrEmpty(scopeId))
            {
                if (!string.IsNullOrEmpty(lockId))
                {
                    lockId += ".";
                }
                lockId += scopeId;
            }

            lockId = string.Format(CultureInfo.InvariantCulture, "{0}/{1}", hostId, lockId);

            return lockId;
        }

        public string GetBoundScopeId(string scopeId, IReadOnlyDictionary<string, object> bindingData = null)
        {
            if (_nameResolver != null)
            {
                scopeId = _nameResolver.ResolveWholeString(scopeId);
            }

            if (bindingData != null)
            {
                BindingTemplate bindingTemplate = BindingTemplate.FromString(scopeId);
                return bindingTemplate.Bind(bindingData);
            }
            else
            {
                return scopeId;
            }
        }

        public static SingletonAttribute GetFunctionSingletonOrNull(FunctionDescriptor descriptor, bool isTriggered)
        {
            if (!descriptor.SingletonAttributes.Any())
            {
                return null;
            }

            if (!isTriggered && descriptor.SingletonAttributes.Any(p => p.Mode == SingletonMode.Listener))
            {
                throw new NotSupportedException("SingletonAttribute using mode 'Listener' cannot be applied to non-triggered functions.");
            }

            SingletonAttribute[] singletonAttributes = descriptor.SingletonAttributes.Where(p => p.Mode == SingletonMode.Function).ToArray();
            SingletonAttribute singletonAttribute = null;
            if (singletonAttributes.Length > 1)
            {
                throw new NotSupportedException("Only one SingletonAttribute using mode 'Function' is allowed.");
            }
            else if (singletonAttributes.Length == 1)
            {
                singletonAttribute = singletonAttributes[0];
                ValidateSingletonAttribute(singletonAttribute, SingletonMode.Function);
            }

            return singletonAttribute;
        }

        /// <summary>
        /// Creates and returns singleton listener scoped to the host.
        /// </summary>
        /// <param name="innerListener">The inner listener to wrap.</param>
        /// <param name="scopeId">The scope ID to use.</param>
        /// <returns>The singleton listener.</returns>
        public IListener CreateHostSingletonListener(IListener innerListener, string scopeId)
        {
            SingletonAttribute singletonAttribute = new SingletonAttribute(scopeId, SingletonScope.Host)
            {
                Mode = SingletonMode.Listener
            };
            return new SingletonListener(null, singletonAttribute, this, innerListener, _loggerFactory);
        }

        public static SingletonAttribute GetListenerSingletonOrNull(Type listenerType, FunctionDescriptor method)
        {
            // First check the method, then the listener class. This allows a method to override an implicit
            // listener singleton.
            SingletonAttribute singletonAttribute = null;
            SingletonAttribute[] singletonAttributes = method.SingletonAttributes.Where(p => p.Mode == SingletonMode.Listener).ToArray();
            if (singletonAttributes.Length > 1)
            {
                throw new NotSupportedException("Only one SingletonAttribute using mode 'Listener' is allowed.");
            }
            else if (singletonAttributes.Length == 1)
            {
                singletonAttribute = singletonAttributes[0];
            }
            else
            {
                singletonAttribute = listenerType.GetCustomAttributes<SingletonAttribute>().SingleOrDefault(p => p.Mode == SingletonMode.Listener);
            }

            if (singletonAttribute != null)
            {
                ValidateSingletonAttribute(singletonAttribute, SingletonMode.Listener);
            }

            return singletonAttribute;
        }

        internal static TimeSpan GetLockAcquisitionTimeout(SingletonAttribute attribute, SingletonOptions config)
        {
            TimeSpan acquisitionTimeout = attribute.LockAcquisitionTimeout != -1
                    ? TimeSpan.FromSeconds(attribute.LockAcquisitionTimeout)
                    : config.LockAcquisitionTimeout;

            return acquisitionTimeout;
        }

        internal static void ValidateSingletonAttribute(SingletonAttribute attribute, SingletonMode mode)
        {
            if (attribute.Scope == SingletonScope.Host && string.IsNullOrEmpty(attribute.ScopeId))
            {
                throw new InvalidOperationException("A ScopeId value must be provided when using scope 'Host'.");
            }

            if (mode == SingletonMode.Listener && attribute.Scope == SingletonScope.Host)
            {
                throw new InvalidOperationException("Scope 'Host' cannot be used when the mode is set to 'Listener'.");
            }
        }

        public async virtual Task<string> GetLockOwnerAsync(SingletonAttribute attribute, string lockId, CancellationToken cancellationToken)
        {
            return await _lockManager.GetLockOwnerAsync(attribute.Account, lockId, cancellationToken);
        }

        internal class RenewLeaseCommand : ITaskSeriesCommand
        {
            private readonly IDistributedLockManager _lockManager;
            private readonly IDistributedLock _lock;
            private readonly IDelayStrategy _delayStrategy;

            public RenewLeaseCommand(IDistributedLockManager lockManager, IDistributedLock @lock, IDelayStrategy delayStrategy)
            {
                _lock = @lock;
                _lockManager = lockManager;
                _delayStrategy = delayStrategy;
            }

            public async Task<TaskSeriesCommandResult> ExecuteAsync(CancellationToken cancellationToken)
            {
                // Exceptions will propagate 
                bool renewalSucceeded = await _lockManager.RenewAsync(_lock, cancellationToken);

                TimeSpan delay = _delayStrategy.GetNextDelay(renewalSucceeded);
                return new TaskSeriesCommandResult(wait: Task.Delay(delay));
            }
        }
    }
}
