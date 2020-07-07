// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Loggers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WebJobs.Host.Storage.Logging
{
    internal sealed class LoggerProviderFactory
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly bool _hasFastTableHook;
        private readonly Lazy<object> _loggerProvider;
        private readonly StorageAccountOptions _storageAccountOptions;

        public LoggerProviderFactory(
            IOptions<StorageAccountOptions> storageAccountOptions,
            ILoggerFactory loggerFactory,
            IEventCollectorFactory fastLoggerFactory = null)
        {
            _storageAccountOptions = storageAccountOptions.Value;
            _loggerFactory = loggerFactory;
            _hasFastTableHook = fastLoggerFactory != null;

            _loggerProvider = new Lazy<object>(CreateLoggerProvider);
        }

        private object CreateLoggerProvider()
        {
            // $$$ if this is null, we should have registered different DI components
            bool noDashboardStorage = _storageAccountOptions.Dashboard == null; 
            
            if (_hasFastTableHook && noDashboardStorage)
            {
                return new FastTableLoggerProvider(_loggerFactory);
            }

            return new DefaultLoggerProvider(_storageAccountOptions, _loggerFactory);
        }

        public T GetLoggerProvider<T>() where T : class => _loggerProvider.Value as T;
    }
}
