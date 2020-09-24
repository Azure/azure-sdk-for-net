// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Azure.WebJobs.Host.Queues.Listeners;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Extensions.Logging;
using Azure.Storage.Queues;
using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    internal class BlobListenerFactory : IListenerFactory
    {
        private const string SingletonBlobListenerScopeId = "WebJobs.Internal.Blobs";
        private readonly IHostIdProvider _hostIdProvider;
        private readonly QueuesOptions _queueOptions;
        private readonly BlobsOptions _blobsOptions;
        private readonly IWebJobsExceptionHandler _exceptionHandler;
        private readonly IContextSetter<IBlobWrittenWatcher> _blobWrittenWatcherSetter;
        private readonly SharedQueueWatcher _messageEnqueuedWatcherSetter;
        private readonly ISharedContextProvider _sharedContextProvider;
        private readonly FunctionDescriptor _functionDescriptor;
        private readonly ILoggerFactory _loggerFactory;
        private readonly StorageAccount _hostAccount;
        private readonly StorageAccount _dataAccount;
        private readonly BlobContainerClient _container;
        private readonly IBlobPathSource _input;
        private readonly ITriggeredFunctionExecutor _executor;
        private readonly IHostSingletonManager _singletonManager;

        public BlobListenerFactory(IHostIdProvider hostIdProvider,
            QueuesOptions queueOptions,
            BlobsOptions blobsOptions,
            IWebJobsExceptionHandler exceptionHandler,
            IContextSetter<IBlobWrittenWatcher> blobWrittenWatcherSetter,
            SharedQueueWatcher messageEnqueuedWatcherSetter,
            ISharedContextProvider sharedContextProvider,
            ILoggerFactory loggerFactory,
            FunctionDescriptor functionDescriptor,
            StorageAccount hostAccount,
            StorageAccount dataAccount,
            BlobContainerClient container,
            IBlobPathSource input,
            ITriggeredFunctionExecutor executor,
            IHostSingletonManager singletonManager)
        {
            _hostIdProvider = hostIdProvider ?? throw new ArgumentNullException(nameof(hostIdProvider));
            _queueOptions = queueOptions ?? throw new ArgumentNullException(nameof(queueOptions));
            _blobsOptions = blobsOptions ?? throw new ArgumentNullException(nameof(blobsOptions));
            _exceptionHandler = exceptionHandler ?? throw new ArgumentNullException(nameof(exceptionHandler));
            _blobWrittenWatcherSetter = blobWrittenWatcherSetter ?? throw new ArgumentNullException(nameof(blobWrittenWatcherSetter));
            _messageEnqueuedWatcherSetter = messageEnqueuedWatcherSetter ?? throw new ArgumentNullException(nameof(messageEnqueuedWatcherSetter));
            _sharedContextProvider = sharedContextProvider ?? throw new ArgumentNullException(nameof(sharedContextProvider));
            _functionDescriptor = functionDescriptor ?? throw new ArgumentNullException(nameof(functionDescriptor));
            _loggerFactory = loggerFactory;
            _hostAccount = hostAccount ?? throw new ArgumentNullException(nameof(hostAccount));
            _dataAccount = dataAccount ?? throw new ArgumentNullException(nameof(dataAccount));
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _input = input ?? throw new ArgumentNullException(nameof(input));
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));
            _singletonManager = singletonManager ?? throw new ArgumentNullException(nameof(singletonManager));
        }

        public async Task<IListener> CreateAsync(CancellationToken cancellationToken)
        {
            // Note that these clients are intentionally for the storage account rather than for the dashboard account.
            // We use the storage, not dashboard, account for the blob receipt container and blob trigger queues.
            var primaryQueueClient = _hostAccount.CreateQueueServiceClient();
            var primaryBlobClient = _hostAccount.CreateBlobServiceClient();

            // Important: We're using the storage account of the function target here, which is the account that the
            // function the listener is for is targeting. This is the account that will be used
            // to read the trigger blob.
            var targetBlobClient = _dataAccount.CreateBlobServiceClient();
            var targetQueueClient = _dataAccount.CreateQueueServiceClient();

            string hostId = await _hostIdProvider.GetHostIdAsync(cancellationToken).ConfigureAwait(false);
            string hostBlobTriggerQueueName = HostQueueNames.GetHostBlobTriggerQueueName(hostId);
            var hostBlobTriggerQueue = primaryQueueClient.GetQueueClient(hostBlobTriggerQueueName);

            SharedQueueWatcher sharedQueueWatcher = _messageEnqueuedWatcherSetter;

            SharedBlobListener sharedBlobListener = _sharedContextProvider.GetOrCreateInstance<SharedBlobListener>(
                new SharedBlobListenerFactory(hostId, _hostAccount, _exceptionHandler, _blobWrittenWatcherSetter, _loggerFactory.CreateLogger<BlobListener>()));

            // Register the blob container we wish to monitor with the shared blob listener.
            await RegisterWithSharedBlobListenerAsync(hostId, sharedBlobListener, primaryBlobClient,
                hostBlobTriggerQueue, sharedQueueWatcher, cancellationToken).ConfigureAwait(false);

            // Create a "bridge" listener that will monitor the blob
            // notification queue and dispatch to the target job function.
            SharedBlobQueueListener sharedBlobQueueListener = _sharedContextProvider.GetOrCreateInstance<SharedBlobQueueListener>(
                new SharedBlobQueueListenerFactory(_hostAccount, sharedQueueWatcher, hostBlobTriggerQueue,
                    _queueOptions, _exceptionHandler, _loggerFactory, sharedBlobListener.BlobWritterWatcher, _functionDescriptor));
            var queueListener = new BlobListener(sharedBlobQueueListener);

            // determine which client to use for the poison queue
            // by default this should target the same storage account
            // as the blob container we're monitoring
            var poisonQueueClient = targetQueueClient;
            if (
                // _dataAccount.Type != StorageAccountType.GeneralPurpose || $$$
                _blobsOptions.CentralizedPoisonQueue)
            {
                // use the primary storage account if the centralize flag is true,
                // or if the target storage account doesn't support queues
                poisonQueueClient = primaryQueueClient;
            }

            // Register our function with the shared blob queue listener
            RegisterWithSharedBlobQueueListenerAsync(sharedBlobQueueListener, targetBlobClient, poisonQueueClient);

            // check a flag in the shared context to see if we've created the singleton
            // shared blob listener in this host instance
            object singletonListenerCreated = false;
            if (!_sharedContextProvider.TryGetValue(SingletonBlobListenerScopeId, out singletonListenerCreated))
            {
                // Create a singleton shared blob listener, since we only
                // want a single instance of the blob poll/scan logic to be running
                // across host instances
                var singletonBlobListener = _singletonManager.CreateHostSingletonListener(
                    new BlobListener(sharedBlobListener), SingletonBlobListenerScopeId);
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
            QueueClient hostBlobTriggerQueue,
            IMessageEnqueuedWatcher messageEnqueuedWatcher,
            CancellationToken cancellationToken)
        {
            BlobTriggerExecutor triggerExecutor = new BlobTriggerExecutor(hostId, _functionDescriptor, _input, new BlobReceiptManager(blobClient),
                new BlobTriggerQueueWriter(hostBlobTriggerQueue, messageEnqueuedWatcher), _loggerFactory.CreateLogger<BlobListener>());

            await sharedBlobListener.RegisterAsync(blobClient, _container, triggerExecutor, cancellationToken).ConfigureAwait(false);
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
        }
    }
}
