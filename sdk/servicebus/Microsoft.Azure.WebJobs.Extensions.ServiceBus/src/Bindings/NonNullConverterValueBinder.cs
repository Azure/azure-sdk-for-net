// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    // Same as ConverterValueBinder, but doesn't enqueue null values.
    internal class NonNullConverterValueBinder<TInput> : IOrderedValueBinder
    {
        private readonly ServiceBusEntity _entity;
        private readonly IConverter<TInput, Message> _converter;
        private readonly Guid _functionInstanceId;

        public NonNullConverterValueBinder(ServiceBusEntity entity, IConverter<TInput, Message> converter,
            Guid functionInstanceId)
        {
            _entity = entity;
            _converter = converter;
            _functionInstanceId = functionInstanceId;
        }

        public BindStepOrder StepOrder
        {
            get { return BindStepOrder.Enqueue; }
        }

        public Type Type
        {
            get { return typeof(TInput); }
        }

        public Task<object> GetValueAsync()
        {
            return Task.FromResult<object>(null);
        }

        public string ToInvokeString()
        {
            return _entity.MessageSender.Path;
        }

        public Task SetValueAsync(object value, CancellationToken cancellationToken)
        {
            if (value == null)
            {
                return Task.FromResult(0);
            }

            Debug.Assert(value is TInput);
            Message message = _converter.Convert((TInput)value);
            Debug.Assert(message != null);

            return _entity.SendAndCreateEntityIfNotExistsAsync(message, _functionInstanceId, cancellationToken);
        }
    }
}
