// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal class MessageSenderArgumentBindingProvider : IQueueArgumentBindingProvider
    {
        public IArgumentBinding<ServiceBusEntity> TryCreate(ParameterInfo parameter)
        {
            if (parameter.ParameterType != typeof(ServiceBusSender))
            {
                return null;
            }

            return new MessageSenderArgumentBinding();
        }

        internal class MessageSenderArgumentBinding : IArgumentBinding<ServiceBusEntity>
        {
            public Type ValueType
            {
                get { return typeof(ServiceBusSender); }
            }

            public Task<IValueProvider> BindAsync(ServiceBusEntity value, ValueBindingContext context)
            {
                if (context == null)
                {
                    throw new ArgumentNullException(nameof(context));
                }

                IValueProvider provider = new MessageSenderValueBinder(value.MessageSender);

                return Task.FromResult(provider);
            }

            private class MessageSenderValueBinder : IValueBinder
            {
                private readonly ServiceBusSender _messageSender;

                public MessageSenderValueBinder(ServiceBusSender messageSender)
                {
                    _messageSender = messageSender;
                }

                public static BindStepOrder StepOrder
                {
                    get { return BindStepOrder.Enqueue; }
                }

                public Type Type
                {
                    get { return typeof(ServiceBusSender); }
                }

                public Task<object> GetValueAsync()
                {
                    return Task.FromResult<object>(_messageSender);
                }

                public string ToInvokeString()
                {
                    return _messageSender.EntityPath;
                }

                public Task SetValueAsync(object value, CancellationToken cancellationToken)
                {
                    return Task.CompletedTask;
                }
            }
        }
    }
}
