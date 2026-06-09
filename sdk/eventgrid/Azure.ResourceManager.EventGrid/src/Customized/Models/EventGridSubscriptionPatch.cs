// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.EventGrid.Models
{
    public partial class EventGridSubscriptionPatch
    {
        /// <summary> Information about the expiration time for the event subscription. </summary>
        [WirePath("expirationTimeUtc")]
        public DateTimeOffset? ExpireOn
        {
            get => ExpirationTimeUtc;
            set => ExpirationTimeUtc = value;
        }
    }
}
