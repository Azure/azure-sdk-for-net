// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Scale;
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
        private readonly BlobsOptions _blobsOptions;
        private readonly IWebJobsExceptionHandler _exceptionHandler;
        private readonly IContextSetter<IBlobWrittenWatcher> _blobWrittenWatcherSetter;
        private readonly BlobTriggerQueueWriterFactory _blobTriggerQueueWriterFactory;
        private readonly ISharedContextProvider _sharedContextProvider;
        private readonly IHostSingletonManager _singletonManager;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger _logger;
        private readonly ConcurrencyManager _concurrencyManager;
        private readonly IDrainModeManager _drainModeManager;

        public BlobTriggerAttributeBindingProvider(
            INameResolver nameResolver,
            BlobServiceClientProvider blobServiceClientProvider,
            QueueServiceClientProvider queueServiceClientProvider,
            IHostIdProvider hostIdProvider,
            IOptions<BlobsOptions> blobsOptions,
            IWebJobsExceptionHandler exceptionHandler,
            IContextSetter<IBlobWrittenWatcher> blobWrittenWatcherSetter,
            BlobTriggerQueueWriterFactory blobTriggerQueueWriterFactory,
            ISharedContextProvider sharedContextProvider,
            IHostSingletonManager singletonManager,
            ILoggerFactory loggerFactory,
            ConcurrencyManager concurrencyManager,
            IDrainModeManager drainModeManager)
        {
            _blobServiceClientProvider = blobServiceClientProvider ?? throw new ArgumentNullException(nameof(blobServiceClientProvider));
            _queueServiceClientProvider = queueServiceClientProvider ?? throw new ArgumentNullException(nameof(queueServiceClientProvider));
            _hostIdProvider = hostIdProvider ?? throw new ArgumentNullException(nameof(hostIdProvider));
            _blobsOptions = (blobsOptions ?? throw new ArgumentNullException(nameof(blobsOptions))).Value;
            _exceptionHandler = exceptionHandler ?? throw new ArgumentNullException(nameof(exceptionHandler));
            _blobWrittenWatcherSetter = blobWrittenWatcherSetter ?? throw new ArgumentNullException(nameof(blobWrittenWatcherSetter));
            _blobTriggerQueueWriterFactory = blobTriggerQueueWriterFactory ?? throw new ArgumentNullException(nameof(blobTriggerQueueWriterFactory));
            _sharedContextProvider = sharedContextProvider ?? throw new ArgumentNullException(nameof(sharedContextProvider));
            _singletonManager = singletonManager ?? throw new ArgumentNullException(nameof(singletonManager));
            _concurrencyManager = concurrencyManager ?? throw new ArgumentNullException(nameof(concurrencyManager));

            _nameResolver = nameResolver;
            _loggerFactory = loggerFactory;
            _logger = loggerFactory.CreateLogger<BlobTriggerAttributeBindingProvider>();
            _drainModeManager = drainModeManager;
        }

        public Task<ITriggerBinding> TryCreateAsync(TriggerBindingProviderContext context)
        {
            ParameterInfo parameter = context.Parameter;
            var blobTriggerAttribute = TypeUtility.GetResolvedAttribute<BlobTriggerAttribute>(context.Parameter);

            if (parameter.ParameterType == typeof(PageBlobClient) && blobTriggerAttribute.Source == BlobTriggerSource.EventGrid)
            {
                _logger.LogError($"PageBlobClient is not supported with {nameof(BlobTriggerSource.EventGrid)}");
                return Task.FromResult<ITriggerBinding>(null);
            }

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

            ITriggerBinding binding = new BlobTriggerBinding(
                parameter,
                hostBlobServiceClient,
                hostQueueServiceClient,
                dataBlobServiceClient,
                dataQueueServiceClient,
                path,
                blobTriggerAttribute.Source,
                _hostIdProvider,
                _blobsOptions,
                _exceptionHandler,
                _blobWrittenWatcherSetter,
                _blobTriggerQueueWriterFactory,
                _sharedContextProvider,
                _singletonManager,
                _loggerFactory,
                _concurrencyManager,
                _drainModeManager);

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
