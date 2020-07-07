// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs
{
    public interface IJobHost
    {
        Task CallAsync(string name, IDictionary<string, object> arguments = null, CancellationToken cancellationToken = default(CancellationToken));

        Task StartAsync(CancellationToken cancellationToken);

        Task StopAsync();
    }
}