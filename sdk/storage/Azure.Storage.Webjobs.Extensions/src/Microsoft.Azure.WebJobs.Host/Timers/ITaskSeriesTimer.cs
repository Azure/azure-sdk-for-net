// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Timers
{
    internal interface ITaskSeriesTimer : IDisposable
    {
        void Start();

        Task StopAsync(CancellationToken cancellationToken);

        void Cancel();
    }
}
