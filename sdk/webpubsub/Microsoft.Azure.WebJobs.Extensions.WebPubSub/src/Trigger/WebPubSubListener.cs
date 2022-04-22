// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal class WebPubSubListener : IListener
    {
        public ITriggeredFunctionExecutor Executor { get; private set; }

        public WebPubSubValidationOptions ValidationOptions { get; }

        private readonly string _listenerKey;
        private readonly IWebPubSubTriggerDispatcher _dispatcher;

        public WebPubSubListener(ITriggeredFunctionExecutor executor, string listenerKey, IWebPubSubTriggerDispatcher dispatcher, WebPubSubValidationOptions validationOptions)
        {
            _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
            _listenerKey = listenerKey ?? throw new ArgumentNullException(nameof(listenerKey));
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
