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
        /// <summary> Gets or sets the expiration time. </summary>
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
        /// <summary> Gets or sets the expiration time if the channel is not activated. </summary>
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
        /// <summary> Gets the base endpoint URI. </summary>
        [WirePath("properties.endpointBaseUrl")]
        public Uri BaseEndpoint => Properties is null ? default : Properties.BaseEndpoint;

        /// <summary> Gets or sets the endpoint URI. </summary>
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

        /// <summary> Gets or sets the URI or Microsoft Entra application ID. </summary>
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
}
