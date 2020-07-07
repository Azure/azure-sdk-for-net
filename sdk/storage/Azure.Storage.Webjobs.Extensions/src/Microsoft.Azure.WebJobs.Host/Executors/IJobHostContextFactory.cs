// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    public interface IJobHostContextFactory
    {
        Task<JobHostContext> Create(JobHost host, CancellationToken shutdownToken, CancellationToken cancellationToken);
    }
}
