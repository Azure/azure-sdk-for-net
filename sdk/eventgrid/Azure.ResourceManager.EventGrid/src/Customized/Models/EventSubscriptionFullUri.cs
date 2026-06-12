// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.EventGrid.Models
{
    public partial class EventSubscriptionFullUri
    {
        /// <summary> The URL that represents the endpoint of the destination of an event subscription. </summary>
        [WirePath("endpointUrl")]
        public Uri Endpoint => EndpointUri is null ? null : new Uri(EndpointUri);
    }
}
