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
#pragma warning disable SA1649 // File name should match first type name
    internal class OperationPoller<T> : OperationPoller
#pragma warning restore SA1649 // File name should match first type name
    {
        public OperationPoller(Response rawResponse, OperationPollingStrategy? defaultPollingStrategy = null) : base(rawResponse, defaultPollingStrategy)
        {
        }

        public virtual Response<T> WaitForCompletion(UpdateStatus updateStatus, HasCompleted hasCompleted, Value value, GetRawResponse getRawResponse, TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            while (true)
            {
                Response response = updateStatus(cancellationToken);

                if (hasCompleted())
                {
                    return Response.FromValue(value(), getRawResponse());
                }
                Thread.Sleep(_pollingStrategy.GetNextWait(response, pollingInterval));
            }
        }

        public virtual async ValueTask<Response<T>> WaitForCompletionAsync(UpdateStatusAsync updateStatusAsync, HasCompleted hasCompleted, Value value, GetRawResponse getRawResponse, WaitAsync waitAsync, TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            while (true)
            {
                Response response = await updateStatusAsync(cancellationToken).ConfigureAwait(false);
                if (hasCompleted())
                {
                    return Response.FromValue(value(), getRawResponse());
                }
                await waitAsync(_pollingStrategy.GetNextWait(response, pollingInterval), cancellationToken).ConfigureAwait(false);
            }
        }

        public delegate T Value();
    }
}
