﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Azure.WebJobs.Extensions.Storage.Blobs;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Blobs;
using Microsoft.Azure.WebJobs.Host.Blobs.Triggers;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Queues.Listeners;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Triggers
{
    internal class BlobTriggerAttributeBindingProvider : ITriggerBindingProvider
    {
        private readonly INameResolver _nameResolver;
        private readonly BlobServiceClientProvider _blobServiceClientProvider;
        private readonly QueueServiceClientProvider _queueServiceClientProvider;
        private readonly IHostIdProvider _hostIdProvider;
        private readonly QueuesOptions _queueOptions;
        private readonly BlobsOptions _blobsOptions;
        private readonly IWebJobsExceptionHandler _exceptionHandler;
        private readonly IContextSetter<IBlobWrittenWatcher> _blobWrittenWatcherSetter;
        private readonly SharedQueueWatcher _messageEnqueuedWatcherSetter;
        private readonly ISharedContextProvider _sharedContextProvider;
        private readonly IHostSingletonManager _singletonManager;
        private readonly ILoggerFactory _loggerFactory;

        public BlobTriggerAttributeBindingProvider(
            INameResolver nameResolver,
            BlobServiceClientProvider blobServiceClientProvider,
            QueueServiceClientProvider queueServiceClientProvider,
            IHostIdProvider hostIdProvider,
            IOptions<QueuesOptions> queueOptions,
            IOptions<BlobsOptions> blobsOptions,
            IWebJobsExceptionHandler exceptionHandler,
            IContextSetter<IBlobWrittenWatcher> blobWrittenWatcherSetter,
            SharedQueueWatcher messageEnqueuedWatcherSetter,
            ISharedContextProvider sharedContextProvider,
            IHostSingletonManager singletonManager,
            ILoggerFactory loggerFactory)
        {
            _blobServiceClientProvider = blobServiceClientProvider ?? throw new ArgumentNullException(nameof(blobServiceClientProvider));
            _queueServiceClientProvider = queueServiceClientProvider ?? throw new ArgumentNullException(nameof(queueServiceClientProvider));
            _hostIdProvider = hostIdProvider ?? throw new ArgumentNullException(nameof(hostIdProvider));
            _queueOptions = (queueOptions ?? throw new ArgumentNullException(nameof(queueOptions))).Value;
            _blobsOptions = (blobsOptions ?? throw new ArgumentNullException(nameof(blobsOptions))).Value;
            _exceptionHandler = exceptionHandler ?? throw new ArgumentNullException(nameof(exceptionHandler));
            _blobWrittenWatcherSetter = blobWrittenWatcherSetter ?? throw new ArgumentNullException(nameof(blobWrittenWatcherSetter));
            _messageEnqueuedWatcherSetter = messageEnqueuedWatcherSetter ?? throw new ArgumentNullException(nameof(messageEnqueuedWatcherSetter));
            _sharedContextProvider = sharedContextProvider ?? throw new ArgumentNullException(nameof(sharedContextProvider));
            _singletonManager = singletonManager ?? throw new ArgumentNullException(nameof(singletonManager));

            _nameResolver = nameResolver;
            _loggerFactory = loggerFactory;
        }

        public Task<ITriggerBinding> TryCreateAsync(TriggerBindingProviderContext context)
        {
            ParameterInfo parameter = context.Parameter;
            var blobTriggerAttribute = TypeUtility.GetResolvedAttribute<BlobTriggerAttribute>(context.Parameter);

            if (blobTriggerAttribute == null)
            {
                return Task.FromResult<ITriggerBinding>(null);
            }

            string resolvedCombinedPath = Resolve(blobTriggerAttribute.BlobPath);
            IBlobPathSource path = BlobPathSource.Create(resolvedCombinedPath);

            var hostBlobServiceClient = _blobServiceClientProvider.GetHost();
            var dataBlobServiceClient = _blobServiceClientProvider.Get(blobTriggerAttribute.Connection, _nameResolver);
            var hostQueueServiceClient = _queueServiceClientProvider.GetHost();
            var dataQueueServiceClient = _queueServiceClientProvider.Get(blobTriggerAttribute.Connection, _nameResolver);

            // premium does not support blob logs, so disallow for blob triggers
            // $$$
            // dataAccount.AssertTypeOneOf(StorageAccountType.GeneralPurpose, StorageAccountType.BlobOnly);

            ITriggerBinding binding = new BlobTriggerBinding(parameter, hostBlobServiceClient, hostQueueServiceClient,
                dataBlobServiceClient, dataQueueServiceClient, path,
                _hostIdProvider, _queueOptions, _blobsOptions, _exceptionHandler, _blobWrittenWatcherSetter,
                _messageEnqueuedWatcherSetter, _sharedContextProvider, _singletonManager, _loggerFactory);

            return Task.FromResult(binding);
        }

        private string Resolve(string queueName)
        {
            if (_nameResolver == null)
            {
                return queueName;
            }

            return _nameResolver.ResolveWholeString(queueName);
        }
    }
}
