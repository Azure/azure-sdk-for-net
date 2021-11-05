// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Executors;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners
{
    internal interface ITriggerExecutor<TTriggerValue>
    {
        Task<FunctionResult> ExecuteAsync(TTriggerValue value, CancellationToken cancellationToken);
    }
}
