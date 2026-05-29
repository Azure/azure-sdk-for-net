// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Billing.Models
{
    // Back-compat aliases for GA 1.2.2 property names. The new generator emits the raw
    // spec names (SubscriptionBeneficiaryTenantId/SubscriptionCustomerId); GA exposed
    // BeneficiaryTenantId (Guid?) and CustomerId (string) directly on the patch.
    //
    // Workaround for MPG codegen bug #59545: enable-wire-path-attribute: true makes
    // the generator emit 4 duplicate [WirePath("tags")] attributes on Tags. Suppress
    // the generated Tags and redeclare it with a single [WirePath("tags")].
    // TODO: remove the [CodeGenSuppress("Tags")] + redeclared Tags below once
    // https://github.com/Azure/azure-sdk-for-net/issues/59545 ships.
    [CodeGenSuppress("Tags")]
    public partial class BillingSubscriptionPatch
    {
        /// <summary> Dictionary of metadata associated with the resource. It may not be populated for all resource types. Maximum key/value length supported of 256 characters. Keys/value should not empty value nor null. Keys can not contain &lt; &gt; % &amp; \ ? /. </summary>
        [WirePath("tags")]
        public IDictionary<string, string> Tags { get; }

        /// <summary> The tenant id of the customer for whom the subscription is created. </summary>
        public Guid? BeneficiaryTenantId
        {
            get => SubscriptionBeneficiaryTenantId;
            set => SubscriptionBeneficiaryTenantId = value;
        }

        /// <summary> The ID of the customer for whom the subscription was created. </summary>
        public string CustomerId
        {
            get => SubscriptionCustomerId;
            set => SubscriptionCustomerId = value;
        }
    }
}
