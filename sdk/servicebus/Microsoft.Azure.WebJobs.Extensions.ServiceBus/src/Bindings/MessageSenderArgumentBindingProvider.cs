// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus.Core;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal class MessageSenderArgumentBindingProvider : IQueueArgumentBindingProvider
    {
        public IArgumentBinding<ServiceBusEntity> TryCreate(ParameterInfo parameter)
        {
            if (parameter.ParameterType != typeof(MessageSender))
            {
                return null;
            }

            return new MessageSenderArgumentBinding();
        }

        internal class MessageSenderArgumentBinding : IArgumentBinding<ServiceBusEntity>
        {
            public Type ValueType
            {
                get { return typeof(MessageSender); }
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
                private readonly MessageSender _messageSender;

                public MessageSenderValueBinder(MessageSender messageSender)
                {
                    _messageSender = messageSender;
                }

                public static BindStepOrder StepOrder
                {
                    get { return BindStepOrder.Enqueue; }
                }

                public Type Type
                {
                    get { return typeof(MessageSender); }
                }

                public Task<object> GetValueAsync()
                {
                    return Task.FromResult<object>(_messageSender);
                }

                public string ToInvokeString()
                {
                    return _messageSender.Path;
                }

                public Task SetValueAsync(object value, CancellationToken cancellationToken)
                {
                    return Task.CompletedTask;
                }
            }
        }
    }
}
