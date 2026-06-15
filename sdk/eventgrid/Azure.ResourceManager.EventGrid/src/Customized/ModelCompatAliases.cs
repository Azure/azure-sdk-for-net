#pragma warning disable CS1591
#pragma warning disable SA1402

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.EventGrid.Models
{
    // These shims preserve GA member names that still need SDK-side forwarding after the Swagger -> TypeSpec migration.
    public partial class NamespaceTopicEventSubscriptionPatch
    {
        [WirePath("properties.expirationTimeUtc")]
        public DateTimeOffset? ExpireOn
        {
            get => Properties is null ? default : Properties.ExpireOn;
            set
            {
                Properties ??= new SubscriptionUpdateParametersProperties();
                Properties.ExpireOn = value;
            }
        }
    }

    public partial class PartnerNamespaceChannelPatch
    {
        [WirePath("properties.expirationTimeIfNotActivatedUtc")]
        public DateTimeOffset? ExpireOnIfNotActivated
        {
            get => Properties is null ? default : Properties.ExpireOnIfNotActivated;
            set
            {
                Properties ??= new ChannelUpdateParametersProperties();
                Properties.ExpireOnIfNotActivated = value;
            }
        }
    }

    public partial class WebHookEventSubscriptionDestination
    {
        [WirePath("properties.endpointBaseUrl")]
        public Uri BaseEndpoint => Properties is null ? default : Properties.BaseEndpoint;

        [WirePath("properties.endpointUrl")]
        public Uri Endpoint
        {
            get => Properties is null ? default : Properties.Endpoint;
            set
            {
                Properties ??= new WebHookEventSubscriptionDestinationProperties();
                Properties.Endpoint = value;
            }
        }

        [WirePath("properties.azureActiveDirectoryApplicationIdOrUri")]
        public string UriOrAzureActiveDirectoryApplicationId
        {
            get => Properties is null ? default : Properties.UriOrAzureActiveDirectoryApplicationId;
            set
            {
                Properties ??= new WebHookEventSubscriptionDestinationProperties();
                Properties.UriOrAzureActiveDirectoryApplicationId = value;
            }
        }
    }

    public readonly partial struct TlsVersion
    {
        public static TlsVersion One0 => _10;
        public static TlsVersion One1 => _11;
        public static TlsVersion One2 => _12;
    }
}
