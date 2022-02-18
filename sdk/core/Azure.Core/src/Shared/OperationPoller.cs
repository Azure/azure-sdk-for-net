// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    /// <summary>
    /// Implementation of LRO polling logic.
    /// </summary>
    internal class OperationPoller
    {
        protected static readonly OperationPollingStrategy DefaultPollingStrategy = new ConstantPollingStrategy();
        protected OperationPollingStrategy _pollingStrategy;

        public OperationPoller(Response rawResponse, OperationPollingStrategy? defaultPollingStrategy = null)
        {
            _pollingStrategy = OperationPollingStrategy.ChoosePollingStrategy(rawResponse, defaultPollingStrategy ?? DefaultPollingStrategy);
        }

        public virtual async ValueTask<Response> WaitForCompletionResponseAsync(UpdateStatusAsync updateStatusAsync, HasCompleted hasCompleted, GetRawResponse getRawResponse, WaitAsync waitAsync, TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            while (true)
            {
                Response response = await updateStatusAsync(cancellationToken).ConfigureAwait(false);

                if (hasCompleted())
                {
                    return getRawResponse();
                }

                await waitAsync(_pollingStrategy.GetNextWait(response, pollingInterval), cancellationToken).ConfigureAwait(false);
            }
        }

        public virtual Response WaitForCompletionResponse(UpdateStatus updateStatus, HasCompleted hasCompleted, GetRawResponse getRawResponse, TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            while (true)
            {
                Response response = updateStatus(cancellationToken);

                if (hasCompleted())
                {
                    return getRawResponse();
                }
                Thread.Sleep(_pollingStrategy.GetNextWait(response, pollingInterval));
            }
        }

        public delegate Response UpdateStatus(CancellationToken cancellationToken = default);

        public delegate ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken);

        public delegate bool HasCompleted();

        public delegate Response GetRawResponse();

        public delegate Task WaitAsync(TimeSpan delay, CancellationToken cancellationToken);
    }
}
