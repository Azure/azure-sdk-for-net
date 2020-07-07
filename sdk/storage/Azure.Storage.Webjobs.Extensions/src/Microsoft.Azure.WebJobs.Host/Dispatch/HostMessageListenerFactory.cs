// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Indexers;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Loggers;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Host.Queues.Listeners
{
    internal class HostMessageListenerFactory : IListenerFactory
    {
        private readonly string _queueName;
        private readonly IWebJobsExceptionHandler _exceptionHandler;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IFunctionIndexLookup _functionLookup;
        private readonly IFunctionInstanceLogger _functionInstanceLogger;
        private readonly IFunctionExecutor _executor;
        private readonly ILoadBalancerQueue _queueFactory;

        public HostMessageListenerFactory(
            ILoadBalancerQueue queueFactory,
            string queueName,
            IWebJobsExceptionHandler exceptionHandler,
            ILoggerFactory loggerFactory,
            IFunctionIndexLookup functionLookup,
            IFunctionInstanceLogger functionInstanceLogger,
            IFunctionExecutor executor)
        {
            _queueName = queueName ?? throw new ArgumentNullException(nameof(queueName));
            _queueFactory = queueFactory ?? throw new ArgumentNullException(nameof(queueFactory));
            _exceptionHandler = exceptionHandler ?? throw new ArgumentNullException(nameof(exceptionHandler));
            _functionLookup = functionLookup ?? throw new ArgumentNullException(nameof(functionLookup));
            _functionInstanceLogger = functionInstanceLogger ?? throw new ArgumentNullException(nameof(functionInstanceLogger));
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));

            _loggerFactory = loggerFactory;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public Task<IListener> CreateAsync(CancellationToken cancellationToken)
        {
            var triggerExecutor = new HostMessageExecutor(_executor, _functionLookup, _functionInstanceLogger);

            IListener listener = _queueFactory.CreateQueueListenr(_queueName, null, triggerExecutor.ExecuteAsync);
    
            return Task.FromResult(listener);
        }
    }
}
