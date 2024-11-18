// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
{
    internal class WebPubSubForSocketIOListener : IListener
    {
        public ITriggeredFunctionExecutor Executor { get; private set; }

        public WebPubSubValidationOptions ValidationOptions { get; }

        private readonly SocketIOTriggerKey _listenerKey;
        private readonly IWebPubSubForSocketIOTriggerDispatcher _dispatcher;

        public WebPubSubForSocketIOListener(ITriggeredFunctionExecutor executor, SocketIOTriggerKey listenerKey, IWebPubSubForSocketIOTriggerDispatcher dispatcher, WebPubSubValidationOptions validationOptions)
        {
            _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
            _listenerKey = listenerKey;
            Executor = executor ?? throw new ArgumentNullException(nameof(executor));
            ValidationOptions = validationOptions;
        }

        public void Cancel()
        {
        }

        public void Dispose()
        {
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _dispatcher.AddListener(_listenerKey, this);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
