// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ArizeAIObservabilityEval.Models
{
    public partial class ArizeAIObservabilityEvalOrganizationProperties
    {
        /// <summary> Initializes a new instance of <see cref="ArizeAIObservabilityEvalOrganizationProperties"/>. </summary>
        /// <param name="marketplace"> Marketplace details of the resource. </param>
        /// <param name="user"> Details of the user. </param>
        /// <param name="partnerProperties"> partner properties. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="marketplace"/>, <paramref name="user"/> or <paramref name="partnerProperties"/> is null. </exception>
        public ArizeAIObservabilityEvalOrganizationProperties(ArizeAIObservabilityEvalMarketplaceDetails marketplace, ArizeAIObservabilityEvalUserDetails user, ArizeAIObservabilityEvalOfferPartnerProperties partnerProperties)
        {
            Argument.AssertNotNull(marketplace, nameof(marketplace));
            Argument.AssertNotNull(user, nameof(user));
            Argument.AssertNotNull(partnerProperties, nameof(partnerProperties));

            Marketplace = marketplace;
            User = user;
            PartnerProperties = partnerProperties;
        }
    }
}
