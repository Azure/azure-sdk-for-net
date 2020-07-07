// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Hosting
{
    /// <summary>
    /// An <see cref="IHostedService"/> that streams logs from an <see cref="IOptionsLoggingSource"/> into an <see cref="ILogger"/>.
    /// </summary>
    internal class OptionsLoggingService : IHostedService
    {
        private readonly ILogger<OptionsLoggingService> _logger;
        private readonly IOptionsLoggingSource _source;
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        private Task _processingTask;

        public OptionsLoggingService(IOptionsLoggingSource source, ILogger<OptionsLoggingService> logger)
        {
            _logger = logger;
            _source = source;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _processingTask = ProcessLogs();
            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _cts.Cancel();
            await _processingTask;
        }

        private async Task ProcessLogs()
        {
            ISourceBlock<string> source = _source.LogStream;
            try
            {
                while (await source.OutputAvailableAsync(_cts.Token))
                {
                    _logger.LogInformation(await source.ReceiveAsync());
                }
            }
            catch (OperationCanceledException)
            {
                // This occurs during shutdown.
            }
        }
    }
}
