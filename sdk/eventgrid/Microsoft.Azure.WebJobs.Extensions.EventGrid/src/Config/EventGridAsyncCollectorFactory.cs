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

        internal const string MissingSettingsErrorMessage =
            "The required settings were not found. Either the 'TopicEndpointUri' and the 'TopicKeySetting' properties must be set," +
            " or the 'Connection' property must be set to the name of an application setting containing the Event" +
            " Grid connection information.";

        internal const string ConflictingSettingsErrorMessage =
            "When specifying the 'Connection' property, the 'TopicKeySetting' and 'TopicEndpointUri' properties should not be specified.";

        internal const string MissingTopicKeySettingErrorMessage =
            "The 'TopicKeySetting' property must be the name of an application setting containing the Topic Key.";

        internal const string MustBeValidAbsoluteUriErrorMessage =
            "The 'TopicEndpointUri' property must be a valid absolute Uri.";

        protected EventGridAsyncCollectorFactory()
        { }

        public EventGridAsyncCollectorFactory(IConfiguration configuration, AzureComponentFactory componentFactory)
        {
            _configuration = configuration;
            _componentFactory = componentFactory;
        }

        internal void Validate(EventGridAttribute attribute)
        {
            if (!string.IsNullOrWhiteSpace(attribute.TopicKeySetting) || !string.IsNullOrWhiteSpace(attribute.TopicEndpointUri))
            {
                if (!string.IsNullOrWhiteSpace(attribute.Connection))
                {
                    throw new InvalidOperationException(ConflictingSettingsErrorMessage);
                }
            }

            if (!string.IsNullOrWhiteSpace(attribute.Connection))
            {
                var connectionSection = _configuration.GetSection(attribute.Connection);
                if (!connectionSection.Exists())
                    throw new InvalidOperationException($"The '{attribute.Connection}' setting does not exist. " +
                                                    "Make sure that it is a defined App Setting.");

                var eventGridTopicUri = connectionSection[TopicEndpointUri];
                if (!string.IsNullOrWhiteSpace(eventGridTopicUri))
                {
                    if (!Uri.IsWellFormedUriString(eventGridTopicUri, UriKind.Absolute))
                    {
                        throw new InvalidOperationException($"The 'topicEndpointUri' in '{attribute.Connection}' must be a valid absolute Uri.");
                    }

                    return;
                }

                throw new InvalidOperationException($"The 'topicEndpointUri' was not specified in '{attribute.Connection}'.");
            }

            if (!string.IsNullOrWhiteSpace(attribute.TopicEndpointUri))
            {
                if (!Uri.IsWellFormedUriString(attribute.TopicEndpointUri, UriKind.Absolute))
                {
                    throw new InvalidOperationException(MustBeValidAbsoluteUriErrorMessage);
                }

                if (string.IsNullOrWhiteSpace(attribute.TopicKeySetting))
                {
                    throw new InvalidOperationException(MissingTopicKeySettingErrorMessage);
                }

                return;
            }

            throw new InvalidOperationException(MissingSettingsErrorMessage);
        }

        internal virtual IAsyncCollector<object> CreateCollector(EventGridAttribute attribute)
            => new EventGridAsyncCollector(CreateClient(attribute));

        internal EventGridPublisherClient CreateClient(EventGridAttribute attribute, EventGridPublisherClientOptions options = null)
        {
            var connectionInformation = ResolveConnectionInformation(attribute);
            if (connectionInformation.AzureKeyCredential != null)
            {
                return new EventGridPublisherClient(connectionInformation.Endpoint, connectionInformation.AzureKeyCredential, options);
            }
            else
            {
                return new EventGridPublisherClient(connectionInformation.Endpoint, connectionInformation.TokenCredential, options);
            }
        }

        internal EventGridConnectionInformation ResolveConnectionInformation(EventGridAttribute attribute)
        {
            if (!string.IsNullOrWhiteSpace(attribute.TopicKeySetting))
            {
                return new EventGridConnectionInformation(new Uri(attribute.TopicEndpointUri), new AzureKeyCredential(attribute.TopicKeySetting));
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
