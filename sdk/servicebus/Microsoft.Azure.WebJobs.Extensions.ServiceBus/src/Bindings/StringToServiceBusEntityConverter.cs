// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus.Core;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal class StringToServiceBusEntityConverter : IAsyncConverter<string, ServiceBusEntity>
    {
        private readonly ServiceBusAccount _account;
        private readonly IBindableServiceBusPath _defaultPath;
        private readonly EntityType _entityType;
        private readonly MessagingProvider _messagingProvider;

        public StringToServiceBusEntityConverter(ServiceBusAccount account, IBindableServiceBusPath defaultPath, EntityType entityType, MessagingProvider messagingProvider)
        {
            _account = account;
            _defaultPath = defaultPath;
            _entityType = entityType;
            _messagingProvider = messagingProvider;
        }

        public Task<ServiceBusEntity> ConvertAsync(string input, CancellationToken cancellationToken)
        {
            string queueOrTopicName;

            // For convenience, treat an an empty string as a request for the default value.
            if (String.IsNullOrEmpty(input) && _defaultPath.IsBound)
            {
                queueOrTopicName = _defaultPath.Bind(null);
            }
            else
            {
                queueOrTopicName = input;
            }

            cancellationToken.ThrowIfCancellationRequested();
            var messageSender = _messagingProvider.CreateMessageSender(queueOrTopicName, _account.ConnectionString);

            var entity = new ServiceBusEntity
            {
                MessageSender = messageSender,
                EntityType = _entityType
            };

            return Task.FromResult(entity);
        }
    }
}
