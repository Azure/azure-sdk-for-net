// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.EventGrid;

public partial class PartnerEventSubscriptionDestination
{
    /// <summary> The Azure Resource ID of the partner destination. </summary>
    // Changing the released BicepValue<string> property to BicepValue<ResourceIdentifier>
    // fails ApiCompat with CP0002. The C# alternate type is shared with the management
    // library, where ResourceIdentifier is the existing API, so preserve the provisioning
    // string type and nested wire path with custom code.
    [CodeGenMember("ResourceId")]
    public BicepValue<string> ResourceId
    {
        get
        {
            return Properties.ResourceId;
        }
        set
        {
            if (value is null || ((IBicepValue)value).Kind != BicepValueKind.Literal)
            {
                ((IBicepValue)Properties.ResourceId).Assign(value);
            }
            else
            {
                Properties.ResourceId = new ResourceIdentifier(value.Value);
            }
        }
    }
}
