// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Dispatch;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Indexers;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Loggers;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Queues.Listeners;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Extensions.Logging;

namespace WebJobs.Host.Storage.Logging
{
    // $$$ 
    // Wires up V1 dashboard logging 
    internal class DashboardLoggingSetup : IDashboardLoggingSetup
    {
        private readonly IWebJobsExceptionHandler _exceptionHandler;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IFunctionInstanceLogger _functionInstanceLogger;
        private readonly IFunctionExecutor _functionExecutor;
        private readonly SharedQueueHandler _sharedQueueHandler;
        private readonly ILoadBalancerQueue _queueFactory;
        private readonly StorageAccountOptions _storageAccountOptions;

        public DashboardLoggingSetup(
            StorageAccountOptions storageAccountOptions,
            IWebJobsExceptionHandler exceptionHandler,
            ILoggerFactory loggerFactory,
            IFunctionInstanceLogger functionInstanceLogger,
            IFunctionExecutor functionExecutor,
            SharedQueueHandler sharedQueueHandler,
            ILoadBalancerQueue queueFactory
            )
        {
            _storageAccountOptions = storageAccountOptions;
            _exceptionHandler = exceptionHandler;
            _loggerFactory = loggerFactory;
            _functionInstanceLogger = functionInstanceLogger;
            _functionExecutor = functionExecutor;
            _sharedQueueHandler = sharedQueueHandler;
            _queueFactory = queueFactory;
        }

        public bool Setup(
            IFunctionIndex functions,
            IListenerFactory functionsListenerFactory,
            out IFunctionExecutor hostCallExecutor,
            out IListener listener,
            out HostOutputMessage hostOutputMessage,
            string hostId,
            CancellationToken shutdownToken)
        {
            string sharedQueueName = HostQueueNames.GetHostQueueName(hostId);
            var sharedQueue = sharedQueueName;

            IListenerFactory sharedQueueListenerFactory = new HostMessageListenerFactory(_queueFactory, sharedQueue,
                 _exceptionHandler, _loggerFactory, functions,
                _functionInstanceLogger, _functionExecutor);

            Guid hostInstanceId = Guid.NewGuid();
            string instanceQueueName = HostQueueNames.GetHostQueueName(hostInstanceId.ToString("N"));
            var instanceQueue = instanceQueueName;
            IListenerFactory instanceQueueListenerFactory = new HostMessageListenerFactory(_queueFactory, instanceQueue,
                _exceptionHandler, _loggerFactory, functions,
                _functionInstanceLogger, _functionExecutor);

            HeartbeatDescriptor heartbeatDescriptor = new HeartbeatDescriptor
            {
                SharedContainerName = HostContainerNames.Hosts,
                SharedDirectoryName = HostDirectoryNames.Heartbeats + "/" + hostId,
                InstanceBlobName = hostInstanceId.ToString("N"),
                ExpirationInSeconds = (int)HeartbeatIntervals.ExpirationInterval.TotalSeconds
            };

            var dashboardAccount = _storageAccountOptions.GetDashboardStorageAccount();
            DelegatingHandler delegatingHandler = _storageAccountOptions.DelegatingHandlerProvider?.Create();

            var blob = new CloudBlobClient(dashboardAccount.BlobStorageUri, dashboardAccount.Credentials, delegatingHandler)
                .GetContainerReference(heartbeatDescriptor.SharedContainerName)
                .GetBlockBlobReference(heartbeatDescriptor.SharedDirectoryName + "/" + heartbeatDescriptor.InstanceBlobName);
            IRecurrentCommand heartbeatCommand = new UpdateHostHeartbeatCommand(new HeartbeatCommand(blob));

            IEnumerable<MethodInfo> indexedMethods = functions.ReadAllMethods();
            Assembly hostAssembly = JobHostContextFactory.GetHostAssembly(indexedMethods);
            string displayName = hostAssembly != null ? AssemblyNameCache.GetName(hostAssembly).Name : "Unknown";

            hostOutputMessage = new JobHostContextFactory.DataOnlyHostOutputMessage
            {
                HostInstanceId = hostInstanceId,
                HostDisplayName = displayName,
                SharedQueueName = sharedQueueName,
                InstanceQueueName = instanceQueueName,
                Heartbeat = heartbeatDescriptor,
                WebJobRunIdentifier = WebJobRunIdentifier.Current
            };

            hostCallExecutor = JobHostContextFactory.CreateHostCallExecutor(instanceQueueListenerFactory, heartbeatCommand,
                _exceptionHandler, shutdownToken, _functionExecutor);
            IListenerFactory hostListenerFactory = new CompositeListenerFactory(functionsListenerFactory,
                sharedQueueListenerFactory, instanceQueueListenerFactory);
            listener = JobHostContextFactory.CreateHostListener(hostListenerFactory, _sharedQueueHandler, heartbeatCommand, _exceptionHandler, shutdownToken);

            return true;
        }
    }
}
