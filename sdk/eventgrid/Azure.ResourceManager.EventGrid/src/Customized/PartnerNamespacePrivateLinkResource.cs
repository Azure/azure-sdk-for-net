// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59358
    // (Mgmt CodeGen dynamic-parent expansion: naming divergence vs legacy AutoRest).
    // Note: PartnerNamespace PLR variant does NOT have the "EventGrid" prefix on main.
    [CodeGenType("PartnerNamespaceEventGridPrivateLinkResource")]
    public partial class PartnerNamespacePrivateLinkResource
    {
    }
}
