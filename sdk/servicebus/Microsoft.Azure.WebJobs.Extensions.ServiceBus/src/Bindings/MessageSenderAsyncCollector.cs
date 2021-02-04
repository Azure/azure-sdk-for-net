// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal class MessageSenderAsyncCollector<T> : IAsyncCollector<T>
    {
        private readonly ServiceBusEntity _entity;
        private readonly IConverter<T, Message> _converter;
        private readonly Guid _functionInstanceId;

        public MessageSenderAsyncCollector(ServiceBusEntity entity, IConverter<T, Message> converter,
            Guid functionInstanceId)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (converter == null)
            {
                throw new ArgumentNullException(nameof(converter));
            }

            _entity = entity;
            _converter = converter;
            _functionInstanceId = functionInstanceId;
        }

        public Task AddAsync(T item, CancellationToken cancellationToken)
        {
            Message message = _converter.Convert(item);

            if (message == null)
            {
                throw new InvalidOperationException("Cannot enqueue a null brokered message instance.");
            }

            return _entity.SendAndCreateEntityIfNotExistsAsync(message, _functionInstanceId, cancellationToken);
        }

        public Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Batching not supported.
            return Task.FromResult(0);
        }
    }
}
