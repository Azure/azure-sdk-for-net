// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Hosting
{
    public class JobHostService : IHostedService
    {
        private readonly ILogger<JobHostService> _logger;
        private readonly IJobHost _jobHost;

        public JobHostService(IJobHost jobhost, ILogger<JobHostService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _jobHost = jobhost;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting JobHost");
            return _jobHost.StartAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping JobHost");
            return _jobHost.StopAsync();
        }
    }
}
