// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs.Host.Bindings;
using System.Diagnostics;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal class ConverterValueBinder<TInput> : IOrderedValueBinder
    {
        private readonly ServiceBusEntity _entity;
        private readonly IConverter<TInput, Message> _converter;
        private readonly Guid _functionInstanceId;

        public ConverterValueBinder(ServiceBusEntity entity, IConverter<TInput, Message> converter,
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
            return Task.FromResult<object>(default(TInput));
        }

        public string ToInvokeString()
        {
            return _entity.MessageSender.Path;
        }

        public Task SetValueAsync(object value, CancellationToken cancellationToken)
        {
            Message message = _converter.Convert((TInput)value);
            Debug.Assert(message != null);
            return _entity.SendAndCreateEntityIfNotExistsAsync(message, _functionInstanceId, cancellationToken);
        }
    }
}
