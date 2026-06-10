// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.EventGrid
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59358
    // (Mgmt CodeGen dynamic-parent expansion: naming divergence vs legacy AutoRest).
    // Rename per-parent Private Endpoint Connection resource/collection classes to match
    // the back-compat names. The new MPG generator prefixes the parent singular ("Domain",
    // "Topic", "PartnerNamespace") to "EventGridPrivateEndpointConnection*"; main shipped
    // these as "EventGrid<Parent>PrivateEndpointConnection*". Use [CodeGenType] to swap.
    [CodeGenType("DomainEventGridPrivateEndpointConnectionResource")]
    public partial class EventGridDomainPrivateEndpointConnectionResource
    {
    }
}
