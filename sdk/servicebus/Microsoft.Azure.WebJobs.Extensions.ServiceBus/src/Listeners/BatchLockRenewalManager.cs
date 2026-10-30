// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.ServiceBus.Listeners
{
    internal sealed class BatchLockRenewalManager
    {
        private readonly object _syncLock = new();
        private readonly Dictionary<object, Renewal> _renewals = new();
        private readonly TimeSpan _maxDuration;
        private readonly CancellationToken _cancellationToken;
        private readonly ILogger _logger;

        public BatchLockRenewalManager(TimeSpan maxDuration, CancellationToken cancellationToken, ILogger logger)
        {
            _maxDuration = maxDuration;
            _cancellationToken = cancellationToken;
            _logger = logger;
        }

        public void Start(ServiceBusReceivedMessage message, ServiceBusReceiver receiver)
        {
            if (receiver is ServiceBusSessionReceiver)
            {
                return;
            }

            Start(message, receiver, () => message.LockedUntil, token => receiver.RenewMessageLockAsync(message, token));
        }

        public void Start(ServiceBusSessionReceiver receiver)
            => Start(receiver, receiver, () => receiver.SessionLockedUntil, receiver.RenewSessionLockAsync);

        private void Start(object key, ServiceBusReceiver receiver, Func<DateTimeOffset> lockedUntil, Func<CancellationToken, Task> renew)
        {
            if (_maxDuration == TimeSpan.Zero || receiver.ReceiveMode != ServiceBusReceiveMode.PeekLock)
            {
                return;
            }

            lock (_syncLock)
            {
                if (_cancellationToken.IsCancellationRequested || _renewals.ContainsKey(key))
                {
                    return;
                }

                var cancellation = CancellationTokenSource.CreateLinkedTokenSource(_cancellationToken);
                cancellation.CancelAfter(_maxDuration);
                var renewal = new Renewal(cancellation);
                _renewals.Add(key, renewal);
                renewal.Task = Task.Run(() => RenewAsync(key, receiver, lockedUntil, renew, renewal));
            }
        }

        public void Cancel(object key)
        {
            lock (_syncLock)
            {
                if (_renewals.TryGetValue(key, out var renewal))
                {
                    renewal.Cancellation.Cancel();
                }
            }
        }

        public Task StopAsync(object key) => StopAsync(new[] { key });

        public Task StopAsync(IEnumerable<object> keys)
        {
            lock (_syncLock)
            {
                var renewals = keys.Where(_renewals.ContainsKey).Select(key => _renewals[key]).Distinct().ToArray();
                foreach (var renewal in renewals)
                {
                    renewal.Cancellation.Cancel();
                }

                return Task.WhenAll(renewals.Select(renewal => renewal.Task));
            }
        }

        public Task StopAllAsync()
        {
            lock (_syncLock)
            {
                return StopAsync(_renewals.Keys.ToArray());
            }
        }

        private async Task RenewAsync(
            object key,
            ServiceBusReceiver receiver,
            Func<DateTimeOffset> lockedUntil,
            Func<CancellationToken, Task> renew,
            Renewal renewal)
        {
            var token = renewal.Cancellation.Token;
            try
            {
                while (!token.IsCancellationRequested && !receiver.IsClosed)
                {
                    await Task.Delay(CalculateRenewDelay(lockedUntil()), token).ConfigureAwait(false);
                    if (token.IsCancellationRequested || receiver.IsClosed)
                    {
                        break;
                    }

                    try
                    {
                        await renew(token).ConfigureAwait(false);
                    }
                    catch (OperationCanceledException) when (token.IsCancellationRequested)
                    {
                        break;
                    }
                    catch (Exception exception)
                    {
                        if (token.IsCancellationRequested)
                        {
                            break;
                        }

                        _logger.LogError(exception, "Automatic batch lock renewal failed for entity '{EntityPath}'.", receiver.EntityPath);
                        if (exception is not ServiceBusException { IsTransient: true })
                        {
                            break;
                        }

                        await Task.Delay(TimeSpan.FromSeconds(1), token).ConfigureAwait(false);
                    }
                }
            }
            catch (OperationCanceledException) when (token.IsCancellationRequested)
            {
                // Completion, the renewal budget, and listener shutdown all cancel renewal.
            }
            finally
            {
                lock (_syncLock)
                {
                    _renewals.Remove(key);
                    renewal.Cancellation.Dispose();
                }
            }
        }

        internal static TimeSpan CalculateRenewDelay(DateTimeOffset lockedUntil)
        {
            var remaining = lockedUntil - DateTimeOffset.UtcNow;
            var buffer = TimeSpan.FromTicks(Math.Min(remaining.Ticks / 2, TimeSpan.FromSeconds(10).Ticks));
            return TimeSpan.FromTicks(Math.Max(0, (remaining - buffer).Ticks));
        }

        private sealed class Renewal
        {
            public Renewal(CancellationTokenSource cancellation) => Cancellation = cancellation;

            public CancellationTokenSource Cancellation { get; }
            public Task Task { get; set; }
        }
    }
}
