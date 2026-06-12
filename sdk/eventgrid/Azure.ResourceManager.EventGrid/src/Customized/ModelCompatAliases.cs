#pragma warning disable CS1591
#pragma warning disable SA1402

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.EventGrid.Models
{
    public partial class EventSubscriptionIdentity
    {
        [WirePath("type")]
        public EventSubscriptionIdentityType? IdentityType
        {
            get => Type;
            set => Type = value;
        }
    }

    public partial class NamespaceTopicEventSubscriptionPatch
    {
        [WirePath("properties.expirationTimeUtc")]
        public DateTimeOffset? ExpireOn
        {
            get => ExpirationTimeUtc;
            set => ExpirationTimeUtc = value;
        }
    }

    public partial class PartnerNamespaceChannelPatch
    {
        [WirePath("properties.expirationTimeIfNotActivatedUtc")]
        public DateTimeOffset? ExpireOnIfNotActivated
        {
            get => ExpirationTimeIfNotActivatedUtc;
            set => ExpirationTimeIfNotActivatedUtc = value;
        }
    }

    public partial class RoutingIdentityInfo
    {
        [WirePath("type")]
        public RoutingIdentityType? IdentityType
        {
            get => Type;
            set => Type = value;
        }
    }

    public partial class WebHookEventSubscriptionDestination
    {
        [WirePath("properties.endpointBaseUrl")]
        public Uri BaseEndpoint => string.IsNullOrEmpty(EndpointBaseUri) ? null : new Uri(EndpointBaseUri, UriKind.RelativeOrAbsolute);

        [WirePath("properties.endpointUrl")]
        public Uri Endpoint
        {
            get => string.IsNullOrEmpty(EndpointUri) ? null : new Uri(EndpointUri, UriKind.RelativeOrAbsolute);
            set => EndpointUri = value?.AbsoluteUri;
        }

        [WirePath("properties.azureActiveDirectoryApplicationIdOrUri")]
        public string UriOrAzureActiveDirectoryApplicationId
        {
            get => AzureActiveDirectoryApplicationIdOrUri;
            set => AzureActiveDirectoryApplicationIdOrUri = value;
        }
    }

    public readonly partial struct TlsVersion
    {
        public static TlsVersion One0 => _10;
        public static TlsVersion One1 => _11;
        public static TlsVersion One2 => _12;
    }
}
