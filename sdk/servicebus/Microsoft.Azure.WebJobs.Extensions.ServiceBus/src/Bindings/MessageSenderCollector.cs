// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using Azure.Messaging.ServiceBus;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal class MessageSenderCollector<T> : ICollector<T>
    {
        private readonly ServiceBusEntity _entity;
        private readonly IConverter<T, ServiceBusMessage> _converter;
        private readonly Guid _functionInstanceId;

        public MessageSenderCollector(ServiceBusEntity entity, IConverter<T, ServiceBusMessage> converter,
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

        public void Add(T item)
        {
            ServiceBusMessage message = _converter.Convert(item);

            if (message == null)
            {
                throw new InvalidOperationException("Cannot enqueue a null message instance.");
            }
            _entity.SendAndCreateEntityIfNotExistsAsync(message, _functionInstanceId, CancellationToken.None)
#pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult(). There are no synchronous methods in SB SDK, so we have to do sync over async to support this.
                .GetAwaiter().GetResult();
#pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
        }
    }
}
