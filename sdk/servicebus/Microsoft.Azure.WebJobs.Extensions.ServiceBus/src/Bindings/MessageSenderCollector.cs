// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using Microsoft.Azure.WebJobs.Host.Converters;
using Microsoft.Azure.ServiceBus;
using Azure.Core.Pipeline;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal class MessageSenderCollector<T> : ICollector<T>
    {
        private readonly ServiceBusEntity _entity;
        private readonly IConverter<T, Message> _converter;
        private readonly Guid _functionInstanceId;

        public MessageSenderCollector(ServiceBusEntity entity, IConverter<T, Message> converter,
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
            Message message = _converter.Convert(item);

            if (message == null)
            {
                throw new InvalidOperationException("Cannot enqueue a null brokered message instance.");
            }
#pragma warning disable AZC0106
            _entity.SendAndCreateEntityIfNotExistsAsync(message, _functionInstanceId,
                CancellationToken.None).EnsureCompleted();
#pragma warning restore AZC0106
        }
    }
}
