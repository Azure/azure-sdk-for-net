// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Host.Scale;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    internal class BlobListenerFactory : IListenerFactory
    {
        private const string SingletonBlobListenerScopeId = "WebJobs.Internal.Blobs";
        private readonly IHostIdProvider _hostIdProvider;
        private readonly BlobsOptions _blobsOptions;
        private readonly IWebJobsExceptionHandler _exceptionHandler;
        private readonly IContextSetter<IBlobWrittenWatcher> _blobWrittenWatcherSetter;
        private readonly BlobTriggerQueueWriterFactory _blobTriggerQueueWriterFactory;
        private readonly ISharedContextProvider _sharedContextProvider;
        private readonly FunctionDescriptor _functionDescriptor;
        private readonly ILoggerFactory _loggerFactory;
        private readonly BlobServiceClient _hostBlobServiceClient;
        private readonly QueueServiceClient _hostQueueServiceClient;
        private readonly BlobServiceClient _dataBlobServiceClient;
        private readonly QueueServiceClient _dataQueueServiceClient;
        private readonly BlobContainerClient _container;
        private readonly IBlobPathSource _input;
        private readonly BlobTriggerSource _blobTriggerSource;
        private readonly ITriggeredFunctionExecutor _executor;
        private readonly IHostSingletonManager _singletonManager;
        private readonly ConcurrencyManager _concurrencyManager;
        private readonly IDrainModeManager _drainModeManager;

        public BlobListenerFactory(
            IHostIdProvider hostIdProvider,
            BlobsOptions blobsOptions,
            IWebJobsExceptionHandler exceptionHandler,
            IContextSetter<IBlobWrittenWatcher> blobWrittenWatcherSetter,
            BlobTriggerQueueWriterFactory blobTriggerQueueWriterFactory,
            ISharedContextProvider sharedContextProvider,
            ILoggerFactory loggerFactory,
            FunctionDescriptor functionDescriptor,
            BlobServiceClient hostBlobServiceClient,
            QueueServiceClient hostQueueServiceClient,
            BlobServiceClient dataBlobServiceClient,
            QueueServiceClient dataQueueServiceClient,
            BlobContainerClient container,
            IBlobPathSource input,
            BlobTriggerSource triggerKind,
            ITriggeredFunctionExecutor executor,
            IHostSingletonManager singletonManager,
            ConcurrencyManager concurrencyManager,
            IDrainModeManager drainModeManager)
        {
            _hostIdProvider = hostIdProvider ?? throw new ArgumentNullException(nameof(hostIdProvider));
            _blobTriggerQueueWriterFactory = blobTriggerQueueWriterFactory ?? throw new ArgumentNullException(nameof(blobTriggerQueueWriterFactory));
            _blobsOptions = blobsOptions ?? throw new ArgumentNullException(nameof(blobsOptions));
            _exceptionHandler = exceptionHandler ?? throw new ArgumentNullException(nameof(exceptionHandler));
            _blobWrittenWatcherSetter = blobWrittenWatcherSetter ?? throw new ArgumentNullException(nameof(blobWrittenWatcherSetter));
            _sharedContextProvider = sharedContextProvider ?? throw new ArgumentNullException(nameof(sharedContextProvider));
            _functionDescriptor = functionDescriptor ?? throw new ArgumentNullException(nameof(functionDescriptor));
            _loggerFactory = loggerFactory;
            _hostBlobServiceClient = hostBlobServiceClient ?? throw new ArgumentNullException(nameof(hostBlobServiceClient));
            _hostQueueServiceClient = hostQueueServiceClient ?? throw new ArgumentNullException(nameof(hostQueueServiceClient));
            _dataBlobServiceClient = dataBlobServiceClient ?? throw new ArgumentNullException(nameof(dataBlobServiceClient));
            _dataQueueServiceClient = dataQueueServiceClient ?? throw new ArgumentNullException(nameof(dataQueueServiceClient));
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _input = input ?? throw new ArgumentNullException(nameof(input));
            _blobTriggerSource = triggerKind;
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));
            _singletonManager = singletonManager ?? throw new ArgumentNullException(nameof(singletonManager));
            _concurrencyManager = concurrencyManager ?? throw new ArgumentNullException(nameof(concurrencyManager));
            _drainModeManager = drainModeManager ?? throw new ArgumentNullException(nameof(drainModeManager));
        }

        public async Task<IListener> CreateAsync(CancellationToken cancellationToken)
        {
            // Note that these clients are intentionally for the storage account rather than for the dashboard account.
            // We use the storage, not dashboard, account for the blob receipt container and blob trigger queues.
            var primaryBlobClient = _hostBlobServiceClient;

            // Important: We're using the storage account of the function target here, which is the account that the
            // function the listener is for is targeting. This is the account that will be used
            // to read the trigger blob.
            var targetBlobClient = _dataBlobServiceClient;
            var targetQueueClient = _dataQueueServiceClient;

            BlobTriggerQueueWriter blobTriggerQueueWriter = await _blobTriggerQueueWriterFactory.CreateAsync(cancellationToken).ConfigureAwait(false);

            string hostId = await _hostIdProvider.GetHostIdAsync(cancellationToken).ConfigureAwait(false);

            SharedBlobListener sharedBlobListener = null;
            // we do not need to create SharedBlobListener for EventGrid blob trigger
            if (_blobTriggerSource == BlobTriggerSource.LogsAndContainerScan)
            {
                sharedBlobListener = _sharedContextProvider.GetOrCreateInstance<SharedBlobListener>(
                    new SharedBlobListenerFactory(hostId, _hostBlobServiceClient, _exceptionHandler, _blobWrittenWatcherSetter, _loggerFactory.CreateLogger<BlobListener>()));

                // Register the blob container we wish to monitor with the shared blob listener.
                await RegisterWithSharedBlobListenerAsync(
                    hostId,
                    sharedBlobListener,
                    targetBlobClient,
                    blobTriggerQueueWriter,
                    cancellationToken).ConfigureAwait(false);
            }

            // Create a "bridge" listener that will monitor the blob
            // notification queue and dispatch to the target job function.
            SharedBlobQueueListener sharedBlobQueueListener = _sharedContextProvider.GetOrCreateInstance<SharedBlobQueueListener>(
                new SharedBlobQueueListenerFactory(
                    _hostQueueServiceClient,
                    blobTriggerQueueWriter.SharedQueueWatcher,
                    blobTriggerQueueWriter.QueueClient,
                    _blobsOptions,
                    _exceptionHandler,
                    _loggerFactory,
                    sharedBlobListener?.BlobWritterWatcher,
                    _functionDescriptor,
                    _blobTriggerSource,
                    _concurrencyManager,
                    _drainModeManager));
            var queueListener = new BlobListener(sharedBlobQueueListener, _container, _input, _loggerFactory);

            // the client to use for the poison queue
            // by default this should target the same storage account
            // as the blob container we're monitoring
            var poisonQueueClient = targetQueueClient;

            // Register our function with the shared blob queue listener
            RegisterWithSharedBlobQueueListenerAsync(sharedBlobQueueListener, targetBlobClient, poisonQueueClient);

            // Check a flag in the shared context to see if we've created the singleton
            // shared blob listener in this host instance.
            // We do not need SharedBlobListener for EventGrid blob trigger.
            object singletonListenerCreated = false;
            if (_blobTriggerSource == BlobTriggerSource.LogsAndContainerScan
                && !_sharedContextProvider.TryGetValue(SingletonBlobListenerScopeId, out singletonListenerCreated))
            {
                // Create a singleton shared blob listener, since we only
                // want a single instance of the blob poll/scan logic to be running
                // across host instances
                var singletonBlobListener = _singletonManager.CreateHostSingletonListener(
                    new BlobListener(sharedBlobListener, _container, _input, _loggerFactory), SingletonBlobListenerScopeId);
                _sharedContextProvider.SetValue(SingletonBlobListenerScopeId, true);

                return new CompositeListener(singletonBlobListener, queueListener);
            }
            else
            {
                // We've already created the singleton blob listener
                // so just return our queue listener. Note that while we want the
                // blob scan to be singleton, the shared queue listener needs to run
                // on ALL instances so load can be scaled out
                return queueListener;
            }
        }

        private async Task RegisterWithSharedBlobListenerAsync(
            string hostId,
            SharedBlobListener sharedBlobListener,
            BlobServiceClient blobClient,
            BlobTriggerQueueWriter blobTriggerQueueWriter,
            CancellationToken cancellationToken)
        {
            BlobTriggerExecutor triggerExecutor = new BlobTriggerExecutor(hostId, _functionDescriptor, _input, new BlobReceiptManager(blobClient),
                blobTriggerQueueWriter, _loggerFactory.CreateLogger<BlobListener>());

            await sharedBlobListener.RegisterAsync(
                blobClient,
                _container,
                triggerExecutor,
                cancellationToken).ConfigureAwait(false);
        }

        private void RegisterWithSharedBlobQueueListenerAsync(
            SharedBlobQueueListener sharedBlobQueueListener,
            BlobServiceClient blobClient,
            QueueServiceClient queueClient)
        {
            BlobQueueRegistration registration = new BlobQueueRegistration
            {
                Executor = _executor,
                BlobServiceClient = blobClient,
                QueueServiceClient = queueClient
            };

            sharedBlobQueueListener.Register(_functionDescriptor.Id, registration);
            sharedBlobQueueListener.Register(_functionDescriptor.ShortName, registration);
        }
    }
}
