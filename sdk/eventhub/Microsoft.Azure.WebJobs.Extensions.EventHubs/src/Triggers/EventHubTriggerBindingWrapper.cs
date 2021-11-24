// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Triggers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.EventHubs
{
    [SupportsRetry]
    internal class EventHubTriggerBindingWrapper : ITriggerBinding
    {
        private readonly ITriggerBinding _innerTriggerBinding;

        public EventHubTriggerBindingWrapper(ITriggerBinding triggerBinding)
        {
            _innerTriggerBinding = triggerBinding;
        }

        public Type TriggerValueType => _innerTriggerBinding.TriggerValueType;

        public IReadOnlyDictionary<string, Type> BindingDataContract => _innerTriggerBinding.BindingDataContract;

        public Task<ITriggerData> BindAsync(object value, ValueBindingContext context)
        {
            return _innerTriggerBinding.BindAsync(value, context);
        }

        public Task<IListener> CreateListenerAsync(ListenerFactoryContext context)
        {
            return _innerTriggerBinding.CreateListenerAsync(context);
        }

        public ParameterDescriptor ToParameterDescriptor()
        {
            return _innerTriggerBinding.ToParameterDescriptor();
        }
    }
}
