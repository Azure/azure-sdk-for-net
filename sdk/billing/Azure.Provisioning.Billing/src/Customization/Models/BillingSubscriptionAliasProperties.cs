// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Billing
{
    // Suppress the flattened property until the generator bug is fixed; the alias
    // inherits ProvisioningState from BillingSubscriptionProperties (tracked by #61500).
    [CodeGenSuppress("ProvisioningState")]
    internal partial class BillingSubscriptionAliasProperties
    {
    }
}
