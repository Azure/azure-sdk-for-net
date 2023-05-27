// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Messaging.EventGrid;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using System;

namespace Microsoft.Azure.WebJobs.Extensions.EventGrid.Config
{
    internal class EventGridAsyncCollectorFactory
    {
        private readonly IConfiguration _configuration;
        private readonly AzureComponentFactory _componentFactory;

        protected EventGridAsyncCollectorFactory()
        { }

        public EventGridAsyncCollectorFactory(IConfiguration configuration, AzureComponentFactory componentFactory)
        {
            _configuration = configuration;
            _componentFactory = componentFactory;
        }

        internal void Validate(EventGridAttribute attribute)
        {
            if (!string.IsNullOrWhiteSpace(attribute.Connection))
            {
                if (attribute.TopicKeySetting != null)
                    throw new InvalidOperationException($"Conflicting Event Grid topic credentials have been set in '{nameof(EventGridAttribute.Connection)}' and '{nameof(EventGridAttribute.TopicKeySetting)}'");

                var connectionSection = _configuration.GetSection(attribute.Connection);
                if (!connectionSection.Exists())
                    throw new InvalidOperationException($"Event Grid topic connection string '{attribute.Connection}' does not exist. " +
                                                    $"Make sure that it is a defined App Setting.");

                if (!string.IsNullOrWhiteSpace(connectionSection.Value))
                {
                    if (!Uri.IsWellFormedUriString(connectionSection.Value, UriKind.Absolute))
                    {
                        throw new InvalidOperationException($"Event Grid topic connection string '{attribute.Connection}' must be a valid absolute Uri");
                    }

                    if (!string.IsNullOrWhiteSpace(attribute.TopicEndpointUri) && attribute.TopicEndpointUri != connectionSection.Value)
                    {
                        throw new InvalidOperationException($"Event Grid topic connection string '{attribute.Connection}' is set to a different Uri");
                    }
                }
            }
            else if (string.IsNullOrWhiteSpace(attribute.TopicEndpointUri))
            {
                throw new InvalidOperationException($"The '{nameof(EventGridAttribute.Connection)}' property or '{nameof(EventGridAttribute.TopicEndpointUri)}' property must be set");
            }
            else
            {
                // if app setting is missing, it will be caught by runtime
                // this logic tries to validate the practicality of attribute properties
                if (string.IsNullOrWhiteSpace(attribute.TopicKeySetting))
                {
                    throw new InvalidOperationException($"The '{nameof(EventGridAttribute.TopicKeySetting)}' property must be the name of an application setting containing the Topic Key");
                }

                if (!Uri.IsWellFormedUriString(attribute.TopicEndpointUri, UriKind.Absolute))
                {
                    throw new InvalidOperationException($"The '{nameof(EventGridAttribute.TopicEndpointUri)}' property must be a valid absolute Uri");
                }
            }
        }

        internal virtual IAsyncCollector<object> CreateCollector(EventGridAttribute attribute)
            => new EventGridAsyncCollector(CreateClient(attribute));

        private EventGridPublisherClient CreateClient(EventGridAttribute attribute)
        {
            if (string.IsNullOrWhiteSpace(attribute.Connection))
            {
                return new EventGridPublisherClient(new Uri(attribute.TopicEndpointUri), new AzureKeyCredential(attribute.TopicKeySetting));
            }

            var connectionSection = _configuration.GetSection(attribute.Connection);
            if (!string.IsNullOrWhiteSpace(connectionSection.Value))
            {
                return new EventGridPublisherClient(new Uri(connectionSection.Value), _componentFactory.CreateTokenCredential(connectionSection));
            }
            else
            {
                return new EventGridPublisherClient(new Uri(attribute.TopicEndpointUri), _componentFactory.CreateTokenCredential(connectionSection));
            }
        }
    }
}
