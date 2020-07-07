// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    internal class ShutdownFunctionExecutor : IFunctionExecutor
    {
        private readonly CancellationToken _shutdownToken;
        private readonly IFunctionExecutor _innerExecutor;

        public ShutdownFunctionExecutor(CancellationToken shutdownToken, IFunctionExecutor innerExecutor)
        {
            _shutdownToken = shutdownToken;
            _innerExecutor = innerExecutor;
        }

        public async Task<IDelayedException> TryExecuteAsync(IFunctionInstance instance, CancellationToken cancellationToken)
        {
            using (CancellationTokenSource callCancellationSource = CancellationTokenSource.CreateLinkedTokenSource(
                _shutdownToken, cancellationToken))
            {
                return await _innerExecutor.TryExecuteAsync(instance, callCancellationSource.Token);
            }
        }
    }
}
