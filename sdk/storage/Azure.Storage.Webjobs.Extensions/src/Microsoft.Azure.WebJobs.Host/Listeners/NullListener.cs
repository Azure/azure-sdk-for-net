// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Listeners
{
    internal sealed class NullListener : IListener
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }

        public void Cancel()
        {
        }

        public void Dispose()
        {
        }
    }
}
