// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host.Loggers;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Extensions.Logging;

namespace WebJobs.Host.Storage.Logging
{
    internal class DefaultLoggerProvider : IHostInstanceLoggerProvider, IFunctionInstanceLoggerProvider, IFunctionOutputLoggerProvider
    {
        private bool _loggersSet;
        private IHostInstanceLogger _hostInstanceLogger;
        private IFunctionInstanceLogger _functionInstanceLogger;
        private IFunctionOutputLogger _functionOutputLogger;
        private ILoggerFactory _loggerFactory;
        private StorageAccountOptions _storageAccountOptions;

        public DefaultLoggerProvider(StorageAccountOptions storageAccountOptions, ILoggerFactory loggerFactory)
        {
            _storageAccountOptions = storageAccountOptions;
            _loggerFactory = loggerFactory;
        }

        async Task<IHostInstanceLogger> IHostInstanceLoggerProvider.GetAsync(CancellationToken cancellationToken)
        {
            await EnsureLoggersAsync(cancellationToken);
            return _hostInstanceLogger;
        }

        async Task<IFunctionInstanceLogger> IFunctionInstanceLoggerProvider.GetAsync(CancellationToken cancellationToken)
        {
            await EnsureLoggersAsync(cancellationToken);
            return _functionInstanceLogger;
        }

        async Task<IFunctionOutputLogger> IFunctionOutputLoggerProvider.GetAsync(CancellationToken cancellationToken)
        {
            await EnsureLoggersAsync(cancellationToken);
            return _functionOutputLogger;
        }

        private void EnsureLoggers()
        {
            if (_loggersSet)
            {
                return;
            }

            IFunctionInstanceLogger functionLogger = new FunctionInstanceLogger(_loggerFactory);

            if (_storageAccountOptions.Dashboard != null)
            {
                var dashboardAccount = _storageAccountOptions.GetDashboardStorageAccount();
                DelegatingHandler delegatingHandler = _storageAccountOptions.DelegatingHandlerProvider?.Create();

                // Create logging against a live Azure account.
                var dashboardBlobClient = new CloudBlobClient(dashboardAccount.BlobStorageUri, dashboardAccount.Credentials, delegatingHandler);
                IPersistentQueueWriter<PersistentQueueMessage> queueWriter = new PersistentQueueWriter<PersistentQueueMessage>(dashboardBlobClient);
                PersistentQueueLogger queueLogger = new PersistentQueueLogger(queueWriter);
                _hostInstanceLogger = queueLogger;
                _functionInstanceLogger = new CompositeFunctionInstanceLogger(queueLogger, functionLogger);
                _functionOutputLogger = new BlobFunctionOutputLogger(dashboardBlobClient);
            }
            else
            {
                // No auxillary logging. Logging interfaces are nops or in-memory.
                _hostInstanceLogger = new NullHostInstanceLogger();
                _functionInstanceLogger = functionLogger;
                _functionOutputLogger = new NullFunctionOutputLogger();
            }

            _loggersSet = true;
        }
        private Task EnsureLoggersAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() => EnsureLoggers(), cancellationToken);
        }
    }
}
