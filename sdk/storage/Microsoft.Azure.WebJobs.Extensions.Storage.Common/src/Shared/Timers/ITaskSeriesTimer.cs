// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Timers
{
    internal interface ITaskSeriesTimer : IDisposable
    {
        void Start();

        Task StopAsync(CancellationToken cancellationToken);

        void Cancel();
    }
}
