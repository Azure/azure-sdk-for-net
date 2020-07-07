// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host
{
    internal class DrainModeManager : IDrainModeManager
    {
        private readonly ILogger _logger;
        private ConcurrentDictionary<Guid, CancellationTokenSource> _cancellationTokenSources;

        public DrainModeManager(ILogger<DrainModeManager> logger)
        {
            _logger = logger;
            _cancellationTokenSources = new ConcurrentDictionary<Guid, CancellationTokenSource>();
        }

        public bool IsDrainModeEnabled { get; private set; } = false;

        public ICollection<IListener> Listeners { get; private set; } = new Collection<IListener>();

        public void RegisterListener(IListener listener)
        {
            Listeners.Add(listener);
        }

        public void RegisterTokenSource(Guid guid, CancellationTokenSource tokenSource)
        {
            _cancellationTokenSources.TryAdd(guid, tokenSource);
        }

        public void UnRegisterTokenSource(Guid guid)
        {
            _cancellationTokenSources.RemoveIfContainsKey(guid);
        }

        public async Task EnableDrainModeAsync(CancellationToken cancellationToken)
        {
            if (!IsDrainModeEnabled)
            {
                IsDrainModeEnabled = true;
                _logger.LogInformation("DrainMode mode enabled");

                CancelFunctionInvocations();

                List<Task> tasks = new List<Task>();

                _logger.LogInformation("Calling StopAsync on the registered listeners");
                foreach (IListener listener in Listeners)
                {
                    tasks.Add(listener.StopAsync(cancellationToken));
                }

                await Task.WhenAll(tasks);

                _logger.LogInformation("Call to StopAsync complete, registered listeners are now stopped");
            }
        }

        public void CancelFunctionInvocations()
        {
            foreach (var keyValuePair in _cancellationTokenSources)
            {
                string invocationId = keyValuePair.Key.ToString();
                try
                {
                    _logger?.LogInformation("Requesting cancellation for function invocation '{invocationId}'", invocationId);
                    keyValuePair.Value.Cancel();
                }
                catch (ObjectDisposedException)
                {
                    _logger?.LogInformation("Cancellation token for function invocation '{invocationId}' already disposed. No action required", invocationId);
                }
                catch (Exception exception)
                {
                    _logger?.LogError(exception, "Exception occured when attempting to request cancellation for function invocation '{invocationId}'", invocationId);
                }
            }
        }
    }
}