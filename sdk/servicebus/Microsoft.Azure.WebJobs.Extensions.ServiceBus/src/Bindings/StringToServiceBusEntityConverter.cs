// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal class StringToServiceBusEntityConverter : IAsyncConverter<string, ServiceBusEntity>
    {
        private readonly ServiceBusAttribute _attribute;
        private readonly IBindableServiceBusPath _defaultPath;
        private readonly EntityType _entityType;
        private readonly ServiceBusClientFactory _clientFactory;

        public StringToServiceBusEntityConverter(ServiceBusAttribute attribute, IBindableServiceBusPath defaultPath, ServiceBusClientFactory clientFactory)
        {
            _attribute = attribute;
            _defaultPath = defaultPath;
            _entityType = _attribute.EntityType;
            _clientFactory = clientFactory;
        }

        public Task<ServiceBusEntity> ConvertAsync(string input, CancellationToken cancellationToken)
        {
            string queueOrTopicName;

            // For convenience, treat an an empty string as a request for the default value.
            if (string.IsNullOrEmpty(input) && _defaultPath.IsBound)
            {
                queueOrTopicName = _defaultPath.Bind(null);
            }
            else
            {
                queueOrTopicName = input;
            }

            cancellationToken.ThrowIfCancellationRequested();
            var messageSender = _clientFactory.CreateMessageSender(queueOrTopicName, _attribute.Connection);

            var entity = new ServiceBusEntity
            {
                MessageSender = messageSender,
                EntityType = _entityType
            };

            return Task.FromResult(entity);
        }
    }
}
