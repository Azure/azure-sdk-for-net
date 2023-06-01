// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Core;
using Azure.Messaging.EventGrid;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using System;

namespace Microsoft.Azure.WebJobs.Extensions.EventGrid.Config
{
    internal class EventGridAsyncCollectorFactory
    {
        private const string TopicEndpointUri = "topicEndpointUri";

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
            if (attribute.TopicKeySetting != null)
            {
                if (!string.IsNullOrWhiteSpace(attribute.Connection))
                {
                    throw new InvalidOperationException($"Conflicting topic credentials have been set in '{attribute.Connection}' and '{nameof(EventGridAttribute.TopicKeySetting)}'");
                }

                if (string.IsNullOrWhiteSpace(attribute.TopicKeySetting))
                {
                    throw new InvalidOperationException($"The '{nameof(EventGridAttribute.TopicKeySetting)}' property must be the name of an application setting containing the Topic Key");
                }
            }

            if (!string.IsNullOrWhiteSpace(attribute.Connection))
            {
                var connectionSection = _configuration.GetSection(attribute.Connection);
                if (!connectionSection.Exists())
                    throw new InvalidOperationException($"The topic endpoint uri in '{attribute.Connection}' does not exist. " +
                                                    $"Make sure that it is a defined App Setting.");

                var eventGridTopicUri = connectionSection[TopicEndpointUri];
                if (!string.IsNullOrWhiteSpace(eventGridTopicUri))
                {
                    if (!Uri.IsWellFormedUriString(eventGridTopicUri, UriKind.Absolute))
                    {
                        throw new InvalidOperationException($"The topic endpoint uri in '{attribute.Connection}' must be a valid absolute Uri");
                    }

                    if (!string.IsNullOrWhiteSpace(attribute.TopicEndpointUri) && eventGridTopicUri != attribute.TopicEndpointUri)
                    {
                        throw new InvalidOperationException($"Conflicting topic endpoint uris have been set in '{attribute.Connection}' and '{nameof(EventGridAttribute.TopicEndpointUri)}'");
                    }

                    return;
                }
            }

            if (!string.IsNullOrWhiteSpace(attribute.TopicEndpointUri))
            {
                if (!Uri.IsWellFormedUriString(attribute.TopicEndpointUri, UriKind.Absolute))
                {
                    throw new InvalidOperationException($"The '{nameof(EventGridAttribute.TopicEndpointUri)}' property must be a valid absolute Uri");
                }

                return;
            }

            throw new InvalidOperationException($"The '{nameof(EventGridAttribute.Connection)}.{TopicEndpointUri}' property or '{nameof(EventGridAttribute.TopicEndpointUri)}' property must be set");
        }

        internal virtual IAsyncCollector<object> CreateCollector(EventGridAttribute attribute)
            => new EventGridAsyncCollector(CreateClient(attribute));

        private EventGridPublisherClient CreateClient(EventGridAttribute attribute)
        {
            var connectionInformation = ResolveConnectionInformation(attribute);
            if (connectionInformation.AzureKeyCredential != null)
            {
                return new EventGridPublisherClient(connectionInformation.Endpoint, connectionInformation.AzureKeyCredential);
            }
            else
            {
                return new EventGridPublisherClient(connectionInformation.Endpoint, connectionInformation.TokenCredential);
            }
        }

        internal EventGridConnectionInformation ResolveConnectionInformation(EventGridAttribute attribute)
        {
            if (!string.IsNullOrWhiteSpace(attribute.TopicKeySetting))
            {
                return new EventGridConnectionInformation(new Uri(attribute.TopicEndpointUri), new AzureKeyCredential(attribute.TopicKeySetting));
            }

            if (string.IsNullOrWhiteSpace(attribute.Connection))
            {
                var emptyConfiguration = new ConfigurationBuilder().Build();
                return new EventGridConnectionInformation(new Uri(attribute.TopicEndpointUri), _componentFactory.CreateTokenCredential(emptyConfiguration));
            }

            var connectionSection = _configuration.GetSection(attribute.Connection);
            var topicEndpointUri = connectionSection[TopicEndpointUri];
            if (string.IsNullOrWhiteSpace(topicEndpointUri))
                topicEndpointUri = attribute.TopicEndpointUri;

            return new EventGridConnectionInformation(new Uri(topicEndpointUri), _componentFactory.CreateTokenCredential(connectionSection));
        }

        internal record EventGridConnectionInformation
        {
            public EventGridConnectionInformation(Uri endpoint, AzureKeyCredential azureKeyCredential)
            {
                Endpoint = endpoint;
                AzureKeyCredential = azureKeyCredential;
            }

            public EventGridConnectionInformation(Uri endpoint, TokenCredential tokenCredential)
            {
                Endpoint = endpoint;
                TokenCredential = tokenCredential;
            }

            public Uri Endpoint { get; }
            public AzureKeyCredential AzureKeyCredential { get; }
            public TokenCredential TokenCredential { get; }
        }
    }
}
