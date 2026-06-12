// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.EventGrid.Models
{
    public partial class EventGridPartnerContent
    {
        /// <summary> Expiration time of the partner authorization. </summary>
        [WirePath("authorizationExpirationTimeInUtc")]
        public DateTimeOffset? AuthorizationExpireOn
        {
            get => AuthorizationExpirationTimeInUtc;
            set => AuthorizationExpirationTimeInUtc = value;
        }
    }
}
