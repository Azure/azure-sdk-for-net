// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.EventGrid.Config;
using Microsoft.Azure.WebJobs.Host.Executors;

namespace Microsoft.Azure.WebJobs.Extensions.EventGrid
{
    internal class EventGridListener : Host.Listeners.IListener
    {
        public ITriggeredFunctionExecutor Executor { get; private set; }
        public readonly bool SingleDispatch;
        public BindingType BindingType { get; }

        private EventGridExtensionConfigProvider _listenersStore;
        private readonly string _functionName;

        public EventGridListener(ITriggeredFunctionExecutor executor, EventGridExtensionConfigProvider listenersStore, string functionName, bool singleDispatch, BindingType bindingType)
        {
            _listenersStore = listenersStore;
            _functionName = functionName;
            SingleDispatch = singleDispatch;
            Executor = executor;
            BindingType = bindingType;

            // Register the listener as part of create time initialization
            _listenersStore.AddListener(_functionName, this);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }

        public void Dispose()
        {
        }

        public void Cancel()
        {
        }
    }
}
