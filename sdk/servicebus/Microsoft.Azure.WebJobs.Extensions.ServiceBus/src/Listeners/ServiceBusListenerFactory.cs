// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.ServiceBus.Listeners
{
    internal class ServiceBusListenerFactory : IListenerFactory
    {
        private readonly ServiceBusAccount _account;
        private readonly EntityType _entityType;
        private readonly string _entityPath;
        private readonly bool _isSessionsEnabled;
        private readonly ITriggeredFunctionExecutor _executor;
        private readonly FunctionDescriptor _descriptor;
        private readonly ServiceBusOptions _options;
        private readonly MessagingProvider _messagingProvider;
        private readonly ILoggerFactory _loggerFactory;
        private readonly bool _singleDispatch;

        public ServiceBusListenerFactory(ServiceBusAccount account, EntityType entityType, string entityPath, bool isSessionsEnabled, ITriggeredFunctionExecutor executor,
            FunctionDescriptor descriptor, ServiceBusOptions options, MessagingProvider messagingProvider, ILoggerFactory loggerFactory, bool singleDispatch)
        {
            _account = account;
            _entityType = entityType;
            _entityPath = entityPath;
            _isSessionsEnabled = isSessionsEnabled;
            _executor = executor;
            _descriptor = descriptor;
            _options = options;
            _messagingProvider = messagingProvider;
            _loggerFactory = loggerFactory;
            _singleDispatch = singleDispatch;
        }

        public Task<IListener> CreateAsync(CancellationToken cancellationToken)
        {
            var listener = new ServiceBusListener(_descriptor.Id, _entityType, _entityPath, _isSessionsEnabled, _executor, _options, _account, _messagingProvider, _loggerFactory, _singleDispatch);
            return Task.FromResult<IListener>(listener);
        }
    }
}
