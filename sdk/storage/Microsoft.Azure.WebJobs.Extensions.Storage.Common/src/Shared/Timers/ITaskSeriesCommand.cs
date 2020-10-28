// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Timers
{
    internal interface ITaskSeriesCommand
    {
        Task<TaskSeriesCommandResult> ExecuteAsync(CancellationToken cancellationToken);
    }
}
