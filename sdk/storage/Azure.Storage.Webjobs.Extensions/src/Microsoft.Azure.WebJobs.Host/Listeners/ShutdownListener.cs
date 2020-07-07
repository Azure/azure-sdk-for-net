// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Listeners
{
    internal class ShutdownListener : IListener
    {
        private readonly CancellationToken _shutdownToken;
        private readonly CancellationTokenRegistration _shutdownRegistration;
        private readonly IListener _innerListener;

        private bool _disposed;

        public ShutdownListener(CancellationToken shutdownToken, IListener innerListener)
        {
            _shutdownToken = shutdownToken;
            _shutdownRegistration = shutdownToken.Register(Cancel);
            _innerListener = innerListener;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (CancellationTokenSource combinedCancellationSource = CancellationTokenSource.CreateLinkedTokenSource(
                cancellationToken, _shutdownToken))
            {
                await _innerListener.StartAsync(combinedCancellationSource.Token);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return _innerListener.StopAsync(cancellationToken);
        }

        public void Cancel()
        {
            _innerListener.Cancel();
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _shutdownRegistration.Dispose();
                _innerListener.Dispose();

                _disposed = true;
            }
        }
    }
}
