// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    internal class SharedBlobListenerFactory : IFactory<SharedBlobListener>
    {
        private readonly StorageAccount _account;
        private readonly IWebJobsExceptionHandler _exceptionHandler;
        private readonly IContextSetter<IBlobWrittenWatcher> _blobWrittenWatcherSetter;
        private readonly ILogger<BlobListener> _logger;
        private readonly string _hostId;

        public SharedBlobListenerFactory(string hostId, StorageAccount account,
            IWebJobsExceptionHandler exceptionHandler,
            IContextSetter<IBlobWrittenWatcher> blobWrittenWatcherSetter,
            ILogger<BlobListener> logger)
        {
            _account = account ?? throw new ArgumentNullException(nameof(account));
            _exceptionHandler = exceptionHandler ?? throw new ArgumentNullException(nameof(exceptionHandler));
            _blobWrittenWatcherSetter = blobWrittenWatcherSetter ?? throw new ArgumentNullException(nameof(blobWrittenWatcherSetter));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _hostId = hostId;
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public SharedBlobListener Create()
        {
            SharedBlobListener listener = new SharedBlobListener(_hostId, _account, _exceptionHandler, _logger);
            _blobWrittenWatcherSetter.SetValue(listener.BlobWritterWatcher);
            return listener;
        }
    }
}
